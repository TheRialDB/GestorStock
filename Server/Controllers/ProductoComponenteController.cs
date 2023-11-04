using GestorStock.BD.Data;
using GestorStock.BD.Data.Entity;
using GestorStock.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestorStock.Server.Controllers
{
    [ApiController]
    [Route("api/ProductoComponente")]

    public class ProductoComponenteController : ControllerBase
    {
        private readonly Context context;

        public ProductoComponenteController(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductoComponente>>> Get()
        {

            var lista = await context.ProductoComponentes.ToListAsync();

            if (lista == null || lista.Count == 0)
            {
                return BadRequest("No hay productos compuestos cargados");
            }

            return lista;
        }

        //[HttpGet("{id:int}")]
        //public async Task<ActionResult<ProductoComponente?>> Get(int id)
        //{
        //    var existe = await context.ProductoComponentes.AnyAsync(x => x.id == id);
        //    if (!existe)
        //    {
        //        return NotFound($"El producto compuesto {id} no existe");
        //    }
        //    return await context.ProductoComponentes.FirstOrDefaultAsync(ped => ped.id == id);
        //}

        [HttpPost]
        public async Task<ActionResult> Post(ProductoComponenteDTO entidad)
        {
            try
            {

                //var existe = await context.Unidades.AnyAsync(x => x.id == entidad.UnidadId);
                //if (!existe)
                //{
                //    return NotFound($"La unidad de id={entidad.UnidadId} no existe");
                //}

                ProductoComponente nuevoProdComponente = new ProductoComponente();


                nuevoProdComponente.ProductoId = entidad.ProductoId;
                nuevoProdComponente.ComponenteId = entidad.ComponenteId;
                nuevoProdComponente.cantidad = entidad.cantidad;


                await context.AddAsync(nuevoProdComponente);
                await context.SaveChangesAsync();
                //return nuevoProdComponente.id;
                return Ok("El producto compuesto se cargo correctamente");


            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //[HttpPut("{id:int}")]
        //public async Task<ActionResult> Put(ProductoComponenteDTO productoDTO, int id)
        //{
        //    //comprobar que ese id exista en la base de datos
        //    var exist = await context.Productos.AnyAsync(e => e.id == id);
        //    if (!exist)
        //    {
        //        return BadRequest("El Producto no existe");
        //    }

        //    Producto entidad = new Producto();
        //    entidad.id = id;
        //    entidad.codigo = productoDTO.codigo;
        //    entidad.nombreProducto = productoDTO.nombreProducto;
        //    entidad.UnidadId = productoDTO.UnidadId;

        //    //actualizar
        //    context.Update(entidad);
        //    await context.SaveChangesAsync();
        //    return Ok("Actualizado con Exito");
        //}

        //[HttpDelete("{id:int}")]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    var existe = await context.Productos.AnyAsync(x => x.id == id);
        //    if (!existe)
        //    {
        //        return NotFound($"El producto con el ID={id} no existe");
        //    }

        //    context.Remove(new Producto() { id = id });
        //    await context.SaveChangesAsync();
        //    return Ok();
        //}

    }
}
