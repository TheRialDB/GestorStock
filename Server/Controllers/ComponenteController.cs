using GestorStock.BD.Data.Entity;
using GestorStock.BD.Data;
using GestorStock.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestorStock.Server.Controllers
{
    [ApiController]
    [Route("api/Componente")]

    public class ComponenteController : ControllerBase
    {
        private readonly Context context;

        public ComponenteController(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Componente>>> Get()
        {
            var lista = await context.Componentes.ToListAsync();
            if (lista == null || lista.Count == 0)
            {
                return BadRequest("No hay componentes cargados");
            }

            return lista;

        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Componente?>> Get(int id)
        {
            var existe = await context.Componentes.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound($"El componente {id} no existe");
            }
            return await context.Componentes.FirstOrDefaultAsync(ped => ped.id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Componente componente)
        {
            context.Add(componente);
            await context.SaveChangesAsync();
            return Ok();
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Componente componente, int id)
        {
            if (id != componente.id)
            {
                BadRequest("El id del componente no coincide.");
            }
            var existe = await context.Componentes.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound($"El componente con el ID={id} no existe");
            }

            context.Update(componente);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Componentes.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound($"El componente con el ID={id} no existe");
            }

            context.Remove(new Componente() { id = id });
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}
