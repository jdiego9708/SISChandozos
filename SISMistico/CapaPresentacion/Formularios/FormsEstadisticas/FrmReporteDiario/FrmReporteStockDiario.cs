using CapaEntidades.Helpers;
using CapaEntidades.Models;
using CapaNegocio;
using CapaPresentacion.Formularios.FormsProductos;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace CapaPresentacion.Formularios.FormsEstadisticas
{
    public partial class FrmReporteStockDiario : Form
    {
        public FrmReporteStockDiario()
        {
            InitializeComponent();
        }

        public List<Productos> Products { get; set; }
        public List<Productos> ProductsDetails { get; set; }
        public List<Productos> ProductsInventory { get; set; }

        private ReportViewer reportViewer1;

        public async void ProcessReport(int id_turno)
        {
            this.BuscarProductos("ALL PRODUCTS", "");

            var resultNovedades = await NNovedades.BuscarNovedades("ID TURNO", id_turno.ToString());

            DataTable dtNovedades = resultNovedades.dt;

            DataTable dtNovedadesAdd = new DataTable();
            dtNovedadesAdd.Columns.Add("Id_novedad", typeof(string));
            dtNovedadesAdd.Columns.Add("Nombre_producto", typeof(string));
            dtNovedadesAdd.Columns.Add("Cantidad_novedad", typeof(string));
            dtNovedadesAdd.Columns.Add("Hora_novedad", typeof(string));
            dtNovedadesAdd.Columns.Add("Observaciones_novedad", typeof(string));

            List<Novedades> novedades = new List<Novedades>();

            if (dtNovedades != null)
            {
                foreach (DataRow row in dtNovedades.Rows)
                {
                    DataRow newRowNovedad = dtNovedadesAdd.NewRow();

                    Novedades nov = new Novedades(row);

                    newRowNovedad["Id_novedad"] = nov.Id_novedad;
                    newRowNovedad["Nombre_producto"] = nov.Producto.Nombre_producto;
                    newRowNovedad["Cantidad_novedad"] = nov.Cantidad_novedad;
                    newRowNovedad["Hora_novedad"] = nov.Hora_novedad;
                    newRowNovedad["Observaciones_novedad"] = nov.Descripcion_novedad;

                    dtNovedadesAdd.Rows.Add(newRowNovedad);
                    novedades.Add(nov);
                }
            }

            List<int> idsProcess = new List<int>();

            List<ProductoResumenStock> productoResumen = new List<ProductoResumenStock>();

            List<TipoResumen> listResumen = await this.LoadVentasDetalles(id_turno);

            foreach (Productos productSelected in this.ProductsDetails)
            {
                if (idsProcess.Contains(productSelected.Id_producto))
                    continue;

                idsProcess.Add(productSelected.Id_producto);

                foreach (Detail_products detail in productSelected.Detail_products)
                {
                    var prExists = productoResumen.Where(x => x.Id_producto == detail.Id_product_reference).FirstOrDefault();

                    if (prExists != null)
                        continue;

                    var productSelectedFind = this.Products.Where(x => x.Id_producto == detail.Id_product_reference).FirstOrDefault();

                    if (productSelectedFind == null) continue;

                    idsProcess.Add(detail.Id_product_reference);

                    decimal stock_inicial = 0;

                    var listResumenFind = listResumen.Where(x => x.Id_tipo == productSelected.Id_producto).ToList();

                    if (listResumenFind == null || listResumenFind.Count < 1)
                        stock_inicial = productSelectedFind.Last_stock.Total_stock;
                    else
                    {
                        foreach (TipoResumen tipo in listResumenFind)
                        {
                            var findPr = this.Products.Where(x => x.Id_producto == tipo.Id_tipo).FirstOrDefault();
                            if (findPr == null) continue;

                            stock_inicial += (productSelectedFind.Last_stock.Total_stock + (tipo.Cantidad * detail.Amount_product));
                        }
                    }

                    var listNovedadesFind = novedades.Where(x => x.Id_producto == productSelectedFind.Id_producto);

                    foreach(Novedades nove in listNovedadesFind)
                    {
                        stock_inicial += nove.Cantidad_novedad;
                    }

                    decimal stock_final = productSelectedFind.Last_stock.Total_stock;
                    decimal diferencia = stock_inicial - stock_final;

                    productoResumen.Add(new ProductoResumenStock()
                    {
                        Id_producto = productSelectedFind.Id_producto,
                        Nombre_producto = productSelectedFind.Nombre_producto,
                        Stock_inicial_producto = stock_inicial,
                        Stock_final_producto = stock_final,
                        Diferencia_producto = diferencia,
                        Medicion = productSelectedFind.Last_stock.Type_medition
                    });

                   
                }              
            }

            foreach (Productos productSelected in this.ProductsInventory)
            {
                if (idsProcess.Contains(productSelected.Id_producto))
                    continue;

                idsProcess.Add(productSelected.Id_producto);

                decimal stock_inicial = productSelected.Last_stock.Total_stock;
                decimal stock_final = productSelected.Last_stock.Total_stock;
                decimal diferencia = stock_inicial - stock_final;

                var listNovedadesFind = novedades.Where(x => x.Id_producto == productSelected.Id_producto);

                foreach (Novedades nove in listNovedadesFind)
                {
                    stock_inicial += nove.Cantidad_novedad;
                }

                productoResumen.Add(new ProductoResumenStock()
                {
                    Id_producto = productSelected.Id_producto,
                    Nombre_producto = productSelected.Nombre_producto,
                    Stock_inicial_producto = stock_inicial,
                    Stock_final_producto = stock_final,
                    Diferencia_producto = diferencia,
                    Medicion = productSelected.Last_stock.Type_medition
                });
            }

            DataTable dtStockProducts = new DataTable();
            dtStockProducts.Columns.Add("Id_producto", typeof(string));
            dtStockProducts.Columns.Add("Stock_inicial_producto", typeof(string));
            dtStockProducts.Columns.Add("Stock_final_producto", typeof(string));
            dtStockProducts.Columns.Add("Diferencia_producto", typeof(string));
            dtStockProducts.Columns.Add("Nombre_producto", typeof(string));

            foreach(ProductoResumenStock prRe in productoResumen)
            {
                string medition = string.Empty;
                if (string.IsNullOrEmpty(prRe.Medicion))
                {
                    medition = "SIN STOCK";
                }
                else
                {
                    medition = prRe.Medicion;
                }

                DataRow newRow = dtStockProducts.NewRow();
                newRow["Id_producto"] = prRe.Id_producto;
                newRow["Stock_inicial_producto"] = prRe.Stock_inicial_producto.ToString("N2").Replace(",00", "") + " " + medition;
                newRow["Stock_final_producto"] = prRe.Stock_final_producto.ToString("N2").Replace(",00", "") + " " + medition;
                newRow["Diferencia_producto"] = prRe.Diferencia_producto.ToString("N2").Replace(",00", "") + " " + medition;
                newRow["Nombre_producto"] = prRe.Nombre_producto;
                dtStockProducts.Rows.Add(newRow);
            }

            this.ObtenerReporte(dtStockProducts, dtNovedadesAdd);
        }
        private void BuscarProductos(string tipo_busqueda, string texto_busqueda)
        {
            try
            {
                this.Products = new List<Productos>();
                this.ProductsDetails = new List<Productos>();
                this.ProductsInventory = new List<Productos>();

                var result = NProductos.BuscarProductos(tipo_busqueda, texto_busqueda);

                DataTable dtProductos = result.Result.dt;

                if (dtProductos == null)
                {
                    return;
                }

                if (dtProductos.Rows.Count < 1)
                {
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
                }

                this.Products = products;
                this.ProductsDetails = productsDetailsView;
                this.ProductsInventory = productsInventoryView;
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BuscarProductos",
                    "Hubo un error con la tabla de datos", ex.Message);
            }
        }
        public async Task<List<TipoResumen>> LoadVentasDetalles(int id_turno)
        {
            MensajeEspera.ShowWait("Cargando...");



            DataTable dtEstadistica;
            DataTable dtDetalle;
            DataTable dtPagos;

            var result =
            await NNomina.EstadisticasDiarias(id_turno, DateTime.Now.ToString("yyyy-MM-dd"));
            dtEstadistica = result.dtEstadistica;
            dtDetalle = result.dtDetalle;
            dtPagos = result.dtPagos;

            List<TipoResumen> resumen = new List<TipoResumen>();

            foreach (DataRow row in dtDetalle.Rows)
            {
                int id_tipo = Convert.ToInt32(row["Id_tipo"]);
                int cantidad = Convert.ToInt32(row["Cantidad"]);
                string nombre = Convert.ToString(row["Nombre"]);
                decimal precio = Convert.ToDecimal(row["Precio"]) * cantidad;

                List<TipoResumen> results = resumen.Where(x => x.Id_tipo == id_tipo).ToList();
                if (results.Count > 0)
                {
                    results[0].Cantidad += cantidad;
                    results[0].Valor_total += precio;
                }
                else
                {
                    TipoResumen tipo = new TipoResumen
                    {
                        Id_tipo = id_tipo,
                        Nombre = nombre,
                        Cantidad = cantidad,
                        Valor_total = precio,
                    };
                    resumen.Add(tipo);
                }
            }

            return resumen;
            //this.ObtenerReporte();

            //MensajeEspera.CloseForm();
        }
        public void ObtenerReporte(DataTable dtDetails, DataTable dtNovedades)
        {
            if (this.gbReporte.Controls.Count > 0)
                this.gbReporte.Controls.Clear();

            this.reportViewer1 = new ReportViewer
            {
                Dock = DockStyle.Fill,
                Location = new Point(0, 0),
                ProcessingMode = ProcessingMode.Local,
            };

            PageSettings pageSettings = new PageSettings();
            pageSettings.Margins.Left = 10;
            pageSettings.Margins.Right = 10;
            pageSettings.Margins.Top = 10;
            pageSettings.Margins.Bottom = 10;

            this.reportViewer1.SetPageSettings(pageSettings);

            this.reportViewer1.LocalReport.ReportEmbeddedResource =
            "CapaPresentacion.Formularios.FormsEstadisticas.FrmReporteDiario.rptReporteStockDiario.rdlc";

            ReportParameter[] reportParameters = new ReportParameter[1];
            reportParameters[0] = new ReportParameter("FechaHora", DateTime.Now.ToString("dddd dd - MMMM yyyy"));
            this.reportViewer1.LocalReport.SetParameters(reportParameters);

            ReportDataSource dsDetails = new ReportDataSource("dsStock", dtDetails);
            reportViewer1.LocalReport.DataSources.Add(dsDetails);

            ReportDataSource dsNovedades = new ReportDataSource("dsNovedades", dtNovedades);
            reportViewer1.LocalReport.DataSources.Add(dsNovedades);

            this.gbReporte.Controls.Add(this.reportViewer1);

            this.reportViewer1.RefreshReport();

            MensajeEspera.CloseForm();

            //Warning[] warnings;
            //string[] streamids;
            //string mimeType;
            //string encoding;
            //string extension;

            //byte[] bytes = reportViewer1.LocalReport.Render(
            //    "PDF", null, out mimeType, out encoding, out extension,
            //    out streamids, out warnings);

            //string outputPath = Path.Combine(Application.StartupPath, "Informe.pdf");

            //using (FileStream fs = new FileStream(outputPath, FileMode.Create))
            //{
            //    fs.Write(bytes, 0, bytes.Length);
            //}
        }

        public class ProductoResumenStock
        {
            public int Id_producto { get; set; }
            public string Nombre_producto { get; set; }
            public decimal Stock_inicial_producto { get; set; }
            public decimal Stock_final_producto { get; set; }
            public decimal Diferencia_producto { get; set; }
            public string Medicion { get; set; }
        }
        public class TipoResumen
        {
            public int Id_tipo { get; set; }
            public string Nombre { get; set; }
            public int Cantidad { get; set; }
            public decimal Valor_total { get; set; }
        }
    }
}
