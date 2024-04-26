using System;
using BBNetCore.Converters;
using BBNetCore.Enumerators;
using Newtonsoft.Json;

namespace BBNetCore.Models;

/// <summary>
/// Classe que representa os dados de juros que incedem sobre o boleto.
/// </summary>
public class DadosBoletoJurosMora
{
    /// <summary>
    /// Código utilizado pela FEBRABAN para identificar o tipo de taxa de juros.
    /// Domínios: 0 - DISPENSAR; 1 - VALOR DIA ATRASO; 2 - TAXA MENSAL; 3 - ISENTO.
    /// </summary>
    [JsonProperty("tipo", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(TipoJurosMoraConverter))]
    public TipoJurosMora Tipo { get; set; }

    /// <summary>
    /// Se tipo = 2, definir uma porcentagem de juros >= 0.00 (formato decimal separado por ".").
    /// </summary>
    [JsonProperty("porcentagem", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(FormataDecimalConverter))]
    public decimal? Porcentagem { get; set; }

    /// <summary>
    /// Se tipo = 1, definir um valor de juros >= 0.00 (formato decimal separado por ".").
    /// </summary>
    [JsonProperty("valor", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(FormataDecimalConverter))]
    public decimal? Valor { get; set; }

    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="DadosBoletoJurosMora"/>.
    /// </summary>
    public DadosBoletoJurosMora()
    {
    }

    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="DadosBoletoJurosMora"/>.
    /// <param name="tipo">Tipo de taxa de juros.</param>
    /// <param name="valorPorcentagem">Valor ou porcentagem da taxa de juros.</param>
    /// </summary>
    public DadosBoletoJurosMora(TipoJurosMora tipo, decimal valorPorcentagem)
    {
        Tipo = tipo;
        switch (tipo)
        {
            default:
            case TipoJurosMora.Isento:
            case TipoJurosMora.Dispenar:
                break;
            case TipoJurosMora.ValorPorDiaAtraso:
                Valor = valorPorcentagem;
                break;
            case TipoJurosMora.TaxaMensal:
                Porcentagem = valorPorcentagem;
                break;
        }
    }
}