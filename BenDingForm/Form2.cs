using BenDingActive;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BenDingForm
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btn_ini_Click(object sender, EventArgs e)
        {
            string msg = "";
            var resultData = YinHaiNewCOM.Init(out msg);
            if (resultData)
            {
                MessageBox.Show("初始化成功!!!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string  msg = "";
                 YinHaiNewCOM.yh_CHS_call(txt_Transaction_Code.Text, txt_Input.Text.Trim(),ref msg);
            if (!string.IsNullOrWhiteSpace(msg))
            {
                txt_Output.Text = msg;
            }
        }
    }
}
