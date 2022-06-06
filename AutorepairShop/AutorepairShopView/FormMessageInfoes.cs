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

namespace AutorepairShopView
{
    public partial class FormMessageInfoes : Form
    {

        private readonly IMessageInfoLogic logic;
        public FormMessageInfoes(IMessageInfoLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }
        private void LoadData()
        {
            try
            {
                Program.ConfigGrid(logic.Read(null), dataGridView);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FormMessageInfoes_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
