using System;
using BBNetCore.Converters;
using BBNetCore.Enumerators;
using Newtonsoft.Json;

namespace BBNetCore.Models;

/// <summary>
/// Classe que representa a resposta de uma devolução da cobrança imediata.
/// </summary>
public class RespostaDevolucaoPix
{
    /// <summary>
    /// Id gerado pelo cliente para representar unicamente uma devolução
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; }

    /// <summary>
    /// Id da devolução que transita na PACS004.
    /// </summary>
    [JsonProperty("rtrId")]
    public string DevolucaoId { get; set; }

    /// <summary>
    /// Valor a devolver
    /// </summary>
    [JsonProperty("valor")]
    [JsonConverter(typeof(FormataDecimalConverter))]
    public decimal Valor { get; set; }

    /// <summary>
    /// Natureza
    /// </summary>
    [JsonProperty("natureza")]
    public string Natureza { get; set; }

    /// <summary>
    /// Descrição
    /// </summary>
    [JsonProperty("descricao")]
    public string Descricao { get; set; }

    /// <summary>
    /// Horário da devolução
    /// </summary>
    [JsonProperty("horario")]
    public DadosDataDevolucaoPix Horario { get; set; }

    /// <summary>
    /// Status da devolução.
    /// </summary>
    [JsonProperty("status")]
    [JsonConverter(typeof(StatusDevolucaoConverter))]
    public StatusDevolucao StatusDevolucao { get; set; }

    /// <summary>
    /// Motivo
    /// </summary>
    [JsonProperty("motivo")]
    public string Motivo { get; set; }
}