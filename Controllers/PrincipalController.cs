using DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class PrincipalController(DBcontext ctx): Controller
{
    
    public IActionResult Index()
    {
        var Usuario = ctx.Database.SqlQuery<Usuario>($"SELECT * FROM usuario").ToList();
        return View(Usuario);
    }

    [HttpPost]
    public IActionResult VerificarCredenciales(string usuario, string correo, string contrasena)
    {
        var usuarioEncontrado = ctx.Usuarios.FirstOrDefault(u =>
            u.usuario == usuario && u.correo == correo && u.contrasena == contrasena);

        if (usuarioEncontrado != null)
        {
            return Json(new { success = true, usuario = usuarioEncontrado.usuario });
        }

        return Json(new { success = false });
    }

    public IActionResult Principal()
    {
        var usuario = ViewData["Usuario"] as string;
        var Notas = ctx.Database.SqlQuery<Nota>($"SELECT * FROM Notas").ToList();
        return View(Notas);
    
    }
}