using Microsoft.AspNetCore.Mvc;
using GestorStock.BD.Data;
using GestorStock.BD.Data.Entity;
using Microsoft.EntityFrameworkCore;
using GestorStock.Shared.DTO;

namespace GestorStock.Server.Controllers
{
    [ApiController]
    [Route("api/Deposito")]

    public class DepositoController : ControllerBase
    {
        private readonly Context context;

        public DepositoController(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Deposito>>> Get()
        {
            
            //var lista = await context.Depositos.ToListAsync();

			var lista = await context.Depositos
			.Include(deposito => deposito.Obra) 
			.ToListAsync();

			if (lista == null || lista.Count == 0)
            {
                return BadRequest("No hay depositos cargados");
            }

            return lista;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Deposito?>> Get(int id)
        {
            var existe = await context.Depositos.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound($"El deposito {id} no existe");
            }
            return await context.Depositos.FirstOrDefaultAsync(ped => ped.id == id);
        }


        [HttpPost]
        public async Task<ActionResult<int>> Post(DepositoDTO entidad)
        {
            try
            {
                var existe = await context.Obras.AnyAsync(x => x.id == entidad.ObraId);
                if (!existe)
                {
                    return NotFound($"La obra {entidad.ObraId} no existe");
                }

                Deposito nuevodeposito = new Deposito();

                nuevodeposito.ObraId = entidad.ObraId;
                nuevodeposito.nombreDeposito = entidad.nombreDeposito;
                nuevodeposito.direccion = entidad.direccion;

                await context.AddAsync(nuevodeposito);
                await context.SaveChangesAsync();
                return nuevodeposito.id;

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(DepositoDTO depositoDTO, int id)
        {
            //comprobar que ese id exista en la base de datos
            var exist = await context.Depositos.AnyAsync(e => e.id == id);
            if (!exist)
            {
                return BadRequest("El Deposito no existe");
            }

            Deposito entidad = new Deposito();
            entidad.id = id;
            entidad.nombreDeposito = depositoDTO.nombreDeposito;
            entidad.direccion = depositoDTO.direccion;
            entidad.ObraId = depositoDTO.ObraId;

            //actualizar
            context.Update(entidad);
            await context.SaveChangesAsync();
            return Ok("Actualizado con Exito");
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Depositos.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound($"El deposito con el ID={id} no existe");
            }

            context.Remove(new Deposito() { id = id });
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}
