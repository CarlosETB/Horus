using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace HorusApplication
{
    public partial class frmAviso_Saida : Form
    {
        public frmAviso_Saida()
        {
            InitializeComponent();            
            this.ShowInTaskbar = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Fechar();            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        public static int tente = 1;        

        private void timer1_Tick(object sender, EventArgs e)
        {           

            if (tente == 1)
            {
                this.BackgroundImage = null;

                label1.ForeColor = Color.White;
                label2.ForeColor = Color.White;
                button1.ForeColor = Color.White;
                button5.ForeColor = Color.White;
            }
            else if (tente == 2)
            {
                this.BackgroundImage = HorusApplication.Properties.Resources.Principal_Background2;

                label1.ForeColor = Color.Black;
                label2.ForeColor = Color.Black;
                button1.ForeColor = Color.Black;
                button5.ForeColor = Color.Black;
            }
            else {}
            

        }        

        public void Fechar()
        {
            

            frmAcesso.g.Visible = false;
            this.Visible = false;

            /*
            frmTelas meuForm = new frmTelas();

            try
            {
                frmTelas.time = 1;
            }
            catch { }

            frmPrincipal Principal = new frmPrincipal();

            try
            {
                frmPrincipal.time = 1;
            }
            catch { }
            */
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }      
}
         