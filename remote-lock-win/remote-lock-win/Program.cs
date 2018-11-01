using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace remote_lock_win
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (DialogResult.Yes == MessageBox.Show("Would you like to lock the current session?", "Lock Session", MessageBoxButtons.YesNo))
                Win32.LockSession();
        }
    }
}
