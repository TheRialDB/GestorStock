using GestorStock.BD.Data;
using GestorStock.BD.Data.Entity;
using GestorStock.Shared.DTO;
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
            var lista = await context.Productos.ToListAsync();
            if (lista == null || lista.Count == 0)
            {
                return BadRequest("No hay productos cargados");
            }

            return lista;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Producto?>> Get(int id)
        {
            var existe = await context.Productos.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound($"El producto {id} no existe");
            }
            return await context.Productos.FirstOrDefaultAsync(ped => ped.id == id);
        }

        [HttpPost]
        public async Task<ActionResult <int>> Post(ProductoDTO entidad)
        {
            try
            {
                var existe = await context.Depositos.AnyAsync(x => x.id == entidad.DepositoId);
                if (!existe)
                {
                    return NotFound($"El deposito de id={entidad.DepositoId} no existe");
                }

                existe = await context.Unidades.AnyAsync(x => x.id == entidad.UnidadId);
                if (!existe)
                {
                    return NotFound($"La unidad de id={entidad.UnidadId} no existe");
                }

                Producto nuevoproducto = new Producto();

                nuevoproducto.DepositoId = entidad.DepositoId;
                nuevoproducto.UnidadId = entidad.UnidadId;
                nuevoproducto.codigo = entidad.codigo;
                nuevoproducto.nombreProducto = entidad.nombreProducto;
                nuevoproducto.descripcion = entidad.descripcion;
                nuevoproducto.cantidad = entidad.cantidad;
                nuevoproducto.estado = entidad.estado;


                await context.AddAsync(nuevoproducto);
                await context.SaveChangesAsync();
                return nuevoproducto.id;


            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
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
