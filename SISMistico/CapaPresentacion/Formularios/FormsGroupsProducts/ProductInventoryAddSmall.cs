using CapaEntidades.Models;
using System;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios.FormsGroupsProducts
{
    public partial class ProductInventoryAddSmall : UserControl
    {
        public ProductInventoryAddSmall()
        {
            InitializeComponent();
            this.btnDelete.Click += BtnDelete_Click;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            this.OnBtnRemoveClick?.Invoke(this.DetailProduct, e);
        }

        private Detail_products _detailProduct;

        public Detail_products DetailProduct 
        { 
            get => _detailProduct;
            set
            {
                _detailProduct = value;
                this.AsignarDatos(value);
            }
        }

        private void AsignarDatos(Detail_products detail)
        {
            this.txtInfo.Text = $"{detail.Product.Nombre_producto} | Cantidad {detail.Amount_product:N} {detail.Medition_product}";
        }

        public event EventHandler OnBtnRemoveClick;
    }
}
