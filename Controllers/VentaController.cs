using Microsoft.AspNetCore.Mvc;
using APIProyectoFinal.Model;
using APIProyectoFinal.Repository;
using APIProyectoFinal.Controllers.PP;
using System.Data.SqlClient;

namespace APIProyectoFinal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VentaController : ControllerBase
    {
        [HttpGet(Name = "GetVentas")]
        public List<Venta> GetVentas()
        {
            try
            {
                return VentaHandler.GetVentas();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Venta>();
            }
        }
        [HttpDelete]
        public bool DeleteVenta([FromBody] int id)
        {
            try
            {
                return VentaHandler.DeleteVenta(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }
        [HttpPost]
        public bool AddVenta([FromBody] PostVenta venta)
        {
            try
            {
                return VentaHandler.AddVenta(new Venta
                {
                    Comentarios = venta.Comentarios
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }
        [HttpPut]
        public bool UpdateVenta([FromBody] PutVenta venta)
        {
            try
            {
                return VentaHandler.UpdateVenta(new Venta
                {
                    Id = venta.Id,
                    Comentarios = venta.Comentarios
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
