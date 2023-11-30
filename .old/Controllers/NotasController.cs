using DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class NotasController(DBcontext ctx): Controller
{
    public IActionResult Index()
    {
        var Notas = ctx.Database.SqlQuery<Nota>($"SELECT * FROM Notas").ToList();
        return View(Notas);
    }
}