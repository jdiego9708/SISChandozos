using CapaEntidades.Helpers;
using System;
using System.Data;

namespace CapaEntidades.Models
{
    public class Novedades
    {
        public Novedades(DataRow row)
        {
            this.Id_novedad = ConvertValueHelper.ConvertirNumero(row["Id_novedad"]);
            this.Id_producto = ConvertValueHelper.ConvertirNumero(row["Id_producto"]);
            this.Id_turno = ConvertValueHelper.ConvertirNumero(row["Id_turno"]);
            this.Fecha_novedad = ConvertValueHelper.ConvertirFecha(row["Fecha_novedad"]);
            this.Hora_novedad = ConvertValueHelper.ConvertirHora(row["Hora_novedad"]);
            this.Id_turno = ConvertValueHelper.ConvertirNumero(row["Id_turno"]);
            this.Cantidad_novedad = ConvertValueHelper.ConvertirDecimal(row["Cantidad_novedad"]);
            this.Tipo_novedad = ConvertValueHelper.ConvertirCadena(row["Tipo_novedad"]);
            this.Descripcion_novedad = ConvertValueHelper.ConvertirCadena(row["Descripcion_novedad"]);
            this.Estado_novedad = ConvertValueHelper.ConvertirCadena(row["Estado_novedad"]);

            if (row.Table.Columns.Contains("Nombre_producto"))
            {
                this.Producto = new Productos(row);
            }

            if (row.Table.Columns.Contains("Fecha_turno"))
            {
                this.Turno = new Turno(row);
            }

        }
        public Novedades()
        {
            this.Tipo_novedad = string.Empty;
            this.Descripcion_novedad = string.Empty;
            this.Estado_novedad = string.Empty;
        }

        public int Id_novedad { get; set; }
        public int Id_producto { get; set; }
        public Productos Producto { get; set; }
        public int Id_turno { get; set; }
        public Turno Turno { get; set; }
        public DateTime Fecha_novedad { get; set; }
        public TimeSpan Hora_novedad { get; set; }
        public decimal Cantidad_novedad { get; set; }
        public string Tipo_novedad { get; set; }
        public string Descripcion_novedad { get; set; }
        public string Estado_novedad { get; set; }
    }
}
