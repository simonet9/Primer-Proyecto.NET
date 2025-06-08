using System.Security.Cryptography;
using System.Text;

namespace CentroEventos.Aplicacion.Helpers;

public static class HashHelper
{
    public static string CalcularHash(string textoPlano)
    {
        var bytes = Encoding.UTF8.GetBytes(textoPlano);
        var hashBytes = SHA256.HashData(bytes);
        var sb = new StringBuilder();
        foreach (var b in hashBytes)
            sb.Append(b.ToString("x2")); 

        return sb.ToString();
    }
}