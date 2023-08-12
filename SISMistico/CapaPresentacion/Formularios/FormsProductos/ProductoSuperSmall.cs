using CapaEntidades.Models;
using System;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios.FormsProductos
{
    public partial class ProductoSuperSmall : UserControl
    {
        public ProductoSuperSmall()
        {
            InitializeComponent();
            this.btnNext.Click += BtnNext_Click;
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            this.OnBtnNextClick?.Invoke(this.ProductSelected, e);
        }

        public event EventHandler OnBtnNextClick;

        private Productos _productSelected;

        public Productos ProductSelected
        {
            get => _productSelected;
            set
            {
                _productSelected = value;

                if (value.Last_stock != null)
                    this.txtInformacion.Text = $"{value.Nombre_producto} | {value.Last_stock.Amount_stock} {value.Last_stock.Type_medition} ";
                else
                    this.txtInformacion.Text = $"{value.Nombre_producto} | 0";

                this.pxImagen.Image = Imagenes.ObtenerImagen("RUTAIMAGES",
                value.Imagen_producto, out string ruta_destino);
            }
        }
    }
}
