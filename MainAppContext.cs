using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace DesktopClean
{
    public class MainAppContext : ApplicationContext
    {
        public static MainComponent main = null;
        public MainAppContext()
        {
            main = new MainComponent();
        }
    }
}
