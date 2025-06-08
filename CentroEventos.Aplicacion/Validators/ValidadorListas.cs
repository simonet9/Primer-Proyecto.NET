using CentroEventos.Aplicacion.Exceptions;

namespace CentroEventos.Aplicacion.Validators;

public static class ValidadorListas
{
    public static List<T> ValidarNoVacia<T>(List<T>? lista, string mensajeError)
    {
        if (lista == null || lista.Count == 0)
            throw new OperacionInvalidaException(mensajeError);
        return lista;
    }
}