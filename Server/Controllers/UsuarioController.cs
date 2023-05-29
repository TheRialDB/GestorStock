using GestorStock.BD.Data;
using GestorStock.BD.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestorStock.Server.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        Context _context;
        public UsuarioController(Context context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<ActionResult<Usuario>> PostTodoItem(Usuario nuevoUsuario)
        {          

            _context.Add<Usuario>(nuevoUsuario);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
        }

    }
}
