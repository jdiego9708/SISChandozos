using CapaEntidades.Helpers;
using System;
using System.Data;

namespace CapaEntidades.Models
{
    public class Stock_products
    {
        public Stock_products(DataRow row)
        {
            this.Id_stock = ConvertValueHelper.ConvertirNumero(row["Id_stock"]);
            this.Id_product = ConvertValueHelper.ConvertirNumero(row["Id_product"]);
            this.Date_stock = ConvertValueHelper.ConvertirFecha(row["Date_stock"]);
            this.Hour_stock = ConvertValueHelper.ConvertirHora(row["Hour_stock"]);
            this.Type_medition = ConvertValueHelper.ConvertirCadena(row["Type_medition"]);
            this.Amount_stock = ConvertValueHelper.ConvertirDecimal(row["Amount_stock"]);
            this.Total_stock = ConvertValueHelper.ConvertirDecimal(row["Total_stock"]);
        }
        public Stock_products()
        {

        }
        public int Id_stock { get; set; }
        public int Id_product { get; set; }
        public DateTime Date_stock { get; set; }
        public TimeSpan Hour_stock { get; set; }
        public string Type_medition { get; set; }
        public decimal Amount_stock { get; set; }
        public decimal Total_stock { get; set; }
    }
}
