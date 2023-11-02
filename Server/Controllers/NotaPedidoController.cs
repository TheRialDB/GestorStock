using GestorStock.BD.Data;
using GestorStock.BD.Data.Entity;
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
            var lista = await context.NotaPedidos
                .Include(notapedido => notapedido.Estado)
                .ToListAsync();

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
                return NotFound($"La nota pedido {id} no existe");
            }
            
            return await context.NotaPedidos.FirstOrDefaultAsync(not => not.id == id);
        }

        [HttpPost]

        public async Task<ActionResult<int>> Post(NotaPedidoDTO entidad)
        {
            try
            {
                var existe = await context.Estados.AnyAsync(x => x.id == entidad.EstadoId);
                if (!existe)
                {
                    return NotFound($"El estado de id = {entidad.EstadoId} no existe");
                }

                NotaPedido nuevanotapedido = new NotaPedido();

                nuevanotapedido.EstadoId = entidad.EstadoId;
                nuevanotapedido.fechaPedido = entidad.fechaPedido;
                nuevanotapedido.emisor = entidad.emisor;
                nuevanotapedido.receptor = entidad.receptor;

                await context.AddAsync(nuevanotapedido);
                await context.SaveChangesAsync();
                return nuevanotapedido.id;
            }

            catch (Exception e) 
            { 
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]

        public async Task<ActionResult> Put(NotaPedidoDTO notaPedidoDTO, int id)
        {
            
            var exist = await context.NotaPedidos.AnyAsync(x => x.id == id);
            if (!exist) 
            {
                return NotFound($"La nota pedido con el ID={id} no existe ");
            }

            NotaPedido entidad = new NotaPedido();
            entidad.id = id;
            entidad.fechaPedido = notaPedidoDTO.fechaPedido;
            entidad.emisor = notaPedidoDTO.emisor;
            entidad.receptor = notaPedidoDTO.receptor;
            entidad.EstadoId = notaPedidoDTO.EstadoId;

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
