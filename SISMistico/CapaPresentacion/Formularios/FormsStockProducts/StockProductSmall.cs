using CapaEntidades.Models;
using System;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios.FormsStockProducts
{
    public partial class StockProductSmall : UserControl
    {
        public StockProductSmall()
        {
            InitializeComponent();
        }

        private void AsignarDatos(Stock_products stockProduct)
        {
            DateTime dateEdit =  stockProduct.Date_stock.Add(stockProduct.Hour_stock);

            this.txtFechaHora.Text = $"{stockProduct.Date_stock:dd-MM-yyyy} | {dateEdit:hh:mm tt}";
            this.txtCantidad.Text = $"{stockProduct.Amount_stock:N2}";
            this.txtMedicion.Text = $"{stockProduct.Type_medition}";
        }

        private Stock_products _stockProduct;
        public Stock_products StockProduct 
        {
            get => _stockProduct;
            set 
            { 
                _stockProduct = value;
                this.AsignarDatos(value);
            }
        }
    }
}
