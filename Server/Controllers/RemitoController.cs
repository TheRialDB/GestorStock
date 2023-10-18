using GestorStock.BD.Data;
using GestorStock.BD.Data.Entity;
using GestorStock.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestorStock.Server.Controllers
{
    [ApiController]
    [Route("api/Remito")]
    public class RemitoController : ControllerBase
    {
        private readonly Context context;

        public RemitoController(Context context)
        {
            this.context = context;
        }

        [HttpGet]

        public async Task<ActionResult<List<Remito>>> Get()
        {
            var lista = await context.Remitos.ToListAsync();
            if (lista == null || lista.Count == 0)
            {
                return BadRequest("no hay remito cargado");
            }

            return Ok(lista);

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Remito>> Get(int id)
        {
            var existe = await context.Remitos.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound($"el Remito {id} no existe");
            }

            return await context.Remitos.FirstOrDefaultAsync(rem => rem.id == id);
        }

        [HttpPost]

        public async Task<ActionResult<int>> Post(RemitoDTO remitoDTO)
        {
            try
            {
                Remito nuevoremito = new Remito();  
                nuevoremito.codigo = remitoDTO.codigo;
                nuevoremito.fechaEgreso = remitoDTO.fechaEgreso;
                nuevoremito.fechaIngreso = remitoDTO.fechaIngreso;
                nuevoremito.descripcion = remitoDTO.descripcion;


                context.Add(nuevoremito);
                await context.SaveChangesAsync();
                return Ok();
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }

        [HttpPut("{id:int}")]

        public async Task<ActionResult> Put(RemitoDTO remitoDTO, int id)
        {
           
            var existe = await context.Remitos.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound($"El remito con el ID={id} no existe ");
            }

            Remito entidad = new Remito();
            entidad.id = id;
            entidad.codigo = remitoDTO.codigo;
            entidad.fechaIngreso = remitoDTO.fechaIngreso;
            entidad.fechaEgreso = remitoDTO.fechaEgreso;
            entidad.descripcion = remitoDTO.descripcion;


            context.Update(entidad);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Remitos.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound($"El remito {id} no existe");
            }

            context.Remove(new Remito() { id = id });
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}
