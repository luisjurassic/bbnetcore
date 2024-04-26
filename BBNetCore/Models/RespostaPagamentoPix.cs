using BBNetCore.Converters;
using Newtonsoft.Json;

namespace BBNetCore.Models;

/// <summary>
/// Classe que representa os dados de uma cobrança imediata.
/// </summary>
public class RespostaPagamentoPix
{
    /// <summary>
    /// Valor original da cobrança.
    /// </summary>
    [JsonProperty("valor")]
    [JsonConverter(typeof(FormataDecimalConverter))]
    public decimal Valor { get; set; }

    /// <summary>
    /// Representa o ID fim a fim da transação que transita na PACS002, PACS004 e PACS008.
    /// O e2eid fica disponível após uma cobrança estar concluída e você pode encontrá-lo no response da consulta da cobrança get/cob
    /// </summary>
    [JsonIgnore]
    public string EndToEndId { get; set; }
    
    /// <summary>
    /// ID que representa uma devolução e é único por CPF/CNPJ do usuário recebedor.
    /// O objetivo desse campo é ser um elemento que possibilite ao usuário recebedor a funcionalidade de conciliação de pagamentos.
    /// O ID é criado exclusivamente pelo usuário recebedor e está sob sua responsabilidade
    /// </summary>
    [JsonIgnore]
    public string Id { get; set; }
}