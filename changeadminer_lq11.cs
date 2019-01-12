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
    public partial class changeadminer_lq11 : Form
    {
        public changeadminer_lq11()
        {
            InitializeComponent();
        }

        private void changeadminer_lq11_Load(object sender, EventArgs e)
        {
            var adminlq11 = File.ReadAllText("D:/签到lq11/管理员lq11/admin.txt");
            var admintemplq11 = adminlq11.Split('-');
            label1.Text = "原账户为：" + admintemplq11[0];
            label2.Text = "原密码为：" + admintemplq11[1];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text==""||textBox2.Text=="")
            {
                MessageBox.Show("输入信息不能为空！");
                return;
            }else
            {
                var admintxt_lq11 = "";
                admintxt_lq11 = textBox1.Text + "-" + textBox2.Text;
                File.WriteAllText("D:/签到lq11/管理员lq11/admin.txt", admintxt_lq11);
                MessageBox.Show("修改成功");
                this.Close();
            }
        }
    }
}
