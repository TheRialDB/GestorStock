using Microsoft.AspNetCore.Mvc;
using GestorStock.BD.Data;
using GestorStock.BD.Data.Entity;
using Microsoft.EntityFrameworkCore;
using GestorStock.Shared.DTO;

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
            //return await context.Obras.ToListAsync();

            var lista = await context.Obras.ToListAsync();
            if (lista == null || lista.Count == 0)
            {
                return BadRequest("No hay obras cargadas");
            }

            return lista;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Obra?>> Get(int id)
        {
            var existe = await context.Obras.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound($"La Obra {id} no existe");
            }
            return await context.Obras.FirstOrDefaultAsync(ped => ped.id == id);
        }

        //[HttpPost]
        //public async Task<ActionResult> Post(Obra obra)
        //{
        //    context.Add(obra);
        //    await context.SaveChangesAsync();
        //    return Ok();
        //}

        [HttpPost]
        public async Task<ActionResult<int>> Post(ObraDTO entidad)
        {
            try
            {
                var existe = await context.Estados.AnyAsync(x => 1 == entidad.EstadoId);
                if (!existe)
                {
                    return NotFound($"El estado de id={entidad.EstadoId} no existe");
                }

                Obra pepe = new Obra();

                pepe.EstadoId = entidad.EstadoId;
                pepe.nombreObra = entidad.nombreObra;
                pepe.direccion = entidad.direccion;

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
