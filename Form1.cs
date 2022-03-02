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


            this.Text = "Veterok";
            Button Kinozal_btn = new Button
            {
                Text = "Osta pilet",
                Location = new System.Drawing.Point(220, 100),//Point(x,y)
                Height = 50,
                Width = 120,
                BackColor = Color.LightYellow
            };

            Button Listat_btn = new Button
            {
                Text = "=>",
                Location = new System.Drawing.Point(580, 425),//Point(x,y)
                Height = 30,
                Width = 60,
                BackColor = Color.LightYellow
            };
            Button Info_btn = new Button
            {
                Text = "Info",
                Location = new System.Drawing.Point(220, 170),//Point(x,y)
                Height = 50,
                Width = 120,
                BackColor = Color.LightYellow
            };

            Button Pravil_btn = new Button
            {
                Text = "Reegel",
                Location = new System.Drawing.Point(220, 240),//Point(x,y)
                Height = 50,
                Width = 120,
                BackColor = Color.LightYellow
            };



            Label lbl = new Label
            {
                Text = "Kinoteatr „Veterok“",
                Size = new System.Drawing.Size(250, 60),
                Location = new System.Drawing.Point(180, 25),
                Font = new Font("Oswald", 16, FontStyle.Bold)

            };


            this.Controls.Add(Kinozal_btn);
            this.Controls.Add(Info_btn);
            this.Controls.Add(Pravil_btn);
            this.Controls.Add(lbl);

            this.BackColor = Color.LightSalmon;


            this.Controls.Add(Listat_btn);
            this.Controls.Add(Kinozal_btn);
            this.Height = 600;//свойство высота формы
            this.Width = 800;

        }
    }
}
