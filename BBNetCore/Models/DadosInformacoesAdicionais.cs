using Newtonsoft.Json;

namespace BBNetCore.Models;

/// <summary>
/// Classe contendo informações adicionais
/// </summary>
public class DadosInformacoesAdicionais
{
    /// <summary>
    /// Nome do campo.
    /// </summary>
    [JsonProperty("nome")]
    public string Nome { get; set; }

    /// <summary>
    /// Dados do campo.
    /// </summary>
    [JsonProperty("valor")]
    public string Dados { get; set; }
}