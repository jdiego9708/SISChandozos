using CapaEntidades.Helpers;
using System.Data;

namespace CapaEntidades.Models
{
    public class Detail_products
    {
        public Detail_products(DataRow row)
        {
            this.Id_detail_product = ConvertValueHelper.ConvertirNumero(row["Id_detail_product"]);
            this.Id_product = ConvertValueHelper.ConvertirNumero(row["Id_product"]);
            this.Id_product_reference = ConvertValueHelper.ConvertirNumero(row["Id_product_reference"]);
            this.Amount_product = ConvertValueHelper.ConvertirDecimal(row["Amount_product"]);
            this.Medition_product = ConvertValueHelper.ConvertirCadena(row["Medition_product"]);
        }
        public Detail_products()
        {

        }
        public int Id_detail_product { get; set; }
        public int Id_product { get; set; }
        public int Id_product_reference { get; set; }
        public Productos Product { get; set; }
        public decimal Amount_product { get; set; }
        public string Medition_product { get; set; }
    }
}
