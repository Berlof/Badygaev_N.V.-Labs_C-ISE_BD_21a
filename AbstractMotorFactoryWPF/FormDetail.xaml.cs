using AbstractMotorFactoryServiceDAL.BindingModels;
using AbstractMotorFactoryServiceDAL.Interfaces;
using AbstractMotorFactoryServiceDAL.ViewModels;
using System;
using System.Windows;
using Unity;

namespace AbstractMotorFactoryWPF
{
    /// <summary>
    /// Логика взаимодействия для FormDetails.xaml
    /// </summary>
    public partial class FormDetail : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private readonly IDetailService service;

        private int? id;

        public FormDetail(IDetailService service)
        {
            InitializeComponent();
            Loaded += FormDetail_Load;
            this.service = service;
        }

        private void FormDetail_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    DetailViewModel view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        textBoxName.Text = view.DetailName;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                if (id.HasValue)
                {
                    service.UpdElement(new DetailBindingModel
                    {
                        Id = id.Value,
                        DetailName = textBoxName.Text
                    });
                }
                else
                {
                    service.AddElement(new DetailBindingModel
                    {
                        DetailName = textBoxName.Text
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