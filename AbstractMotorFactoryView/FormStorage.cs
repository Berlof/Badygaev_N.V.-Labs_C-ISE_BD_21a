using AbstractMotorFactoryServiceDAL.BindingModels;
using AbstractMotorFactoryServiceDAL.Interfaces;
using AbstractMotorFactoryServiceDAL.ViewModels;
using System;
using System.Windows.Forms;

namespace AbstractMotorFactoryView
{
    public partial class FormStore : Form
    {
        public int Id { set { id = value; } }

        private int? id;

        public FormStore()
        {
            InitializeComponent();
        }

        private void FormStore_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    StoreViewModel view = APIClient.GetRequest<StoreViewModel>("api/Store/Get/" + id.Value);
                    if (view != null)
                    {
                        textBox1.Text = view.StoreName;
                        dataGridView1.DataSource = view.StoreDetails;
                        dataGridView1.Columns[0].Visible = false;
                        dataGridView1.Columns[1].Visible = false;
                        dataGridView1.Columns[2].Visible = false;
                        dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (id.HasValue)
                {
                    APIClient.PostRequest<StoreBindingModel, bool>("api/Store/UpdElement", new StoreBindingModel
                    {
                        Id = id.Value,
                        StoreName = textBox1.Text
                    });
                }
                else
                {
                    APIClient.PostRequest<StoreBindingModel, bool>("api/Store/AddElement", new StoreBindingModel
                    {
                        StoreName = textBox1.Text
                    });
                }
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
