using GestorStock.BD.Data;
using GestorStock.BD.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestorStock.Server.Controllers
{
    [ApiController]
    [Route("api/Roles")]

    public class RolesController : ControllerBase
    {
        private readonly Context context;

        public RolesController(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Rol>>> Get()
        {
            return await context.Roles.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Rol?>> Get(int id)
        {
            var existe = await context.Roles.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound($"El Rol {id} no existe");
            }
            return await context.Roles.FirstOrDefaultAsync(x => x.id == id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Rol rol)
        {
            //return BadRequest("ERROR DE PRUEBA");
            context.Add(rol);
            await context.SaveChangesAsync();
            return rol.id;
        }

        [HttpPut("{id:int}")] // api/roles/2
        public async Task<ActionResult> Put(Rol rol, int id)
        {
            if (id != rol.id)
            {
                return BadRequest("El id del rol no corresponde");
            }

            var existe = await context.Roles.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound($"El rol de id={id} no existe");
            }

            context.Update(rol);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Roles.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound($"El rol de id={id} no existe");
            }

            context.Remove(new Rol() { id = id });
            await context.SaveChangesAsync();
            return Ok();
        }
    }

}
