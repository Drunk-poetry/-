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
    public partial class Form3lq11 : Form
    {
        public Form3lq11()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2lq11.Instance.addpeoplelq11(textBox1.Text, textBox2.Text);
            //找到要写入的文件，true表示追加，false表示覆盖
            StreamWriter manlq11 = new StreamWriter("d:/签到lq11/员工资料lq11/people.txt", true);
            var textlq11 = "";
            textlq11 += textBox1.Text + "-" + textBox2.Text + "-";
            manlq11.Write(textlq11);//写入（在文本后追加内容）
            manlq11.Close();//关闭输出流

            this.Close();//关闭窗口
        }
    }
}
