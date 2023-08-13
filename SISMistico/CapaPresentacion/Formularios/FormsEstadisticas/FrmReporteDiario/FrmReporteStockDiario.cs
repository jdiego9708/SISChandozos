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

            DataTable dtStockProducts = new DataTable();
            dtStockProducts.Columns.Add("Id_producto", typeof(string));
            dtStockProducts.Columns.Add("Stock_inicial_producto", typeof(string));
            dtStockProducts.Columns.Add("Stock_final_producto", typeof(string));
            dtStockProducts.Columns.Add("Diferencia_producto", typeof(string));
            dtStockProducts.Columns.Add("Nombre_producto", typeof(string));

            List<TipoResumen> listResumen = await this.LoadVentasDetalles(id_turno);

            foreach (TipoResumen item in listResumen)
            {
                var productSelected = this.Products.Where(x => item.Id_tipo == x.Id_producto).FirstOrDefault();

                if (productSelected == null) continue;

                foreach (Detail_products detail in productSelected.Detail_products)
                {
                    DataRow newRow = dtStockProducts.NewRow();

                    var productFind = this.Products.Where(x => detail.Id_product_reference == x.Id_producto).First();

                    if (productFind == null) continue;

                    decimal stock_inicial = productFind.Last_stock.Amount_stock + (detail.Amount_product * item.Cantidad);
                    decimal stock_final = productFind.Last_stock.Amount_stock;
                    decimal diferencia = stock_inicial - stock_final;

                    newRow["Id_producto"] = productFind.Id_producto;
                    newRow["Stock_inicial_producto"] = stock_inicial.ToString("N2").Replace(",00", "") + " " + productFind.Last_stock.Type_medition.ToLower();
                    newRow["Stock_final_producto"] = stock_final.ToString("N2").Replace(",00", "") + " " + productFind.Last_stock.Type_medition.ToLower();
                    newRow["Diferencia_producto"] = diferencia.ToString("N2").Replace(",00", "") + " " + productFind.Last_stock.Type_medition.ToLower();
                    newRow["Nombre_producto"] = productFind.Nombre_producto;

                    dtStockProducts.Rows.Add(newRow);
                }
            }

            var resultNovedades = await NNovedades.BuscarNovedades("ID TURNO", id_turno.ToString());

            DataTable dtNovedades = resultNovedades.dt;

            DataTable dtNovedadesAdd = new DataTable();
            dtNovedadesAdd.Columns.Add("Id_novedad", typeof(string));
            dtNovedadesAdd.Columns.Add("Nombre_producto", typeof(string));
            dtNovedadesAdd.Columns.Add("Cantidad_novedad", typeof(string));
            dtNovedadesAdd.Columns.Add("Hora_novedad", typeof(string));
            dtNovedadesAdd.Columns.Add("Observaciones_novedad", typeof(string));

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
                }
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

        public class TipoResumen
        {
            public int Id_tipo { get; set; }
            public string Nombre { get; set; }
            public int Cantidad { get; set; }
            public decimal Valor_total { get; set; }
        }
    }
}
