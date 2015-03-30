/******************************* 添加收入、支出记录导航画面 *******************************
 * 项目名称：MS Excel 2010 财务插件
 * 功能描述：显示收入、支出导航内容
 * 创 建 人：方慧聪
 ****************************************************************************************
 */
/* =================================== 版本更新履历 =====================================
 * 更新日期		  更新人		                  更新内容
 * --------------------------------------------------------------------------------------
 * ======================================================================================
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace CtpLibrary
{
    public partial class CtpAddPayment : UserControl
    {
        Dictionary<string, List<string>> DicExpensesTypes = new Dictionary<string, List<string>>();//支出类型数据对象
        List<string> lstIncomeTypes = new List<string>();                                          //收入类型数据对象
        List<string> lstAccountNames = new List<string>();                                         //账户名称数据对象

        public event EventHandler<AddPaymentEventArgs> AddPaymentEventHandler;                     //添加收支记录事件处理对象

        public CtpAddPayment(Dictionary<string, List<string>> DicExpensesTypes, List<string> lstIncomeTypes, List<string> lstAccountNames)
        {
            this.DicExpensesTypes = DicExpensesTypes;
            this.lstIncomeTypes = lstIncomeTypes;
            this.lstAccountNames = lstAccountNames;
            InitializeComponent();
        }

        private void CtpAddPayment_Load(object sender, EventArgs e)
        {
            List<string> lstTypes = new List<string>();

            //判断radiobutton按钮状态
            if (rdbtnExpenditure.Checked)
            {
                lstTypes = DicExpensesTypes.Keys.ToList();
            }
            else
            {
                lstTypes = lstIncomeTypes;
            }

            //载入收入或支出类型
            for (int i = 0; i < lstTypes.Count; i++)
            {
                cbxGeneral_Category.Items.Add(lstTypes[i]);
            }

            //载入账户名称
            for (int i = 0; i < lstAccountNames.Count; i++)
            {
                cbxAccount.Items.Add(lstAccountNames[i]);
            }

            dateTimePicker.Value = DateTime.Now;
        }

        private void cbxGeneral_Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            //根据RadioButton状态，若为支出
            if (rdbtnExpenditure.Checked)
            {
                //根据选中项载入二级类型
                cbxSub_Category.Items.Clear();
                cbxSub_Category.Text = string.Empty;
                List<string> lstTypes = new List<string>();
                DicExpensesTypes.TryGetValue(cbxGeneral_Category.Text, out lstTypes);

                for (int i = 0; i < lstTypes.Count; i++)
                {
                    cbxSub_Category.Items.Add(lstTypes[i]);
                }

                cbxSub_Category.Text = string.Empty;
            }
        }

        private void chkSelectDate_CheckedChanged(object sender, EventArgs e)
        {
            //根据日期选择勾选框状态判断是否启用dateTimePicker控件
            if (chkSelectDate.Checked)
            {
                dateTimePicker.Enabled = true;
                dateTimePicker.Value = DateTime.Now;
            }
            else
            {
                dateTimePicker.Enabled = false;
            }
        }

        private void rdbtnExpenditure_CheckedChanged(object sender, EventArgs e)
        {
            cbxGeneral_Category.Items.Clear();
            cbxSub_Category.Items.Clear();
            cbxGeneral_Category.Text = string.Empty;
            cbxSub_Category.Text = string.Empty;
            List<string> lstTypes = new List<string>();

            //判断radiobutton按钮状态
            if (rdbtnExpenditure.Checked)
            {
                lstTypes = DicExpensesTypes.Keys.ToList();
                groupBox1.Text = "支出类型";
                label2.Text = "总类：";
                label3.Enabled = true;
                cbxSub_Category.Enabled = true;
            }
            else
            {
                lstTypes = lstIncomeTypes;
                groupBox1.Text = "收入类型";
                label2.Text = "类型：";
                label3.Enabled = false;
                cbxSub_Category.Enabled = false;
                cbxSub_Category.Text = string.Empty;
            }

            //载入收入或支出类型
            for (int i = 0; i < lstTypes.Count; i++)
            {
                cbxGeneral_Category.Items.Add(lstTypes[i]);
            }
        }

        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            try
            {
                AddPaymentEventArgs args;

                if (rdbtnExpenditure.Checked)
                {
                    args = new AddPaymentEventArgs(txtName.Text, Convert.ToDouble("-" + txtMoney.Text), cbxGeneral_Category.Text, cbxSub_Category.Text, dateTimePicker.Value, cbxAccount.Text, true);
                }
                else
                {
                    args = new AddPaymentEventArgs(txtName.Text, Convert.ToDouble(txtMoney.Text), cbxGeneral_Category.Text, cbxSub_Category.Text, dateTimePicker.Value, cbxAccount.Text, false);
                }

                EventHandler<AddPaymentEventArgs> eventTemp = null;

                if (Interlocked.Exchange(ref eventTemp, AddPaymentEventHandler) == null)
                {
                    //更改当前画面数据对象
                    txtName.Text = string.Empty;
                    txtMoney.Text = string.Empty;

                    eventTemp(sender, args);                                                       //调用事件
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbxAccount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                btnAddPayment_Click(btnAddPayment, new EventArgs());
            }
        }

        private void txtMoney_Leave(object sender, EventArgs e)
        {
            CommonUI.LeaveMoneyTextbox(txtMoney);
        }
    }
}
