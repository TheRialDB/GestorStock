using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GestorStock.Shared;
using GestorStock.BD.Data.Entity;
using GestorStock.BD.Data;
using Microsoft.EntityFrameworkCore;
using GestorStock.Shared.DTO;

namespace GestorStock.Server.Controllers
{
    [Route("api/Usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly Context context;

        public UsuarioController(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> Get()
        {
            var lista = await context.Usuarios.ToListAsync();
            if (lista == null || lista.Count == 0)
            {
                return BadRequest("No hay usuarios cargados");
            }

            return lista;

        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Usuario?>> Get(int id)
        {
            var existe = await context.Usuarios.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound($"El usuario {id} no existe");
            }
            return await context.Usuarios.FirstOrDefaultAsync(ped => ped.id == id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(UsuarioDTO entidad)
        {
            try
            {
                var existe = await context.Roles.AnyAsync(x => x.id == entidad.RolId);
                if (!existe)
                {
                    return NotFound($"La profesión de id={entidad.RolId} no existe");
                }
               
                Usuario nuevousuario = new Usuario();

               
                nuevousuario.nombre = entidad.nombre;
                nuevousuario.nombreUsuario = entidad.nombreUsuario;
                nuevousuario.correo = entidad.correo;
                nuevousuario.contrasena = entidad.contrasena;
                nuevousuario.RolId = entidad.RolId;
              

                await context.AddAsync(nuevousuario);
                await context.SaveChangesAsync();
                return nuevousuario.id;


            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Usuario usuario, int id)
        {
            if (id != usuario.id)
            {
                BadRequest("El id del usuario no coincide.");
            }
            var existe = await context.Usuarios.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound($"El usuario con el ID={id} no existe");
            }

            context.Update(usuario);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Usuarios.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound($"El usuario con el ID={id} no existe");
            }

            context.Remove(new Usuario() { id = id });
            await context.SaveChangesAsync();
            return Ok();
        }


    }
}
