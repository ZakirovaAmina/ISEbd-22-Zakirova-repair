using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutorepairShopContracts.BusinessLogicsContracts;
using AutorepairShopContracts.ViewModels;
using AutorepairShopContracts.BindingModels;

namespace AutorepairShopView
{
    public partial class FormStorehouseReplenishment : Form
    {
        private readonly IStorehouseLogic _logicStoreh;

        private readonly IComponentLogic _logicComp;
        public FormStorehouseReplenishment(IStorehouseLogic logicStoreh, IComponentLogic logicComp)
        {
            InitializeComponent();
            _logicStoreh = logicStoreh;
            _logicComp = logicComp;
        }

        private void FormStorehouseReplenishment_Load(object sender, EventArgs e)
        {
            try
            {
                List<StorehouseViewModel> listStorehouse = _logicStoreh.Read(null);
                if (listStorehouse != null)
                {
                    comboBox_Storehouse.DisplayMember = "StorehouseName";
                    comboBox_Storehouse.ValueMember = "Id";
                    comboBox_Storehouse.DataSource = listStorehouse;
                    comboBox_Storehouse.SelectedItem = null;
                }

                List<ComponentViewModel> listComponent = _logicComp.Read(null);
                if (listComponent != null)
                {
                    comboBox_Components.DisplayMember = "ComponentName";
                    comboBox_Components.ValueMember = "Id";
                    comboBox_Components.DataSource = listComponent;
                    comboBox_Components.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_Count.Text))
            {
                MessageBox.Show("Заполните поле количество", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBox_Components.SelectedValue == null)
            {
                MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            if (comboBox_Storehouse.SelectedValue == null)
            {
                MessageBox.Show("Выберите склад", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            try
            {
                List<ComponentViewModel> listComponent = _logicComp.Read(null);
                _logicStoreh.Replenishment(new StorehouseReplenishmentBindingModel
                {
                    StorehouseId = Convert.ToInt32(comboBox_Storehouse.SelectedValue),
                    ComponentId = listComponent[comboBox_Components.SelectedIndex].Id,
                    Count = Convert.ToInt32(textBox_Count.Text)
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
