using CapaEntidades.Models;
using CapaNegocio;
using CapaPresentacion.Formularios.FormsProductos;
using System;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios.FormsNovedades
{
    public partial class FrmAddNovedad : Form
    {
        public FrmAddNovedad()
        {
            InitializeComponent();
            this.btnSelectProduct.Click += BtnSelectProduct_Click;
            this.btnSave.Click += BtnSave_Click;
            this.btnCancelar.Click += BtnCancelar_Click;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
           this.Close();
        }
        private async void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ProductSelected == null)
                {
                    Mensajes.MensajeInformacion("Debe seleccionar un producto");
                    return;
                }

                if (this.ProductSelected .Id_producto == 0)
                {
                    Mensajes.MensajeInformacion("Debe seleccionar un producto");
                    return;
                }

                if (string.IsNullOrEmpty(this.txtNovedad.Text))
                {
                    Mensajes.MensajeInformacion("Debe escribir una descripción de la novedad");
                    return;
                }

                DatosInicioSesion datos = DatosInicioSesion.GetInstancia();

                Novedades novedad = new Novedades()
                {
                    Fecha_novedad = DateTime.Now,
                    Hora_novedad = DateTime.Now.TimeOfDay,
                    Cantidad_novedad = this.numericCantidad.Value,
                    Descripcion_novedad = this.txtNovedad.Text,
                    Estado_novedad = "TERMINADO",
                    Id_producto = this.ProductSelected.Id_producto,
                    Producto = this.ProductSelected,
                    Tipo_novedad = "DESCUENTO STOCK",
                    Id_turno = datos.Turno.Id_turno,
                    Turno = datos.Turno,
                };

                string rpta = await NNovedades.InsertarNovedad(novedad);

                if (!rpta.Equals("OK"))
                    throw new Exception(rpta);

                Mensajes.MensajeOkForm("Se guardó la novedad correctamente");

                this.OnNovedadSuccess?.Invoke(novedad, e);

                this.Close();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorForm(ex.Message);
            }
        }
        private void BtnSelectProduct_Click(object sender, EventArgs e)
        {
            FrmObservarProductos frmObservarProductos = new FrmObservarProductos()
            {
                WindowState = FormWindowState.Maximized
            };
            frmObservarProductos.OnBtnProductSelected += FrmObservarProductos_OnBtnProductSelected;
            frmObservarProductos.ShowDialog();
        }
        private void FrmObservarProductos_OnBtnProductSelected(object sender, EventArgs e)
        {
            Productos producto = (Productos)sender;

            this.ProductSelected = producto;

            this.btnSelectProduct.Text = producto.Nombre_producto;
        }

        private Productos _productSelected;
        private Novedades _novedad;
        public Novedades Novedad
        { 
            get => _novedad;
            set
            {
                _novedad = value;
                this.AsignarDatos(value);
            }
        }
        public Productos ProductSelected { get => _productSelected; set => _productSelected = value; }

        private void AsignarDatos(Novedades novedad)
        {
            this.ProductSelected = novedad.Producto;
            this.btnSelectProduct.Text = novedad.Producto.Nombre_producto;

            this.txtNovedad.Text = novedad.Descripcion_novedad;

            this.numericCantidad.Value = novedad.Cantidad_novedad;
        }

        public event EventHandler OnNovedadSuccess;
    }
}
