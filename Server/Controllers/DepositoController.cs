using Microsoft.AspNetCore.Mvc;
using GestorStock.BD.Data;
using GestorStock.BD.Data.Entity;
using Microsoft.EntityFrameworkCore;

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
            return await context.Depositos.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Deposito deposito)
        {
            context.Add(deposito);
            await context.SaveChangesAsync();
            return Ok();
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
