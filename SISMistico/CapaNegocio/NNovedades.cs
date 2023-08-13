using CapaDatos;
using CapaEntidades.Models;
using System.Data;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NNovedades
    {
        public static Task<string> InsertarNovedad(Novedades novedad)
        { 
            DNovedades DNovedades = new DNovedades();
            return DNovedades.InsertarNovedad(novedad);
        }
        public static Task<(string rpta, DataTable dt)> BuscarNovedades(string tipo_busqueda, string texto_busqueda)
        {
            DNovedades DNovedades = new DNovedades();
            return DNovedades.BuscarNovedades(tipo_busqueda, texto_busqueda);
        }      
    }
}
