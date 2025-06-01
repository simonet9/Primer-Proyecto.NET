namespace CentroEventos.Aplicacion.Exceptions
{
    public class FalloAutorizacionException(string mensaje = "No posee los permisos para realizar la operación") : Exception(mensaje)
    {
    }
}