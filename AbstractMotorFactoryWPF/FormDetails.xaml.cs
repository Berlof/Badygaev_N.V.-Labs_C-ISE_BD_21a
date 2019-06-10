using AbstractMotorFactoryServiceDAL.Interfaces;
using AbstractMotorFactoryServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Unity;

namespace AbstractMotorFactoryWPF
{
    /// <summary>
    /// Логика взаимодействия для FormDetails.xaml
    /// </summary>
    public partial class FormDetails : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        private readonly IDetailService service;

        public FormDetails(IDetailService service)
        {
            InitializeComponent();
            Loaded += FormDetails_Load;
            this.service = service;
        }

        private void FormDetails_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                List<DetailViewModel> list = service.GetList();
                if (list != null)
                {
                    dataGridViewDetails.ItemsSource = list;
                    dataGridViewDetails.Columns[0].Visibility = Visibility.Hidden;
                    dataGridViewDetails.Columns[1].Width = DataGridLength.Auto;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormDetail>();
            if (form.ShowDialog() == true)
                LoadData();
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridViewDetails.SelectedItem != null)
            {
                var form = Container.Resolve<FormDetail>();
                form.Id = ((DetailViewModel)dataGridViewDetails.SelectedItem).Id;
                if (form.ShowDialog() == true)
                    LoadData();
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridViewDetails.SelectedItem != null)
            {
                if (MessageBox.Show("Удалить запись?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    int id = ((DetailViewModel)dataGridViewDetails.SelectedItem).Id;
                    try
                    {
                        service.DelElement(id);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}