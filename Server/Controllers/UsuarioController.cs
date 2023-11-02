using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GestorStock.Shared;
using GestorStock.BD.Data.Entity;
using GestorStock.BD.Data;
using Microsoft.EntityFrameworkCore;
using GestorStock.Shared.DTO;
using BlazorCrud.Shared;

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
            var lista = await context.Usuarios
                .Include(usuario => usuario.Rol)
                .ToListAsync();

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
        public async Task<ActionResult> Put(UsuarioDTO usuarioDTO, int id)
        {
            //comprobar que ese id exista en la base de datos
            var exist = await context.Usuarios.AnyAsync(e => e.id == id);
            if (!exist)
            {
                return BadRequest("El Usuario no existe");
            }

            Usuario entidad = new Usuario();
            entidad.id = id;
            entidad.nombre = usuarioDTO.nombre;
            entidad.nombreUsuario = usuarioDTO.correo;
            entidad.correo = usuarioDTO.correo;
            entidad.contrasena = usuarioDTO.contrasena;
            entidad.RolId = usuarioDTO.RolId;
            


            //actualizar
            context.Update(entidad);
            await context.SaveChangesAsync();
            return Ok("Actualizado con Exito");
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
