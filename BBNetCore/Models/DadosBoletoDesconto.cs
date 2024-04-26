using System;
using BBNetCore.Converters;
using BBNetCore.Enumerators;
using Newtonsoft.Json;

namespace BBNetCore.Models;

/// <summary>
/// Classe que representa a definição da ausência ou a forma como será concedido o desconto para o Título de Cobrança.
/// </summary>
public class DadosBoletoDesconto
{
    /// <summary>
    /// Mensagem definida pelo beneficiário para ser impressa no boleto. (Limitado a 30 caracteres)
    /// </summary>
    [JsonProperty("tipo", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public TipoDesconto Tipo { get; set; }

    /// <summary>
    /// Se tipo > 0, Definir uma data de expiração do desconto, no formato "dd.mm.aaaa".
    /// </summary>
    [JsonProperty("dataExpiracao", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(FormataDataConverter), "dd.MM.yyyy")]
    public DateTime DataExpiracao { get; set; }

    /// <summary>
    /// Se tipo = 2, definir uma porcentagem de desconto >= 0.00 (formato decimal separado por ".").
    /// </summary>
    [JsonProperty("porcentagem", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(FormataDecimalConverter))]
    public decimal porcentagem { get; set; }

    /// <summary>
    /// Se tipo = 1, definir um valor de desconto >= 0.00 (formato decimal separado por ".").
    /// </summary>
    [JsonProperty("valor", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(FormataDecimalConverter))]
    public decimal Valor { get; set; }
}

/// <summary>
/// Classe que representa a definição da ausência ou a forma como será concedido o segundo desconto para o Título de Cobrança.
/// </summary>
public class DadosBoletoSegundoDesconto : DadosBoletoDesconto
{
}

/// <summary>
/// Classe que representa a definição da ausência ou a forma como será concedido o terceiro desconto para o Título de Cobrança.
/// </summary>
public class DadosBoletoTerceiroDesconto : DadosBoletoDesconto
{
}