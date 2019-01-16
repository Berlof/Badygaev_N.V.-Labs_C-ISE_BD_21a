using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labs
{
    public partial class FormAuto : Form
    {
        private bulldozer bulldozer;
        public FormAuto()
        {
            InitializeComponent();
        }
        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxBulldozer.Width, pictureBoxBulldozer.Height);
            Graphics gr = Graphics.FromImage(bmp);
            bulldozer.DrawCar(gr);
            pictureBoxBulldozer.Image = bmp;
        }
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            bulldozer = new bulldozer(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.Blue,
           Color.Yellow, true);
            bulldozer.SetPosition(rnd.Next(10, 100), rnd.Next(10, 100), pictureBoxBulldozer.Width, pictureBoxBulldozer.Height);
            Draw();
        }

        private void buttonMove_Click(object sender, EventArgs e)
        {
            //получаем имя кнопк
            string name = (sender as Button).Name;
            switch (name)
            {
                case "buttonUp":
                    bulldozer.MoveTransport(Direction.Up);
                    break;
                case "buttonDown":
                    bulldozer.MoveTransport(Direction.Down);
                    break;
                case "buttonLeft":
                    bulldozer.MoveTransport(Direction.Left);
                    break;
                case "buttonRight":
                    bulldozer.MoveTransport(Direction.Right);
                    break;
            }
            Draw();
        }
    }
}
