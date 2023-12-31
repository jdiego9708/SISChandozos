﻿using CapaEntidades.Models;
using CapaNegocio;
using CapaPresentacion.ReportesFacturas.Comandas;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmComandas : Form
    {
        public FrmComandas()
        {
            InitializeComponent();
        }
        public string Titulo { get; set; }
        public void ObtenerReporte(string titulo)
        {
            this.Titulo = titulo;

            if (this.Controls.Count > 0)
            {
                this.Controls.Remove(this.reportViewer1);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = null;
                this.reportViewer1.DataBindings.Clear();
                this.reportViewer1.LocalReport.DataSources.Clear();
            }

            this.Controls.Add(this.reportViewer1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource =
                "CapaPresentacion.ReportesFacturas.Comandas.ComandasPedido.rdlc";
        }
        private int ComprobacionNumComandas()
        {
            var fecha = ConfigComandas.Default.Fecha;
            int numcomanda = ConfigComandas.Default.NumComanda;

            if (fecha == null)
            {
                ConfigComandas.Default.Fecha = DateTime.Now.ToString("yyyy-MM-dd");
                numcomanda = 1;
                ConfigComandas.Default.NumComanda = numcomanda;
            }
            else if (string.IsNullOrEmpty(fecha))
            {
                ConfigComandas.Default.Fecha = DateTime.Now.ToString("yyyy-MM-dd");
                numcomanda += 1;
                ConfigComandas.Default.NumComanda = numcomanda;
            }
            else if (DateTime.Now.ToString("yyyy-MM-dd") == fecha.ToString())
            {
                numcomanda += 1;
                ConfigComandas.Default.NumComanda = numcomanda;
            }
            else
            {
                ConfigComandas.Default.Fecha = DateTime.Now.ToString("yyyy-MM-dd");
                numcomanda = 1;
                ConfigComandas.Default.NumComanda = numcomanda;
            }

            ConfigComandas.Default.Save();

            return numcomanda;
        }
        public void ImprimirFactura(int Repetir)
        {
            try
            {

                //Asignar parámetros de observaciones y horas
                int num = this.ComprobacionNumComandas();

                ReportParameter[] reportParameters = new ReportParameter[4];
                reportParameters[0] = new ReportParameter("parameterObservaciones", this.ObservacionesGeneral);
                reportParameters[1] = new ReportParameter("parameterHora", DateTime.Now.ToShortTimeString());
                reportParameters[2] = new ReportParameter("NumeroComanda", num.ToString());
                reportParameters[3] = new ReportParameter("Titulo", Titulo == string.Empty ? "Chandozos" : Titulo);
                this.reportViewer1.LocalReport.SetParameters(reportParameters);

                ReportDataSource dsDatosPedido = new ReportDataSource("DatosPedido", this.TablaDatosPedido);
                reportViewer1.LocalReport.DataSources.Add(dsDatosPedido);

                ReportDataSource dsDetallePedido = new ReportDataSource("DetallePedido", this.TablaDetallePedido);
                reportViewer1.LocalReport.DataSources.Add(dsDetallePedido);

                this.reportViewer1.RefreshReport();

                int contador = 0;
                while (contador != Repetir)
                {
                    objImpresion.Imprimir(reportViewer1.LocalReport);
                    objImpresion.Dispose();

                    contador += 1;
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorForm(ex.Message);
            }
        }
        public void AsignarTablas()
        {
            this.TablaDatosPedido =
                NPedido.BuscarPedidosYDetalle("ID PEDIDO Y DETALLE", Convert.ToString(this.Id_pedido),
                out this.TablaDetallePedido, out string rpta);

            int cantidad_productos = 0;
            foreach (DataRow row in this.TablaDetallePedido.Rows)
            {
                int id_tipo = Convert.ToInt32(row["Id_tipo"]);
                string tipo = Convert.ToString(row["Tipo"]);
                string nombre = Convert.ToString(row["Nombre"]);
                string observaciones = Convert.ToString(row["Observaciones"]);
                int cantidad = Convert.ToInt32(row["Cantidad"]);
                cantidad_productos += cantidad;

                if (!string.IsNullOrEmpty(observaciones))
                    nombre += Environment.NewLine + "**" + observaciones;

                row["Nombre"] = nombre;
            }

            this.ObservacionesGeneral = "Cantidad de platos/bebidas " + cantidad_productos;
        }
        public void AsignarTablas(DataTable detallepedido)
        {
            this.TablaDetallePedido = null;

            int cantidad_productos = 0;
            foreach (DataRow row in detallepedido.Rows)
            {
                int cantidad = Convert.ToInt32(row["Cantidad"]);
                string nombre = Convert.ToString(row["Nombre"]);
                string observaciones = Convert.ToString(row["Observaciones"]);
                cantidad_productos += cantidad;

                if (!string.IsNullOrEmpty(observaciones))
                    nombre += Environment.NewLine + "**" + observaciones;

                row["Nombre"] = nombre;
            }

            this.ObservacionesGeneral = "Cantidad de productos " + cantidad_productos;

            this.TablaDetallePedido = detallepedido;

            this.TablaDatosPedido =
                NPedido.BuscarPedidos("ID PEDIDO", Convert.ToString(this.Id_pedido));
        }
        public void AsignarTablas(Pedidos pedido, List<Detalle_pedido> detalles)
        {
            this.Id_pedido = pedido.Id_pedido;

            this.TablaDetallePedido = null;
            this.TablaDetallePedido = new DataTable();

            this.TablaDetallePedido.Columns.Add("Id_pedido", typeof(int));
            this.TablaDetallePedido.Columns.Add("Id_tipo", typeof(int));
            this.TablaDetallePedido.Columns.Add("Tipo", typeof(string));
            this.TablaDetallePedido.Columns.Add("Cantidad", typeof(int));
            this.TablaDetallePedido.Columns.Add("Nombre", typeof(string));
            this.TablaDetallePedido.Columns.Add("Observaciones", typeof(string));
            this.TablaDetallePedido.Columns.Add("Precio", typeof(string));
            this.TablaDetallePedido.Columns.Add("Total", typeof(string));

            int cantidad_productos = 0;
            foreach (Detalle_pedido detalle in detalles)
            {
                int cantidad = detalle.Cantidad;
                string nombre = detalle.Producto.Nombre_producto;
                string observaciones = detalle.Observaciones;
                cantidad_productos += cantidad;

                if (!string.IsNullOrEmpty(observaciones))
                    nombre += Environment.NewLine + "**" + observaciones;

                DataRow rowAdd = this.TablaDetallePedido.NewRow();
                rowAdd["Id_pedido"] = pedido.Id_pedido;
                rowAdd["Id_tipo"] = detalle.Id_producto;
                rowAdd["Tipo"] = "PRODUCTO";
                rowAdd["Nombre"] = nombre;
                rowAdd["Precio"] = detalle.Producto.Precio_producto.ToString("C").Replace(",00", "");
                rowAdd["Cantidad"] = cantidad_productos;
                rowAdd["Total"] = detalle.Producto.Precio_producto * cantidad_productos;
                rowAdd["Observaciones"] = observaciones;
                this.TablaDetallePedido.Rows.Add(rowAdd);
            }

            this.ObservacionesGeneral = "Cantidad de productos " + cantidad_productos;

            this.TablaDatosPedido =
                NPedido.BuscarPedidos("ID PEDIDO", Convert.ToString(this.Id_pedido));
        }

        #region VARIABLES
        ControladorImpresion objImpresion = new ControladorImpresion();
        DataTable TablaDetallePedido;
        DataTable TablaDatosPedido;
        private int _id_pedido;
        public string ObservacionesGeneral { get; set; }
        public int Id_pedido
        {
            get
            {
                return _id_pedido;
            }

            set
            {
                _id_pedido = value;
            }
        }
        #endregion
    }
}
