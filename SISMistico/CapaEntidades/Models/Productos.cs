using System;
using System.Collections.Generic;
using System.Data;

namespace CapaEntidades.Models
{
    public class Productos
    {
        public Productos()
        {

        }

        public Productos(DataRow row)
        {
            try
            {
                this.Id_producto = Convert.ToInt32(row["Id_producto"]);
                this.Id_tipo_producto = Convert.ToInt32(row["Id_tipo_producto"]);
                this.Nombre_producto = Convert.ToString(row["Nombre_producto"]);
                this.Precio_producto = Convert.ToDecimal(row["Precio_producto"]);
                this.Imagen_producto = Convert.ToString(row["Imagen_producto"]);
                this.Descripcion_producto = Convert.ToString(row["Descripcion_producto"]);
                this.Estado_producto = Convert.ToString(row["Estado_producto"]);

                this.Tipo_producto = new Catalogo(row);
                this.Detail_products = new List<Detail_products>();
                this.Last_stock = new Stock_products();
            }
            catch (Exception ex)
            {
                
            }
        }

        public int Id_producto { get; set; }
        public int Id_tipo_producto { get; set; }
        public string Nombre_producto { get; set; }
        public decimal Precio_producto { get; set; }
        public string Imagen_producto { get; set; }
        public string Descripcion_producto { get; set; }
        public string Estado_producto { get; set; }
        public Catalogo Tipo_producto { get; set; }
        public List<Detail_products> Detail_products { get; set; }
        public Stock_products Last_stock{ get; set; }
    }
}
