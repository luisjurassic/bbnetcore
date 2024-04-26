using Newtonsoft.Json;

namespace BBNetCore.Models;

/// <summary>
/// Clase que representa os dados do Pix do boleto.
/// </summary>
public class RespostaBoletoQrCode
{
    /// <summary>
    /// URL do payload do QR Code Pix.
    /// </summary>
    [JsonProperty("url", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Url { get; set; }

    /// <summary>
    /// Codigo que identifica a transação Pix - transactionID
    /// </summary>
    [JsonProperty("txId", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string TransacaoId { get; set; }

    /// <summary>
    /// BR Code no padrão EMV. Sequência de caracteres correspondente ao payload do QR Code Pix.
    /// </summary>
    [JsonProperty("emv", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string CodigoEmv { get; set; }
}