using GestorStock.BD.Data;
using GestorStock.BD.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestorStock.Server.Controllers
{
    [ApiController]
    [Route("api/ProductoSimple")]

    public class ProductoSimpleController : ControllerBase
    {
        private readonly Context context;

        public ProductoSimpleController(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductoSimple>>> Get()
        {
            return await context.ProductosSimples.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(ProductoSimple productoSimple)
        {
            context.Add(productoSimple);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(ProductoSimple productoSimple, int id)
        {
            if (id != productoSimple.id)
            {
                BadRequest("El id del producto no coincide.");
            }
            var existe = await context.ProductosSimples.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound($"El producto con el ID={id} no existe");
            }

            context.Update(productoSimple);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.ProductosSimples.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound($"El producto con el ID={id} no existe");
            }

            context.Remove(new ProductoSimple() { id = id });
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}
