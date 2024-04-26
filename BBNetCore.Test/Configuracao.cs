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
            ChaveApp = "621594c648280bea57deaf45c12542fc",
            ClienteId = "eyJpZCI6ImRjOGQxZGYtNDYwMS00MDcxLWFkNWMtY2NlIiwiY29kaWdvUHVibGljYWRvciI6MCwiY29kaWdvU29mdHdhcmUiOjkzMDM1LCJzZXF1ZW5jaWFsSW5zdGFsYWNhbyI6MX0",
            ClienteSecret = "eyJpZCI6ImJlYTgyMmMtYjZmNi00NjVmLTkwZmUtZDhiOTA3N2JlMjg3M2EiLCJjb2RpZ29QdWJsaWNhZG9yIjowLCJjb2RpZ29Tb2Z0d2FyZSI6OTMwMzUsInNlcXVlbmNpYWxJbnN0YWxhY2FvIjoxLCJzZXF1ZW5jaWFsQ3JlZGVuY2lhbCI6MSwiYW1iaWVudGUiOiJob21vbG9nYWNhbyIsImlhdCI6MTcxMjYwNDQ3Njg2MH0"
        };
    }
}