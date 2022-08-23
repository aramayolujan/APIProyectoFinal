using APIProyectoFinal.Model;
using System.Data;
using System.Data.SqlClient;

namespace APIProyectoFinal.Repository
{
    public static class VentaHandler
    {
        public const string ConnectionString = "Server=LAPTOP-CM3G4G50\\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True";
        public static List<Venta> GetVentas()
        {
            List<Venta> ventas = new List<Venta>();
            string queryGet = "SELECT * FROM Venta";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(queryGet, sqlConnection);

                try
                {
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Venta objSales = new Venta();
                        objSales.Id = Convert.ToInt32(sqlDataReader["Id"]);
                        objSales.Comentarios = sqlDataReader["Comentarios"].ToString();
                        ventas.Add(objSales);
                    }
                    sqlDataReader.Close();
                    sqlConnection.Close();
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return ventas;
        }
        public static bool DeleteVenta(int id)
        {
            bool result = false;
            string queryDelete = "delete from Venta where Id = @id";
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
        public static bool AddVenta(Venta venta)
        {
            bool result = false;
            string queryAdd = "insert into Venta (Comentarios) " +
                        "values (@comentarios)";
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(queryAdd, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@comentarios", venta.Comentarios);

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
        public static bool UpdateVenta(Venta venta)
        {

            string queryUpdate = "update Venta set Comentarios = @nuevoComentario where Id = @id";
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                bool result = false;
                SqlCommand sqlCommand = new SqlCommand(queryUpdate, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", venta.Id);
                sqlCommand.Parameters.AddWithValue("@comentarios", venta.Comentarios);

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

                    throw new Exception("There is an error on query definition! " + ex.Message);
                }
                return result;
            }
        }
    }
}

