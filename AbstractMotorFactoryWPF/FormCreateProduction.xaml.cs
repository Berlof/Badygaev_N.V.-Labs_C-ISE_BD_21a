using AbstractMotorFactoryServiceDAL.BindingModels;
using AbstractMotorFactoryServiceDAL.Interfaces;
using AbstractMotorFactoryServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Unity;

namespace AbstractMotorFactoryWPF
{
    /// <summary>
    /// Логика взаимодействия для FormCreateProduction.xaml
    /// </summary>
    public partial class FormCreateProduction : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        private readonly ICustomerService serviceC;

        private readonly IEngineService serviceCF;

        private readonly ICoreService serviceM;


        public FormCreateProduction(ICustomerService serviceC, IEngineService serviceCF, ICoreService serviceM)
        {
            InitializeComponent();
            Loaded += FormCreateProduction_Load;
            comboBoxEngine.SelectionChanged += comboBoxEngine_SelectedIndexChanged;

            comboBoxEngine.SelectionChanged += new SelectionChangedEventHandler(comboBoxEngine_SelectedIndexChanged);
            this.serviceC = serviceC;
            this.serviceCF = serviceCF;
            this.serviceM = serviceM;
        }

        private void FormCreateProduction_Load(object sender, EventArgs e)
        {
            try
            {
                List<CustomerViewModel> listC = serviceC.GetList();
                if (listC != null)
                {
                    comboBoxCustomer.DisplayMemberPath = "CustomerFIO";
                    comboBoxCustomer.SelectedValuePath = "Id";
                    comboBoxCustomer.ItemsSource = listC;
                    comboBoxEngine.SelectedItem = null;
                }
                List<EngineViewModel> listCF = serviceCF.GetList();
                if (listCF != null)
                {
                    comboBoxEngine.DisplayMemberPath = "EngineName";
                    comboBoxEngine.SelectedValuePath = "Id";
                    comboBoxEngine.ItemsSource = listCF;
                    comboBoxEngine.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CalcSum()
        {
            if (comboBoxEngine.SelectedItem != null && !string.IsNullOrEmpty(textBoxCount.Text))
            {
                try
                {
                    int id = ((EngineViewModel)comboBoxEngine.SelectedItem).Id;
                    EngineViewModel product = serviceCF.GetElement(id);
                    int count = Convert.ToInt32(textBoxCount.Text);
                    textBoxSum.Text = (count * product.Cost).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void textBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void comboBoxEngine_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (comboBoxCustomer.SelectedItem == null)
            {
                MessageBox.Show("Выберите получателя", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (comboBoxEngine.SelectedItem == null)
            {
                MessageBox.Show("Выберите изделие", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                serviceM.CreateOrder(new ProductionBindingModel
                {
                    CustomerId = ((CustomerViewModel)comboBoxCustomer.SelectedItem).Id,
                    EngineId = ((EngineViewModel)comboBoxEngine.SelectedItem).Id,
                    Number = Convert.ToInt32(textBoxCount.Text),
                    Amount = Convert.ToInt32(textBoxSum.Text)
                });
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