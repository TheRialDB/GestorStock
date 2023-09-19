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
        public async Task<ActionResult> Post(Estado estado)
        {
            context.Add(estado);
            await context.SaveChangesAsync();
            return Ok();
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(EstadoDTO estadoDTO, int id)
        {
            //comprobar que ese id exista en la base de datos
            var exist = await context.Estados.AnyAsync(e => e.id == id);
            if (!exist)
            {
                return BadRequest("El Estado no existe");
            }

            Estado entidad = new Estado();

            entidad.id = id;
            entidad.nombreEstado = estadoDTO.nombreEstado;

            //actualizar
            context.Update(entidad);
            await context.SaveChangesAsync();
            return Ok("Actualizado con Exito");
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
