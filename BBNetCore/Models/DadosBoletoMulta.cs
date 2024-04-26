using System;
using BBNetCore.Converters;
using BBNetCore.Enumerators;
using Newtonsoft.Json;

namespace BBNetCore.Models;

/// <summary>
/// Classe que representa os dados de multa que incedem sobre o boleto.
/// </summary>
public class DadosBoletoMulta
{
    /// <summary>
    /// Como a multa será concedida, inteiro >= 0.
    /// Domínios: 0 - DISPENSAR; 1 - VALOR FIXO; 2 - PERCENTUAL;.
    /// </summary>
    [JsonProperty("tipo", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(TipoMultaConverter))]
    public TipoMulta Tipo { get; set; }

    /// <summary>
    /// Se tipo > 0, definir uma data de multa, no formato "dd.mm.aaaa"
    /// </summary>
    [JsonProperty("data", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(FormataDataConverter), "dd.MM.yyyy")]
    public DateTime? Data { get; set; }

    /// <summary>
    /// Se tipo = 2, definir uma porcentagem >= 0.00 (formato decimal separado por ".").
    /// </summary>
    [JsonProperty("porcentagem", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(FormataDecimalConverter))]
    public decimal? Porcentagem { get; set; }

    /// <summary>
    /// Se tipo = 1, definir um valor >= 0.00 (formato decimal separado por ".").
    /// </summary>
    [JsonProperty("valor", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(FormataDecimalConverter))]
    public decimal? Valor { get; set; }

    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="DadosBoletoMulta"/>.
    /// </summary>
    public DadosBoletoMulta()
    {
    }

    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="DadosBoletoMulta"/>.
    /// <param name="tipo">Tipo de multa.</param>
    /// <param name="valorPorcentagem">Valor ou porcentagem da multa.</param>
    /// <param name="data">Data a partir da qual será cobrada a multa. Deve ser posterior a data de vencimento do boleto.</param>
    /// </summary>
    public DadosBoletoMulta(TipoMulta tipo, decimal valorPorcentagem, DateTime data)
    {
        Tipo = tipo;
        Data = data;
        switch (tipo)
        {
            default:
            case TipoMulta.SemMulta:
                break;
            case TipoMulta.ValorFixo:
                Valor = valorPorcentagem;
                break;
            case TipoMulta.Percentual:
                Porcentagem = valorPorcentagem;
                break;
        }
    }
}