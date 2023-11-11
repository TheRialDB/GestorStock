using GestorStock.BD.Data;
using GestorStock.BD.Data.Entity;
using GestorStock.Client.Pages.pStock;
using GestorStock.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestorStock.Server.Controllers
{
    [ApiController]
    [Route("api/NotaPedido")]
    public class NotaPedidoController : ControllerBase
    {
        private readonly Context context;

        public NotaPedidoController(Context context)
        {
            this.context = context;
        }

        [HttpGet]

        public async Task<ActionResult<List<NotaPedido>>> Get()
        {
            var lista = await context.NotaPedidos.ToListAsync();

            //var lista = await context.NotaPedidos
            //    .Include(s => s.)
            //        .ThenInclude(p => p.Productos)
            //        .ToListAsync();

            if (lista == null || lista.Count == 0)
            {
                return BadRequest("no hay nota de pedido cargada");
            }

            return Ok(lista);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<NotaPedido>> Get(int id)
        {
            var existe = await context.NotaPedidos.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return BadRequest($"La nota pedido {id} no existe");
            }
            
            return await context.NotaPedidos.FirstOrDefaultAsync(not => not.id == id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(NotaPedidoDTO notaPedidoDTO)
        {
            var existe = await context.Estados.AnyAsync(x => x.id == notaPedidoDTO.EstadoId);
            if (!existe)
            {
                return BadRequest($"El estado de id = {notaPedidoDTO.EstadoId} no existe");
            }

            try
            {
                NotaPedido entidad = new NotaPedido();

                entidad.EstadoId = notaPedidoDTO.EstadoId;
                entidad.fechaPedido = notaPedidoDTO.fechaPedido;
                entidad.codDepEmisor = notaPedidoDTO.codDepEmisor;
                entidad.codDepReceptor = notaPedidoDTO.codDepReceptor;
                entidad.CodStock = notaPedidoDTO.CodStock;
                entidad.Cantidad = notaPedidoDTO.Cantidad;

                await context.AddAsync(entidad);
                await context.SaveChangesAsync();
                return entidad.id;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            //try
            //{
            //    var existe = await context.Estados.AnyAsync(x => x.id == notaPedidoDTO.EstadoId);
            //    if (!existe)
            //    {
            //        return NotFound($"El estado de id = {notaPedidoDTO.EstadoId} no existe");
            //    }

            //    //NotaPedido entidad = new NotaPedido();

            //    //entidad.EstadoId = notaPedidoDTO.EstadoId;
            //    //entidad.fechaPedido = notaPedidoDTO.fechaPedido;
            //    //entidad.codDepEmisor = notaPedidoDTO.codDepEmisor;
            //    //entidad.codDepReceptor = notaPedidoDTO.codDepReceptor;

            //    await context.AddAsync(entidad);
            //    await context.SaveChangesAsync();
            //    return entidad.id;
            //}

            //catch (Exception e) 
            //{ 
            //    return BadRequest(e.Message);
            //}
        }

        [HttpPut("{id:int}")]

        public async Task<ActionResult> Put(NotaPedidoDTO notaPedidoDTO, int id)
        {
            
            var entidad = await context.NotaPedidos.FirstOrDefaultAsync(x => x.id == id);

            if ( entidad == null) 
            {
                return BadRequest($"La nota pedido con el ID={id} no existe ");
            }

            

            entidad.id = id;
            entidad.EstadoId = notaPedidoDTO.EstadoId;
            entidad.fechaPedido = notaPedidoDTO.fechaPedido;
            entidad.codDepEmisor = notaPedidoDTO.codDepEmisor;
            entidad.codDepReceptor = notaPedidoDTO.codDepReceptor;
            entidad.CodStock = notaPedidoDTO.CodStock;
            entidad.Cantidad = notaPedidoDTO.Cantidad;

            context.Update(entidad);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]

        public async Task <ActionResult> Delete (int id)
        {
            var existe = await context.NotaPedidos.AnyAsync( x => x.id == id);
            if (!existe)
            {
                return BadRequest($"La nota pedido con el ID={id} no existe");
            }

            context.Remove(new NotaPedido() { id = id });
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
