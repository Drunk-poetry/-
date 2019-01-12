using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Finalwork_1
{
    public partial class adminerlq11 : Form
    {
        public adminerlq11()
        {
            InitializeComponent();
        }

        private void adminerlq11_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var adminlq11 = File.ReadAllText("D:/签到lq11/管理员lq11/admin.txt");
            var admintemplq11 = adminlq11.Split('-');
            if(textBox1.Text==admintemplq11[0])
            {
                if(textBox2.Text==admintemplq11[1])
                {
                    new adminmenu_lq11().Show();//如果账号和密码正确，显示管理窗口
                    this.Close();
                }
                else
                {
                    MessageBox.Show("密码输入错误");
                }
            }
            else
            {
                MessageBox.Show("管理员账号不正确");
            }
        }
    }
}
