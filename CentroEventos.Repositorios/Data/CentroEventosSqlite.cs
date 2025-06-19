using Microsoft.Extensions.DependencyInjection;

namespace CentroEventos.Repositorios.Data;

public static class CentroEventosSqlite
{
    public static void Inicializar(IServiceProvider serviceProvider)
    {
        using var context = serviceProvider.GetRequiredService<MyContext>();
        if (context.Database.EnsureCreated())
        {
            Console.WriteLine("Se creó base de datos");
        }
    }
}