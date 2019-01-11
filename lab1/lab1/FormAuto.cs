using System;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsCars;

namespace lab1
{
    public partial class FormAuto : Form
    {
        private Itrandport car;
        
        public FormAuto()
        {
            InitializeComponent();
        }

        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxBulldozer.Width, pictureBoxBulldozer.Height);
            Graphics gr = Graphics.FromImage(bmp);
            car.DrawCar(gr);
            pictureBoxBulldozer.Image = bmp;
        }
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            car = new bulldozer(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.Blue,
           Color.Black, true);
            car.SetPosition(rnd.Next(10, 100), rnd.Next(10, 100), pictureBoxBulldozer.Width,
           pictureBoxBulldozer.Height);
            Draw();
        }
        private void buttonCreateCar_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            car = new Car(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.Blue);
            car.SetPosition(rnd.Next(10, 100), rnd.Next(10, 100), pictureBoxBulldozer.Width,
           pictureBoxBulldozer.Height);
            Draw();

        }
        private void buttonMove_Click(object sender, EventArgs e)
        {
            //получаем имя кнопки
            string name = (sender as Button).Name;
            switch (name)
            {
                case "buttonUp":
                    car.MoveTransport(Direction.Up);
                    break;
                case "button1":
                    car.MoveTransport(Direction.Down);
                    break;
                case "buttonLeft":
                    car.MoveTransport(Direction.Left);
                    break;
                case "button2":
                    car.MoveTransport(Direction.Right);
                    break;
            }
            Draw();
        }
    }
}
