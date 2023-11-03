using GestorStock.BD.Data.Entity;
using GestorStock.BD.Data;
using GestorStock.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestorStock.Server.Controllers
{
    [ApiController]
    [Route("api/DetallePedido")]
    public class DetallePedidoController : ControllerBase
    {
        private readonly Context context;

        public DetallePedidoController(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<DetallePedido>>> Get()
        {
            var lista = await context.DetallePedidos.ToListAsync();
            if (lista == null || lista.Count == 0)
            {
                return BadRequest("No hay detalles de pedidos cargados");
            }

            return lista;

        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<DetallePedido?>> Get(int id)
        {
            var existe = await context.DetallePedidos.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound($"El detalle de pedido {id} no existe");
            }
            return await context.DetallePedidos.FirstOrDefaultAsync(ped => ped.id == id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(DetallePedidoDTO entidad)
        {
            try
            {
                var existe = await context.Stocks.AnyAsync(x => x.id == entidad.StockId);
                if (!existe)
                {
                    return NotFound($"El producto de id={entidad.StockId} no existe");
                }
                var existes = await context.NotaPedidos.AnyAsync(x => x.id == entidad.NotaPedidoId);
                if (!existes)
                {
                    return NotFound($"La nota de pedido con id={entidad.NotaPedidoId} no existe");
                }

                DetallePedido pepe = new DetallePedido();


                pepe.cantidad = entidad.cantidad;
                pepe.NotaPedidoId = entidad.NotaPedidoId;
                pepe.StockId = entidad.StockId;
            

                await context.AddAsync(pepe);
                await context.SaveChangesAsync();
                return pepe.id;


            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(DetallePedidoDTO detallePedidoDTO, int id)
        {
            try
            {
                var existe = await context.Productos.AnyAsync(x => x.id == detallePedidoDTO.StockId);
                if (!existe)
                {
                    return NotFound($"El producto de id={detallePedidoDTO.StockId} no existe");
                }
                var existes = await context.NotaPedidos.AnyAsync(x => x.id == detallePedidoDTO.NotaPedidoId);
                if (!existes)
                {
                    return NotFound($"La nota de pedido con id={detallePedidoDTO.NotaPedidoId} no existe");
                }
                var existen = await context.DetallePedidos.AnyAsync(x => x.id == id);
                if (!existen)
                {
                    return NotFound($"El detalle de pedido con el ID={id} no existe");
                }

                DetallePedido pepe = new DetallePedido();

                pepe.id = id;
                pepe.cantidad = detallePedidoDTO.cantidad;
                pepe.NotaPedidoId = detallePedidoDTO.NotaPedidoId;
                pepe.StockId = detallePedidoDTO.StockId;

               

                context.Update(pepe);
                await context.SaveChangesAsync();
                return Ok();


            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
           
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.DetallePedidos.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound($"El detalle de pedido con el ID={id} no existe");
            }

            context.Remove(new DetallePedido() { id = id });
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
