using Microsoft.AspNetCore.Mvc;
using APIProyectoFinal.Model;
using APIProyectoFinal.Repository;
using APIProyectoFinal.Controllers.PP;

namespace APIProyectoFinal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        [HttpGet(Name = "GetUsuarios")]
        public List<Usuario> GetUsuarios()
        {
            try
            {
                return UsuarioHandler.GetUsuarios();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Usuario>();
            }

        }
        [HttpPut]
        public bool UpdateUsuario([FromBody] PutUsuario usuario)
        {
            try
            {
                return UsuarioHandler.UpdateUsuario(new Usuario
                {
                    Nombre = usuario.Nombre,
                    Apellido = usuario.Apellido,
                    NombreUsuario = usuario.NombreUsuario,
                    Contraseña = usuario.Contraseña,
                    Mail = usuario.Mail,
                    Id = usuario.Id
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        [HttpDelete]
        public bool DeleteUsuario([FromBody] int id)
        {
            try
            {
                return UsuarioHandler.DeleteUsuario(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }
        [HttpPost]
        public bool AddUsuario([FromBody] PostUsuario usuario)
        {
            try
            {
                return UsuarioHandler.AddUsuario(new Usuario
                {
                    Nombre = usuario.Nombre,
                    Apellido = usuario.Apellido,
                    NombreUsuario = usuario.NombreUsuario,
                    Contraseña = usuario.Contrasena,
                    Mail = usuario.Mail
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }

    }
}
