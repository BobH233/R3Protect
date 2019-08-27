using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CSR3Protect
{

    public partial class Form1 : Form
    {
        private bool close = true;//禁止关闭状态
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label2.Text = Process.GetCurrentProcess().Id.ToString();
        }
        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;
            if (m.Msg == WM_SYSCOMMAND && (int)m.WParam == SC_CLOSE && close)
                return;
            base.WndProc(ref m);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = true;//这样就关不了了 
            base.OnFormClosing(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists("user64.dll"))
            {

            }
            else
            {
                MessageBox.Show("关键部件 user64.dll 缺失,请重新下载", "user64.dll not found");
            }
        }
    }
}
