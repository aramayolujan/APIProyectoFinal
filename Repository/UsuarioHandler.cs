using APIProyectoFinal.Model;
using System.Data.SqlClient;

namespace APIProyectoFinal.Repository
{
    public  static class UsuarioHandler
    {
        public const string ConnectionString = "Server=LAPTOP-CM3G4G50\\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True";

        public  static List<Usuario> GetUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {

                using (SqlCommand sqlCommand = new SqlCommand(
                    "SELECT * FROM Usuario ", sqlConnection))
                {

                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {

                        // Me aseguro que haya filas que leer
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Usuario usuario = new Usuario();
                                usuario.Id = Convert.ToInt32(dataReader["Id"]);
                                usuario.NombreUsuario = dataReader["NombreUsuario"].ToString();
                                usuario.Nombre = dataReader["Nombre"].ToString();
                                usuario.Apellido = dataReader["Apellido"].ToString();
                                usuario.Contraseña = dataReader["Contraseña"].ToString();
                                usuario.Mail = dataReader["Mail"].ToString();


                                usuarios.Add(usuario);


                            }
                        }
                    }

                    sqlConnection.Close();
                }
            }
            return usuarios;
        }
        public  static bool DeleteUsuario(int id)
        {
            bool result = false;
            string queryDelete = "delete from Usuario where Id = @id";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
             {
                SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", id);
                SqlParameter parametro = new SqlParameter();

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

        }//modificado
        public  static bool UpdateUsuario(Usuario usuario)
        {
            string queryUpdate = "update Usuario set NombreUsuario = @nuevoNombreUsuario where Id = @idUsuario";
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                bool result = false;
                SqlCommand sqlCommand = new SqlCommand(queryUpdate, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", usuario.Id);
                sqlCommand.Parameters.AddWithValue("@nombre", usuario.Nombre);
                sqlCommand.Parameters.AddWithValue("@apellido", usuario.Apellido);
                sqlCommand.Parameters.AddWithValue("@nombreUsuario", usuario.NombreUsuario);
                sqlCommand.Parameters.AddWithValue("@contrasena", usuario.Contraseña);
                sqlCommand.Parameters.AddWithValue("@mail", usuario.Mail);

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
            
            
        }//modificado
        public  static bool AddUsuario(Usuario usuario)
        {
            bool result = false;
            string queryAdd = "insert into Usuario (Nombre, Apellido, NombreUsuario,Contraseña, Mail) " +
                        "values (@nombre,@apellido,@nombreUsuario,@contraseña,@mail)";
            
           using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(queryAdd, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@nombre", usuario.Nombre);
                sqlCommand.Parameters.AddWithValue("@apellido", usuario.Apellido);
                sqlCommand.Parameters.AddWithValue("@nombreUsuario", usuario.NombreUsuario);
                sqlCommand.Parameters.AddWithValue("@contrasena", usuario.Contraseña);
                sqlCommand.Parameters.AddWithValue("@mail", usuario.Mail);

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