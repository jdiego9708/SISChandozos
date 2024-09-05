using CapaDatos;
using CapaEntidades.Models;
using System.Data;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NProductos
    {
        public static Task<string> InsertarProducto(Productos producto)
        {
            DProductos DProductos = new DProductos();
            return DProductos.InsertarProducto(producto);
        }
        public static Task<string> EditarProducto(Productos producto)
        {
            DProductos DProductos = new DProductos();
            return DProductos.EditarProducto(producto);
        }
        public static Task<(string rpta, DataTable dt)> BuscarProductos(string tipo_busqueda, string texto_busqueda)
        {
            DProductos DProductos = new DProductos();
            return DProductos.BuscarProductos(tipo_busqueda, texto_busqueda);
        }
        public static Task<(string rpta, DataTable dt)> BuscarTipoProductos(string tipo_busqueda, string texto_busqueda)
        {
            DProductos DProductos = new DProductos();
            return DProductos.BuscarTipoProductos(tipo_busqueda, texto_busqueda);
        }
        public static Task<string> InsertStockProduct(Stock_products stock)
        {
            DProductos DProductos = new DProductos();
            return DProductos.InsertStockProduct(stock);
        }
        public static Task<(string rpta, DataTable dt)> GetStockProducts(string tipo_busqueda, string texto_busqueda)
        {
            DProductos DProductos = new DProductos();
            return DProductos.GetStockProducts(tipo_busqueda, texto_busqueda);
        }
        public static Task<string> InsertDetailProduct(Detail_products detail)
        {
            DProductos DProductos = new DProductos();
            return DProductos.InsertDetailProduct(detail);
        }
        public static Task<string> RemoveDetailProduct(Detail_products detail)
        {
            DProductos DProductos = new DProductos();
            return DProductos.DeleteDetailProduct(detail);
        }
        public static Task<string> UpdateAmountDetailProduct(Detail_products detail)
        {
            DProductos DProductos = new DProductos();
            return DProductos.UpdateAmountDetailProduct(detail);
        }
        public static Task<string> DeleteProduct(Productos product)
        {
            DProductos DProductos = new DProductos();
            return DProductos.DeleteProduct(product);
        }
    }
}
