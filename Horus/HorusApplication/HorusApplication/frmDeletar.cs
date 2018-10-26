using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace HorusApplication
{
    public partial class frmDeletar : Form
    {
        public frmDeletar()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string filepath = textBox1.Text;

            if (File.Exists(filepath))
            {
                File.Delete(filepath);
                MessageBox.Show("File Deleted");
            }
            else
            {
                MessageBox.Show("File Not Deleted");
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void frmDeletar_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string folderepath = textBox2.Text;

            if (Directory.Exists(folderepath))
            {
                Directory.Delete(folderepath, true);
                MessageBox.Show("Folder Deleted");

            }
            else
            {
                MessageBox.Show("Folder Not Deleted");
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
