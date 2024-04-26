using System;
using BBNetCore.Converters;
using Newtonsoft.Json;

namespace BBNetCore.Models;

/// <summary>
/// Classe que representa os horários da devolução.
/// </summary>
public class DadosDataDevolucaoPix
{
    /// <summary>
    /// Horário no qual a devolução foi solicitada no PSP.
    /// </summary>
    [JsonProperty("solicitacao")]
    [JsonConverter(typeof(FormataDataConverter), "yyyy-MM-ddTHH:mm:ss")]
    public DateTime DataSolicitacao { get; set; }

    /// <summary>
    /// Horário no qual a devolução foi liquidada no PSP.
    /// </summary>
    [JsonProperty("liquidacao")]
    [JsonConverter(typeof(FormataDataConverter), "yyyy-MM-ddTHH:mm:ss")]
    public DateTime DataLiquidacao { get; set; }
}