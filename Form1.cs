using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Laborr_too
{
    public partial class Form1 : Form
    {
        Label dljameshe = new Label();
        PictureBox osnova = new PictureBox();


        public Form1()
        {
            InitializeComponent();
            MenuStrip menu = new MenuStrip();
            //-------------Help---------------
            ToolStripMenuItem File = new ToolStripMenuItem("File");
            ToolStripMenuItem New = new ToolStripMenuItem("New");
            New.ShortcutKeys = Keys.Control | Keys.N;
            New.Click += New_Click;
            ToolStripMenuItem Open = new ToolStripMenuItem("Open");
            Open.ShortcutKeys = Keys.F3;
            ToolStripMenuItem Save = new ToolStripMenuItem("Save");
            Save.ShortcutKeys = Keys.F2;
            Save.Click += Save_Click;
            ToolStripMenuItem Exit = new ToolStripMenuItem("Exit");
            Exit.ShortcutKeys = Keys.Alt | Keys.X;
            Exit.Click += Exit_Click;
            // -------------------Edit----------
            ToolStripMenuItem Edit = new ToolStripMenuItem("Edit");
            ToolStripMenuItem Undo = new ToolStripMenuItem("Undo");
            Undo.ShortcutKeys = Keys.Control | Keys.Z;
            ToolStripMenuItem Reno = new ToolStripMenuItem("Reno");
            Reno.ShortcutKeys = Keys.Control | Keys.Shift | Keys.Z;
            ToolStripMenuItem Pen = new ToolStripMenuItem("Pen") { Checked = true };
            ToolStripMenuItem Style = new ToolStripMenuItem("Style") { Checked = true };
            ToolStripMenuItem Color = new ToolStripMenuItem("Color");
            ToolStripMenuItem Solid = new ToolStripMenuItem("Solid") { Checked = true };
            ToolStripMenuItem Dot = new ToolStripMenuItem("Dot");
            ToolStripMenuItem DashDotDot = new ToolStripMenuItem("DashDotDot");
            //-------------Help---------------
            ToolStripMenuItem Help = new ToolStripMenuItem("Help");
            ToolStripMenuItem About = new ToolStripMenuItem("About");
            About.ShortcutKeys = Keys.F1;
            // -------------------File----------
            File.DropDownItems.Add(New);
            File.DropDownItems.Add(Open);
            File.DropDownItems.Add(Save);
            File.DropDownItems.Add(Exit);
            // -------------------Edit----------
            Edit.DropDownItems.Add(Undo);
            Edit.DropDownItems.Add(Reno);
            Edit.DropDownItems.Add(Pen);
            Pen.DropDownItems.Add(Style);
            Pen.DropDownItems.Add(Color);
            Style.DropDownItems.Add(Solid);
            Style.DropDownItems.Add(Dot);
            Style.DropDownItems.Add(DashDotDot);
            //-------------Help---------------
            Help.DropDownItems.Add(About);

            //-------Dobavlenie_v_menu-------
            menu.Items.Add(File);
            menu.Items.Add(Edit);
            menu.Items.Add(Help);

            //---------Bokovoe_menu--------------
            ToolStrip bokovoemenu = new ToolStrip();
            bokovoemenu.Dock = DockStyle.Left;
            bokovoemenu.ImageScalingSize = new Size(70, 70);
            bokovoemenu.AutoSize = false;
            bokovoemenu.Margin = new System.Windows.Forms.Padding(20, 0, 20, 0);

            ToolStripButton Newbtn = new ToolStripButton();
            Newbtn.Image = Image.FromFile(@"..\..\Pilti\New.png");
            Newbtn.Margin = new Padding(0, 0, 0, 30);          
            ToolStripButton Openbtn = new ToolStripButton();
            Openbtn.Image = Image.FromFile(@"..\..\Pilti\Open.png");
            Openbtn.Margin = new Padding(0, 0, 0, 30);
            ToolStripButton Savebtn = new ToolStripButton();
            Savebtn.Image = Image.FromFile(@"..\..\Pilti\Save.png");
            Savebtn.Margin = new Padding(0, 0, 0, 30);
            Savebtn.Click += Savebtn_Click;
            ToolStripButton Colorbtn = new ToolStripButton();
            Colorbtn.Image = Image.FromFile(@"..\..\Pilti\Palitra.png");
            Colorbtn.Margin = new Padding(0, 0, 0, 30);
            ToolStripButton Exitbtn = new ToolStripButton();
            Exitbtn.Image = Image.FromFile(@"..\..\Pilti\Vexod.png");
            Exitbtn.Margin = new Padding(0, 0, 0, 30);
            Exitbtn.Click += Exitbtn_Click;

            bokovoemenu.Items.Add(Newbtn);
            bokovoemenu.Items.Add(Openbtn);
            bokovoemenu.Items.Add(Savebtn);
            bokovoemenu.Items.Add(Colorbtn);
            bokovoemenu.Items.Add(Exitbtn);

            //---------------------Panel-----------------
            Panel panelka = new Panel();
            panelka.Location = new System.Drawing.Point(150, 400);
            panelka.Size = new System.Drawing.Size(100, 500);


            //--------------TrackBar--------------
            TrackBar tudasuda = new TrackBar();
            tudasuda.Orientation = Orientation.Horizontal;
            tudasuda.Minimum = 0;
            tudasuda.Maximum = 100;
            tudasuda.Value = 40;
            tudasuda.Location = new System.Drawing.Point(750, 600);
            tudasuda.Width = 250;
            tudasuda.Height = 100;

            //---------------Label-----------------      
            dljameshe.Location = new System.Drawing.Point(150, 600);
            dljameshe.Text = "X: 0 ;  Y: 0";


            //-------Pilti, tocnee iconko dlja menu------------------
            New.Image = Image.FromFile(@"..\..\Pilti\karandash.ico");

            //----------------PictureBox--------------
            
            osnova.Location = new System.Drawing.Point(107, 34);
            osnova.Width = 950;
            osnova.Height = 551;
            osnova.ImageLocation = (@"..\..\Pilti\fon.png");

            //--------------------Bitmap---------------
            Bitmap pic = new Bitmap(950, 551);
            osnova.Image = pic;
            
            //---------Forma-------
            this.Controls.Add(menu);
            this.Controls.Add(bokovoemenu);
            //this.Controls.Add(panelka);
            this.Controls.Add(tudasuda);
            this.Controls.Add(dljameshe);
            this.Click += Form1_Click;
            
            MouseMove += Form1_MouseMove1;


             this.Icon = Properties.Resources.iconkaglavnaja;
            //this.BackColor = Color.Gainsboro;
            this.Text = "Pildiredaktor";
            this.Height = 700;//свойство высота формы
            this.Width = 1100;

        }

        

        public void Savepilti()
        {
            SaveFileDialog SaveDlg = new SaveFileDialog();
            SaveDlg.Filter = "JPEG Image|*.jpg|Bitmap Image|*.bmp|GIF Image|*.gif|PNG Image|*png";
            SaveDlg.Title = "Save an Image  File";
            SaveDlg.FilterIndex = 4;
            SaveDlg.ShowDialog();
            if (SaveDlg.FileName != "")
            {
                System.IO.FileStream fs = (System.IO.FileStream)SaveDlg.OpenFile();

                switch (SaveDlg.FilterIndex)
                {
                    case 1:
                        this.osnova.Image.Save(fs, ImageFormat.Jpeg);
                        break;
                    case 2:
                        this.osnova.Image.Save(fs, ImageFormat.Bmp);
                        break;
                    case 3:
                        this.osnova.Image.Save(fs, ImageFormat.Gif);
                        break;
                    case 4:
                        this.osnova.Image.Save(fs, ImageFormat.Png);
                        break;
                }
                fs.Close();
            }
        }

        
        //-------------Save---------------
        private void Save_Click(object sender, EventArgs e)
        {
            Savepilti();
        }       
        private void Savebtn_Click(object sender, EventArgs e)
        {
            Savepilti();
        }
        //---------------------------------
        private void Form1_Click(object sender, EventArgs e)
        {
            if (osnova.Image == null)
            {
                MessageBox.Show("Сначала создайте новый файл!");
                return;
            }

        }

        public void New_Click(object sender, EventArgs e)
        {
            this.Controls.Add(osnova);
        }

        private void Form1_MouseMove1(object sender, MouseEventArgs e)
        {
            dljameshe.Text = e.X.ToString() + " " + e.Y.ToString();

        }
        //-----------------------Exit----------------
        private void Exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void Exitbtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        //-------------------------------------------
        public void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            int CursorX = Cursor.Position.X;
            int CursorY = Cursor.Position.Y;

            dljameshe.Text = "X: " + CursorX.ToString() + "; Y: " + CursorY.ToString();
        }
    }
}
