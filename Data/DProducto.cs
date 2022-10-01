using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entity;

namespace Data
{
    public class DProducto
    {
        public List<Producto> Listar(Producto producto)
        {
            SqlParameter[] parameters = null;
            string comandText = string.Empty;
            List<Producto> productos = null;

            try
            {
                comandText = "USP_GetProducto";
                parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idproducto", SqlDbType.Int);
                parameters[0].Value = producto.IdProducto;
                productos = new List<Producto>();

                using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.Connection, comandText,
                    CommandType.StoredProcedure, parameters))
                {
                    while (reader.Read())
                    {
                        productos.Add(new Producto
                        {
                            IdProducto = reader["Idproducto"] != null ? Convert.ToInt32(reader["Idproducto"]) : 0,
                            NombreProducto = reader["nombreProducto"] != null ? Convert.ToString(reader["nombreProducto"]) : String.Empty,
                            precio = reader["precio"] != null ? Convert.ToInt32(reader["precio"]) : 0,
                            activo = reader["activo"] != null ? Convert.ToString(reader["activo"]) : String.Empty
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return productos;
        }

        public void Insertar(Producto producto)
        {
            SqlParameter[] parameters = null;
            string comandText = string.Empty;
            try
            {
                comandText = "USP_InsProducto";
                parameters = new SqlParameter[2];


                parameters[0] = new SqlParameter("@nombreproducto", SqlDbType.VarChar);
                parameters[0].Value = producto.NombreProducto;

                parameters[1] = new SqlParameter("@precio", SqlDbType.Int);
                parameters[1].Value = producto.precio;

                parameters[2] = new SqlParameter("@activo", SqlDbType.Text);
                parameters[2].Value = producto.activo;



                SqlHelper.ExecuteNonQuery(SqlHelper.Connection, comandText, CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Actualizar(Producto producto)
        {
            SqlParameter[] parameters = null;
            string comandText = string.Empty;
            try
            {
                comandText = "USP_UpdProducto";
                parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@idProducto", SqlDbType.Int);
                parameters[0].Value = producto.IdProducto;
                parameters[1] = new SqlParameter("@nombreproducto", SqlDbType.VarChar);
                parameters[1].Value = producto.NombreProducto;
                parameters[2] = new SqlParameter("@precio", SqlDbType.Int);
                parameters[2].Value = producto.precio;
                parameters[3] = new SqlParameter("@activo", SqlDbType.Text);
                parameters[3].Value = producto.activo;



                SqlHelper.ExecuteNonQuery(SqlHelper.Connection, comandText, CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Eliminar(int IdProducto)
        {
            SqlParameter[] parameters = null;
            string comandText = string.Empty;
            try
            {
                comandText = "USP_DelProducto";
                parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idproducto", SqlDbType.Int);
                parameters[0].Value = IdProducto;
                SqlHelper.ExecuteNonQuery(SqlHelper.Connection, comandText, CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}

