namespace CentroEventos.Repositorios.Data;

public class CentroEventosSqlite
{
    public static void Inicializar()
    {
        using var context = new MyContext();
        if (context.Database.EnsureCreated())
        {
            Console.WriteLine("Se creó base de datos");
        }
    }

}