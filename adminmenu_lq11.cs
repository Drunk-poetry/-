using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finalwork_1
{
    public partial class adminmenu_lq11 : Form
    {
        public adminmenu_lq11()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form2lq11().Show();//显示员工管理窗口
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://tcxqq.top");//打开链接
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new changeadminer_lq11().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new latepeple_lq11().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new TimeChange_lq11().Show();
        }
    }
}
