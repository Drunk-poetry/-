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
    public partial class SignSuccess_lq11 : Form
    {
        public SignSuccess_lq11()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void SignSuccess_lq11_Load(object sender, EventArgs e)
        {
            DateTime time_lq11 = new DateTime();
            time_lq11 = DateTime.Now;
            //MessageBox.Show(time_lq11.ToString());
            var timetext_lq11 = "";
            var year_lq11 = time_lq11.Year;
            var month_lq11 = time_lq11.Month;
            var day_lq11 = time_lq11.Day;
            var hour_lq11 = time_lq11.Hour;
            var minute_lq11 = time_lq11.Minute;
            var second_lq11 = time_lq11.Second;
            label3.Text=year_lq11+"年"+month_lq11+"月"+day_lq11+"日"+hour_lq11+"时"+minute_lq11+"分"+second_lq11+"秒";

        }
    }
}
