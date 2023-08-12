using CapaEntidades.BindingModels;
using CapaEntidades.Models;
using CapaNegocio;
using CapaPresentacion.Formularios.FormsPedido;
using CapaPresentacion.Formularios.FormsProductos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Animation;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace CapaPresentacion.Formularios.FormsGroupsProducts
{
    public partial class FrmAddGroupProduct : Form
    {
        public FrmAddGroupProduct()
        {
            InitializeComponent();
            this.Load += FrmAddGroupProduct_Load;
            this.btnSave.Click += BtnSave_Click;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            this.SaveDetails();
        }

        private void FrmAddGroupProduct_Load(object sender, EventArgs e)
        {
            this.LoadCategorias("CATALOGO PADRE", "TIPOS DE PRODUCTOS");


            //if (this.Categorias != null)
            //{
            //    Catalogo TipoDefault = this.Categorias[0];

            //    if (TipoDefault == null)
            //        return;

            //    this.BuscarProductos("ID TIPO PRODUCTO INVENTARIO", TipoDefault.Id_tipo.ToString());
            //}
        }
        public void BuscarProductos(List<Productos> products)
        {
            try
            {
                this.panelProductos.clearDataSource();

                List<UserControl> controls = new List<UserControl>();

                List<FormsProductos.ProductoSuperSmall> controlsCustom = new List<FormsProductos.ProductoSuperSmall>();

                foreach (Productos producto in products)
                {
                    FormsProductos.ProductoSuperSmall productoSmall = new FormsProductos.ProductoSuperSmall()
                    {
                        ProductSelected = producto,
                    };
                    productoSmall.OnBtnNextClick += ProductoSmall_OnBtnNextClick;
                    controls.Add(productoSmall);
                    controlsCustom.Add(productoSmall);
                }

                if (controls.Count < 1)
                {
                    this.panelProductos.BackgroundImage = Properties.Resources.No_hay_productos;
                    return;
                }

                this.ControlsCustom = controlsCustom;

                this.panelProductos.BackgroundImage = null;
                //this.panelProductos.AddArrayControl(controls);
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BuscarProductos",
                    "Hubo un error con la tabla de datos", ex.Message);
            }
        }
        private void BuscarProductos(string tipo_busqueda, string texto_busqueda)
        {
            try
            {
                this.panelProductos.clearDataSource();

                var result = NProductos.BuscarProductos(tipo_busqueda, texto_busqueda);

                DataTable dtProductos = result.Result.dt;

                if (dtProductos == null)
                {
                    this.panelProductos.BackgroundImage = Properties.Resources.No_hay_productos;
                    return;
                }

                if (dtProductos.Rows.Count < 1)
                {
                    this.panelProductos.BackgroundImage = Properties.Resources.No_hay_productos;
                    return;
                }

                List<UserControl> controls = new List<UserControl>();
                foreach (DataRow row in dtProductos.Rows)
                {
                    Productos producto = new Productos(row);

                    FormsProductos.ProductoSuperSmall productoSmall = new FormsProductos.ProductoSuperSmall()
                    {
                        ProductSelected = producto,
                    };
                    productoSmall.OnBtnNextClick += ProductoSmall_OnBtnNextClick;
                    controls.Add(productoSmall);
                }

                if (controls.Count < 1)
                {
                    this.panelProductos.BackgroundImage = Properties.Resources.No_hay_productos;
                    return;
                }

                this.panelProductos.BackgroundImage = null;
                this.panelProductos.AddArrayControl(controls);
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BuscarProductos",
                    "Hubo un error con la tabla de datos", ex.Message);
            }
        }
        private void ProductoSmall_OnBtnEditarClick(object sender, EventArgs e)
        {
            Productos producto = (Productos)sender;

            FrmAgregarProducto frmEditarProducto = new FrmAgregarProducto()
            {
                StartPosition = FormStartPosition.CenterScreen,
                MinimizeBox = false,
                MaximizeBox = false,
                Producto = producto,
            };
            frmEditarProducto.ShowDialog();
        }
        private void ProductoSmall_OnBtnNextClick(object sender, EventArgs e)
        {
            Productos producto = (Productos)sender;

            FrmDetailProduct frmDetail = new FrmDetailProduct()
            {
                StartPosition = FormStartPosition.CenterScreen,
                MinimizeBox = false,
                MaximizeBox = false,
                ProductSelected = producto,
            };
            frmDetail.OnBtnSaveClick += FrmDetail_OnBtnSaveClick;
            frmDetail.ShowDialog();
        }
        private void FrmDetail_OnBtnSaveClick(object sender, EventArgs e)
        {
            FrmDetailProduct frmDetail = (FrmDetailProduct)sender;

            if (this.DetailProductsAdd == null)
                this.DetailProductsAdd = new List<Detail_products>();

            Productos product = frmDetail.ProductSelected;

            decimal amount = frmDetail.numericAmount.Value;

            Detail_products detail = new Detail_products()
            {
                Product = product,
                Id_product = this.ProductSelected.Id_producto,
                Id_product_reference = product.Id_producto,
                Amount_product = amount,
                Medition_product = product.Last_stock == null ? "UNIDADES" : product.Last_stock.Type_medition,
            };

            this.DetailProductsAdd.Add(detail);

            this.panelProductsAdd.clearDataSource();

            var listCustomControls = (from Detail_products de in this.DetailProductsAdd
                                select new ProductInventoryAddSmall()
                                {
                                    DetailProduct = de,
                                }).ToList();

            var listUsersControls = listCustomControls.Cast<UserControl>().ToList();

            this.panelProductsAdd.AddArrayControl(listUsersControls);
        }
        private void SaveDetails()
        {
            try
            {
                if (this.DetailProductsAdd == null)
                {
                    Mensajes.MensajeInformacion("No hay detalles para guardar");
                    return;
                }

                if (this.DetailProductsAdd.Count < 1)
                {
                    Mensajes.MensajeInformacion("No hay detalles para guardar");
                    return;
                }

                this.DetailProductsAdd.ForEach(x => NProductos.InsertDetailProduct(x));

                Mensajes.MensajeOkForm("Se adicionaron los detalles al producto correctamente, ahora cuando haga una venta se descontará las cantidades del stock!");

                this.OnSaveGroupSuccess?.Invoke(this.ProductSelected, EventArgs.Empty);

                this.Close();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeInformacion($"Error guardando el detalle del producto {ex.Message}");
            }
        }
        private void LoadCategorias(string tipo_busqueda, string texto_busqueda)
        {
            try
            {
                this.panelTiposProductos.clearDataSource();

                var result = NProductos.BuscarTipoProductos(tipo_busqueda, texto_busqueda);

                if (result == null)
                    throw new Exception("Error obteniendo las categorias");

                if (result.Result.dt != null)
                {
                    DataTable dtCategorias = result.Result.dt;
                    List<UserControl> controls = new List<UserControl>();
                    this.Categorias = new List<Catalogo>();
                    foreach (DataRow row in dtCategorias.Rows)
                    {
                        Catalogo ca = new Catalogo(row);
                        TipoItem categoria = new TipoItem()
                        {
                            Catalogo = ca,
                            NombreTipo = ca.Nombre_tipo,
                        };
                        categoria.OnBtnTipoClick += Categoria_OnBtnCatalogo;
                        controls.Add(categoria);
                        this.Categorias.Add(ca);
                    }
                    this.panelTiposProductos.AddArrayControl(controls);
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeInformacion($"No se pudieron obtener las categorías | {ex.Message}");
            }
        }
        private void Categoria_OnBtnCatalogo(object sender, EventArgs e)
        {
            Catalogo catalogo = (Catalogo)sender;

            if (catalogo == null)
                return;

            TipoProductoSelected = catalogo;

            if (this.ControlsCustom == null)
                return;

            if (this.ControlsCustom.Count < 1)
                return;

            var findUsersControls = this.ControlsCustom.Where(x => x.ProductSelected.Id_tipo_producto == catalogo.Id_tipo).ToList();

            List<UserControl> userSControls = findUsersControls.Cast<UserControl>().ToList();

            this.panelProductos.clearDataSource();
            this.panelProductos.AddArrayControl(userSControls);
        }


        public List<FormsProductos.ProductoSuperSmall> ControlsCustom { get; set; }
        public List<Productos> Products { get; set; }
        public List<Detail_products> DetailProductsAdd { get; set; }

        private Productos _productSelected;

        public List<Catalogo> Categorias { get; set; }
        public Catalogo TipoProductoSelected { get; set; }
        public Productos ProductSelected
        {
            get => _productSelected;
            set
            {
                _productSelected = value;
                this.btnProduct.Text = value.Nombre_producto;
                this.btnProduct.Enabled = false;

                if (value.Detail_products != null)
                {
                    if (value.Detail_products.Count > 0)
                    {
                        this.Text = "Editar los detalles de un producto para venta";
                        this.panelProductsAdd.clearDataSource();

                        var listCustomControls = (from Detail_products de in value.Detail_products
                                                  select new ProductInventoryAddSmall()
                                                  {
                                                      DetailProduct = de,
                                                  }).ToList();

                        var listUsersControls = listCustomControls.Cast<UserControl>().ToList();

                        this.panelProductsAdd.AddArrayControl(listUsersControls);
                    }
                }

            }
        }

        public event EventHandler OnSaveGroupSuccess;
    }
}
