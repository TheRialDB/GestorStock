using GestorStock.BD.Data.Entity;
using GestorStock.BD.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestorStock.Shared.DTO;

namespace GestorStock.Server.Controllers
{
    [ApiController]
    [Route("api/Estado")]
    public class EstadoController : ControllerBase
    {

        private readonly Context context;

        public EstadoController(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Estado>>> Get()
        {
            var lista = await context.Estados.ToListAsync();
            if (lista == null || lista.Count == 0)
            {
                return BadRequest("No hay estados cargados");
            }

            return lista;

        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Estado?>> Get(int id)
        {
            var existe = await context.Componentes.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound($"El estado {id} no existe");
            }
            return await context.Estados.FirstOrDefaultAsync(ped => ped.id == id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(EstadoDTO entidad)
        {
            try
            {

                Estado estado = new Estado();

                estado.nombreEstado = entidad.nombreEstado;

                await context.AddAsync(estado);
                await context.SaveChangesAsync();
                return estado.id;


            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(EstadoDTO estadoDTO, int id)
        {
            try
            {
                var existen = await context.Estados.AnyAsync(x => x.id == id);
                if (!existen)
                {
                    return NotFound($"El estado con el ID={id} no existe");
                }

                Estado estado = new Estado();

                estado.nombreEstado = estadoDTO.nombreEstado;

                await context.AddAsync(estado);
                await context.SaveChangesAsync();
                return Ok();


            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            //if (id != estado.id)
            //{
            //    BadRequest("El id del estado no coincide.");
            //}
            //var existe = await context.Estados.AnyAsync(x => x.id == id);
            //if (!existe)
            //{
            //    return NotFound($"El estado con ID={id} no existe");
            //}

            //context.Update(estado);
            //await context.SaveChangesAsync();
            //return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Estados.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound($"El estado con ID={id} no existe");
            }

            context.Remove(new Estado() { id = id });
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
