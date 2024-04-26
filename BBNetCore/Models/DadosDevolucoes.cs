using BBNetCore.Converters;
using BBNetCore.Enumerators;
using Newtonsoft.Json;

namespace BBNetCore.Models;

/// <summary>
/// Classe que representa uma devolução.
/// </summary>
public class DadosDevolucoes
{
    /// <summary>
    /// Id gerado pelo cliente para representar unicamente uma devolução
    /// </summary>
    [JsonProperty("id", Required = Required.Always)]
    public string Id { get; set; }

    /// <summary>
    /// Id da devolução que transita na PACS004.
    /// </summary>
    [JsonProperty("rtrId", Required = Required.Always)]
    public string DevolucaoId { get; set; }

    /// <summary>
    /// Valor a devolver
    /// </summary>
    [JsonProperty("valor", Required = Required.Always)]
    [JsonConverter(typeof(FormataDecimalConverter))]
    public decimal Valor { get; set; }

    /// <summary>
    /// Horário da devolução
    /// </summary>
    [JsonProperty("horario", Required = Required.Always)]
    public DadosDataDevolucaoPix DataDevolucao { get; set; }

    /// <summary>
    /// Status da devolução.
    /// </summary>
    [JsonProperty("status", Required = Required.Always)]
    [JsonConverter(typeof(StatusDevolucaoConverter))]
    public StatusDevolucao StatusDevolucao { get; set; }

    /// <summary>
    /// Descrição do status da devolução
    /// </summary>
    [JsonProperty("motivo", ReferenceLoopHandling = ReferenceLoopHandling.Ignore)]
    public string Descricao { get; set; }
}