using System;
using System.Drawing;
using System.Windows.Forms;

namespace Labs
{
    public partial class FormAuto : Form
    {
        private ITransport tractor;

        public FormAuto()
        {
            InitializeComponent();
        }
        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxBulldozer.Width, pictureBoxBulldozer.Height);
            Graphics gr = Graphics.FromImage(bmp);
            tractor.DrawCar(gr);
            pictureBoxBulldozer.Image = bmp;
        }
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            tractor = new bulldozer(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.Blue,
           Color.Yellow, true);
            tractor.SetPosition(rnd.Next(10, 100), rnd.Next(10, 100), pictureBoxBulldozer.Width, pictureBoxBulldozer.Height);
            Draw();
        }

        private void buttonMove_Click(object sender, EventArgs e)
        {
            //получаем имя кнопк
            string name = (sender as Button).Name;
            switch (name)
            {
                case "buttonUp":
                    tractor.MoveTransport(Direction.Up);
                    break;
                case "buttonDown":
                    tractor.MoveTransport(Direction.Down);
                    break;
                case "buttonLeft":
                    tractor.MoveTransport(Direction.Left);
                    break;
                case "buttonRight":
                    tractor.MoveTransport(Direction.Right);
                    break;
            }
            Draw();
        }

        private void buttonCreateTractor_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            tractor = new Tractor(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.Blue);
            tractor.SetPosition(rnd.Next(10, 100), rnd.Next(10, 100), pictureBoxBulldozer.Width,
           pictureBoxBulldozer.Height);
            Draw();
        }
    }
}
