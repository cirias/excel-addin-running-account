namespace CtpLibrary
{
    partial class CtpAccountManage
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddAccount = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtInitialMoney = new System.Windows.Forms.TextBox();
            this.txtAccountName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblAccountType = new System.Windows.Forms.Label();
            this.cbxSecondAccountType_Add = new System.Windows.Forms.ComboBox();
            this.cbxFirstAccountType_Add = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbxAccountName = new System.Windows.Forms.ComboBox();
            this.btnDeleteAccount = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxSecondAccountType_Delete = new System.Windows.Forms.ComboBox();
            this.cbxFirstAccountType_Delete = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddAccount);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtInitialMoney);
            this.groupBox1.Controls.Add(this.txtAccountName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblAccountType);
            this.groupBox1.Controls.Add(this.cbxSecondAccountType_Add);
            this.groupBox1.Controls.Add(this.cbxFirstAccountType_Add);
            this.groupBox1.Location = new System.Drawing.Point(0, 195);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 203);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "添加账户";
            // 
            // btnAddAccount
            // 
            this.btnAddAccount.Location = new System.Drawing.Point(135, 157);
            this.btnAddAccount.Name = "btnAddAccount";
            this.btnAddAccount.Size = new System.Drawing.Size(75, 23);
            this.btnAddAccount.TabIndex = 4;
            this.btnAddAccount.Text = "添加";
            this.btnAddAccount.UseVisualStyleBackColor = true;
            this.btnAddAccount.Click += new System.EventHandler(this.btnAddAccount_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "初始金额：";
            // 
            // txtInitialMoney
            // 
            this.txtInitialMoney.Location = new System.Drawing.Point(89, 114);
            this.txtInitialMoney.Name = "txtInitialMoney";
            this.txtInitialMoney.Size = new System.Drawing.Size(121, 21);
            this.txtInitialMoney.TabIndex = 3;
            this.txtInitialMoney.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInitialMoney_KeyPress);
            this.txtInitialMoney.Leave += new System.EventHandler(this.txtInitialMoney_Leave);
            // 
            // txtAccountName
            // 
            this.txtAccountName.Location = new System.Drawing.Point(89, 87);
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(121, 21);
            this.txtAccountName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "账户名称：";
            // 
            // lblAccountType
            // 
            this.lblAccountType.AutoSize = true;
            this.lblAccountType.Location = new System.Drawing.Point(18, 38);
            this.lblAccountType.Name = "lblAccountType";
            this.lblAccountType.Size = new System.Drawing.Size(65, 12);
            this.lblAccountType.TabIndex = 2;
            this.lblAccountType.Text = "账户类型：";
            // 
            // cbxSecondAccountType_Add
            // 
            this.cbxSecondAccountType_Add.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSecondAccountType_Add.FormattingEnabled = true;
            this.cbxSecondAccountType_Add.Location = new System.Drawing.Point(89, 61);
            this.cbxSecondAccountType_Add.Name = "cbxSecondAccountType_Add";
            this.cbxSecondAccountType_Add.Size = new System.Drawing.Size(121, 20);
            this.cbxSecondAccountType_Add.TabIndex = 1;
            // 
            // cbxFirstAccountType_Add
            // 
            this.cbxFirstAccountType_Add.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFirstAccountType_Add.FormattingEnabled = true;
            this.cbxFirstAccountType_Add.Location = new System.Drawing.Point(89, 35);
            this.cbxFirstAccountType_Add.Name = "cbxFirstAccountType_Add";
            this.cbxFirstAccountType_Add.Size = new System.Drawing.Size(121, 20);
            this.cbxFirstAccountType_Add.TabIndex = 0;
            this.cbxFirstAccountType_Add.SelectedIndexChanged += new System.EventHandler(this.cbxFirstAccountType_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbxAccountName);
            this.groupBox2.Controls.Add(this.btnDeleteAccount);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cbxSecondAccountType_Delete);
            this.groupBox2.Controls.Add(this.cbxFirstAccountType_Delete);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(222, 186);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "删除账户";
            // 
            // cbxAccountName
            // 
            this.cbxAccountName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAccountName.FormattingEnabled = true;
            this.cbxAccountName.Location = new System.Drawing.Point(86, 100);
            this.cbxAccountName.Name = "cbxAccountName";
            this.cbxAccountName.Size = new System.Drawing.Size(121, 20);
            this.cbxAccountName.TabIndex = 2;
            this.cbxAccountName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbxAccountName_KeyPress);
            // 
            // btnDeleteAccount
            // 
            this.btnDeleteAccount.Location = new System.Drawing.Point(132, 142);
            this.btnDeleteAccount.Name = "btnDeleteAccount";
            this.btnDeleteAccount.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteAccount.TabIndex = 3;
            this.btnDeleteAccount.Text = "删除";
            this.btnDeleteAccount.UseVisualStyleBackColor = true;
            this.btnDeleteAccount.Click += new System.EventHandler(this.btnDeleteAccount_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "账户名称：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "账户类型：";
            // 
            // cbxSecondAccountType_Delete
            // 
            this.cbxSecondAccountType_Delete.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSecondAccountType_Delete.FormattingEnabled = true;
            this.cbxSecondAccountType_Delete.Location = new System.Drawing.Point(86, 62);
            this.cbxSecondAccountType_Delete.Name = "cbxSecondAccountType_Delete";
            this.cbxSecondAccountType_Delete.Size = new System.Drawing.Size(121, 20);
            this.cbxSecondAccountType_Delete.TabIndex = 1;
            this.cbxSecondAccountType_Delete.SelectedIndexChanged += new System.EventHandler(this.cbxSecondAccountType_Delete_SelectedIndexChanged);
            // 
            // cbxFirstAccountType_Delete
            // 
            this.cbxFirstAccountType_Delete.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFirstAccountType_Delete.FormattingEnabled = true;
            this.cbxFirstAccountType_Delete.Location = new System.Drawing.Point(86, 36);
            this.cbxFirstAccountType_Delete.Name = "cbxFirstAccountType_Delete";
            this.cbxFirstAccountType_Delete.Size = new System.Drawing.Size(121, 20);
            this.cbxFirstAccountType_Delete.TabIndex = 0;
            this.cbxFirstAccountType_Delete.SelectedIndexChanged += new System.EventHandler(this.cbxFirstAccountType_SelectedIndexChanged);
            // 
            // CtpAccountManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "CtpAccountManage";
            this.Size = new System.Drawing.Size(228, 508);
            this.Load += new System.EventHandler(this.CtpAccountManage_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbxSecondAccountType_Add;
        private System.Windows.Forms.ComboBox cbxFirstAccountType_Add;
        private System.Windows.Forms.Button btnAddAccount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtInitialMoney;
        private System.Windows.Forms.TextBox txtAccountName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAccountType;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbxAccountName;
        private System.Windows.Forms.Button btnDeleteAccount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxSecondAccountType_Delete;
        private System.Windows.Forms.ComboBox cbxFirstAccountType_Delete;
    }
}
