using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CtpLibrary
{
    public class CommonUI
    {
        public static void LeaveMoneyTextbox(TextBox textBox)
        {
            double dblMoney = 0;

            try
            {
                dblMoney = Convert.ToDouble(textBox.Text);
            }
            catch
            {
                MessageBox.Show("请输入金额！");
                textBox.Focus();
            }

            if (dblMoney != 0)
            {
                textBox.Text = dblMoney.ToString("0.00");
            }
            else
            {
                textBox.Text = string.Empty;
            }
        }
    }
}
