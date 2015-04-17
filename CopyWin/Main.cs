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

namespace CopyWin
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = Path.GetFullPath(folderBrowserDialog1.SelectedPath.ToString());
                DirectoryInfo dir = new DirectoryInfo(@"" + textBox1.Text);
                foreach (var d in dir.GetDirectories())
                {
                    listBox1.Items.Add(d.Name);
                }
                foreach (var d in dir.GetFiles())
                {
                    listBox1.Items.Add(d.Name);
                }

            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            if (folderBrowserDialog2.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = Path.GetFullPath(folderBrowserDialog2.SelectedPath.ToString());
                DirectoryInfo dir = new DirectoryInfo(@"" + textBox2.Text);
                foreach (var d in dir.GetDirectories())
                {
                    listBox2.Items.Add(d.Name);
                }
                foreach (var d in dir.GetFiles())
                {
                    listBox2.Items.Add(d.Name);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {          
           
            Copy.CopyTo(@"" + textBox1.Text, @"" + textBox2.Text, true);
            listBox2.Items.Clear();
            listBox1.Items.Clear();

            DirectoryInfo dir1 = new DirectoryInfo(@"" + textBox1.Text);
            DirectoryInfo dir2 = new DirectoryInfo(@"" + textBox2.Text);

            foreach (var d in dir1.GetDirectories())
            {
                listBox1.Items.Add(d.Name);
            }
            foreach (var d in dir1.GetFiles())
            {
                listBox1.Items.Add(d.Name);
            }      

            foreach (var d in dir2.GetDirectories())
            {
                listBox2.Items.Add(d.Name);
            }
            foreach (var d in dir2.GetFiles())
            {
                listBox2.Items.Add(d.Name);
            }           
        }

        private void button4_Click(object sender, EventArgs e)
        {
           InitializeTimer();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void InitializeTimer()
        {            
            var ticksss = System.Convert.ToInt32(textBox3.Text);
                      
                Timer timer1 = new Timer();
                timer1.Enabled = true;
                timer1.Interval = ticksss;
                timer1.Tick += button3_Click;
                       
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AboutBox AboutBox = new AboutBox();
            AboutBox.Show();
        }

        private void notifyIcon1_MouseClick(object sender, EventArgs e)
        {         
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                notifyIcon1.Visible = false;
            }
        }

        private void Main_Deactivate(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                notifyIcon1.Visible = true;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {           
            ToolTip btnSourceDir = new ToolTip();
            btnSourceDir.SetToolTip(button1, "Нижмите и выберите путь или введите его откуда копируем");

            ToolTip btnDestDir = new ToolTip();
            btnDestDir.SetToolTip(button2, "Нижмите и выберите путь или введите его куда копируем");

            ToolTip btnCopy = new ToolTip();
            btnCopy.SetToolTip(button3,"Нажмите для копирования");

            ToolTip btnTimer = new ToolTip();
            btnTimer.SetToolTip(button4, "Запускаем таймер не забывает указывать число мили/сек");

            ToolTip btnClose = new ToolTip();
            btnClose.SetToolTip(button5, "Закрыть приложение");

            ToolTip btnAbout = new ToolTip();
            btnAbout.SetToolTip(button6, "О программе");

            ToolTip txtBS = new ToolTip();
            txtBS.SetToolTip(textBox1, "Исходный путь");

            ToolTip txtBD = new ToolTip();
            txtBD.SetToolTip(textBox2, "Конечный путь");

            ToolTip txtbs = new ToolTip();
            txtbs.SetToolTip(textBox3, "Введите значение");
        }

    }
}
