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
        #region Fields
        public const string LogFile = "DesktopClean.log";
        private bool cleanALL = false;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets a flag that determines if all files are moved, regardless of the LeaveFor setting
        /// </summary>
        public bool CleanALL
        {
            get { return cleanALL; }
            set { cleanALL = value; }
        }

        /// <summary>
        /// Gets setting for action to be performed when a file exists
        /// </summary>
        private FileExistsOption FileExistsAction
        {
            get { return (FileExistsOption)Settings.Default.FileExistsSetting; }
        }

        /// <summary>
        /// Gets the cleanup path setting.  This is the path that files from the desktop are moved to
        /// </summary>
        private string CleanupPath
        {
            get { return Settings.Default.MoveToPath; }
        }

        /// <summary>
        /// Gets the files to exclude from moving.  Contains a list of file wildcards separated by a semi-colon 
        /// </summary>
        private string FilesToExclude
        {
            get { return Settings.Default.FilesToExclude; }
        }

        /// <summary>
        /// Gets the number of minutes since file was last accessed before moving
        /// </summary>
        private long LeaveFor
        {
            get { return Settings.Default.LeaveFor; }
        }
        
        /// <summary>
        /// Gets the path to the desktop on current operating system.
        /// </summary>
        private string DesktopPath
        {
            get { return Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); }
        }
        #endregion

        #region File operation methods
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

        /// <summary>
        /// Moves a file and writes to the log file
        /// </summary>
        /// <param name="fileName">name of file to move</param>
        /// <param name="newPath">the path where the file is being moved to</param>
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

        /// <summary>
        /// Adds a date/time stamp to a Filename
        /// </summary>
        /// <param name="destFileName">Full path and filename to be renamed</param>
        /// <returns>Filename with date/time stamp added</returns>
        private string RenameFile(string destFileName)
        {
            string path = Path.GetDirectoryName(destFileName);
            string extension = Path.GetExtension(destFileName);
            string newFileName = Path.GetFileNameWithoutExtension(destFileName);

            newFileName += DateTime.Now.ToString("_yyyyMMddhhmmss");

            return Path.Combine(path, newFileName) + extension;
        } 

        /// <summary>
        /// Moves an entire folder and all it's contents
        /// </summary>
        /// <param name="source">Folder to move</param>
        /// <param name="destination">Path to move to</param>
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
        #endregion

        #region Log file methods
        /// <summary>
        /// Write a comment to the log file
        /// </summary>
        /// <param name="comment">comment string</param>
        private void WriteLogComment(string comment)
        {
            string logText = string.Format("{0}:  {1}", DateTime.Now, comment);
            File.AppendAllText(LogFile, logText);
            File.AppendAllText(LogFile, Environment.NewLine);
        }

        /// <summary>
        /// Writes details of file moves to the log file.
        /// </summary>
        /// <param name="desktopFile">Name of File on desktop to be moved</param>
        /// <param name="movedFile">Full Path and Filename of location where file was moved to</param>
        private void WriteLog(string desktopFile, string movedFile)
        {
            string logText = string.Format("{0}:  {1} -> {2}", DateTime.Now, desktopFile, movedFile);
            File.AppendAllText(LogFile, logText);
            File.AppendAllText(LogFile, Environment.NewLine);
        }

        /// <summary>
        /// Write details of an exception to the log file
        /// </summary>
        /// <param name="ex">The Exception</param>
        private void WriteError(Exception ex, string filename)
        {
            string logText = string.Format("{0}: File: {1} - Error {2}", DateTime.Now, filename, ex.Message);
            File.AppendAllText(LogFile, logText);
            File.AppendAllText(LogFile, Environment.NewLine);
        }
        #endregion
    }

}
