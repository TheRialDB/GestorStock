using Microsoft.AspNetCore.Mvc;
using GestorStock.BD.Data;
using GestorStock.BD.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace GestorStock.Server.Controllers
{
    [ApiController]
    [Route("api/Obra")]

    public class ObraController : ControllerBase
    {
        private readonly Context context;

        public ObraController(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Obra>>> Get()
        {
            return await context.Obras.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Obra obra)
        {
            context.Add(obra);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Obra obra, int id)
        {
            if (id != obra.id)
            {
                BadRequest("El id de la obra no coincide.");
            }
            var existe = await context.Obras.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound($"La obra con el ID={id} no existe");
            }

            context.Update(obra);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Obras.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound($"La obra con el ID={id} no existe");
            }

            context.Remove(new Obra() { id = id });
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}
