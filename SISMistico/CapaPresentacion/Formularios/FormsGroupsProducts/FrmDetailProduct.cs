using CapaEntidades.Models;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios.FormsGroupsProducts
{
    public partial class FrmDetailProduct : Form
    {
        public FrmDetailProduct()
        {
            InitializeComponent();
            this.btnSave.Click += BtnSave_Click;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            this.OnBtnSaveClick?.Invoke(this, e);

            this.Close();
        }

        public event EventHandler OnBtnSaveClick;

        private Productos _productSelected;

        public Productos ProductSelected 
        {
            get => _productSelected;
            set
            {
                _productSelected = value;

                if (value.Last_stock != null)
                {
                    this.lblMedida.Text = value.Last_stock.Type_medition;
                }
                
            }
        }
    }
}
