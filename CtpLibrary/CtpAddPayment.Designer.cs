namespace CtpLibrary
{
    partial class CtpAddPayment
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
            this.btnAddPayment = new System.Windows.Forms.Button();
            this.lblAccount = new System.Windows.Forms.Label();
            this.cbxAccount = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.rdbtnExpenditure = new System.Windows.Forms.RadioButton();
            this.rdbtnIncome = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxGeneral_Category = new System.Windows.Forms.ComboBox();
            this.cbxSub_Category = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMoney = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbxPerson = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.chkSelectDate = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddPayment
            // 
            this.btnAddPayment.Location = new System.Drawing.Point(115, 432);
            this.btnAddPayment.Name = "btnAddPayment";
            this.btnAddPayment.Size = new System.Drawing.Size(75, 23);
            this.btnAddPayment.TabIndex = 6;
            this.btnAddPayment.Text = "确定";
            this.btnAddPayment.UseVisualStyleBackColor = true;
            this.btnAddPayment.Click += new System.EventHandler(this.btnAddPayment_Click);
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Location = new System.Drawing.Point(18, 23);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(41, 12);
            this.lblAccount.TabIndex = 20;
            this.lblAccount.Text = "账户：";
            // 
            // cbxAccount
            // 
            this.cbxAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAccount.FormattingEnabled = true;
            this.cbxAccount.Location = new System.Drawing.Point(65, 20);
            this.cbxAccount.Name = "cbxAccount";
            this.cbxAccount.Size = new System.Drawing.Size(121, 20);
            this.cbxAccount.TabIndex = 4;
            this.cbxAccount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbxAccount_KeyPress);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(66, 24);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(121, 21);
            this.txtName.TabIndex = 0;
            // 
            // rdbtnExpenditure
            // 
            this.rdbtnExpenditure.AutoSize = true;
            this.rdbtnExpenditure.Checked = true;
            this.rdbtnExpenditure.Location = new System.Drawing.Point(40, 26);
            this.rdbtnExpenditure.Name = "rdbtnExpenditure";
            this.rdbtnExpenditure.Size = new System.Drawing.Size(47, 16);
            this.rdbtnExpenditure.TabIndex = 7;
            this.rdbtnExpenditure.TabStop = true;
            this.rdbtnExpenditure.Text = "支出";
            this.rdbtnExpenditure.UseVisualStyleBackColor = true;
            this.rdbtnExpenditure.CheckedChanged += new System.EventHandler(this.rdbtnExpenditure_CheckedChanged);
            // 
            // rdbtnIncome
            // 
            this.rdbtnIncome.AutoSize = true;
            this.rdbtnIncome.Location = new System.Drawing.Point(110, 26);
            this.rdbtnIncome.Name = "rdbtnIncome";
            this.rdbtnIncome.Size = new System.Drawing.Size(47, 16);
            this.rdbtnIncome.TabIndex = 8;
            this.rdbtnIncome.Text = "收入";
            this.rdbtnIncome.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 20;
            this.label1.Text = "名称：";
            // 
            // cbxGeneral_Category
            // 
            this.cbxGeneral_Category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxGeneral_Category.FormattingEnabled = true;
            this.cbxGeneral_Category.Location = new System.Drawing.Point(66, 26);
            this.cbxGeneral_Category.Name = "cbxGeneral_Category";
            this.cbxGeneral_Category.Size = new System.Drawing.Size(121, 20);
            this.cbxGeneral_Category.TabIndex = 2;
            this.cbxGeneral_Category.SelectedIndexChanged += new System.EventHandler(this.cbxGeneral_Category_SelectedIndexChanged);
            // 
            // cbxSub_Category
            // 
            this.cbxSub_Category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSub_Category.FormattingEnabled = true;
            this.cbxSub_Category.Location = new System.Drawing.Point(66, 63);
            this.cbxSub_Category.Name = "cbxSub_Category";
            this.cbxSub_Category.Size = new System.Drawing.Size(121, 20);
            this.cbxSub_Category.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbxGeneral_Category);
            this.groupBox1.Controls.Add(this.cbxSub_Category);
            this.groupBox1.Location = new System.Drawing.Point(3, 188);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "支出类型";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 20;
            this.label3.Text = "子类：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "总类：";
            // 
            // txtMoney
            // 
            this.txtMoney.Location = new System.Drawing.Point(66, 60);
            this.txtMoney.Name = "txtMoney";
            this.txtMoney.Size = new System.Drawing.Size(121, 21);
            this.txtMoney.TabIndex = 1;
            this.txtMoney.Leave += new System.EventHandler(this.txtMoney_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 20;
            this.label4.Text = "金额：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Controls.Add(this.txtMoney);
            this.groupBox2.Location = new System.Drawing.Point(3, 82);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "基本信息";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbxPerson);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.cbxAccount);
            this.groupBox3.Controls.Add(this.lblAccount);
            this.groupBox3.Location = new System.Drawing.Point(4, 304);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 100);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "账户人员";
            // 
            // cbxPerson
            // 
            this.cbxPerson.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPerson.Enabled = false;
            this.cbxPerson.FormattingEnabled = true;
            this.cbxPerson.Location = new System.Drawing.Point(65, 55);
            this.cbxPerson.Name = "cbxPerson";
            this.cbxPerson.Size = new System.Drawing.Size(121, 20);
            this.cbxPerson.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Location = new System.Drawing.Point(18, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 20;
            this.label5.Text = "人员：";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CustomFormat = "yyyy年mm月dd日";
            this.dateTimePicker.Enabled = false;
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(77, 55);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(113, 21);
            this.dateTimePicker.TabIndex = 8;
            // 
            // chkSelectDate
            // 
            this.chkSelectDate.AutoSize = true;
            this.chkSelectDate.Location = new System.Drawing.Point(15, 58);
            this.chkSelectDate.Name = "chkSelectDate";
            this.chkSelectDate.Size = new System.Drawing.Size(48, 16);
            this.chkSelectDate.TabIndex = 7;
            this.chkSelectDate.Text = "手动";
            this.chkSelectDate.UseVisualStyleBackColor = true;
            this.chkSelectDate.CheckedChanged += new System.EventHandler(this.chkSelectDate_CheckedChanged);
            // 
            // CtpAddPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkSelectDate);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rdbtnIncome);
            this.Controls.Add(this.rdbtnExpenditure);
            this.Controls.Add(this.btnAddPayment);
            this.Name = "CtpAddPayment";
            this.Size = new System.Drawing.Size(207, 586);
            this.Load += new System.EventHandler(this.CtpAddPayment_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddPayment;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.ComboBox cbxAccount;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.RadioButton rdbtnExpenditure;
        private System.Windows.Forms.RadioButton rdbtnIncome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxGeneral_Category;
        private System.Windows.Forms.ComboBox cbxSub_Category;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMoney;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbxPerson;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.CheckBox chkSelectDate;
    }
}
