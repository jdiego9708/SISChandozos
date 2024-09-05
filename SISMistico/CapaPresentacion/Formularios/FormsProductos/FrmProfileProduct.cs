using CapaEntidades.Models;
using CapaNegocio;
using CapaPresentacion.Formularios.FormsGroupsProducts;
using CapaPresentacion.Formularios.FormsStockProducts;
using CapaPresentacion.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios.FormsProductos
{
    public partial class FrmProfileProduct : Form
    {
        public FrmProfileProduct()
        {
            InitializeComponent();
            this.btnAddStock.Click += BtnAddStock_Click;
        }

        private PoperContainer container;
        private void BtnAddStock_Click(object sender, EventArgs e)
        {
            FrmAddStockProduct frmAddStockProduct = new FrmAddStockProduct
            {
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = false,
                ProductSelected = this.Producto,
                LastStock = this.LastStock
            };

            frmAddStockProduct.OnProductSaveSuccess += FrmAddStockProduct_OnProductSaveSuccess;

            container = new PoperContainer(frmAddStockProduct);
            container.Show(this.btnAddStock);

            frmAddStockProduct.Show();
        }
        private async void FrmAddStockProduct_OnProductSaveSuccess(object sender, EventArgs e)
        {
            this.container.Close();

            await this.LoadStockProduct(this.Producto.Id_producto);
        }
        private async Task LoadStockProduct(int id_product)
        {
            this.panelHistorialStock.clearDataSource();
            this.panelHistorialStock.BackgroundImage = Resources.No_hay_stock;

            var resultStockProducts = await NProductos.GetStockProducts("ID PRODUCT LAST STOCKS", id_product.ToString());

            if (resultStockProducts.dt == null)
                return;

            List<Stock_products> listStock = (from DataRow row in resultStockProducts.dt.Rows
                                              select new Stock_products(row)).ToList();

            if (listStock.Count > 0)
            {
                Stock_products lastDefault = listStock[0];
                this.LastStock = lastDefault;
                this.txtStockActual.Text = $"{lastDefault.Total_stock:N} | {lastDefault.Type_medition}";
            }
            else
            {
                this.txtStockActual.Text = $"0";
            }


            List<UserControl> controls = new List<UserControl>();
            foreach (Stock_products stock in listStock)
            {
                StockProductSmall stockItem = new StockProductSmall()
                {
                    StockProduct = stock,
                };
                controls.Add(stockItem);
            }

            this.panelHistorialStock.BackgroundImage = null;

            this.panelHistorialStock.AddArrayControl(controls);
        }
        private async void AsignarDatos(Productos producto)
        {
            this.gbDetails.Visible = false;
            this.gbUltimosIngresos.Visible = true;

            this.txtNombre.Text = producto.Nombre_producto;
            this.txtTipoProducto.Text = producto.Tipo_producto.Nombre_tipo;

            this.pxImage.Image = Imagenes.ObtenerImagen("RUTAIMAGES",
                producto.Imagen_producto, out string ruta_destino);

            this.txtDescription.Text = producto.Descripcion_producto;
            this.txtPrecio.Text = producto.Precio_producto.ToString("C");

            await this.LoadStockProduct(producto.Id_producto);

            if (producto.Detail_products != null)
            {
                if (producto.Detail_products.Count > 0)
                {
                    var productDefaultMain = producto.Detail_products[0];

                    if (productDefaultMain != null)
                    {
                        this.panelDetails.clearDataSource();

                        List<UserControl> usersControls = new List<UserControl>();

                        foreach (var de in producto.Detail_products)
                        {
                            var productDefault = this.Products.Where(x => x.Id_producto == de.Id_product_reference).FirstOrDefault();

                            if (productDefault == null)
                                de.Product = producto;
                            else
                                de.Product = productDefault;

                            ProductInventoryAddSmall prSmall = new ProductInventoryAddSmall()
                            {
                                DetailProduct = de,
                            };
                            prSmall.OnBtnRemoveClick += PrSmall_OnBtnRemoveClick;
                            prSmall.OnBtnEditClick += PrSmall_OnBtnEditClick;


                            usersControls.Add(prSmall);
                        }

                        if (productDefaultMain.Product.Id_producto == producto.Id_producto)
                        {
                            return;
                        }
                        else
                        {
                            this.gbDetails.Visible = true;
                            this.gbUltimosIngresos.Visible = false;
                        }

                        this.panelDetails.AddArrayControl(usersControls);
                    }
                }
            }
        }

        private void PrSmall_OnBtnEditClick(object sender, EventArgs e)
        {
            Detail_products detail = (Detail_products)sender;

            FrmDetailProduct frmDetailProduct = new FrmDetailProduct()
            {
                Detail_products = detail,
                StartPosition = FormStartPosition.CenterScreen,
            };
            frmDetailProduct.OnBtnSaveClick += FrmDetailProduct_OnBtnSaveClick;
            frmDetailProduct.ShowDialog();
        }

        private void FrmDetailProduct_OnBtnSaveClick(object sender, EventArgs e)
        {
            FrmDetailProduct frmDetailProduct = (FrmDetailProduct)sender;
            Detail_products detail = frmDetailProduct.Detail_products;
            detail.Amount_product = frmDetailProduct.numericAmount.Value;

            NProductos.UpdateAmountDetailProduct(detail);
        }

        private void PrSmall_OnBtnRemoveClick(object sender, EventArgs e)
        {
            Detail_products detail = (Detail_products)sender;

            NProductos.RemoveDetailProduct(detail);


        }

        public List<Productos> Products { get; set; }

        private Productos _producto;
        private Stock_products _lastStock;
        public Productos Producto
        {
            get => _producto;
            set
            {
                _producto = value;
                this.AsignarDatos(value);
            }
        }
        public Stock_products LastStock { get => _lastStock; set => _lastStock = value; }
    }
}
