using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

namespace CtpLibrary
{
    [ComVisible(true)]
    public partial class CtpInitializeWizard : UserControl
    {
        List<string> lstTitles = new List<string>() { "1", "2" };

        public CtpInitializeWizard()
        {
            InitializeComponent();
        }

        public event EventHandler<InitializeEventArgs> InitializeEventHandler;

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            InitializeEventArgs args = new InitializeEventArgs(lstTitles);
            EventHandler<InitializeEventArgs> eventTemp = null;
            if (Interlocked.Exchange(ref eventTemp, InitializeEventHandler) == null)
            {
                eventTemp(sender, args);
            }
        }
    }
}
