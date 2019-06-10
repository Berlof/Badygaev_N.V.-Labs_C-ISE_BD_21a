using AbstractMotorFactoryServiceDAL.BindingModels;
using AbstractMotorFactoryServiceDAL.Interfaces;
using AbstractMotorFactoryServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;
using Unity;

namespace AbstractMotorFactoryWPF
{
    /// <summary>
    /// Логика взаимодействия для PutOnStore.xaml
    /// </summary>
    public partial class FormPutOnStore : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        private readonly IStoreService serviceS;

        private readonly IDetailService serviceI;

        private readonly ICoreService serviceM;

        public FormPutOnStore(IStoreService serviceS, IDetailService serviceI, ICoreService serviceM)
        {
            InitializeComponent();
            Loaded += FormPutOnStore_Load;
            this.serviceS = serviceS;
            this.serviceI = serviceI;
            this.serviceM = serviceM;
        }

        private void FormPutOnStore_Load(object sender, EventArgs e)
        {
            try
            {
                List<DetailViewModel> listI = serviceI.GetList();
                if (listI != null)
                {
                    comboBoxDetail.DisplayMemberPath = "DetailName";
                    comboBoxDetail.SelectedValuePath = "Id";
                    comboBoxDetail.ItemsSource = listI;
                    comboBoxDetail.SelectedItem = null;
                }
                List<StoreViewModel> listS = serviceS.GetList();
                if (listS != null)
                {
                    comboBoxStore.DisplayMemberPath = "StoreName";
                    comboBoxStore.SelectedValuePath = "Id";
                    comboBoxStore.ItemsSource = listS;
                    comboBoxStore.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
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
            if (comboBoxStore.SelectedItem == null)
            {
                MessageBox.Show("Выберите базу", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                serviceM.PutDetailOnStore(new StoreDetailBindingModel
                {
                    DetailId = Convert.ToInt32(comboBoxDetail.SelectedValue),
                    StoreId = Convert.ToInt32(comboBoxStore.SelectedValue),
                    Number = Convert.ToInt32(textBoxCount.Text)
                });
                MessageBox.Show("Сохранение прошло успешно", "Информация",
                    MessageBoxButton.OK, MessageBoxImage.Information);
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
