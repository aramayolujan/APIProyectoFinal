using Microsoft.AspNetCore.Mvc;
using APIProyectoFinal.Model;
using APIProyectoFinal.Repository;
using APIProyectoFinal.Controllers.PP;

namespace APIProyectoFinal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoVendidoController : ControllerBase
    {
        [HttpGet(Name = "GetProductosVendidos")]
        public List<ProductoVendido> GetProductosVendidos()
        {
            try
            {
                return ProductoVendidoHandler.GetProductosVendidos();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<ProductoVendido>();
            }

        }
        [HttpDelete]
        public bool DeleteProductoVendido([FromBody] int id)
        {
            try
            {
                return ProductoVendidoHandler.DeleteProductoVendido(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }
        [HttpPost]
        public bool AddProductoVendido([FromBody] PostProductoVendido productoVendido)
        {
            try
            {
                return ProductoVendidoHandler.AddProductoVendido(new ProductoVendido
                {
                    Stock = productoVendido.Stock,
                    IdProducto = productoVendido.IdProducto
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }
        [HttpPut]
        public bool UpdateProductoVendido([FromBody] PutProductoVendido productoVendido)
        {
            try
            {
                return ProductoVendidoHandler.UpdateProductoVendido(new ProductoVendido
                {
                    Id = productoVendido.Id,
                    Stock = productoVendido.Stock,
                    IdProducto = productoVendido.IdProducto
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
