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
    public partial class Form2lq11 : Form
    {
        static public Form2lq11 Instance;
        public Form2lq11()
        {
            InitializeComponent();
            Instance = this;
        }

        private void Form2lq11_Load(object sender, EventArgs e)
        {
            //初始化listview
            listView1.Columns.Add(new ColumnHeader() { Text = "姓名", Width = 80 });//添加头部
            listView1.Columns.Add(new ColumnHeader() { Text = "密码", Width = 200 });
            //读取文件将已有数据加入到listview中--开始
            var fileStreamlq11 = File.OpenText("d:/签到lq11/员工资料lq11/people.txt");
            while (!fileStreamlq11.EndOfStream)
            {
                var templq11 = fileStreamlq11.ReadLine();
                var itemslq11 = templq11.Split('-');//按照-分割
                for(int ilq11=0;ilq11<itemslq11.Length;ilq11+=2)
                {
                    if(ilq11<itemslq11.Length-1)
                    addpeoplelq11(itemslq11[ilq11], itemslq11[ilq11 + 1]);//循环加入listview中
                }
            }
            fileStreamlq11.Close();
            //读取文件将已有数据加入到listview中--结束
        }
        public void addpeoplelq11(string namelq11,string passworldlq11)//向listview中添加数据
        {
            listView1.Items.Add(new ListViewItem(new[] { namelq11, passworldlq11 }));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form3lq11().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //删除成员--开始
            foreach (ListViewItem itemlq11 in listView1.Items)
            {
                if (listView1.SelectedItems.Contains(itemlq11))
                {
                    int indexDellq11 = listView1.Items.IndexOf(listView1.FocusedItem);
                    if (listView1.SelectedItems.Count != 0)
                    {
                        listView1.Items.RemoveAt(indexDellq11);//删除  
                    }
                }
            }
            //删除成员--结束

            //将删除后的数据保存--开始
            var manslq11 = "";
            foreach (ListViewItem item in listView1.Items)
            {
                var linelq11 = "";

                foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                {
                    //获取一个人的数据
                    linelq11 += subItem.Text;
                    linelq11 += "-";
                }
                //将每个人的数据以字符串的形式加在一起
                manslq11 += linelq11;
            }
            //保存数据
            File.WriteAllText("d:/签到lq11/员工资料lq11/people.txt", manslq11);
            //将删除后的数据保存--结束
        }
    }
}
