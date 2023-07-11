using GestorStock.BD.Data;
using GestorStock.BD.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestorStock.Server.Controllers
{
    [ApiController]
    [Route("api/Producto")]

    public class ProductoController : ControllerBase
    {
        private readonly Context context;

        public ProductoController(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Producto>>> Get()
        {
            return await context.Productos.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Producto producto)
        {
            context.Add(producto);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Producto producto, int id)
        {
            if (id != producto.id)
            {
                BadRequest("El id del producto no coincide.");
            }
            var existe = await context.Productos.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound($"El producto con el ID={id} no existe");
            }

            context.Update(producto);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Productos.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound($"El producto con el ID={id} no existe");
            }

            context.Remove(new Producto() { id = id });
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}
