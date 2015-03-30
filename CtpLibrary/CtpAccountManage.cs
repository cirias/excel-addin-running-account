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
    public partial class CtpAccountManage : UserControl
    {
        Dictionary<string, Dictionary<string, Dictionary<string, dynamic>>> dicAccountInfo = new Dictionary<string, Dictionary<string, Dictionary<string, dynamic>>>();//账户信息数据对象

        public event EventHandler<AddAccountEventArgs> AddAccountEventHandler;                     //添加账户事件处理对象

        public event EventHandler<DeleteAccountEventArgs> DeleteAccountEventHandler;               //删除账户事件处理对象

        public CtpAccountManage(Dictionary<string, Dictionary<string, Dictionary<string, dynamic>>> dicAccountTypes)
        {
            this.dicAccountInfo = dicAccountTypes;
            InitializeComponent();
        }

        private void CtpAccountManage_Load(object sender, EventArgs e)
        {
            //载入一级账户类型
            List<string> lstFirstAccountTypes = dicAccountInfo.Keys.ToList();

            for (int i = 0; i < lstFirstAccountTypes.Count; i++)
            {
                cbxFirstAccountType_Add.Items.Add(lstFirstAccountTypes[i]);
                cbxFirstAccountType_Delete.Items.Add(lstFirstAccountTypes[i]);
            }

            cbxFirstAccountType_Add.Text = cbxFirstAccountType_Add.Items[0].ToString();
            cbxFirstAccountType_Delete.Text = cbxFirstAccountType_Delete.Items[0].ToString();
        }

        private void cbxFirstAccountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //根据选中一级类型载入二级类型
            Dictionary<string, Dictionary<string, dynamic>> dicSecondAccountTypes = new Dictionary<string, Dictionary<string, dynamic>>();
            dicAccountInfo.TryGetValue(((ComboBox)sender).Text, out dicSecondAccountTypes);
            List<string> lstSecondAccountTypes = dicSecondAccountTypes.Keys.ToList();

            //载入“删除”控件或“添加”控件的数据
            if (((ComboBox)sender).Name == "cbxFirstAccountType_Delete")
            {
                cbxSecondAccountType_Delete.Items.Clear();

                for (int i = 0; i < lstSecondAccountTypes.Count; i++)
                {
                    cbxSecondAccountType_Delete.Items.Add(lstSecondAccountTypes[i]);
                }

                cbxSecondAccountType_Delete.Text = cbxSecondAccountType_Delete.Items[0].ToString();
            }
            else
            {
                cbxSecondAccountType_Add.Items.Clear();

                for (int i = 0; i < lstSecondAccountTypes.Count; i++)
                {
                    cbxSecondAccountType_Add.Items.Add(lstSecondAccountTypes[i]);
                }

                cbxSecondAccountType_Add.Text = cbxSecondAccountType_Add.Items[0].ToString();
            }
        }

        private void cbxSecondAccountType_Delete_SelectedIndexChanged(object sender, EventArgs e)
        {
            //根据二级目录载入账户名称
            if (dicAccountInfo[cbxFirstAccountType_Delete.Text][cbxSecondAccountType_Delete.Text] != null)
            {
                List<string> lstAccountNames = dicAccountInfo[cbxFirstAccountType_Delete.Text][cbxSecondAccountType_Delete.Text].Keys.ToList();
                cbxAccountName.Items.Clear();

                for (int i = 0; i < lstAccountNames.Count; i++)
                {
                    cbxAccountName.Items.Add(lstAccountNames[i]);
                }
            }
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            if (txtAccountName.Text == "")
            {
                MessageBox.Show("账户名称不能为空！");
                return;
            }

            if (txtInitialMoney.Text == "")
            {
                MessageBox.Show("初始金额不能为空！");
                return;
            }

            try
            {
                Convert.ToDouble(txtInitialMoney.Text);
            }
            catch
            {
                MessageBox.Show("初始金额应为数字！");
                return;
            }

            AddAccountEventArgs args = new AddAccountEventArgs(txtAccountName.Text, Convert.ToDouble(txtInitialMoney.Text), cbxFirstAccountType_Add.Text, cbxSecondAccountType_Add.Text);//载入事件参数
            EventHandler<AddAccountEventArgs> eventTemp = null;

            if (Interlocked.Exchange(ref eventTemp, AddAccountEventHandler) == null)
            {
                try
                {
                    //更改当前画面数据对象
                    if (dicAccountInfo[cbxFirstAccountType_Add.Text][cbxSecondAccountType_Add.Text] == null)
                    {
                        Dictionary<string, dynamic> dicNewAccountNameAndMoney = new Dictionary<string, dynamic>();
                        dicNewAccountNameAndMoney.Add(txtAccountName.Text, Convert.ToDouble(txtInitialMoney.Text));

                        dicAccountInfo[cbxFirstAccountType_Add.Text][cbxSecondAccountType_Add.Text] = dicNewAccountNameAndMoney;
                    }
                    else
                    {
                        dicAccountInfo[cbxFirstAccountType_Add.Text][cbxSecondAccountType_Add.Text].Add(txtAccountName.Text, Convert.ToDouble(txtInitialMoney.Text));
                    }

                    eventTemp(sender, args);                                                       //调用事件
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            MessageBox.Show("成功添加账户！");
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            if (DialogResult.Cancel == MessageBox.Show("确定删除该账户？", "警告", MessageBoxButtons.OKCancel))
            {
                return;
            }

            if (cbxAccountName.Text == "")
            {
                MessageBox.Show("账户名称不能为空！");
                return;
            }

            DeleteAccountEventArgs args = new DeleteAccountEventArgs(cbxAccountName.Text, cbxFirstAccountType_Delete.Text, cbxSecondAccountType_Delete.Text);
            EventHandler<DeleteAccountEventArgs> eventTemp = null;

            if (Interlocked.Exchange(ref eventTemp, DeleteAccountEventHandler) == null)
            {
                try
                {
                    //更改当前画面数据对象
                    dicAccountInfo[cbxFirstAccountType_Delete.Text][cbxSecondAccountType_Delete.Text].Remove(cbxAccountName.Text);

                    eventTemp(sender, args);                                                       //调用事件
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            //初始化控件
            cbxAccountName.Items.Remove(cbxAccountName.Text);
            cbxAccountName.Text = "";

            MessageBox.Show("成功删除账户！");
        }

        private void txtInitialMoney_Leave(object sender, EventArgs e)
        {
            CommonUI.LeaveMoneyTextbox(txtInitialMoney);
        }

        private void txtInitialMoney_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                btnAddAccount_Click(btnAddAccount, new EventArgs());
            }
        }

        private void cbxAccountName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                btnDeleteAccount_Click(btnDeleteAccount, new EventArgs());
            }
        }
    }
}
