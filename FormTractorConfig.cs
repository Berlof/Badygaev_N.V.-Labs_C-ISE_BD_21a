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
    public partial class FormTractorConfig : Form
    {
        /// <summary>
        /// Переменная-выбранная машина
        /// </summary>
        ITransport tractor = null;

        /// <summary>
        /// Событие
        /// </summary>
        private event tractorDelegate eventAddCar;

        public FormTractorConfig()
        {
            InitializeComponent();

            panelColor1.MouseDown += panelColor_MouseDown;
            panelColor2.MouseDown += panelColor_MouseDown;
            panelColor3.MouseDown += panelColor_MouseDown;
            panelColor4.MouseDown += panelColor_MouseDown;
            panelColor5.MouseDown += panelColor_MouseDown;
            panelColor6.MouseDown += panelColor_MouseDown;
            panelColor7.MouseDown += panelColor_MouseDown;
            panelColor8.MouseDown += panelColor_MouseDown;
            buttonClose.Click += (object sender, EventArgs e) => { Close(); };
        }

        /// <summary>
        /// Отрисовать машину
        /// </summary>
        private void DrawTractor()
        {
            if (tractor != null)
            {
                Bitmap bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
                Graphics gr = Graphics.FromImage(bmp);
                tractor.SetPosition(5, 5, pictureBox.Width, pictureBox.Height);
                tractor.DrawCar(gr);
                pictureBox.Image = bmp;
            }
        }

        /// <summary>
        /// Добавление события
        /// </summary>
        /// <param name="ev"></param>
        public void AddEvent(tractorDelegate ev)
        {
            if (eventAddCar == null)
            {
                eventAddCar = new tractorDelegate(ev);
            }
            else
            {
                eventAddCar += ev;
            }
        }

        /// <summary>
        /// Передаем информацию при нажатии на Label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelTractorBase_MouseDown(object sender, MouseEventArgs e)
        {
            labelTractorBase.DoDragDrop(labelTractorBase.Text, DragDropEffects.Move | DragDropEffects.Copy);
        }
        /// <summary>
        /// Передаем информацию при нажатии на Label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelTractor_MouseDown(object sender, MouseEventArgs e)
        {
            labelTractor.DoDragDrop(labelTractor.Text, DragDropEffects.Move | DragDropEffects.Copy);
        }
        /// <summary>
        /// Проверка получаемой информации (ее типа на соответствие требуемому)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelTractor_DragEnter(object sender, DragEventArgs e)
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
        /// <summary>
        /// Действия при приеме перетаскиваемой информации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelTractor_DragDrop(object sender, DragEventArgs e)
        {
            switch (e.Data.GetData(DataFormats.Text).ToString())
            {
                case "Трактор":
                    tractor = new Tractor(100, 500, Color.White);
                    break;
                case "Бульдозер":
                    tractor = new bulldozer(100, 500, Color.White, Color.Black, true);
                    break;
            }
            DrawTractor();
        }

        /// <summary>
        /// Отправляем цвет с панели
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelColor_MouseDown(object sender, MouseEventArgs e)
        {
            (sender as Control).DoDragDrop((sender as Control).BackColor, DragDropEffects.Move | DragDropEffects.Copy);
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
            if (tractor != null)
            {
                tractor.SetMainColor((Color)e.Data.GetData(typeof(Color)));
                DrawTractor();
            }
        }
        /// <summary>
        /// Принимаем дополнительный цвет
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelDopColor_DragDrop(object sender, DragEventArgs e)
        {
            if (tractor != null)
            {
                if (tractor is bulldozer)
                {
                    (tractor as bulldozer).SetDopColor((Color)e.Data.GetData(typeof(Color)));
                    DrawTractor();
                }
            }
        }
        /// <summary>
        /// Добавление машины
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            eventAddCar?.Invoke(tractor);
            Close();
        }
    }
}