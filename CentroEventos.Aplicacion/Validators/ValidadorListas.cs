namespace CentroEventos.Aplicacion.Validators;

public class ValidadorListas
{
    public static List<T> ValidarNoVacia<T>(List<T>? lista, string mensajeError)
    {
        if (lista == null || lista.Count == 0)
            throw new InvalidOperationException(mensajeError);
        return lista;
    }
}