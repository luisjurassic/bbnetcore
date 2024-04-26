using BBNetCore.Converters;
using Newtonsoft.Json;

namespace BBNetCore.Models;

/// <summary>
/// Valores monetários referentes à cobrança.
/// </summary>
public class DadosValores
{
    /// <summary>
    /// Valor original da cobrança.
    /// </summary>
    [JsonProperty("original")]
    [JsonConverter(typeof(FormataDecimalConverter))]
    public decimal Valor { get; set; }

    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="DadosValores"/>.
    /// </summary>
    public DadosValores()
    {
    }

    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="DadosValores"/>.
    /// </summary>
    /// <param name="valor">Valor da cobrança</param>
    public DadosValores(decimal valor)
    {
        Valor = valor;
    }
}