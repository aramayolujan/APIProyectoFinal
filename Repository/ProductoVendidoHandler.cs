using APIProyectoFinal.Model;
using System.Data;
using System.Data.SqlClient;

namespace APIProyectoFinal.Repository
{
    public class ProductoVendidoHandler
    {
        public const string ConnectionString = "Server=LAPTOP-CM3G4G50\\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True";

        public  static List<ProductoVendido> GetProductosVendidos()
        {
            List<ProductoVendido> soldProductList = new List<ProductoVendido>();
            string queryGet = "select Id, Stock, IdProducto, IdVenta from ProductoVendido";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(queryGet, sqlConnection);

                try
                {
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ProductoVendido objSoldProduct = new ProductoVendido();
                        objSoldProduct.Id = Convert.ToInt32(sqlDataReader["Id"]);
                        objSoldProduct.Stock = Convert.ToInt32(sqlDataReader["Stock"]);
                        objSoldProduct.IdProducto = Convert.ToInt32(sqlDataReader["IdProducto"]);
                        objSoldProduct.IdVenta = Convert.ToInt32(sqlDataReader["IdVenta"]);

                        soldProductList.Add(objSoldProduct);
                    }
                    sqlDataReader.Close();
                    sqlConnection.Close();
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return soldProductList;

        }
        public  static bool DeleteProductoVendido(int id)
        {
            bool result = false;
            string queryDelete = "delete from ProductoVendido where Id = @id";
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
        public static bool AddProductoVendido(ProductoVendido productoVendido)
        {
            bool result = false;
            string queryAdd = "insert into ProductoVendido (IdProducto, Stock, IdVenta) " +
                        "values (@idProducto,@stock,@idVenta)";
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(queryAdd, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@stock", productoVendido.Stock);
                sqlCommand.Parameters.AddWithValue("@idProducto", productoVendido.IdProducto);

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
        public static bool UpdateProductoVendido(ProductoVendido productoVendido)
        {
            string queryUpdate = "update ProductoVendido set Stock = @stock , IdProducto = @idProducto where Id = @id";
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                bool result = false;
                SqlCommand sqlCommand = new SqlCommand(queryUpdate, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", productoVendido.Id);
                sqlCommand.Parameters.AddWithValue("@stock", productoVendido.Stock);
                sqlCommand.Parameters.AddWithValue("@idProducto", productoVendido.IdProducto);
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
