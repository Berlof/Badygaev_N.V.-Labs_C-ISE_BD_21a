using AbstractMotorFactoryServiceDAL.Interfaces;
using AbstractMotorFactoryServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;
using Unity;

namespace AbstractMotorFactoryWPF
{
    /// <summary>
    /// Логика взаимодействия для FormBlankCraft.xaml
    /// </summary>
    public partial class FormEngineDetail : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        public EngineDetailViewModel Model { set { model = value; } get { return model; } }

        private readonly IDetailService service;

        private EngineDetailViewModel model;

        public FormEngineDetail(IDetailService service)
        {
            InitializeComponent();
            Loaded += FormEngineDetail_Load;
            this.service = service;
        }

        private void FormEngineDetail_Load(object sender, EventArgs e)
        {
            List<DetailViewModel> list = service.GetList();
            try
            {
                if (list != null)
                {
                    comboBoxDetail.DisplayMemberPath = "DetailName";
                    comboBoxDetail.SelectedValuePath = "Id";
                    comboBoxDetail.ItemsSource = list;
                    comboBoxDetail.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (model != null)
            {
                comboBoxDetail.IsEnabled = false;
                foreach (DetailViewModel item in list)
                {
                    if (item.DetailName == model.DetailName)
                    {
                        comboBoxDetail.SelectedItem = item;
                    }
                }
                textBoxCount.Text = model.Number.ToString();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (comboBoxDetail.SelectedItem == null)
            {
                MessageBox.Show("Выберите заготовку", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                if (model == null)
                {
                    model = new EngineDetailViewModel
                    {
                        DetailId = Convert.ToInt32(comboBoxDetail.SelectedValue),
                        DetailName = comboBoxDetail.Text,
                        Number = Convert.ToInt32(textBoxCount.Text)
                    };
                }
                else
                {
                    model.Number = Convert.ToInt32(textBoxCount.Text);
                }
                MessageBox.Show("Сохранение прошло успешно", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}