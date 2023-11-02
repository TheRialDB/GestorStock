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

            //var lista = await context.Obras.ToListAsync();

            var lista = await context.Obras
            .Include(obra => obra.Estado) // Include the Estado navigation property
            .ToListAsync();

            if (lista == null || lista.Count == 0)
            {
                return NotFound("No hay obras cargadas");
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

        [HttpPost]
        public async Task<ActionResult<int>> Post(ObraDTO entidad)
        {
            try
            {
                var existe = await context.Estados.AnyAsync(x => x.id == entidad.EstadoId);
                if (!existe)
                {
                    return NotFound($"El estado de id={entidad.EstadoId} no existe");
                }

                Obra nuevaobra = new Obra();

                nuevaobra.EstadoId = entidad.EstadoId;
                nuevaobra.nombreObra = entidad.nombreObra;
                nuevaobra.direccion = entidad.direccion;

                await context.AddAsync(nuevaobra);
                await context.SaveChangesAsync();
                return nuevaobra.id;

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(ObraDTO obraDTO, int id)
        {
            //comprobar que ese id exista en la base de datos
            var exist = await context.Obras.AnyAsync(e => e.id == id);
            if (!exist)
            {
                return BadRequest("La Obra no existe");
            }

            Obra entidad = new Obra();

            entidad.id = id;
            entidad.nombreObra = obraDTO.nombreObra;
            entidad.direccion = obraDTO.direccion;
            entidad.EstadoId = obraDTO.EstadoId;

            //actualizar
            context.Update(entidad);
            await context.SaveChangesAsync();
            return Ok("Actualizado con Exito");
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
