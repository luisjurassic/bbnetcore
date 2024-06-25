using System.Security.Cryptography.X509Certificates;
using BBNetCore.Enumerators;
using BBNetCore.Models;

namespace BBNetCore.Test
{
    internal abstract class Configuracao
    {
        internal static readonly ConfiguracoesApiBB ConfiguracoesApiBb = new()
        {
            AmbienteApi = AmbienteApi.Desenvolvimento,
            Certificado = new X509Certificate2("..."),
            ChaveApp = "...",
            ClienteId = "...",
            ClienteSecret = "..."
        };
    }
}