namespace CtpLibrary
{
    partial class CtpAddTransfer
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
            this.chkSelectDate = new System.Windows.Forms.CheckBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMoney = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxInAccount = new System.Windows.Forms.ComboBox();
            this.cbxOutAccount = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkSelectDate);
            this.groupBox1.Controls.Add(this.dateTimePicker);
            this.groupBox1.Controls.Add(this.btnConfirm);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtMoney);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbxInAccount);
            this.groupBox1.Controls.Add(this.cbxOutAccount);
            this.groupBox1.Location = new System.Drawing.Point(5, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 185);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "转账信息";
            // 
            // chkSelectDate
            // 
            this.chkSelectDate.AutoSize = true;
            this.chkSelectDate.Location = new System.Drawing.Point(8, 23);
            this.chkSelectDate.Name = "chkSelectDate";
            this.chkSelectDate.Size = new System.Drawing.Size(48, 16);
            this.chkSelectDate.TabIndex = 4;
            this.chkSelectDate.Text = "手动";
            this.chkSelectDate.UseVisualStyleBackColor = true;
            this.chkSelectDate.CheckedChanged += new System.EventHandler(this.chkSelectDate_CheckedChanged);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CustomFormat = "yyyy年mm月dd日";
            this.dateTimePicker.Enabled = false;
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(73, 20);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(121, 21);
            this.dateTimePicker.TabIndex = 5;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(119, 130);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 3;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "金额：";
            // 
            // txtMoney
            // 
            this.txtMoney.Location = new System.Drawing.Point(73, 100);
            this.txtMoney.Name = "txtMoney";
            this.txtMoney.Size = new System.Drawing.Size(121, 21);
            this.txtMoney.TabIndex = 2;
            this.txtMoney.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMoney_KeyPress);
            this.txtMoney.Leave += new System.EventHandler(this.txtMoney_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "转入账户：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "转出账户：";
            // 
            // cbxInAccount
            // 
            this.cbxInAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxInAccount.FormattingEnabled = true;
            this.cbxInAccount.Location = new System.Drawing.Point(73, 74);
            this.cbxInAccount.Name = "cbxInAccount";
            this.cbxInAccount.Size = new System.Drawing.Size(121, 20);
            this.cbxInAccount.TabIndex = 1;
            // 
            // cbxOutAccount
            // 
            this.cbxOutAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxOutAccount.FormattingEnabled = true;
            this.cbxOutAccount.Location = new System.Drawing.Point(73, 48);
            this.cbxOutAccount.Name = "cbxOutAccount";
            this.cbxOutAccount.Size = new System.Drawing.Size(121, 20);
            this.cbxOutAccount.TabIndex = 0;
            // 
            // CtpAddTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "CtpAddTransfer";
            this.Size = new System.Drawing.Size(208, 629);
            this.Load += new System.EventHandler(this.CtpAddTransfer_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMoney;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxInAccount;
        private System.Windows.Forms.ComboBox cbxOutAccount;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.CheckBox chkSelectDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
    }
}
