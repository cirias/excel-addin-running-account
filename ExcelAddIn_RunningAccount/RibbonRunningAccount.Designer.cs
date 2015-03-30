namespace ExcelAddIn_RunningAccount
{
    partial class RibbonRunningAccount : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public RibbonRunningAccount()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabMenu = this.Factory.CreateRibbonTab();
            this.groupInitialize = this.Factory.CreateRibbonGroup();
            this.btnInitializeModel = this.Factory.CreateRibbonButton();
            this.tabMenu.SuspendLayout();
            this.groupInitialize.SuspendLayout();
            // 
            // tabMenu
            // 
            this.tabMenu.Groups.Add(this.groupInitialize);
            this.tabMenu.Label = "流水账";
            this.tabMenu.Name = "tabMenu";
            // 
            // groupInitialize
            // 
            this.groupInitialize.Items.Add(this.btnInitializeModel);
            this.groupInitialize.Label = "初始化";
            this.groupInitialize.Name = "groupInitialize";
            // 
            // btnInitializeModel
            // 
            this.btnInitializeModel.Label = "初始化模板";
            this.btnInitializeModel.Name = "btnInitializeModel";
            this.btnInitializeModel.ShowImage = true;
            // 
            // RibbonRunningAccount
            // 
            this.Name = "RibbonRunningAccount";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tabMenu);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.RibbonRunningAccount_Load);
            this.tabMenu.ResumeLayout(false);
            this.tabMenu.PerformLayout();
            this.groupInitialize.ResumeLayout(false);
            this.groupInitialize.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tabMenu;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup groupInitialize;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnInitializeModel;
    }

    partial class ThisRibbonCollection
    {
        internal RibbonRunningAccount RibbonRunningAccount
        {
            get { return this.GetRibbon<RibbonRunningAccount>(); }
        }
    }
}
