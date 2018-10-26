using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace HorusApplication
{
    public partial class frmUrls : Form
    {
        

        public frmUrls()
        {
            InitializeComponent();
        }
        public string previousWindow = String.Empty;


        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder txt, int count);

        public void getWindowTitle()
        {
            if (previousWindow == getActiveWindowName())
            {

            }
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

        private void frmUrls_Load(object sender, EventArgs e)
        {

        }

        private void Timer_Tick_1(object sender, EventArgs e)
        {

        }

    }
}
