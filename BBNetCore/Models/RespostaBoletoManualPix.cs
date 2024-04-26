using Newtonsoft.Json;

namespace BBNetCore.Models;

/// <summary>
/// Classe que representação dos campos de resposta de uma solicitação de pix vinculado a boleto bancário registrado por troca de arquivo.
/// </summary>
public class RespostaBoletoManualPix
{
    /// <summary>
    /// Código chave do beneficiário do Pix.
    /// </summary>
    [JsonProperty("pix.chave")]
    public string ChavePagadorPix { get; set; }

    /// <summary>
    /// URL do payload do QR Code Pix.
    /// </summary>
    [JsonProperty("qrCode.url")]
    public string Url { get; set; }

    /// <summary>
    /// Código que identifica a transação Pix - transactionID.
    /// </summary>
    [JsonProperty("qrCode.txId")]
    public string TransacaoId { get; set; }

    /// <summary>
    /// BR Code no padrão EMV. Sequência de caracteres correspondente ao payload do QR Code Pix.
    /// </summary>
    [JsonProperty("qrCode.emv")]
    public string CodigoEmv { get; set; }
}