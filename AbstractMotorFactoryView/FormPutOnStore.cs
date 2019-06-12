using AbstractMotorFactoryServiceDAL.BindingModels;
using AbstractMotorFactoryServiceDAL.Interfaces;
using AbstractMotorFactoryServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AbstractMotorFactoryView
{
    public partial class FormPutOnStore : Form
    {
        public FormPutOnStore()
        {
            InitializeComponent();
        }

        private void FormPutOnStore_Load(object sender, EventArgs e)
        {
            try
            {
                List<DetailViewModel> listD = APIClient.GetRequest<List<DetailViewModel>>("api/Detail/GetList");
                if (listD != null)
                {
                    comboBoxDetail.DisplayMember = "DetailName";
                    comboBoxDetail.ValueMember = "Id";
                    comboBoxDetail.DataSource = listD;
                    comboBoxDetail.SelectedItem = null;
                }
                List<StoreViewModel> listS = APIClient.GetRequest<List<StoreViewModel>>("api/Store/GetList");
                if (listS != null)
                {
                    comboBoxStore.DisplayMember = "StoreName";
                    comboBoxStore.ValueMember = "Id";
                    comboBoxStore.DataSource = listS;
                    comboBoxStore.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxNum.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxDetail.SelectedValue == null)
            {
                MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxStore.SelectedValue == null)
            {
                MessageBox.Show("Выберите склад", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                APIClient.PostRequest<StoreDetailBindingModel, bool>("api/Core/PutDetailOnStore", new StoreDetailBindingModel
                {
                    DetailId = Convert.ToInt32(comboBoxDetail.SelectedValue),
                    StoreId = Convert.ToInt32(comboBoxStore.SelectedValue),
                    Number = Convert.ToInt32(textBoxNum.Text)
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
