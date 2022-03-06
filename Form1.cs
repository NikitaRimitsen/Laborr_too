using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laborr_too
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
            MenuStrip menu = new MenuStrip();
            //-------------Help---------------
            ToolStripMenuItem File = new ToolStripMenuItem("File");
            ToolStripMenuItem New = new ToolStripMenuItem("New");
            New.ShortcutKeys = Keys.Control | Keys.N;
            ToolStripMenuItem Open = new ToolStripMenuItem("Open");
            Open.ShortcutKeys = Keys.F3;
            ToolStripMenuItem Save = new ToolStripMenuItem("Save");
            Save.ShortcutKeys = Keys.F2;
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
            ToolStripButton Colorbtn = new ToolStripButton();
            Colorbtn.Image = Image.FromFile(@"..\..\Pilti\Palitra.png");
            Colorbtn.Margin = new Padding(0, 0, 0, 30);
            ToolStripButton Exitbtn = new ToolStripButton();
            Exitbtn.Image = Image.FromFile(@"..\..\Pilti\Vexod.png");
            Exitbtn.Margin = new Padding(0, 0, 0, 30);

            bokovoemenu.Items.Add(Newbtn);
            bokovoemenu.Items.Add(Openbtn);
            bokovoemenu.Items.Add(Savebtn);
            bokovoemenu.Items.Add(Colorbtn);
            bokovoemenu.Items.Add(Exitbtn);

            //---------------------Panel-----------------
            Panel panelka = new Panel();
            panelka.Location = new System.Drawing.Point(80, 600);
            panelka.Name = "Panel1";
            panelka.Size = new System.Drawing.Size(50, 200);


            //--------------TrackBar
            //-------Pilti, tocnee iconko dlja menu------------------
            New.Image = Image.FromFile(@"..\..\Pilti\karandash.ico");

            //---------Forma-------
            this.Controls.Add(menu);
            this.Controls.Add(bokovoemenu);
            this.Controls.Add(panelka);

            //this.Icon = Properties.Resources.karandash;
            //this.BackColor = Color.Gainsboro;
            this.Height = 700;//свойство высота формы
            this.Width = 1100;

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }



    }
}
