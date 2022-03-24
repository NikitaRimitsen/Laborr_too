using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laborr_too
{
    class Varvid : Form
    {
        public Color color;
        HScrollBar red = new HScrollBar();
        HScrollBar green = new HScrollBar();
        HScrollBar blue = new HScrollBar();
        NumericUpDown rednumeric = new NumericUpDown();
        NumericUpDown greennumeric = new NumericUpDown();
        NumericUpDown bluenumeric = new NumericUpDown();
        PictureBox pokazevaet = new PictureBox();
        Color colorResult;
        public Varvid(Color color)
        {
            //--------------------Button----------------------
            Button Ok = new Button()
            {
                Text = "Ok",
                Width =85,
                Height=25,
                Location = new System.Drawing.Point(30, 320)
            };
            Ok.Click += Ok_Click;
            Button Cancel = new Button()
            {
                Text = "Cancel",
                Width = 85,
                Height = 25,
                Location = new System.Drawing.Point(140, 320)
            };
            Cancel.Click += Cancel_Click;
            Button OtherColor = new Button()
            {
                Text = "OtherColor",
                Width = 85,
                Height = 25,
                Location = new System.Drawing.Point(520, 320)
            };
            OtherColor.Click += OtherColor_Click;
            //------------------------------------------
            //-------------------HscrollBar-----------------------
            red = new HScrollBar()
            {
                Width = 230,
                Height = 20,
                Location = new System.Drawing.Point(120, 50),
                Minimum = 0,
                Maximum = 255,
                LargeChange = 1
            };
            red.ValueChanged += Red_ValueChanged;
            green = new HScrollBar()
            {
                Width = 230,
                Height = 20,
                Location = new System.Drawing.Point(120, 100),
                Minimum = 0,
                Maximum = 255,
                LargeChange = 1
            };
            green.ValueChanged += Green_ValueChanged;
            blue = new HScrollBar()
            {
                Width = 230,
                Height = 20,
                Location = new System.Drawing.Point(120, 150),
                Minimum = 0,
                Maximum = 255,
                LargeChange = 1
            };
            blue.ValueChanged += Blue_ValueChanged;
            //------------------------------------------
            //--------------------Label----------------------
            Label redlabel = new Label()
            {
                Text = "Red",
                Location = new System.Drawing.Point(50, 50)
            };
            Label greeblabel = new Label()
            {
                Text = "Green",
                Location = new System.Drawing.Point(50, 100)
            };
            Label bluelabel = new Label()
            {
                Text = "Blue",
                Location = new System.Drawing.Point(50, 150)
            };
            //------------------------------------------
            //--------------------NumericUpDown----------------------
            rednumeric = new NumericUpDown()
            {
                Width = 40,
                Location = new System.Drawing.Point(390, 50),
                Minimum = 0,
                Maximum = 255,
                Increment = 1
            };
            rednumeric.ValueChanged += Rednumeric_ValueChanged;
            greennumeric = new NumericUpDown()
            {
                Width = 40,
                Location = new System.Drawing.Point(390, 100),
                Minimum = 0,
                Maximum = 255,
                Increment = 1
            };
            greennumeric.ValueChanged += Greennumeric_ValueChanged;
            bluenumeric = new NumericUpDown()
            {
                Width = 40,
                Location = new System.Drawing.Point(390, 150),
                Minimum = 0,
                Maximum = 255,
                Increment = 1
            };
            bluenumeric.ValueChanged += Bluenumeric_ValueChanged;
            //------------------------------------------
            //--------------------PictureBox----------------------
            pokazevaet = new PictureBox()
            {
                Width = 130,
                Height = 130,
                Location = new System.Drawing.Point(480, 40),
                BackColor = Color.Black
            };
            //------------------------------------------
            this.Controls.Add(Ok);
            this.Controls.Add(Cancel);
            this.Controls.Add(OtherColor);
            this.Controls.Add(red);
            this.Controls.Add(green);
            this.Controls.Add(blue);
            this.Controls.Add(redlabel);
            this.Controls.Add(greeblabel);
            this.Controls.Add(bluelabel);
            this.Controls.Add(rednumeric);
            this.Controls.Add(greennumeric);
            this.Controls.Add(bluenumeric);
            this.Controls.Add(pokazevaet);
            this.Text = "Pildiredaktor";
            this.Height = 400;//свойство высота формы
            this.Width = 650;


            red.Tag = rednumeric;
            green.Tag = greennumeric;
            blue.Tag = bluenumeric;

            rednumeric.Tag = red;
            greennumeric.Tag = green;
            bluenumeric.Tag = blue;

            rednumeric.Value = color.R;
            greennumeric.Value = color.G;
            bluenumeric.Value = color.B;

            
            /*if (forma1 !=null)
            {
                string s = forma1.textBox1.Text;
                forma1.textBox1.Text="OK"
            }*/
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            color = Color.FromArgb(red.Value, green.Value, blue.Value);
            Form1 forma1 = this.Owner as Form1;
            this.Hide();
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            color = Color.FromArgb(red.Value, green.Value, blue.Value);
            Form1 forma1 = this.Owner as Form1;
            this.Hide();
        }

        private void OtherColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                red.Value = colorDialog.Color.R;
                green.Value = colorDialog.Color.G;
                blue.Value = colorDialog.Color.B;

                colorResult = colorDialog.Color;

                UpdateColor();

            }
        }

        //-----------------------UpdateColor-------------------------
        private void UpdateColor()
        {
            colorResult = Color.FromArgb(red.Value, green.Value, blue.Value);
            pokazevaet.BackColor = colorResult;
        }
        //------------------------------------------------
        //----------------------Blue--------------------------
        private void Blue_ValueChanged(object sender, EventArgs e)
        {
            ScrollBar scrollBar = (ScrollBar)sender;
            NumericUpDown numericUpDown = (NumericUpDown)scrollBar.Tag;
            numericUpDown.Value = scrollBar.Value;
            UpdateColor();
        }

        private void Bluenumeric_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = (NumericUpDown)sender;
            ScrollBar scrollBar = (ScrollBar)numericUpDown.Tag;
            scrollBar.Value = (int)numericUpDown.Value;
        }

        //------------------------------------------------
        //----------------------Green--------------------------
        private void Green_ValueChanged(object sender, EventArgs e)
        {
            ScrollBar scrollBar = (ScrollBar)sender;
            NumericUpDown numericUpDown = (NumericUpDown)scrollBar.Tag;
            numericUpDown.Value = scrollBar.Value;
            UpdateColor();
        }
        private void Greennumeric_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = (NumericUpDown)sender;
            ScrollBar scrollBar = (ScrollBar)numericUpDown.Tag;
            scrollBar.Value = (int)numericUpDown.Value;
        }
        //------------------------------------------------
        //----------------------Red--------------------------
        private void Red_ValueChanged(object sender, EventArgs e)
        {
            ScrollBar scrollBar = (ScrollBar)sender;
            NumericUpDown numericUpDown = (NumericUpDown)scrollBar.Tag;
            numericUpDown.Value = scrollBar.Value;
            UpdateColor();
        }
        private void Rednumeric_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = (NumericUpDown)sender;
            ScrollBar scrollBar = (ScrollBar)numericUpDown.Tag;
            scrollBar.Value = (int)numericUpDown.Value;
        }
        //----------------------------------------------------
    }
}
