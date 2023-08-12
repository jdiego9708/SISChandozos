using CapaEntidades.Models;
using CapaPresentacion.Formularios.FormsGroupsProducts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios.FormsProductos
{
    public partial class ProductoSmall : UserControl
    {
        public ProductoSmall()
        {
            InitializeComponent();
            this.btnEditar.Click += BtnEditar_Click;
            this.btnNext.Click += BtnNext_Click;
            this.btnAddDetailProduct.Click += BtnAddDetailProduct_Click;
        }

        private void BtnAddDetailProduct_Click(object sender, EventArgs e)
        {
            this.OnBtnAddGroupClick?.Invoke(this.Producto, e);
        }

        public event EventHandler OnBtnNextClick;
        public event EventHandler OnBtnEditarClick;
        public event EventHandler OnBtnAddGroupClick;

        private void BtnNext_Click(object sender, EventArgs e)
        {
            this.OnBtnNextClick?.Invoke(this.Producto, e);
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            this.OnBtnEditarClick?.Invoke(this.Producto, e);
        }

        private void ObtenerStockProducto()
        {

        }
        private void AsignarDatos(Productos producto)
        {
            this.txtNombre.Text = producto.Nombre_producto;
            //this.txtTipo.Text = producto.Tipo_producto.Nombre_tipo;

            this.pxImagen.Image = Imagenes.ObtenerImagen("RUTAIMAGES", 
                producto.Imagen_producto, out string ruta_destino);
          
            StringBuilder info = new StringBuilder();

            info.Append($"Precio: {producto.Precio_producto:C}");

            if (!string.IsNullOrEmpty(producto.Descripcion_producto))
                info.Append($" | {producto.Descripcion_producto} | "); 

            this.txtInformacion.Text = info.ToString();

            if (producto.Last_stock != null)
            {
                this.txtStock.Text = producto.Last_stock.Total_stock.ToString("N") + $" {producto.Last_stock.Type_medition}";
            }              
            else
                this.txtStock.Text = "0";
        }

        private Productos _producto;
        public Productos Producto
        {
            get => _producto;
            set
            {
                _producto = value;
                this.AsignarDatos(value);
            }
        }
    }
}
