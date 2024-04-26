using System;
using BBNetCore.Converters;
using Newtonsoft.Json;

namespace BBNetCore.Models;

/// <summary>
/// Classe contendo informações a respeito de controle de tempo da cobrança.
/// </summary>
public class DadosCalendario
{
    /// <summary>
    /// Data de Criação. Timestamp que indica o momento em que foi criada a cobrança. Respeita o formato definido na RFC 3339.
    /// </summary>
    [JsonProperty("criacao")]
    [JsonConverter(typeof(FormataDataConverter), "yyyy-MM-ddTHH:mm:ss")]
    public DateTime Criado { get; set; }

    /// <summary>
    /// Tempo de vida da cobrança, especificado em segundos a partir da data de criação (Calendario.criacao). Default: 86400
    /// </summary>
    [JsonProperty("expiracao")]
    public int SegundosExpiracao { get; set; }

    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="DadosCalendario"/>.
    /// </summary>
    public DadosCalendario()
    {
    }

    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="DadosCalendario"/>.
    /// </summary>
    /// <param name="segundosExpiracao">Tempo de vida da cobrança</param>
    public DadosCalendario(int segundosExpiracao)
    {
        SegundosExpiracao = segundosExpiracao;
    }
}
