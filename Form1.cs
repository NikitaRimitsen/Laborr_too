using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Laborr_too
{
    public partial class Form1 : Form
    {
        public Color color = Color.Black;
        Label dljameshe = new Label();
        PictureBox osnova = new PictureBox();
        TrackBar tudasuda = new TrackBar();
        bool drawing;
        int historyCounter;
        GraphicsPath currentPath;
        Point oldLocation;
        public Pen currentPen;
        Color historyColor;
        List<Image> History;
        //public object color;

        public Form1()
        {
            InitializeComponent();
            drawing = false;
            currentPen = new Pen(color);
            currentPen.Width = tudasuda.Value;

            MainMenu menu = new MainMenu();
            //-------------File---------------
            MenuItem File = new MenuItem("File");        
            File.MenuItems.Add("New", new EventHandler(New_Click)).Shortcut = Shortcut.CtrlN;
            File.MenuItems.Add("Open", new EventHandler(Open_Click)).Shortcut = Shortcut.F3;
            File.MenuItems.Add("Save", new EventHandler(Save_Click)).Shortcut = Shortcut.F2;
            File.MenuItems.Add("Exit", new EventHandler(Exit_Click)).Shortcut = Shortcut.CtrlX;
            MenuItem Edit = new MenuItem("Edit");
            Edit.MenuItems.Add("Undo", new EventHandler(Undo_Click)).Shortcut = Shortcut.CtrlZ;
            Edit.MenuItems.Add("Redo", new EventHandler(Redo_Click)).Shortcut = Shortcut.CtrlShiftZ;
            MenuItem Pen = new MenuItem("Pen") { Checked = true };
            MenuItem Style = new MenuItem("Style") { Checked = true };
            MenuItem Color_ = new MenuItem("Color");
            Color_.Click += Color__Click;
            MenuItem Solid = new MenuItem("Solid") { Checked = true };
            Solid.Click += Solid_Click;
            MenuItem Dot = new MenuItem("Dot");
            Dot.Click += Dot_Click;
            MenuItem DashDotHot = new MenuItem("DashDotHot");
            DashDotHot.Click += DashDotHot_Click;

            MenuItem Help = new MenuItem("Help");
            Help.MenuItems.Add("About", new EventHandler(About_Click)).Shortcut = Shortcut.F1;
            menu.MenuItems.Add(File);
            menu.MenuItems.Add(Edit);
            Edit.MenuItems.Add(Pen);
            Pen.MenuItems.Add(Style);
            Pen.MenuItems.Add(Color_);
            Style.MenuItems.Add(Solid);
            Style.MenuItems.Add(Dot);
            Style.MenuItems.Add(DashDotHot);

            menu.MenuItems.Add(Help);
            /*MenuItem Open = new MenuItem("Open");
            Open.Click += Open_Click;
            MenuItem Save = new MenuItem("Save");
            Save.Click += Save_Click;
            MenuItem Exit = new MenuItem("Exit");
            Exit.Click += Exit_Click;
            // -------------------Edit----------
            ToolStripMenuItem Edit = new ToolStripMenuItem("Edit");
            ToolStripMenuItem Undo = new ToolStripMenuItem("Undo");
            ToolStripMenuItem Reno = new ToolStripMenuItem("Reno");
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
            About.Click += About_Click;
            // -------------------File----------
            /*File.DropDownItems.Add(New);
            File.DropDownItems.Add(Open);
            File.DropDownItems.Add(Save);
            File.DropDownItems.Add(Exit);*/
            // -------------------Edit----------
            /*Edit.DropDownItems.Add(Undo);
            Edit.DropDownItems.Add(Reno);
            Edit.DropDownItems.Add(Pen);
            Pen.DropDownItems.Add(Style);
            Pen.DropDownItems.Add(Color);
            Style.DropDownItems.Add(Solid);
            Style.DropDownItems.Add(Dot);
            Style.DropDownItems.Add(DashDotDot);
            //-------------Help---------------
            Help.DropDownItems.Add(About);*/

            //-------Dobavlenie_v_menu-------
            /*menu.Items.Add(File);
            menu.Items.Add(Edit);
            menu.Items.Add(Help);*/

            //---------Bokovoe_menu--------------
            ToolStrip bokovoemenu = new ToolStrip();
            bokovoemenu.Dock = DockStyle.Left;
            bokovoemenu.ImageScalingSize = new Size(70, 70);
            bokovoemenu.AutoSize = false;
            bokovoemenu.Margin = new System.Windows.Forms.Padding(20, 0, 20, 0);

            ToolStripButton Newbtn = new ToolStripButton();
            Newbtn.Image = Image.FromFile(@"..\..\Pilti\New.png");
            Newbtn.Margin = new Padding(0, 0, 0, 30);
            Newbtn.Click += Newbtn_Click;
            ToolStripButton Openbtn = new ToolStripButton();
            Openbtn.Image = Image.FromFile(@"..\..\Pilti\Open.png");
            Openbtn.Margin = new Padding(0, 0, 0, 30);
            Openbtn.Click += Openbtn_Click;
            ToolStripButton Savebtn = new ToolStripButton();
            Savebtn.Image = Image.FromFile(@"..\..\Pilti\Save.png");
            Savebtn.Margin = new Padding(0, 0, 0, 30);
            Savebtn.Click += Savebtn_Click;
            ToolStripButton Colorbtn = new ToolStripButton();
            Colorbtn.Image = Image.FromFile(@"..\..\Pilti\Palitra.png");
            Colorbtn.Margin = new Padding(0, 0, 0, 30);
            Colorbtn.Click += Colorbtn_Click;
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
            //-------------------------Panel-2-----------------
            Panel nazad = new Panel();
            nazad.Location = new System.Drawing.Point(100, 32);
            nazad.Size = new System.Drawing.Size(1000, 600);

            //--------------TrackBar--------------
            
            tudasuda.Orientation = Orientation.Horizontal;
            tudasuda.Minimum = 1;
            tudasuda.Maximum = 20;
            tudasuda.Value = 5;
            tudasuda.Location = new System.Drawing.Point(750, 650);
            tudasuda.Width = 250;
            tudasuda.Height = 100;
            tudasuda.Scroll += Tudasuda_Scroll;

            //---------------Label-----------------      
            dljameshe.Location = new System.Drawing.Point(150, 650);
            dljameshe.Text = "X: 0 ;  Y: 0";


            //-------Pilti, tocnee iconko dlja menu------------------
            //New.Image = Image.FromFile(@"..\..\Pilti\karandash.ico");

            //----------------PictureBox--------------
            
            //-------------Pamat_List<Image>----------
            History = new List<Image>();
            //--------------------Bitmap--------------
            Bitmap pic = new Bitmap(950, 551);
            osnova.Image = pic;

            //---------Forma-------
            this.Menu = menu;

            //this.Controls.Add(menu);
            this.Controls.Add(bokovoemenu);
            //this.Controls.Add(panelka);
            this.Controls.Add(nazad);
            nazad.Controls.Add(osnova);
            this.Controls.Add(tudasuda);
            this.Controls.Add(dljameshe);

            osnova.MouseMove += Form1_MouseMove1;
            osnova.MouseDown += Osnova_MouseDown1;
            osnova.MouseUp += Osnova_MouseUp;
            this.MouseDown += Osnova_MouseDown;


            this.Icon = Properties.Resources.iconkaglavnaja;
            //this.BackColor = Color.Gainsboro;
            this.Text = "Pildiredaktor";
            this.Height = 750;//свойство высота формы
            this.Width = 1200;

        }

        public void Cvet()
        {
            Varvid varvid = new Varvid(color);
            varvid.Owner = this;
            varvid.ShowDialog();
            currentPen.Color = color;
        }

        private void Colorbtn_Click(object sender, EventArgs e)
        {
            Cvet();
        }

        private void Color__Click(object sender, EventArgs e)
        {
            Cvet();
        }

        private void DashDotHot_Click(object sender, EventArgs e)
        {
            currentPen.DashStyle = DashStyle.DashDotDot;
            MenuItem Solid = new MenuItem("Solid") { Checked = false };
            MenuItem Dot = new MenuItem("Dot") { Checked = false };
            MenuItem DashDotHot = new MenuItem("DashDotDot") { Checked = true };
        }

        private void Dot_Click(object sender, EventArgs e)
        {
            currentPen.DashStyle = DashStyle.Dot;
            MenuItem Solid = new MenuItem("Solid") { Checked = false };
            MenuItem Dot = new MenuItem("Dot") { Checked = true };
            MenuItem DashDotHot = new MenuItem("DashDotDot") { Checked = false };
        }

        private void Solid_Click(object sender, EventArgs e)
        {
            currentPen.DashStyle = DashStyle.Solid;

            MenuItem Solid= new MenuItem("Solid") { Checked = true };
            MenuItem Dot = new MenuItem("Dot") { Checked = false };
            MenuItem DashDotHot = new MenuItem("DashDotDot") { Checked = false };
            //Solid.Checked = true;

        }

        //-------------------Undo_ja_Redo-----------------

        private void Undo_Click(object sender, EventArgs e)
        {
            if (History.Count !=0 && historyCounter !=0)
            {
                osnova.Image = new Bitmap(History[--historyCounter]);
            }
            else MessageBox.Show("История пуста");
        }

        private void Redo_Click(object sender, EventArgs e)
        {
            if (historyCounter < History.Count - 1)
            {
                osnova.Image = new Bitmap(History[++historyCounter]);
            }
            else MessageBox.Show("История пуста");
        }
        //------------------------------------------------
        private void Tudasuda_Scroll(object sender, EventArgs e)
        {
            currentPen.Width = tudasuda.Value;
        }

        private void Osnova_MouseUp(object sender, MouseEventArgs e)
        {
            History.RemoveRange(historyCounter + 1, History.Count - historyCounter - 1);
            History.Add(new Bitmap(osnova.Image));
            if (historyCounter + 1 < 10) historyCounter++;
            if (History.Count - 1 == 10) History.RemoveAt(0);
            drawing = false;
            try
            {
                //historyColor = Color.Yellow;
                currentPath.Dispose();
                currentPen.Color = historyColor;
            }
            catch { };
        }

        private void Osnova_MouseDown1(object sender, MouseEventArgs e)
        {
            if (osnova.Image == null)
            {
                MessageBox.Show("Сначала создайте новый файл!");
            }
            else if (e.Button == MouseButtons.Left)
            {
                historyColor = currentPen.Color;
                drawing = true;
                oldLocation = e.Location;
                currentPath = new GraphicsPath();
            }
            else if (e.Button == MouseButtons.Right)
            {
                historyColor = currentPen.Color;
                drawing = true;
                currentPen.Color = Color.White;
                oldLocation = e.Location;
                currentPath = new GraphicsPath();
            }

        }

        private void About_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Version Programm: 1.17\nDeveloper: Rimitsen Nikita\nDesigner: Rimitsen Nikita\nTester: Rimitsen Nikita", "About");
        }

        //-----------------------Функции------------------------------
        private void Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog OP = new OpenFileDialog();
            OP.Filter = "JPEG Image|*.jpg|Bitmap Image|*.bmp|GIF Image|*.gif|PNG Image|*png";
            OP.Title = "Open an Image File";
            OP.FilterIndex = 1;

            if (OP.ShowDialog() != DialogResult.Cancel)
            {
                osnova.Load(OP.FileName);
                osnova.AutoSize = true;
            }
        }
        private void Openbtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog OP = new OpenFileDialog();
            OP.Filter = "JPEG Image|*.jpg|Bitmap Image|*.bmp|GIF Image|*.gif|PNG Image|*png";
            OP.Title = "Open an Image File";
            OP.FilterIndex = 1;

            if (OP.ShowDialog() != DialogResult.Cancel)
            {
                osnova.Load(OP.FileName);
                osnova.AutoSize = true;
            }
        }


       
        private void Osnova_MouseDown(object sender, MouseEventArgs e)
        {
            
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
        //---------------------------------New----------------

        public void Pojavlenie()
        {
            History.Clear();
            historyCounter = 0;
            osnova.Location = new System.Drawing.Point(107, 34);
            osnova.Width = 950;
            osnova.Height = 551;
            osnova.BackColor = Color.White;
            Bitmap pic = new Bitmap(750, 500);
            osnova.Image = pic;
            History.Add(new Bitmap(osnova.Image));
            
        }
        private void Newbtn_Click(object sender, EventArgs e)
        {
            Pojavlenie();
            if (osnova.Image != null)
            {
                var result = MessageBox.Show("Сохранить текущее изображение перед созданием нового рисунка?", "Предупреждение", MessageBoxButtons.YesNoCancel);
                switch (result)
                {
                    case DialogResult.No: break;
                    case DialogResult.Yes: Savebtn_Click(sender, e); break;
                    case DialogResult.Cancel: return;
                }
            }
        }
        public void New_Click(object sender, EventArgs e)
        {
            Pojavlenie();
            if (osnova.Image != null)
            {
                var result = MessageBox.Show("Сохранить текущее изображение перед созданием нового рисунка?", "Предупреждение", MessageBoxButtons.YesNoCancel);
                switch (result)
                {
                    case DialogResult.No: break;
                    case DialogResult.Yes: Savebtn_Click(sender, e); break;
                    case DialogResult.Cancel: return;
                }
            }
        }
        //------------------------------------------------------
        private void Form1_MouseMove1(object sender, MouseEventArgs e)
        {
            dljameshe.Text = e.X.ToString() + " " + e.Y.ToString();
            if (drawing)
            {
                Graphics g = Graphics.FromImage(osnova.Image);
                currentPath.AddLine(oldLocation, e.Location);
                g.DrawPath(currentPen, currentPath);
                oldLocation = e.Location;
                g.Dispose();
                osnova.Invalidate();
            }

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

    }
}
