using AbstractMotorFactoryServiceDAL.BindingModels;
using AbstractMotorFactoryServiceDAL.Interfaces;
using AbstractMotorFactoryServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using Unity;

namespace AbstractMotorFactoryWPF
{
    /// <summary>
    /// Логика взаимодействия для FormEngine.xaml
    /// </summary>
    public partial class FormEngine : Window
    {
        [Unity.Dependency]

        public IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private readonly IEngineService service;

        private int? id;

        private List<EngineDetailViewModel> EngineDetail;

        public FormEngine(IEngineService service)
        {
            InitializeComponent();
            Loaded += FormEngine_Load;
            this.service = service;
        }

        private void FormEngine_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    EngineViewModel view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        textBoxName.Text = view.EngineName;
                        textBoxCost.Text = view.Cost.ToString();
                        EngineDetail = view.EngineDetails;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
                EngineDetail = new List<EngineDetailViewModel>();
        }

        private void LoadData()
        {
            try
            {
                if (EngineDetail != null)
                {
                    dataGridView.ItemsSource = null;
                    dataGridView.ItemsSource = EngineDetail;
                    dataGridView.Columns[0].Visibility = Visibility.Hidden;
                    dataGridView.Columns[1].Visibility = Visibility.Hidden;
                    dataGridView.Columns[2].Visibility = Visibility.Hidden;
                    dataGridView.Columns[3].Width = DataGridLength.Auto;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormEngineDetail>();
            if (form.ShowDialog() == true)
            {
                if (form.Model != null)
                {
                    if (id.HasValue)
                        form.Model.EngineId = id.Value;
                    EngineDetail.Add(form.Model);
                }
                LoadData();
            }
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedItem != null)
            {
                var form = Container.Resolve<FormEngineDetail>();
                form.Model = EngineDetail[dataGridView.SelectedIndex];
                if (form.ShowDialog() == true)
                {
                    EngineDetail[dataGridView.SelectedIndex] = form.Model;
                    LoadData();
                }
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedItem != null)
            {
                if (MessageBox.Show("Удалить запись?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        EngineDetail.RemoveAt(dataGridView.SelectedIndex);
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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxCost.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (EngineDetail == null || EngineDetail.Count == 0)
            {
                MessageBox.Show("Заполните заготовки", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                List<EngineDetailBindingModel> canFoodDetailBM = new List<EngineDetailBindingModel>();
                for (int i = 0; i < EngineDetail.Count; ++i)
                {
                    canFoodDetailBM.Add(new EngineDetailBindingModel
                    {
                        Id = EngineDetail[i].Id,
                        EngineId = EngineDetail[i].EngineId,
                        DetailId = EngineDetail[i].DetailId,
                        Number= EngineDetail[i].Number
                    });
                }
                if (id.HasValue)
                {
                    service.UpdElement(new EngineBindingModel
                    {
                        Id = id.Value,
                        EngineName = textBoxName.Text,
                        Cost = Convert.ToInt32(textBoxCost.Text),
                        EngineDetails = canFoodDetailBM
                    });
                }
                else
                {
                    service.AddElement(new EngineBindingModel
                    {
                        EngineName = textBoxName.Text,
                        Cost = Convert.ToInt32(textBoxCost.Text),
                        EngineDetails = canFoodDetailBM
                    });
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