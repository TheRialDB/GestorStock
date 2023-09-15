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
            var lista = await context.Depositos.ToListAsync();
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
                    return NotFound($"El deposito {entidad.ObraId} no existe");
                }

                Deposito pepe = new Deposito();

                pepe.ObraId = entidad.ObraId;
                pepe.nombreDeposito = entidad.nombreDeposito;
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
        public async Task<ActionResult> Put(Deposito deposito, int id)
        {
            if (id != deposito.id)
            {
                BadRequest("El id del deposito no coincide.");
            }
            var existe = await context.Depositos.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound($"El deposito con el ID={id} no existe");
            }

            context.Update(deposito);
            await context.SaveChangesAsync();
            return Ok();
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
