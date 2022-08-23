using APIProyectoFinal.Model;
using System.Data;
using System.Data.SqlClient;

namespace APIProyectoFinal.Repository
{
    public  static class ProductoHandler
    {
        public const string ConnectionString = "Server=LAPTOP-CM3G4G50\\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True";

        public static List<Producto> GetProductos()
        {
            List<Producto> productos = new List<Producto>();
            string queryGet = "select Id, Descripciones, Costo, PrecioVenta, Stock, IdUsuario from Producto";
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(queryGet, sqlConnection);

                try
                {
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Producto objProducto = new Producto();
                        objProducto.Id = Convert.ToInt32(sqlDataReader["Id"]);
                        objProducto.Descripciones = sqlDataReader["Descripciones"].ToString();
                        objProducto.Costo = Convert.ToDouble(sqlDataReader["Costo"]);
                        objProducto.PrecioVenta = Convert.ToDouble(sqlDataReader["PrecioVenta"]);
                        objProducto.Stock = Convert.ToInt32(sqlDataReader["Stock"]);
                        objProducto.IdUsuario = Convert.ToInt32(sqlDataReader["IdUsuario"]);
                        productos.Add(objProducto);
                    }
                    sqlDataReader.Close();
                    sqlConnection.Close();
                }

                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
            return productos;
        }
        public static bool DeleteProducto(int id)
        {
            bool result = false;
            string queryDelete = "delete from Producto where Id = @id";
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", id);

                try
                {
                    sqlConnection.Open();
                    int numberOfRows = sqlCommand.ExecuteNonQuery();
                    if (numberOfRows > 0)
                    {
                        result = true;
                    }
                    sqlConnection.Close();
                }

                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
                return result;
            }
        }
        public static bool AddProducto(Producto producto)
        {
            bool result = false;
            string queryAdd = "insert into Producto (Descripciones, Costo, PrecioVenta,Stock, IdUsuario) " +
                        "values ('@descripciones',@costo,@precioVenta,@stock,@idUsuario)";
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(queryAdd, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@descripciones", producto.Descripciones);
                sqlCommand.Parameters.AddWithValue("@costo", producto.Costo);
                sqlCommand.Parameters.AddWithValue("@precioVenta", producto.PrecioVenta);
                sqlCommand.Parameters.AddWithValue("@stock", producto.Stock);

                try
                {
                    sqlConnection.Open();
                    int numberOfRows = sqlCommand.ExecuteNonQuery();
                    if (numberOfRows > 0)
                    {
                        result = true;
                    }
                    sqlConnection.Close();
                }

                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
                return result;
            }
        }
        public static bool UpdateProducto(Producto producto)
        {
            string queryUpdate = "update Producto set Descripciones = @descripciones, Costo = @costo, PrecioVenta = @precioVenta, Stock = @stock where Id = @id";
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                bool result = false;
                SqlCommand sqlCommand = new SqlCommand(queryUpdate, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", producto.Id);
                sqlCommand.Parameters.AddWithValue("@descripciones", producto.Descripciones);
                sqlCommand.Parameters.AddWithValue("@costo", producto.Costo);
                sqlCommand.Parameters.AddWithValue("@precioVenta", producto.PrecioVenta);
                sqlCommand.Parameters.AddWithValue("@stock", producto.Stock);

                try
                {
                    sqlConnection.Open();
                    int numberOfRows = sqlCommand.ExecuteNonQuery();
                    if (numberOfRows > 0)
                    {
                        result = true;
                    }
                    sqlConnection.Close();
                }

                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
                return result;
            }
        }

    }
}

