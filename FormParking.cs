using lab1;
using NLog;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsCars

{
    public partial class FormParking : Form
    {/// <summary>
     /// Объект от класса многоуровневой парковки
     /// </summary>
        MultiLevelParking parking;
        /// <summary>
        /// Форма для добавления
        /// </summary>
        FormCarConfig form;
        /// <summary>
        /// Количество уровней-парковок
        /// </summary>
        /// 
        private const int countLevel = 5;
        /// <summary>
        /// Логгер
        /// </summary>
        private Logger logger;

        public FormParking()
        {
            InitializeComponent();
            logger = LogManager.GetCurrentClassLogger();
            parking = new MultiLevelParking(countLevel, pictureBoxParking.Width,
           pictureBoxParking.Height);
            //заполнение listBox
            for (int i = 0; i < countLevel; i++)
            {
                listBoxLevels.Items.Add("Уровень " + (i + 1));
            }
            listBoxLevels.SelectedIndex = 0;
        }
        private void Draw()
        {
            if (listBoxLevels.SelectedIndex > -1)
            {
                Bitmap bmp = new Bitmap(pictureBoxParking.Width, pictureBoxParking.Height);
                Graphics gr = Graphics.FromImage(bmp);
                parking[listBoxLevels.SelectedIndex].Draw(gr);
                pictureBoxParking.Image = bmp;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (listBoxLevels.SelectedIndex > -1)
            {
                ColorDialog dialog = new ColorDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var car = new Car(100, 1000, dialog.Color);
                    int place = parking[listBoxLevels.SelectedIndex] + car;
                    if (place == -1)
                    {
                        MessageBox.Show("Нет свободных мест", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Draw();
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (listBoxLevels.SelectedIndex > -1)
            {
                ColorDialog dialog = new ColorDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    ColorDialog dialogDop = new ColorDialog();
                    if (dialogDop.ShowDialog() == DialogResult.OK)
                    {
                        var car = new bulldozer(100, 1000, dialog.Color, dialogDop.Color, true);
                        int place = parking[listBoxLevels.SelectedIndex] + car;
                        if (place == -1)
                        {
                            MessageBox.Show("Нет свободных мест", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        Draw();
                    }
                }
            }
        }
        // Забрать
        private void button3_Click(object sender, EventArgs e)
        {
                if (listBoxLevels.SelectedIndex > -1)
                {
                    if (maskedTextBox.Text != "")
                    {
                        try
                        {
                            var car = parking[listBoxLevels.SelectedIndex] -
                           Convert.ToInt32(maskedTextBox.Text);
                            Bitmap bmp = new Bitmap(pictureBoxTakeCar.Width, pictureBoxTakeCar.Height);
                            Graphics gr = Graphics.FromImage(bmp);
                            car.SetPosition(5, 5, pictureBoxTakeCar.Width, pictureBoxTakeCar.Height);
                            car.DrawCar(gr);
                            pictureBoxTakeCar.Image = bmp;
                            logger.Info("Изъят автомобиль " + car.ToString() + " с места " + maskedTextBox.Text);
                            Draw();
                        }
                        catch (ParkingNotFoundException ex)
                        {
                            MessageBox.Show(ex.Message, "Не найдено", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Bitmap bmp = new Bitmap(pictureBoxTakeCar.Width, pictureBoxTakeCar.Height);
                            pictureBoxTakeCar.Image = bmp;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Неизвестная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }   
        }
            /// <summary>
            /// Метод обработки выбора элемента на listBoxs
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
        private void listBoxLevels_SelectedIndexChanged(object sender, EventArgs e)
        {
            Draw();
        }

        private void listBoxLevels_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Draw();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            form = new FormCarConfig();
            form.AddEvent(AddCar);
            form.Show();
        }
        private void AddCar(Itrandport car)
        {
            if (car != null && listBoxLevels.SelectedIndex > -1)
            {
                try
                {
                    int place = parking[listBoxLevels.SelectedIndex] + car;
                    logger.Info("Добавлен автомобиль " + car.ToString() + " на место " + place);
                    Draw();
                }
                catch (ParkingOverflowException ex)
                {
                    MessageBox.Show(ex.Message, "Переполнение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (ParkingAlreadyHaveException ex)
                {
                    MessageBox.Show(ex.Message, "Дублирование", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Неизвестная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// Обработка нажатия пункта меню "Сохранить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    parking.SaveData(saveFileDialog.FileName);
                    MessageBox.Show("Сохранение прошло успешно", "Результат",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    logger.Info("Сохранено в файл " + saveFileDialog.FileName);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Неизвестная ошибка при сохранении",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// Обработка нажатия пункта меню "Загрузить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    parking.LoadData(openFileDialog.FileName);
                    MessageBox.Show("Загрузили", "Результат", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    logger.Info("Загружено из файла " + openFileDialog.FileName);
                }
                catch (ParkingOccupiedPlaceException ex)
                {
                    MessageBox.Show(ex.Message, "Занятое место", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Неизвестная ошибка при сохранении",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Draw();
            }
        }
        /// <summary>
        /// Обработка нажатия кнопки "Сортировка"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSort_Click(object sender, EventArgs e)
        {
            parking.Sort();
            Draw();
            logger.Info("Сортировка уровней");
        }
    }
}