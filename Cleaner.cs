namespace DesktopClean
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Diagnostics;
    using DesktopClean.Properties;

    /// <summary>
    /// Action to be performed when a file already exists in the cleanup folder
    /// </summary>
    public enum FileExistsOption
    {
        /// <summary>
        /// Option to overwrite any existing file in the cleanup folder
        /// </summary>
        Overwrite = 0,

        /// <summary>
        /// Moved file will be renamed by adding a date/time stamp to the filename. Keeps original extension
        /// </summary>
        Rename = 1,

        /// <summary>
        /// Will not move files if they already exist in cleanup folder
        /// </summary>
        Leave = 2
    }

    /// <summary>
    /// Moves files from desktop to another "cleanup" folder.
    /// </summary>
    internal class Cleaner
    {
        public const string LogFile = "DesktopClean.log";
        private bool cleanALL = false;

        public bool CleanALL
        {
            get { return cleanALL; }
            set { cleanALL = value; }
        }

        private FileExistsOption FileExistsAction
        {
            get { return (FileExistsOption)Settings.Default.FileExistsSetting; }
        }

        private string CleanupPath
        {
            get { return Settings.Default.MoveToPath; }
        }

        private string FilesToExclude
        {
            get { return Settings.Default.FilesToExclude; }
        }

        private long LeaveFor
        {
            get { return Settings.Default.LeaveFor; }
        }
        
        private string DesktopPath
        {
            get { return Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); }
        }

        /// <summary>
        /// Performs the cleanup action.  Moves files from desktop to another folder based on settings
        /// </summary>
        public void Cleanup()
        {
            string[] excludePatterns = FilesToExclude.Split(';');
            Regex[] wildcards = new Regex[excludePatterns.Length];
            int counter = 0;

            foreach (string pattern in excludePatterns)
                wildcards[counter++] = new Regex(WildcardToRegex(pattern), RegexOptions.IgnoreCase);
            
            bool doExclude;
            string[] files = Directory.GetFiles(DesktopPath);

            foreach (string file in files)
            {
                doExclude = false;
                foreach (Regex wildcard in wildcards)
                    if (wildcard.IsMatch(Path.GetFileName(file)))
                    {
                        doExclude = true;
                        break;
                    }

                if (!doExclude)
                {
                    TimeSpan accessed = DateTime.Now - Directory.GetLastAccessTime(file);
                    if ((accessed.TotalMinutes > LeaveFor) || CleanALL)
                        MoveFile(file, CleanupPath);
                }
            }

            string[] dirs = Directory.GetDirectories(DesktopPath);
            string topLevelDirName;
            foreach (string dir in dirs)
            {
                doExclude = false;
                topLevelDirName = dir.Replace(DesktopPath, "").Replace(Path.DirectorySeparatorChar,' ').Trim();
                foreach (Regex wildcard in wildcards)
                    if (wildcard.IsMatch(topLevelDirName)) // this does not work - no idea why
                    {
                        doExclude = true;
                        break;
                    }

                if (!doExclude)
                {
                    TimeSpan accessed = DateTime.Now - Directory.GetLastAccessTime(dir);
                    if ((accessed.TotalMinutes > LeaveFor) || CleanALL)
                        MoveFolder(dir, CleanupPath);
                }
            }
        }

        private void MoveFile(string fileName, string newPath)
        {
            try
            {
                string destFileName = Path.Combine(newPath, Path.GetFileName(fileName));
                if (File.Exists(destFileName))
                {
                    switch (FileExistsAction)
                    {
                        case FileExistsOption.Overwrite:
                            File.Delete(destFileName);
                            break;
                        case FileExistsOption.Leave:
                            WriteLogComment(string.Format("File {0} not moved because it already exists in cleanup folder",
                                                          fileName));
                            return;
                        case FileExistsOption.Rename:
                            destFileName = RenameFile(destFileName);
                            break;
                    }

                }

                File.Move(fileName, destFileName);
                if (File.Exists(fileName))
                    throw new IOException("Could not move file: " + fileName);
                WriteLog(fileName, destFileName);
            }
            catch (Exception ex)
            {
                WriteError(ex, fileName);
            }
        }

        private string RenameFile(string destFileName)
        {
            string path = Path.GetDirectoryName(destFileName);
            string extension = Path.GetExtension(destFileName);
            string newFileName = Path.GetFileNameWithoutExtension(destFileName);

            newFileName += DateTime.Now.ToString("_yyyyMMddhhmmss");

            return Path.Combine(path, newFileName) + extension;
        } 

        private void MoveFolder(string source, string destination)
        {
            try
            {
                TimeSpan accessed = DateTime.Now - Directory.GetLastAccessTime(source);
                if ((accessed.TotalMinutes > LeaveFor) || CleanALL)
                {
                    string filePath;
                    string pathToMoveTo;
                    string[] files = Directory.GetFiles(source, "*.*", SearchOption.AllDirectories);
                    foreach (string fileToMove in files)
                    {
                        filePath = fileToMove.Replace(DesktopPath, "");
                        pathToMoveTo = destination + Path.GetDirectoryName(filePath);
                        if (!Directory.Exists(pathToMoveTo))
                            Directory.CreateDirectory(pathToMoveTo);
                        MoveFile(fileToMove, pathToMoveTo);
                    }

                    Directory.Delete(source, true);
                    WriteLog(source, destination);
                }
            }
            catch (Exception ex)
            {
                WriteError(ex, destination);
            }
        }

        /// <summary>
        /// Converts a wildcard (eg *.exe) to a regular expression.
        /// Code taken from http://www.codeproject.com/csharp/wildcardtoregex.asp
        /// </summary>
        /// <param name="pattern">File Wildcard</param>
        /// <returns>Regular Expression of wildcard</returns>
        private string WildcardToRegex(string pattern)
        {
            return "^" + Regex.Escape(pattern).Replace("\\*", ".*").Replace("\\?", ".") + "$";
        }

        private void WriteLogComment(string comment)
        {
            string logText = string.Format("{0}:  {1}", DateTime.Now, comment);
            File.AppendAllText(LogFile, logText);
            File.AppendAllText(LogFile, Environment.NewLine);
        }

        private void WriteLog(string desktopFile, string movedFile)
        {
            string logText = string.Format("{0}:  {1} -> {2}", DateTime.Now, desktopFile, movedFile);
            File.AppendAllText(LogFile, logText);
            File.AppendAllText(LogFile, Environment.NewLine);
        }

        private void WriteError(Exception ex, string filename)
        {
            string logText = string.Format("{0}: File: {1} - Error {2}", DateTime.Now, filename, ex.Message);
            File.AppendAllText(LogFile, logText);
            File.AppendAllText(LogFile, Environment.NewLine);
        }
    }

}
