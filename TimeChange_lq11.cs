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
    public partial class TimeChange_lq11 : Form
    {
        public TimeChange_lq11()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TimeChange_lq11_Load(object sender, EventArgs e)
        {
            //为combox添加数据--开始
            for(int i=1;i<25;i++)
            {
                comboBox1.Items.Add(i);
            }
            for (int i = 0; i < 60; i++)
            {
                comboBox2.Items.Add(i);
            }
            comboBox1.SelectedIndex = 7;
            comboBox2.SelectedIndex = 30;
            //为Combox添加数据--结束

            var timelq11 = File.ReadAllText("D:/签到lq11/管理员lq11/time.txt");
            var oldtimelq11 = timelq11.Split('-');
            label3.Text ="已经设置的时间为："+ oldtimelq11[0] + "点" + oldtimelq11[1] + "分";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //通过覆盖文件的方法保存数据--开始
            if (comboBox1.Text == "" || comboBox2.Text == "")
            {
                MessageBox.Show("输入信息不能为空！");
                return;
            }
            else
            {
                var newtime_lq11 = "";
                newtime_lq11 = comboBox1.Text + "-" + comboBox2.Text;
                File.WriteAllText("D:/签到lq11/管理员lq11/time.txt", newtime_lq11);
                MessageBox.Show("修改成功");
                this.Close();
            }
            //通过覆盖文件的方法保存数据--结束
        }
    }
}
