using Newtonsoft.Json;

namespace BBNetCore.Models;

/// <summary>
/// Classe que representa os dados de resposta de uma solicitação de criação de boletos bancários.
/// </summary>
public class RespostaBoleto
{
    /// <summary>
    /// Identificador exclusivo do boleto.
    /// </summary>
    [JsonProperty("numero")]
    public string Numero { get; set; }

    /// <summary>
    /// Número da carteira do convênio de cobrança
    /// </summary>
    [JsonProperty("numeroCarteira")]
    public int NumeroCarteira { get; set; }

    /// <summary>
    /// Número da variação da carteira do convênio de cobrança
    /// </summary>
    [JsonProperty("numeroVariacaoCarteira")]
    public int VariacaoCarteira { get; set; }

    /// <summary>
    /// Identificação do cliente.
    /// </summary>
    [JsonProperty("codigoCliente")]
    public int CodigoCliente { get; set; }

    /// <summary>
    /// Linha digitável do boleto.
    /// </summary>
    [JsonProperty("linhaDigitavel")]
    public string LinhaDigitavel { get; set; }

    /// <summary>
    /// Define o código de barras numérico do boleto.
    /// </summary>
    [JsonProperty("codigoBarraNumerico")]
    public string CodigoBarras { get; set; }

    /// <summary>
    /// Define o número do contrato de cobrança do boleto.
    /// </summary>
    [JsonProperty("numeroContratoCobranca")]
    public int NumeroContrato { get; set; }

    /// <summary>
    /// Define os dados do beneficiário.
    /// </summary>
    [JsonProperty("beneficiario")]
    public RespostaBoletoBeneficiario Beneficiario { get; set; }

    /// <summary>
    /// Define os dados do pix do boleto.
    /// </summary>
    [JsonProperty("qrCode")]
    public RespostaBoletoQrCode QrCode { get; set; }
}