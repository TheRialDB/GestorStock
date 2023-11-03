using GestorStock.BD.Data;
using GestorStock.BD.Data.Entity;
using GestorStock.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestorStock.Server.Controllers
{
    [ApiController]
    [Route("api/Stock")]
    public class StockController : ControllerBase
    {
        private readonly Context context;

        public StockController(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Stock>>> Get()
        {
            var lista = await context.Stocks.ToListAsync();
            if (lista == null || lista.Count == 0)
            {
                return BadRequest("No hay stock");
            }

            return lista;

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Stock>> Get(int id)
        {
            var existe = await context.Stocks.AnyAsync(x => x.id == id);
            if (!existe) //productos//
            {
                return NotFound($"El estado {id} no existe");
            }
            return await context.Stocks.FirstOrDefaultAsync(ped => ped.id == id);
        }

        [HttpPost]

        public async Task<ActionResult<int>> Post(StockDTO entidad)
        {
            try
            {
                var existe = await context.Stocks.AnyAsync(x => x.id == entidad.DepositoId);
                if (!existe)
                {
                    return NotFound($"El stock de id = {entidad.DepositoId} no existe");
                }
                var existes = await context.Productos.AnyAsync(x => x.id == entidad.ProductoId);
                if (!existes)
                {
                    return NotFound($"El producto de id={entidad.ProductoId} no existe");
                }

                Stock nuevostock = new Stock();

                nuevostock.id = entidad.DepositoId;
                nuevostock.cantidad = entidad.cantidad;
                nuevostock.estado = entidad.estado;
                nuevostock.ProductoId = entidad.ProductoId;

                await context.AddAsync(nuevostock);
                await context.SaveChangesAsync();
                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]

        public async Task<ActionResult> Put(StockDTO stockDTO, int id)
        {

            var exist = await context.Stocks.AnyAsync(x => x.id == id);
            if (!exist)
            {
                return BadRequest($"el stock con el ID={id} no existe ");
            }
            var existe = await context.Productos.AnyAsync(x => x.id == stockDTO.ProductoId);
            if (!existe)
            {
                return NotFound($"El producto de id={stockDTO.ProductoId} no existe");
            }


            Stock entidad = new Stock();

            entidad.id = id;
            entidad.cantidad = stockDTO.cantidad;
            entidad.estado = stockDTO.estado;
            entidad.DepositoId = stockDTO.DepositoId;
            entidad.ProductoId = stockDTO.ProductoId;

            context.Update(entidad);
            await context.SaveChangesAsync();
            return Ok("actualizado con exito");     
        }

        [HttpDelete("{id:int}")]

        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Stocks.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return BadRequest($"El stock con el ID = {id} no se encuentra ");
            }

            context.Remove(new Stock() { id = id });
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}
