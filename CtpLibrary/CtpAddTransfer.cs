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
    public partial class CtpAddTransfer : UserControl
    {
        private List<string> lstAccountNames = new List<string>();

        public event EventHandler<AddTransferEventArgs> AddTransferEventHandler;

        public CtpAddTransfer(List<string> lstAccountNames)
        {
            this.lstAccountNames = lstAccountNames;
            InitializeComponent();
        }

        private void CtpAddTransfer_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < lstAccountNames.Count; i++)
            {
                cbxInAccount.Items.Add(lstAccountNames[i]);
                cbxOutAccount.Items.Add(lstAccountNames[i]);
            }

            cbxInAccount.Text = lstAccountNames[0];
            cbxOutAccount.Text = lstAccountNames[1];

            dateTimePicker.Value = DateTime.Now;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                AddTransferEventArgs args = new AddTransferEventArgs(dateTimePicker.Value, cbxOutAccount.Text, cbxInAccount.Text, Convert.ToDecimal(txtMoney.Text.ToString()));
                EventHandler<AddTransferEventArgs> eventTemp = null;

                if (Interlocked.Exchange(ref eventTemp, AddTransferEventHandler) == null)
                {
                    //更改当前画面数据对象
                    txtMoney.Text = string.Empty;

                    eventTemp(sender, args);                                                       //调用事件
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void txtMoney_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                btnConfirm_Click(btnConfirm, new EventArgs());
            }
        }

        private void txtMoney_Leave(object sender, EventArgs e)
        {
            CommonUI.LeaveMoneyTextbox(txtMoney);
        }
    }
}
