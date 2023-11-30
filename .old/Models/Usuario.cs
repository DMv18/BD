public class Usuario
{
    public int ID { get; set; } // Coincide con la clave primaria en tu tabla SQL
    public string usuario { get; set; }
    public string correo { get; set; }
    public string contrasena { get; set; }
    public string Rol { get; set; }
}