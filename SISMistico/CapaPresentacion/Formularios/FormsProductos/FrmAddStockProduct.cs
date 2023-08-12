using CapaEntidades.Models;
using CapaNegocio;
using System;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios.FormsProductos
{
    public partial class FrmAddStockProduct : Form
    {
        public FrmAddStockProduct()
        {
            InitializeComponent();
            this.btnSave.Click += BtnSave_Click;
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.numericUpDown1.Value == 0)
                {
                    Mensajes.MensajeInformacion("La cantidad del Stock no puede ser 0");
                    return;
                }

                string type_medition = string.Empty;

                if (this.rdGramos.Checked)
                    type_medition = "GRAMOS";
                else if (this.rdMililitros.Checked)
                    type_medition = "MILILITROS";
                else
                    type_medition = "UNIDADES";

                decimal total_stock_product = 0;

                if (this.LastStock != null)
                    total_stock_product = this.LastStock.Total_stock + this.numericUpDown1.Value;
                else 
                    total_stock_product = this.numericUpDown1.Value;

                Stock_products stock = new Stock_products()
                {
                    Date_stock = DateTime.Now,
                    Hour_stock  = DateTime.Now.TimeOfDay,
                    Amount_stock = this.numericUpDown1.Value,
                    Id_product = this.ProductSelected.Id_producto,
                    Type_medition = type_medition,
                    Total_stock = total_stock_product,
                };

                string rpta = await NProductos.InsertStockProduct(stock);

                if (!rpta.Equals("OK"))
                    throw new Exception(rpta);

                Mensajes.MensajeOkForm("Stock del producto actualizado con éxito");

                this.OnProductSaveSuccess?.Invoke(stock, e);

                return;
            }
            catch (Exception ex)
            {
                Mensajes.MensajeInformacion(ex.Message);
            }
        }

        private Productos _product;
        private Stock_products _lastStock;

        public Productos ProductSelected { get => _product; set => _product = value; }
        public Stock_products LastStock 
        {
            get => _lastStock;
            set
            {
                _lastStock = value;

                if (value != null)
                {
                    this.gbMedidas.Enabled = false;
                    
                    if (value.Type_medition.Equals("GRAMOS"))
                        this.rdGramos.Checked = true;
                    else if (value.Type_medition.Equals("Mililitros"))
                        this.rdMililitros.Checked = true;
                    else
                        this.rdUnidades.Checked = true;
                }
            }
        }

        public event EventHandler OnProductSaveSuccess;
    }
}
