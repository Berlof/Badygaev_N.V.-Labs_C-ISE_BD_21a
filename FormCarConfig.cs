using System;
using System.Drawing;
using System.Windows.Forms;
using lab1;
using WindowsFormsCars;

namespace lab1
{
    public partial class FormCarConfig : Form
    {
        /// <summary>
        /// Переменная-выбранная машина
        /// </summary>
        Itrandport car = null;
        private event carDelegate eventAddCar;
        public FormCarConfig()
        {
            InitializeComponent();
            panelBlack.MouseDown += panelColor_MouseDown;
            panel7.MouseDown += panelColor_MouseDown;
            panel8.MouseDown += panelColor_MouseDown;
            panelGrean.MouseDown += panelColor_MouseDown;
            panelRed.MouseDown += panelColor_MouseDown;
            panelW.MouseDown += panelColor_MouseDown;
            panelYellow.MouseDown += panelColor_MouseDown;
            panelBlue.MouseDown += panelColor_MouseDown;
            button2.Click += (object sender, EventArgs e) => { Close(); };
        }

        
        private void DrawCar()
        {
            if (car != null)
            {
                Bitmap bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
                Graphics gr = Graphics.FromImage(bmp);
                car.SetPosition(5, 5, pictureBox.Width, pictureBox.Height);
                car.DrawCar(gr);
                pictureBox.Image = bmp;
            }
        }
        /// <summary>
        /// Добавление события
        /// </summary>
        /// <param name="ev"></param>
        public void AddEvent(carDelegate ev)
        {
            if (eventAddCar == null)
            {
                eventAddCar = new carDelegate(ev);
            }
            else
            {
                eventAddCar += ev;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void labelCar_MouseDown(object sender, MouseEventArgs e)
        {
            labelCar.DoDragDrop(labelCar.Text, DragDropEffects.Move | DragDropEffects.Copy);
        }

        private void panelCar_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void panelCar_DragDrop(object sender, DragEventArgs e)
        {
            switch (e.Data.GetData(DataFormats.Text).ToString())
            {
                case "Трактор":
                    car = new Car(100, 500, Color.White);
                    break;
                case "Бульдозер":
                    car = new bulldozer(100, 500, Color.Yellow, Color.Black, true);
                    break;
            }
            DrawCar();
        }
        /// <summary>
        /// Проверка получаемой информации (ее типа на соответствие требуемому)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelBaseColor_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Color)))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        /// <summary>
        /// Принимаем основной цвет
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelBaseColor_DragDrop(object sender, DragEventArgs e)
        {
            if (car != null)
            {
                car.SetMainColor((Color)e.Data.GetData(typeof(Color)));
                DrawCar();
            }
        }
        private void labelBuldozer_MouseDown(object sender, MouseEventArgs e)
        {
            labelBuldozer.DoDragDrop(labelBuldozer.Text, DragDropEffects.Move | DragDropEffects.Copy);

        }
        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void panelColor_MouseDown(object sender, MouseEventArgs e)
        {
            (sender as Control).DoDragDrop((sender as Control).BackColor, DragDropEffects.Move | DragDropEffects.Copy);
        }
        private void labelDopColor_DragDrop(object sender, DragEventArgs e)
        {

        }
        //Добавление машины
        private void button1_Click(object sender, EventArgs e)
        {
            eventAddCar?.Invoke(car);
            Close();
        }
        private void labelDopColor_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Color)))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
    }
}
