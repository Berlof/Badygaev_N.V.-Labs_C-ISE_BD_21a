using lab1;
using System;
using System.Drawing;
using System.Windows.Forms;
namespace WindowsFormsCars
{
    public partial class FormParking : Form
    {
        /// <summary>
        /// Объект от класса-парковки
        /// </summary>
        Parking<Itrandport> parking;
        public FormParking()
        {
            InitializeComponent();
            parking = new Parking<Itrandport>(20, pictureBoxParking.Width,
           pictureBoxParking.Height);
            Draw();
        }
        /// <summary>
        /// Метод отрисовки парковки
        /// </summary>
        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxParking.Width, pictureBoxParking.Height);
            Graphics gr = Graphics.FromImage(bmp);
            parking.Draw(gr);
            pictureBoxParking.Image = bmp;
        }
        /// <summary>
        /// Обработка нажатия кнопки "Припарковать автомобиль"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
  

                private void buttonSetCar_Click(object sender, EventArgs e)
                {
                    
                }        
        /// <summary>
        /// Обработка нажатия кнопки "Забрать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTakeCar_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var car = new Car(100, 1000, dialog.Color);
                int place = parking + car;
                Draw();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ColorDialog dialogDop = new ColorDialog();
                if (dialogDop.ShowDialog() == DialogResult.OK)
                {
                    var car = new bulldozer(100, 1000, dialog.Color, dialogDop.Color,
                   true);
                    int place = parking + car;
                    Draw();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (maskedTextBox.Text != "")
            {
                var car = parking - Convert.ToInt32(maskedTextBox.Text);
                if (car != null)
                {
                    Bitmap bmp = new Bitmap(pictureBoxTakeCar.Width,
                   pictureBoxTakeCar.Height);
                    Graphics gr = Graphics.FromImage(bmp);
                    car.SetPosition(5, 5, pictureBoxTakeCar.Width,
                   pictureBoxTakeCar.Height);
                    car.DrawCar(gr);
                    pictureBoxTakeCar.Image = bmp;
                }
                else
                {
                    Bitmap bmp = new Bitmap(pictureBoxTakeCar.Width,
                   pictureBoxTakeCar.Height);
                    pictureBoxTakeCar.Image = bmp;
                }
                Draw();
            }
        }
    }
}