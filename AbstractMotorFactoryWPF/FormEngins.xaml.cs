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
    /// Логика взаимодействия для FormEngines.xaml
    /// </summary>
    public partial class FormEngines : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        private readonly IEngineService service;

        public FormEngines(IEngineService service)
        {
            InitializeComponent();
            Loaded += FormEngines_Load;
            this.service = service;
        }

        private void FormEngines_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                List<EngineViewModel> list = service.GetList();
                if (list != null)
                {
                    dataGridViewEngines.ItemsSource = list;
                    dataGridViewEngines.Columns[0].Visibility = Visibility.Hidden;
                    dataGridViewEngines.Columns[1].Width = DataGridLength.Auto;
                    dataGridViewEngines.Columns[3].Visibility = Visibility.Hidden;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormEngine>();
            if (form.ShowDialog() == true)
                LoadData();
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridViewEngines.SelectedItem != null)
            {
                var form = Container.Resolve<FormEngine>();
                form.Id = ((EngineViewModel)dataGridViewEngines.SelectedItem).Id;
                if (form.ShowDialog() == true)
                    LoadData();
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridViewEngines.SelectedItem != null)
            {
                if (MessageBox.Show("Удалить запись?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {

                    int id = ((EngineViewModel)dataGridViewEngines.SelectedItem).Id;
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