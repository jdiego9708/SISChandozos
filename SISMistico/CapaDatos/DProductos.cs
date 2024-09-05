using System;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using CapaEntidades.Models;

namespace CapaDatos
{
    public class DProductos
    {
        #region CONSTRUCTOR VACIO
        public DProductos()
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

        #region METODO INSERTAR PRODUCTO
        public Task<string> InsertarProducto(Productos producto)
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
                    CommandText = "sp_Productos_i",
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter Id_producto = new SqlParameter()
                {
                    ParameterName = "@Id_producto",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                SqlCmd.Parameters.Add(Id_producto);

                SqlParameter Id_tipo_producto = new SqlParameter()
                {
                    ParameterName = "@Id_tipo_producto",
                    SqlDbType = SqlDbType.Int,
                    Value = producto.Id_tipo_producto,
                };
                SqlCmd.Parameters.Add(Id_tipo_producto);

                SqlParameter Nombre_producto = new SqlParameter()
                {
                    ParameterName = "@Nombre_producto",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = producto.Nombre_producto.Trim().ToUpper(),
                };
                SqlCmd.Parameters.Add(Nombre_producto);

                SqlParameter Precio_producto = new SqlParameter()
                {
                    ParameterName = "@Precio_producto",
                    SqlDbType = SqlDbType.Decimal,
                    Value = producto.Precio_producto,
                };
                SqlCmd.Parameters.Add(Precio_producto);

                SqlParameter Imagen_producto = new SqlParameter()
                {
                    ParameterName = "@Imagen_producto",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 200,
                    Value = producto.Imagen_producto.Trim(),
                };
                SqlCmd.Parameters.Add(Imagen_producto);

                SqlParameter Descripcion_producto = new SqlParameter()
                {
                    ParameterName = "@Descripcion_producto",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 200,
                    Value = producto.Descripcion_producto.Trim(),
                };
                SqlCmd.Parameters.Add(Descripcion_producto);

                SqlParameter Estado_producto = new SqlParameter()
                {
                    ParameterName = "@Estado_producto",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = producto.Estado_producto.ToUpper().Trim(),
                };
                SqlCmd.Parameters.Add(Estado_producto);

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
                    producto.Id_producto = Convert.ToInt32(SqlCmd.Parameters["@Id_producto"].Value);
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

        #region METODO EDITAR PRODUCTO
        public Task<string> EditarProducto(Productos producto)
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
                    CommandText = "sp_Productos_u",
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter Id_producto = new SqlParameter()
                {
                    ParameterName = "@Id_producto",
                    SqlDbType = SqlDbType.Int,
                    Value = producto.Id_producto,
                };
                SqlCmd.Parameters.Add(Id_producto);

                SqlParameter Id_tipo_producto = new SqlParameter()
                {
                    ParameterName = "@Id_tipo_producto",
                    SqlDbType = SqlDbType.Int,
                    Value = producto.Id_tipo_producto,
                };
                SqlCmd.Parameters.Add(Id_tipo_producto);

                SqlParameter Nombre_producto = new SqlParameter()
                {
                    ParameterName = "@Nombre_producto",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = producto.Nombre_producto.Trim(),
                };
                SqlCmd.Parameters.Add(Nombre_producto);

                SqlParameter Precio_producto = new SqlParameter()
                {
                    ParameterName = "@Precio_producto",
                    SqlDbType = SqlDbType.Decimal,
                    Value = producto.Precio_producto,
                };
                SqlCmd.Parameters.Add(Precio_producto);

                SqlParameter Imagen_producto = new SqlParameter()
                {
                    ParameterName = "@Imagen_producto",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 200,
                    Value = producto.Imagen_producto.Trim(),
                };
                SqlCmd.Parameters.Add(Imagen_producto);

                SqlParameter Descripcion_producto = new SqlParameter()
                {
                    ParameterName = "@Descripcion_producto",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 200,
                    Value = producto.Descripcion_producto.ToUpper().Trim(),
                };
                SqlCmd.Parameters.Add(Descripcion_producto);

                SqlParameter Estado_producto = new SqlParameter()
                {
                    ParameterName = "@Estado_producto",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = producto.Estado_producto.ToUpper().Trim(),
                };
                SqlCmd.Parameters.Add(Estado_producto);

                rpta = SqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "NO";

                if (rpta != "OK")
                {
                    if (this.Mensaje_error != null)
                    {
                        rpta = this.Mensaje_error;
                    }
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

        #region METODO BUSCAR PRODUCTOS
        public Task<(string rpta, DataTable dt)> BuscarProductos(string tipo_busqueda, string texto_busqueda)
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
                    CommandText = "sp_Productos_g",
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

                SqlParameter Texto_busqueda = new SqlParameter()
                {
                    ParameterName = "@Texto_busqueda",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = texto_busqueda.Trim().ToUpper()
                };
                Sqlcmd.Parameters.Add(Texto_busqueda);

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

        #region METODO BUSCAR TIPO PRODUCTOS
        public Task<(string rpta, DataTable dt)> BuscarTipoProductos(string tipo_busqueda, string texto_busqueda)
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
                    CommandText = "sp_Catalogo_g",
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

                SqlParameter Texto_busqueda = new SqlParameter()
                {
                    ParameterName = "@Texto_busqueda",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = texto_busqueda.Trim().ToUpper()
                };
                Sqlcmd.Parameters.Add(Texto_busqueda);

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

        #region METODO INSERTAR STOCK PRODUCTO
        public Task<string> InsertStockProduct(Stock_products stock)
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
                    CommandText = "sp_Stock_products_i",
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter Id_stock_product = new SqlParameter()
                {
                    ParameterName = "@Id_stock_product",
                    SqlDbType = SqlDbType.Int,
                    Value = stock.Id_stock,
                };
                SqlCmd.Parameters.Add(Id_stock_product);

                SqlParameter Id_producto = new SqlParameter()
                {
                    ParameterName = "@Id_product",
                    SqlDbType = SqlDbType.Int,
                    Value = stock.Id_product,
                };
                SqlCmd.Parameters.Add(Id_producto);

                SqlParameter Date_stock = new SqlParameter()
                {
                    ParameterName = "@Date_stock",
                    SqlDbType = SqlDbType.Date,
                    Value = stock.Date_stock,
                };
                SqlCmd.Parameters.Add(Date_stock);

                SqlParameter Hour_stock = new SqlParameter()
                {
                    ParameterName = "@Hour_stock",
                    SqlDbType = SqlDbType.Time,
                    Value = stock.Hour_stock,
                };
                SqlCmd.Parameters.Add(Hour_stock);

                SqlParameter Type_medition = new SqlParameter()
                {
                    ParameterName = "@Type_medition",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = stock.Type_medition.Trim().ToUpper(),
                };
                SqlCmd.Parameters.Add(Type_medition);

                SqlParameter Amount_stock = new SqlParameter()
                {
                    ParameterName = "@Amount_stock",
                    SqlDbType = SqlDbType.Decimal,
                    Value = stock.Amount_stock,
                };
                SqlCmd.Parameters.Add(Amount_stock);

                SqlParameter Total_stock = new SqlParameter()
                {
                    ParameterName = "@Total_stock",
                    SqlDbType = SqlDbType.Decimal,
                    Value = stock.Total_stock,
                };
                SqlCmd.Parameters.Add(Total_stock);

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
                    stock.Id_product = Convert.ToInt32(SqlCmd.Parameters["@Id_product"].Value);
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

        #region METODO BUSCAR STOCK PRODUCTOS
        public Task<(string rpta, DataTable dt)> GetStockProducts(string tipo_busqueda, string texto_busqueda)
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
                    CommandText = "sp_Stock_products_g",
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

                SqlParameter Texto_busqueda = new SqlParameter()
                {
                    ParameterName = "@Texto_busqueda",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = texto_busqueda.Trim().ToUpper()
                };
                Sqlcmd.Parameters.Add(Texto_busqueda);

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

        #region METODO INSERTAR DETAIL PRODUCT
        public Task<string> InsertDetailProduct(Detail_products detail)
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
                    CommandText = "sp_Detail_products_i",
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter Id_detail_product = new SqlParameter()
                {
                    ParameterName = "@Id_detail_product",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output,
                };
                SqlCmd.Parameters.Add(Id_detail_product);

                SqlParameter Id_product = new SqlParameter()
                {
                    ParameterName = "@Id_product",
                    SqlDbType = SqlDbType.Int,
                    Value = detail.Id_product,
                };
                SqlCmd.Parameters.Add(Id_product);

                SqlParameter Id_product_reference = new SqlParameter()
                {
                    ParameterName = "@Id_product_reference",
                    SqlDbType = SqlDbType.Int,
                    Value = detail.Id_product_reference,
                };
                SqlCmd.Parameters.Add(Id_product_reference);

                SqlParameter Amount_product = new SqlParameter()
                {
                    ParameterName = "@Amount_product",
                    SqlDbType = SqlDbType.Decimal,
                    Value = detail.Amount_product,
                };
                SqlCmd.Parameters.Add(Amount_product);

                SqlParameter Medition_product = new SqlParameter()
                {
                    ParameterName = "@Medition_product",
                    SqlDbType = SqlDbType.VarChar,
                    Value = detail.Medition_product,
                };
                SqlCmd.Parameters.Add(Medition_product);
              
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
                    detail.Id_detail_product = Convert.ToInt32(SqlCmd.Parameters["@Id_detail_product"].Value);
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

        #region METODO DELETE DETAIL PRODUCT
        public Task<string> DeleteDetailProduct(Detail_products detail)
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
                    CommandText = "sp_Detail_products_d",
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter Id_detail_product = new SqlParameter()
                {
                    ParameterName = "@Id_detail_product",
                    SqlDbType = SqlDbType.Int,
                    Value = detail.Id_detail_product,
                };
                SqlCmd.Parameters.Add(Id_detail_product);

                SqlCmd.ExecuteNonQuery();
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

        #region METODO UPDATE AMOUNT DETAIL PRODUCT
        public Task<string> UpdateAmountDetailProduct(Detail_products detail)
        {
            string rpta = "OK";
            SqlConnection SqlCon = new SqlConnection(Conexion.Cn);
            try
            {
                SqlCon.InfoMessage += new SqlInfoMessageEventHandler(SqlCon_InfoMessage);
                SqlCon.FireInfoMessageEventOnUserErrors = true;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand()
                {
                    Connection = SqlCon,
                    CommandText = "sp_Detail_products_u_Amount",
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter Id_detail_product = new SqlParameter()
                {
                    ParameterName = "@Id_detail_product",
                    SqlDbType = SqlDbType.Int,
                    Value = detail.Id_detail_product,
                };
                SqlCmd.Parameters.Add(Id_detail_product);

                SqlParameter Amount_product = new SqlParameter()
                {
                    ParameterName = "@Amount",
                    SqlDbType = SqlDbType.Decimal,
                    Value = detail.Amount_product,
                };
                SqlCmd.Parameters.Add(Amount_product);

                SqlCmd.ExecuteNonQuery();
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

        #region METODO DELETE PRODUCT
        public Task<string> DeleteProduct(Productos product)
        {
            string rpta = "OK";
            SqlConnection SqlCon = new SqlConnection(Conexion.Cn);
            try
            {
                SqlCon.InfoMessage += new SqlInfoMessageEventHandler(SqlCon_InfoMessage);
                SqlCon.FireInfoMessageEventOnUserErrors = true;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand()
                {
                    Connection = SqlCon,
                    CommandText = "sp_Products_d",
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter Id_product = new SqlParameter()
                {
                    ParameterName = "@Id_product",
                    SqlDbType = SqlDbType.Int,
                    Value = product.Id_producto,
                };
                SqlCmd.Parameters.Add(Id_product);

                SqlCmd.ExecuteNonQuery();
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
    }
}
