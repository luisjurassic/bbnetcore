using System.ComponentModel;

namespace BBNetCore.Enumerators;

/// <summary>
/// Enumerador com as versões disponíveis da API do PIX.
/// </summary>
public enum VersaoApi
{
    /// <summary>
    /// Versão 1
    /// </summary>
    [Description("Versão 1")]
    V1,

    /// <summary>
    /// Versão 2
    /// </summary>
    [Description("Versão 2")]
    V2
}