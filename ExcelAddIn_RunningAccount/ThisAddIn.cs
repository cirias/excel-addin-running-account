using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;

namespace ExcelAddIn_RunningAccount
{
    public partial class ThisAddIn
    {
        private Ribbon customerRibbon;

        protected override Office.IRibbonExtensibility CreateRibbonExtensibilityObject()
        {
            customerRibbon = new Ribbon();
            return customerRibbon;
        }

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            Ribbon.taskPaneCollection = this.CustomTaskPanes;
            Ribbon.applicationObject = this.Application;
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
