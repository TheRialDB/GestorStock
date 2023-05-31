﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using GestorStock.Shared;
using GestorStock.BD.Data;
using Microsoft.EntityFrameworkCore;

namespace GestorStock.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        Context context;

        public UsuarioController(Context context)
        {
            this.context = context;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody]LoginDTO login)
        {
            //context.Usuarios.ToListAsync().Wait();
            SesionDTO sesionDTO = new SesionDTO();  


            var usuarios = context.Usuarios.Where(user => user.correo.Equals(login.Correo) && user.contrasena.Equals(login.Clave)).ToList();
            if (usuarios.Count != 0)
            {
                sesionDTO.Nombre = "Juan";
                sesionDTO.Correo = login.Correo;
                sesionDTO.Rol = "Administrador";
            }

            //if (login.Correo == "juanprueba@gmail.com" && login.Clave == "probando123")
            //{

            //    sesionDTO.Nombre = "Juan";
            //    sesionDTO.Correo = login.Correo;
            //    sesionDTO.Rol = "Administrador";
            //}

            //return Ok(sesionDTO);
            return StatusCode(StatusCodes.Status200OK, sesionDTO);


        }
    }
}
