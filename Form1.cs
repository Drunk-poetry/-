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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //FileStream filelq11=new FileStream()
            if (!File.Exists("D:/签到lq11/管理员lq11/admin.txt"))//检查是否存在该文件
            {
                //File.CreateText("D:/签到lq11/管理员lq11/admin.txt");//没有则创建
                File.WriteAllText("D:/签到lq11/管理员lq11/admin.txt", "admin-123456");
            }
            if (!File.Exists("D:/签到lq11/管理员lq11/isfirst.txt"))//检查是否存在该文件
            {
                //写入标志变量，觉判断是否为首次进入
                File.WriteAllText("D:/签到lq11/管理员lq11/isfirst.txt","0");
            }

            var isfirst = File.ReadAllText("D:/签到lq11/管理员lq11/isfirst.txt");//读取 标志变量
            if (isfirst=="0")
            {
                //StreamWriter adminlq11;
                //adminlq11 = File.CreateText("D:/签到lq11/管理员lq11/admin.txt");
                //adminlq11.WriteLine("admin-123456");//写入管理员默认数据
                // adminlq11.Close();
                File.WriteAllText("D:/签到lq11/管理员lq11/isfirst.txt", "1");
            }
            new adminerlq11().Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //创建用于存储数据的文件夹
            if (!Directory.Exists("d:/签到lq11"))//检查是否存在该文件夹
            {
                Directory.CreateDirectory("d:/签到lq11");//没有则创建
            }
            if (!Directory.Exists("d:/签到lq11/员工资料lq11"))//检查是否存在该文件夹
            {
                Directory.CreateDirectory("d:/签到lq11/员工资料lq11");//没有则创建
                File.WriteAllText("D:/签到lq11/员工资料lq11/people.txt","");
            }
            if (!Directory.Exists("d:/签到lq11/签到数据lq11"))//检查是否存在该文件夹
            {
                Directory.CreateDirectory("d:/签到lq11/签到数据lq11");//没有则创建
            }
            if (!Directory.Exists("d:/签到lq11/管理员lq11"))//检查是否存在该文件夹
            {
                Directory.CreateDirectory("d:/签到lq11/管理员lq11");//没有则创建
            }
            if (!File.Exists("D:/签到lq11/管理员lq11/time.txt"))//检查是否存在该文件夹
            {
                File.WriteAllText("D:/签到lq11/管理员lq11/time.txt", "8-30");//没有则创建
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            /*
            var bufflq11 = new byte[1024];
            var Streamlq11 = File.Open("d:/签到lq11/员工资料lq11/people.txt", FileMode.Open);
            var lengthlq11 = Streamlq11.Read(bufflq11, 0, bufflq11.Length);
            var templq11 = Encoding.UTF8.GetString(bufflq11, 0, lengthlq11);
            var manslq11 = templq11.Split('-');
            for(var ilq11=0;ilq11<manslq11.Length;ilq11+=2)
            {
                if(ilq11<manslq11.Length-1)
                {
                    var alq11 = textBox1.Text;
                    if ( alq11==manslq11[ilq11])
                        MessageBox.Show("恭喜" + manslq11[ilq11] + "签到成功");
                }
            }
            MessageBox.Show(templq11);
            */
            var peoplelq11 = File.ReadAllText("d:/签到lq11/员工资料lq11/people.txt");
            var manslq11 = peoplelq11.Split('-');
            var ishavelq11 = false;//判断有无此人
            var issignlq11 = false;//判断是否已经签过到
            for (var ilq11 = 0; ilq11 < manslq11.Length; ilq11 += 2)
            {
                if (ilq11 < manslq11.Length-1)
                {
                    if (textBox1.Text == manslq11[ilq11])//匹配用户名
                    {
                        if (textBox2.Text == manslq11[ilq11 + 1])//匹配密码
                        {
                            //MessageBox.Show("恭喜" + manslq11[ilq11] + "签到成功");
                            SaveSignPeople_lq11(issignlq11);
                            ishavelq11 = true;
                            return;
                        }
                        else
                        {
                            MessageBox.Show("密码输入错误！");
                            return;
                        }
                    }
                       
                }
            }
            if (!ishavelq11)
                MessageBox.Show("该员工不存在！");

        }

        void SaveSignPeople_lq11(bool issignlq11)
        {
            DateTime time_lq11 = new DateTime();
            time_lq11 = DateTime.Now;
            //MessageBox.Show(time_lq11.ToString());
            var year_lq11 = time_lq11.Year;
            var month_lq11 = time_lq11.Month;
            var day_lq11 = time_lq11.Day;
            var hour_lq11 = time_lq11.Hour;
            var minute_lq11 = time_lq11.Minute;
            var second_lq11 = time_lq11.Second;
            if (!File.Exists("D:/签到lq11/签到数据lq11/"+ year_lq11+"年" + month_lq11 + "月" + day_lq11 + "日.txt"))//检查是否存在该文件夹
            {
                File.WriteAllText("D:/签到lq11/签到数据lq11/" + year_lq11+"年" + month_lq11 + "月" + day_lq11 + "日.txt","");//没有则创建
            }


            //读取文件判断是否签过到--开始
            var templq11 = File.ReadAllText("D:/签到lq11/签到数据lq11/" + year_lq11 + "年" + month_lq11 + "月" + day_lq11 + "日.txt");
                var itemslq11 = templq11.Split(';');//按照-分割
                for (int ilq11 = 0; ilq11 < itemslq11.Length; ilq11 ++)
                {
                    if (ilq11 < itemslq11.Length - 1)
                    {
                        var namelq11 = itemslq11[ilq11].Split('-');
                        //MessageBox.Show(namelq11[0]);
                        if (namelq11[0] == textBox1.Text)
                        {
                            MessageBox.Show("请勿重复签到！");
                            issignlq11 = true;
                            return;
                        }
                    }
                        
                }
            if (issignlq11)
                return;
            new SignSuccess_lq11().Show();//显示签到成功的的窗口 
            //读取文件判断是否签过到--结束


            //保存员工签到数据--开始
            if (!issignlq11)
            {
                StreamWriter manlq11 = new StreamWriter("D:/签到lq11/签到数据lq11/" + year_lq11 + "年" + month_lq11 + "月" + day_lq11 + "日.txt", true);
                var textlq11 = "";
                textlq11 = textBox1.Text + "-" + hour_lq11 + ":" + minute_lq11 + ";";
                manlq11.Write(textlq11);//写入（在文本后追加内容）
                manlq11.Close();//关闭输出流
            }
            //保存员工签到数据--结束

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("请与管理员联系！");
        }
    }
}
