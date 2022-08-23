using Microsoft.AspNetCore.Mvc;
using APIProyectoFinal.Model;
using APIProyectoFinal.Repository;
using APIProyectoFinal.Controllers.PP;

namespace APIProyectoFinal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {
        [HttpGet(Name = "GetProductos")]
        public List<Producto> GetProductos()
        {
            try
            {
                return ProductoHandler.GetProductos();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Producto>();
            }

        }
        [HttpDelete]
        public bool DeleteProducto([FromBody] int id)
        {
            try
            {
                return ProductoHandler.DeleteProducto(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }
        [HttpPost]
        public bool AddProducto([FromBody] PostProducto producto)
        {
            try
            {
                return ProductoHandler.AddProducto(new Producto
                {
                    Descripciones = producto.Descripciones,
                    Costo = producto.Costo,
                    PrecioVenta = producto.PrecioVenta,
                    Stock = producto.Stock
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }
        [HttpPut]
        public bool UpdateProducto([FromBody] PutProducto producto)
        {
            try
            {
                return ProductoHandler.UpdateProducto(new Producto
                {
                    Descripciones = producto.Descripciones,
                    Costo = producto.Costo,
                    PrecioVenta = producto.PrecioVenta,
                    Stock = producto.Stock,
                    Id = producto.Id
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
