using CapaEntidades.Helpers;
using CapaEntidades.Models;
using CapaNegocio;
using CapaPresentacion.Formularios.FormsGroupsProducts;
using CapaPresentacion.Formularios.FormsPedido;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Documents;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios.FormsProductos
{
    public partial class FrmObservarProductos : Form
    {
        public FrmObservarProductos()
        {
            InitializeComponent();

            this.Load += FrmObservarProductos_Load;
            this.btnAddProduct.Click += BtnAddProduct_Click;
            this.btnRefresh.Click += BtnRefresh_Click;
            this.txtBusqueda.KeyPress += TxtBusqueda_KeyPress;

            this.btnProductsInventory.Click += BtnProductsInventory_Click;
            this.btnProductsBuys.Click += BtnProductsBuys_Click;
        }

        private void BuscarProductosByName(string name)
        {
            List<ProductoSmall> findControls = this.ControlsCustom.Where(x => x.Producto.Nombre_producto.ToLower().Trim().StartsWith(name.ToLower().Trim()) || 
            x.Producto.Nombre_producto.ToLower().Trim().Contains(name.ToLower().Trim())).ToList();

            if (findControls.Count < 1)
                return;

            List<UserControl> usersControlsFind = findControls.Cast<UserControl>().ToList();

            this.panelProductos.clearDataSource();
            this.panelProductos.AddArrayControl(usersControlsFind);
        }
        private void TxtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.gbResultados.Text = $"Mostrando productos | {TypeProducts}";

                this.LoadCategorias("CATALOGO PADRE", "TIPOS DE PRODUCTOS");

                this.BuscarProductos($"ALL PRODUCTS {TypeProducts} NAME", this.txtBusqueda.Text.Trim().ToLower());

                e.Handled = true;
            }
        }
        private void BtnProductsBuys_Click(object sender, EventArgs e)
        {
            this.TypeProducts = "DETAILS";

            this.gbResultados.Text = $"Mostrando productos para VENTA";

            this.LoadCategorias("CATALOGO PADRE", "TIPOS DE PRODUCTOS");

            this.BuscarProductos($"ALL PRODUCTS {TypeProducts} ID TYPE", TipoProductoSelected.Id_tipo.ToString());

            //if (this.Products == null)
            //{
            //    Mensajes.MensajeInformacion("No hay productos para filtrar");
            //    return;
            //}

            //if (this.Products.Count < 1)
            //{
            //    Mensajes.MensajeInformacion("No hay productos para filtrar");
            //    return;
            //}

            //List<ProductoSmall> controlsCustom = this.ControlsCustom.Where(x => x.Producto.Detail_products.Count > 0).ToList();

            //this.LoadCategorias("CATALOGO PADRE", "TIPOS DE PRODUCTOS");

            //if (controlsCustom == null)
            //    return;

            //if (controlsCustom.Count < 1)
            //    return;

            //List<UserControl> usersControl = new List<UserControl>();

            //foreach (ProductoSmall small in controlsCustom)
            //{
            //    if (small.Producto.Detail_products == null)
            //    {
            //        small.btnAddDetailProduct.Visible = true;
            //        usersControl.Add(small);
            //        continue;
            //    }

            //    if (small.Producto.Detail_products.Count < 1)
            //    {
            //        small.btnAddDetailProduct.Visible = true;
            //        usersControl.Add(small);
            //        continue;
            //    }

            //    small.btnAddDetailProduct.Visible = false;
            //    usersControl.Add(small);
            //}

            //this.panelProductos.clearDataSource();
            //this.panelProductos.AddArrayControl(usersControl);

        }
        private void BtnProductsInventory_Click(object sender, EventArgs e)
        {
            this.TypeProducts = "INVENTORY";

            this.gbResultados.Text = $"Mostrando productos de INVENTARIO";

            this.LoadCategorias("CATALOGO PADRE", "TIPOS DE PRODUCTOS");

            this.BuscarProductos($"ALL PRODUCTS {TypeProducts} ID TYPE", TipoProductoSelected.Id_tipo.ToString());

            //if (this.Products == null)
            //{
            //    Mensajes.MensajeInformacion("No hay productos para filtrar");
            //    return;
            //}

            //if (this.Products.Count < 1)
            //{
            //    Mensajes.MensajeInformacion("No hay productos para filtrar");
            //    return;
            //}

            //List<ProductoSmall> controlsCustom = this.ControlsCustom.Where(x => x.Producto.Detail_products == null ||
            //x.Producto.Detail_products.Count < 1).ToList();

            //this.LoadCategorias("CATALOGO PADRE", "TIPOS DE PRODUCTOS");

            //if (controlsCustom == null)
            //    return;

            //if (controlsCustom.Count < 1)
            //    return;

            //List<UserControl> usersControl = new List<UserControl>();

            //foreach (ProductoSmall small in controlsCustom)
            //{
            //    if (small.Producto.Detail_products == null)
            //    {
            //        small.btnAddDetailProduct.Visible = true;
            //        usersControl.Add(small);
            //        continue;
            //    }

            //    if (small.Producto.Detail_products.Count < 1)
            //    {
            //        small.btnAddDetailProduct.Visible = true;
            //        usersControl.Add(small);
            //        continue;
            //    }

            //    small.btnAddDetailProduct.Visible = true;
            //    usersControl.Add(small);
            //}

            //this.panelProductos.clearDataSource();
            //this.panelProductos.AddArrayControl(usersControl);
        }
        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            this.gbResultados.Text = $"Mostrando productos del {TypeProducts}";

            this.LoadCategorias("CATALOGO PADRE", "TIPOS DE PRODUCTOS");

            this.BuscarProductos($"ALL PRODUCTS {TypeProducts} ID TYPE", TipoProductoSelected.Id_tipo.ToString());

            if (this.ControlsCustom == null)
                return;

            if (this.ControlsCustom.Count < 1)
                return;

            List<UserControl> userSControls = this.ControlsCustom.Cast<UserControl>().ToList();

            this.panelProductos.clearDataSource();
            this.panelProductos.AddArrayControl(userSControls);
        }
        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            FrmAgregarProducto frmAgregarProducto = new FrmAgregarProducto()
            {
                StartPosition = FormStartPosition.CenterScreen,
                MinimizeBox = false,
                MaximizeBox = false,
            };
            frmAgregarProducto.OnProductSuccess += FrmAgregarProducto_OnProductSuccess;
            frmAgregarProducto.ShowDialog();
        }
        private void FrmAgregarProducto_OnProductSuccess(object sender, EventArgs e)
        {
            this.gbResultados.Text = $"Mostrando productos del {TypeProducts}";

            this.LoadCategorias("CATALOGO PADRE", "TIPOS DE PRODUCTOS");

            this.BuscarProductos($"ALL PRODUCTS {TypeProducts} ID TYPE", TipoProductoSelected.Id_tipo.ToString());

            if (this.ControlsCustom == null)
                return;

            if (this.ControlsCustom.Count < 1)
                return;

            List<UserControl> userSControls = this.ControlsCustom.Cast<UserControl>().ToList();

            this.panelProductos.clearDataSource();
            this.panelProductos.AddArrayControl(userSControls);
        }
        private void FrmObservarProductos_Load(object sender, EventArgs e)
        {
            this.TypeProducts = "INVENTORY";

            this.gbResultados.Text = $"Mostrando productos del {TypeProducts}";

            this.LoadCategorias("CATALOGO PADRE", "TIPOS DE PRODUCTOS");

            this.BuscarProductos($"ALL PRODUCTS {TypeProducts} ID TYPE", TipoProductoSelected.Id_tipo.ToString());

            //if (this.Products == null)
            //{
            //    Mensajes.MensajeInformacion("No hay productos para filtrar");
            //    return;
            //}

            //if (this.Products.Count < 1)
            //{
            //    Mensajes.MensajeInformacion("No hay productos para filtrar");
            //    return;
            //}

            //List<ProductoSmall> controlsCustom = this.ControlsCustom.Where(x => x.Producto.Detail_products == null ||
            //x.Producto.Detail_products.Count < 1).ToList();

            //List<UserControl> usersControl = new List<UserControl>();

            //foreach (ProductoSmall small in controlsCustom)
            //{
            //    if (small.Producto.Detail_products == null)
            //    {
            //        small.btnAddDetailProduct.Visible = true;
            //        usersControl.Add(small);
            //        continue;
            //    }

            //    if (small.Producto.Detail_products.Count < 1)
            //    {
            //        small.btnAddDetailProduct.Visible = true;
            //        usersControl.Add(small);
            //        continue;
            //    }

            //    small.btnAddDetailProduct.Visible = true;
            //    usersControl.Add(small);
            //}

            //this.panelProductos.clearDataSource();
            //this.panelProductos.AddArrayControl(usersControl);
        }
        private void BuscarProductos(string tipo_busqueda, string texto_busqueda)
        {
            try
            {
                this.panelProductos.clearDataSource();
                this.ControlsCustom = new List<ProductoSmall>();
                this.Products = new List<Productos>();
                this.ProductsDetails = new List<Productos>();
                this.ProductsInventory = new List<Productos>();

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

                List<ProductoSmall> controlsCustom = new List<ProductoSmall>();

                List<Productos> products = new List<Productos>();

                List<Productos> productsInventoryView = new List<Productos>();

                List<Productos> productsDetailsView = new List<Productos>();

                List<int> idsProcess = new List<int>();

                foreach (DataRow row in dtProductos.Rows)
                {
                    int id_product = ConvertValueHelper.ConvertirNumero(row["Id_producto"]);

                    if (idsProcess.Contains(id_product))
                        continue;

                    Productos producto = new Productos(row);

                    if (dtProductos.Columns.Contains("Id_stock"))
                    {
                        string id_stock = ConvertValueHelper.ConvertirCadena(row["Id_stock"]);

                        if (string.IsNullOrEmpty(id_stock))
                        {
                            producto.Last_stock = new Stock_products()
                            {
                                Amount_stock = 0,
                                Total_stock = 0,
                            };
                        }
                        else
                        {
                            Stock_products last_stock = new Stock_products(row);
                            producto.Last_stock = last_stock;
                        }
                    }
                    else
                    {
                        producto.Last_stock = new Stock_products()
                        {
                            Amount_stock = 0,
                            Total_stock = 0,
                        };
                    }

                    string id_detail_product = ConvertValueHelper.ConvertirCadena(row["Id_detail_product"]);

                    if (string.IsNullOrEmpty(id_detail_product))
                    {
                        products.Add(producto);
                        productsInventoryView.Add(producto);
                    }
                    else
                    {
                        DataRow[] rows = dtProductos.Select($"Id_product = '{id_product}' ");

                        if (rows.Count() < 1)
                        {
                            products.Add(producto);
                            productsInventoryView.Add(producto);
                        }
                        else
                        {                         
                            List<Detail_products> productsDetails = (from DataRow rowDetail in rows
                                                                     select new Detail_products(rowDetail)).ToList();

                            producto.Detail_products = productsDetails;
                      
                            products.Add(producto);
                            productsDetailsView.Add(producto);
                        }
                    }

                    idsProcess.Add(id_product);

                    ProductoSmall productoSmall = new ProductoSmall()
                    {
                        Producto = producto,
                    };

                    if (producto.Detail_products.Count > 0)
                        productoSmall.btnAddDetailProduct.Visible = false;
                    else
                        productoSmall.btnAddDetailProduct.Visible = true;

                    productoSmall.OnBtnNextClick += ProductoSmall_OnBtnNextClick;
                    productoSmall.OnBtnEditarClick += ProductoSmall_OnBtnEditarClick;
                    productoSmall.OnBtnAddGroupClick += ProductoSmall_OnBtnAddGroupClick;

                    controls.Add(productoSmall);
                    controlsCustom.Add(productoSmall);
                }

                if (controls.Count < 1)
                {
                    this.panelProductos.BackgroundImage = Properties.Resources.No_hay_productos;
                    return;
                }

                this.ControlsCustom = controlsCustom;
                this.Products = products;
                this.ProductsDetails = productsDetailsView;
                this.ProductsInventory = productsInventoryView;

                this.panelProductos.BackgroundImage = null;
                this.panelProductos.AddArrayControl(controls);
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BuscarProductos",
                    "Hubo un error con la tabla de datos", ex.Message);
            }
        }
        private void ProductoSmall_OnBtnAddGroupClick(object sender, EventArgs e)
        {
            Productos product = (Productos)sender;

            FrmAddGroupProduct frmAddGroupProduct = new FrmAddGroupProduct()
            {
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                MinimizeBox = false,
                ProductSelected = product,
            };
            frmAddGroupProduct.OnSaveGroupSuccess += FrmAddGroupProduct_OnSaveGroupSuccess;
            frmAddGroupProduct.BuscarProductos(this.Products);
            frmAddGroupProduct.ShowDialog();
        }
        private void FrmAddGroupProduct_OnSaveGroupSuccess(object sender, EventArgs e)
        {
            this.BuscarProductos($"ALL PRODUCTS {TypeProducts} ID TYPE", TipoProductoSelected.Id_tipo.ToString());
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

            if (this.OnBtnProductSelected == null)
            {
                var result = NProductos.BuscarProductos("ALL PRODUCTS", "");

                DataTable dtProductos = result.Result.dt;

                List<Productos> productosList = (from DataRow row in dtProductos.Rows
                                                 select new Productos(row)).ToList();

                FrmProfileProduct frmProfileProduct = new FrmProfileProduct()
                {
                    StartPosition = FormStartPosition.CenterScreen,
                    MinimizeBox = false,
                    MaximizeBox = false,
                    Products = productosList
                };
                frmProfileProduct.Producto = producto;
                frmProfileProduct.ShowDialog();
                return;
            }

            this.OnBtnProductSelected?.Invoke(producto, e);
            this.Close();
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

                    if (TipoProductoSelected == null)
                        TipoProductoSelected = new Catalogo(dtCategorias.Rows[0]);
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

            this.LoadCategorias("CATALOGO PADRE", "TIPOS DE PRODUCTOS");

            this.BuscarProductos($"ALL PRODUCTS {TypeProducts} ID TYPE", TipoProductoSelected.Id_tipo.ToString());

            //if (this.Products == null || this.Products.Count < 1)
            //{
            //    this.BuscarProductos($"ALL PRODUCTS {TypeProducts} ID TYPE", "");
            //}

            //List<ProductoSmall> controlsCustom = new List<ProductoSmall>();

            //if (this.TypeProducts.Equals("INVENTORY"))
            //{
            //    controlsCustom = this.ControlsCustom.Where(x => x.Producto.Detail_products == null ||
            //    x.Producto.Detail_products.Count < 1).ToList();
            //}
            //else
            //{
            //    controlsCustom = this.ControlsCustom.Where(x => x.Producto.Detail_products.Count > 0).ToList();
            //}
          
            //var findUsersControls = controlsCustom.Where(x => x.Producto.Id_tipo_producto == catalogo.Id_tipo).ToList();

            //List<UserControl> userSControls = findUsersControls.Cast<UserControl>().ToList();

            //this.panelProductos.clearDataSource();
            //this.panelProductos.AddArrayControl(userSControls);
        }
        public string TypeProducts { get; set; }
        public Catalogo TipoProductoSelected { get; set; }
        public List<ProductoSmall> ControlsCustom { get; set; }
        public List<Catalogo> Categorias { get; set; }
        public List<Productos> Products { get; set; }
        public List<Productos> ProductsDetails { get; set; }
        public List<Productos> ProductsInventory { get; set; }

        public event EventHandler OnBtnProductSelected;
    }
}
