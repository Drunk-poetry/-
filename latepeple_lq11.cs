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
    public partial class latepeple_lq11 : Form
    {
        static int daylq11;
        public latepeple_lq11()
        {
            InitializeComponent();
        }

        private void latepeple_lq11_Load(object sender, EventArgs e)
        {
            //时间--开始
            DateTime time_lq11 = new DateTime();
            time_lq11 = DateTime.Now;
            //MessageBox.Show(time_lq11.ToString());
            var year_lq11 = time_lq11.Year;
            var month_lq11 = time_lq11.Month;
            var day_lq11 = time_lq11.Day;
            daylq11 = day_lq11;
            //时间--结束
            var ishave = true;
            //初始化listview
            listView1.Columns.Add(new ColumnHeader() { Text = "姓名", Width = 80 });//添加头部
            listView1.Columns.Add(new ColumnHeader() { Text = "时间", Width = 150 });//添加时间
            listView1.Columns.Add(new ColumnHeader() { Text = "状态", Width = 80 });//添加是否迟到

            ShowDate(year_lq11, month_lq11, day_lq11,ref ishave);//显示数据

            }

        public void addpeoplelq11(string namelq11, string passworldlq11,string islatelq11)//向listview中添加数据
        {
            listView1.Items.Add(new ListViewItem(new[] { namelq11, passworldlq11 ,islatelq11}));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            //时间--开始
            DateTime time_lq11 = new DateTime();
            time_lq11 = DateTime.Now;
            //MessageBox.Show(time_lq11.ToString());
            var year_lq11 = time_lq11.Year;
            var month_lq11 = time_lq11.Month;
            //时间--结束
            var ishave = true;
            listView1.Items.Clear();
            ShowDate(year_lq11, month_lq11, --daylq11,ref ishave);
            if(!ishave)
            {
                button1.Enabled = false;
            }

        }

        public void ShowDate(int year_lq11,int month_lq11,int day_lq11,ref bool ishave)
        {
            //读取文件将已有数据加入到listview中--开始
            if (!File.Exists("D:/签到lq11/签到数据lq11/" + year_lq11 + "年" + month_lq11 + "月" + day_lq11 + "日.txt"))//检查是否存在该文件夹
            {
                //File.WriteAllText("D:/签到lq11/签到数据lq11/" + year_lq11 + "年" + month_lq11 + "月" + day_lq11 + "日.txt", "");//没有则创建
                MessageBox.Show("暂无签到数据！");
                ishave = false;
                return;
            }
            var fileStreamlq11 = File.OpenText("D:/签到lq11/签到数据lq11/" + year_lq11 + "年" + month_lq11 + "月" + day_lq11 + "日.txt");

            label2.Text = year_lq11 + "年" + month_lq11 + "月" + day_lq11 + "日";

            while (!fileStreamlq11.EndOfStream)
            {
                //var timehourlq11 = 8;
                //var timeminutelq11 = 30;
                //读取保存在本地的时间数据--开始
                var timedatalq11 = File.ReadAllText("D:/签到lq11/管理员lq11/time.txt");
                var timehourlq11 = Int32.Parse(timedatalq11.Split('-')[0]);
                var timeminutelq11 = Int32.Parse(timedatalq11.Split('-')[1]);

                var templq11 = fileStreamlq11.ReadLine();
                var itemslq11 = templq11.Split(';');//按照-分割得到单个员工数据
                for (int ilq11 = 0; ilq11 < itemslq11.Length; ilq11++)
                {
                    if (ilq11 < itemslq11.Length - 1)
                    {
                        var temp2lq11 = itemslq11[ilq11].Split('-');
                        var peopletimelq11 = temp2lq11[1].Split(':');
                        var islatelq11 = "未迟到";//添加是否迟到的标志
                        if (Int32.Parse(peopletimelq11[0]) > timehourlq11)
                        {
                            //MessageBox.Show("大于");
                            islatelq11 = "迟到";
                        }
                        else if (Int32.Parse(peopletimelq11[0]) == timehourlq11 && Int32.Parse(peopletimelq11[1]) > timeminutelq11)
                        {
                            //MessageBox.Show("小于");
                            islatelq11 = "迟到";
                        }
                        /*
                        var time2lq11 = peopletime[1].Substring(0, 2) + ":" + peopletime[1].Substring(2, peopletime[1].Length-2);
                        var islatelq11 = "未迟到";//添加是否迟到的标志
                        if (Int32.Parse(peopletime[1]) > 0800)
                            islatelq11 = "迟到";
                            */

                        addpeoplelq11(temp2lq11[0], temp2lq11[1], islatelq11);//循环加入listview中
                    }

                }
            }
            fileStreamlq11.Close();
            //读取文件将已有数据加入到listview中--结束

            //改变迟到员工颜色--开始
            foreach (ListViewItem itemlq11 in listView1.Items)
            {
                ListViewItem.ListViewSubItem laterlq11 = itemlq11.SubItems[2];//获取每一组数据的第三个元素
                if (laterlq11.Text == "迟到")
                {
                    itemlq11.BackColor = Color.Red;
                }
                else
                {
                    //itemlq11.BackColor = Color.Green;
                }
            }
            //改变迟到员工颜色--结束
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //时间--开始
            button1.Enabled = true;
            DateTime time_lq11 = new DateTime();
            time_lq11 = DateTime.Now;
            //MessageBox.Show(time_lq11.ToString());
            var year_lq11 = time_lq11.Year;
            var month_lq11 = time_lq11.Month;
            //时间--结束
            var ishave = true;
            listView1.Items.Clear();
            ShowDate(year_lq11, month_lq11, ++daylq11,ref ishave);
            if(!ishave)
            {
                button2.Enabled = false;
            }
        }
    }
}
