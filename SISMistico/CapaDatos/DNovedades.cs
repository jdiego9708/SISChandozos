using System;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using CapaEntidades.Models;

namespace CapaDatos
{
    public class DNovedades
    {
        #region CONSTRUCTOR VACIO
        public DNovedades()
        {
            
        }
        #endregion

        #region MENSAJE SQL
        private void SqlCon_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            this.Mensaje_error = e.Message;
        }
        #endregion

        #region PROPIEDADES
        private string mensaje_error;
        public string Mensaje_error
        {
            get
            {
                return mensaje_error;
            }

            set
            {
                mensaje_error = value;
            }
        }
        #endregion

        #region METODO INSERTAR NOVEDAD
        public Task<string> InsertarNovedad(Novedades novedad)
        {
            string rpta = string.Empty;
            SqlConnection SqlCon = new SqlConnection(Conexion.Cn);
            try
            {
                SqlCon.InfoMessage += new SqlInfoMessageEventHandler(SqlCon_InfoMessage);
                SqlCon.FireInfoMessageEventOnUserErrors = true;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand()
                {
                    Connection = SqlCon,
                    CommandText = "sp_Novedades_i",
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter Id_novedad = new SqlParameter()
                {
                    ParameterName = "@Id_novedad",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                SqlCmd.Parameters.Add(Id_novedad);


                SqlParameter Id_producto = new SqlParameter()
                {
                    ParameterName = "@Id_producto",
                    SqlDbType = SqlDbType.Int,
                    Value = novedad.Id_producto,
                };
                SqlCmd.Parameters.Add(Id_producto);

                SqlParameter Id_turno = new SqlParameter()
                {
                    ParameterName = "@Id_turno",
                    SqlDbType = SqlDbType.Int,
                    Value = novedad.Id_turno,
                };
                SqlCmd.Parameters.Add(Id_turno);

                SqlParameter Fecha_novedad = new SqlParameter()
                {
                    ParameterName = "@Fecha_novedad",
                    SqlDbType = SqlDbType.Date,
                    Value = novedad.Fecha_novedad,
                };
                SqlCmd.Parameters.Add(Fecha_novedad);

                SqlParameter Hora_novedad = new SqlParameter()
                {
                    ParameterName = "@Hora_novedad",
                    SqlDbType = SqlDbType.Time,
                    Value = novedad.Hora_novedad,
                };
                SqlCmd.Parameters.Add(Hora_novedad);

                SqlParameter Cantidad_novedad = new SqlParameter()
                {
                    ParameterName = "@Cantidad_novedad",
                    SqlDbType = SqlDbType.Decimal,
                    Value = novedad.Cantidad_novedad,
                };
                SqlCmd.Parameters.Add(Cantidad_novedad);

                SqlParameter Tipo_novedad = new SqlParameter()
                {
                    ParameterName = "@Tipo_novedad",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = novedad.Tipo_novedad.Trim().ToUpper(),
                };
                SqlCmd.Parameters.Add(Tipo_novedad);

                SqlParameter Descripcion_novedad = new SqlParameter()
                {
                    ParameterName = "@Descripcion_novedad",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 500,
                    Value = novedad.Descripcion_novedad.Trim(),
                };
                SqlCmd.Parameters.Add(Descripcion_novedad);

                SqlParameter Estado_novedad = new SqlParameter()
                {
                    ParameterName = "@Estado_novedad",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = novedad.Estado_novedad.ToUpper().Trim(),
                };
                SqlCmd.Parameters.Add(Estado_novedad);

                rpta = SqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "NO";

                if (rpta != "OK")
                {
                    if (this.Mensaje_error != null)
                    {
                        rpta = this.Mensaje_error;
                    }
                }
                else
                {
                    novedad.Id_novedad = Convert.ToInt32(SqlCmd.Parameters["@Id_novedad"].Value);
                }
            }
            catch (SqlException ex)
            {
                rpta = ex.Message;
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }
            return Task.FromResult(rpta);
        }
        #endregion

        #region METODO BUSCAR NOVEDADES
        public Task<(string rpta, DataTable dt)> BuscarNovedades(string tipo_busqueda, string texto_busqueda)
        {
            string rpta = "OK";
            DataTable dt = new DataTable();
            SqlConnection SqlCon = new SqlConnection(Conexion.Cn);
            try
            {
                SqlCon.InfoMessage += new SqlInfoMessageEventHandler(SqlCon_InfoMessage);
                SqlCon.FireInfoMessageEventOnUserErrors = true;
                SqlCon.Open();

                SqlCommand Sqlcmd = new SqlCommand()
                {
                    Connection = SqlCon,
                    CommandText = "sp_Novedades_g",
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter Tipo_busqueda = new SqlParameter()
                {
                    ParameterName = "@Tipo_busqueda",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = tipo_busqueda.Trim().ToUpper()
                };
                Sqlcmd.Parameters.Add(Tipo_busqueda);

                SqlParameter Texto_busqueda1 = new SqlParameter()
                {
                    ParameterName = "@Texto_busqueda1",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = texto_busqueda.Trim().ToUpper()
                };
                Sqlcmd.Parameters.Add(Texto_busqueda1);

                SqlParameter Texto_busqueda2 = new SqlParameter()
                {
                    ParameterName = "@Texto_busqueda2",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = texto_busqueda.Trim().ToUpper()
                };
                Sqlcmd.Parameters.Add(Texto_busqueda2);

                SqlDataAdapter SqlData = new SqlDataAdapter(Sqlcmd);
                SqlData.Fill(dt);

                if (dt != null)
                {
                    if (dt.Rows.Count < 1)
                    {
                        if (this.Mensaje_error != null)
                            throw new Exception(this.Mensaje_error);
                    }                                      
                }
            }
            catch (SqlException ex)
            {
                rpta = ex.Message;
                dt = null;
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
                dt = null;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }

            return Task.FromResult((rpta, dt));
        }
        #endregion
    }
}
