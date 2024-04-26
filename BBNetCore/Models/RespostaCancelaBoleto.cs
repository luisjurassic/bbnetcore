using Newtonsoft.Json;

namespace BBNetCore.Models;

/// <summary>
/// Classe que representa a resposta da baixa de boletos.
/// </summary>
public class RespostaCancelaBoleto
{
    /// <summary>
    /// Número do contrato de cobrança do boleto bancário.
    /// </summary>
    [JsonProperty("numeroContratoCobranca")]
    public string NumeroContrato { get; set; }

    /// <summary>
    /// Data do pedido de baixa do boleto bancário.
    /// </summary>
    [JsonProperty("dataBaixa")]
    public string Data { get; set; }

    /// <summary>
    /// Horário do pedido de baixa do boleto bancário.HH:mm:ss
    /// </summary>
    [JsonProperty("horarioBaixa")]
    public string Horario { get; set; }
}