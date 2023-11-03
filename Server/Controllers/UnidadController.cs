using GestorStock.BD.Data;
using GestorStock.BD.Data.Entity;
using GestorStock.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestorStock.Server.Controllers
{
    [ApiController]
    [Route("api/Unidad")]

    public class UnidadController : ControllerBase
    {
        private readonly Context context;

        public UnidadController(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Unidad>>> Get()
        {
            var lista = await context.Unidades.ToListAsync();
            if (lista == null || lista.Count == 0)
            {
                return BadRequest("No hay unidades cargadas");
            }

            return lista;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Unidad?>> Get(int id)
        {
            var existe = await context.Unidades.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound($"La unidad {id} no existe");
            }
            return await context.Unidades.FirstOrDefaultAsync(ped => ped.id == id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(UnidadDTO unidadDTO)
        {
            try
            {
                Unidad nuevaUnidad = new Unidad();
                nuevaUnidad.nombreUnidad = unidadDTO.nombreUnidad;
                nuevaUnidad.simbolo = unidadDTO.simbolo;



                context.Add(nuevaUnidad);
                await context.SaveChangesAsync();
                return Ok();
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Unidad entidad, int id)
        {
            if (id != entidad.id)
            {
                return BadRequest("El id de la unidad no corresponde");
            }

            var existe = await context.Unidades.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound($"La unidad {id} no existe");
            }

            context.Update(entidad);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Unidades.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound($"La unidad {id} no existe");
            }

            context.Remove(new Unidad() { id = id });
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
