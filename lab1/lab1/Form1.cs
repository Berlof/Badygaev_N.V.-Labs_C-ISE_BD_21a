using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static lab1.bulldozer;

namespace lab1
{
    public partial class Form1 : Form
    {
        private bulldozer bulldozer;

           
      
        public Form1()
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
        /// <summary>
        /// Обработка нажатия кнопки "Создать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            bulldozer = new bulldozer(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.Blue,
           Color.Yellow, true);
            bulldozer.SetPosition(rnd.Next(10, 100), rnd.Next(10, 100), pictureBoxBulldozer.Width,
           pictureBoxBulldozer.Height);
            Draw();
        }
        /// <summary>
        /// Обработка нажатия кнопок управления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonMove_Click(object sender, EventArgs e)
        {
            //получаем имя кнопки
            string name = (sender as Button).Name;
            switch (name)
            {
                case "buttonUp":
                    bulldozer.MoveTransport(Direction.Up);
                    break;
                case "button1":
                    bulldozer.MoveTransport(Direction.Down);
                    break;
                case "buttonLeft":
                    bulldozer.MoveTransport(Direction.Left);
                    break;
                case "button2":
                    bulldozer.MoveTransport(Direction.Right);
                    break;
            }
            Draw();
        }
    }
}
