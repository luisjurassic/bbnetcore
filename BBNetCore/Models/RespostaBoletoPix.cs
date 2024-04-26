using BBNetCore.Converters;
using Newtonsoft.Json;

namespace BBNetCore.Models;

/// <summary>
/// Classe que representação dos campos de resposta de uma solicitação de pix vinculado a boleto bancário.
/// </summary>
public class RespostaBoletoPix
{
    /// <summary>
    /// Número de identificação do boleto (correspondente ao NOSSO NÚMERO, numeroTituloCliente), no formato STRING,
    /// com 20 dígitos, que deverá ser formatado da seguinte forma:
    /// “000” + (número do convênio com 7 dígitos) + (10 algarismos - se necessário, completar com zeros à esquerda).
    /// Campo Obrigatório.
    /// </summary>
    [JsonProperty("id")]
    public string NossoNumero { get; set; }

    /// <summary>
    /// Data de registro do boleto no banco.
    /// </summary>
    [JsonProperty("dataRegistroTituloCobranca")]
    public string DataRegistroTitulo { get; set; }

    /// <summary>
    /// Número da agência do beneficiário, sem o dígito verificador.
    /// </summary>
    [JsonProperty("agenciaBeneficiario")]
    public int AgenciaBeneficiario { get; set; }

    /// <summary>
    /// Número da conta do beneficiário, sem o dígito verificador.
    /// </summary>
    [JsonProperty("contaBeneficiario")]
    public int ContaBeneficiario { get; set; }

    /// <summary>
    /// Valor original do boleto indicado quando do registro.
    /// </summary>
    [JsonProperty("valorOriginalTituloCobranca")]
    [JsonConverter(typeof(FormataDecimalConverter))]
    public decimal Valor { get; set; }

    /// <summary>
    /// Data de validade do boleto.
    /// </summary>
    [JsonProperty("validadeTituloCobranca")]
    public string Vencimento { get; set; }

    /// <summary>
    /// Dados do PIX do boleto.
    /// </summary>
    [JsonProperty("pix")]
    public PixBoleto Pix { get; set; }

    /// <summary>
    /// Dados do QR Code do boleto.
    /// </summary>
    [JsonProperty("qrCode")]
    public QrCodeBoleto QrCode { get; set; }
}

/// <summary>
/// Classe que representa os dados do Pix.
/// </summary>
public class PixBoleto
{
    /// <summary>
    /// Código chave do pagador do Pix.
    /// </summary>
    [JsonProperty("chave")]
    public string ChavePagador { get; set; }

    /// <summary>
    /// Valor recebido via Pix.
    /// </summary>
    [JsonProperty("valorRecebido")]
    [JsonConverter(typeof(FormataDecimalConverter))]
    public decimal ValorPago { get; set; }

    /// <summary>
    /// Data e hora do recebimento via Pix.
    /// </summary>
    [JsonProperty("timestamp")]
    public string Pagamento { get; set; }

    /// <summary>
    /// Texto da mensagem de retorno do Pix.
    /// </summary>
    [JsonProperty("textoRetorno")]
    public string DescricaoRetorno { get; set; }

    /// <summary>
    /// Código identificador da instituição do pagador do Pix.
    /// </summary>
    [JsonProperty("idInstituicaoPagador")]
    public int CodigoBancoPagador { get; set; }

    /// <summary>
    /// Prefixo da agência do pagador do Pix.
    /// </summary>
    [JsonProperty("agenciaPagador")]
    public int AgenciaPagador { get; set; }

    /// <summary>
    /// Número da conta corrente do pagador do Pix.
    /// </summary>
    [JsonProperty("contaPagador")]
    public int ContaPagador { get; set; }

    /// <summary>
    /// Código do tipo de pessoa do pagador do Pix.
    /// Este valor pode ser 1 para Pessoa Física ou 2 para Pessoa Jurídica.
    /// </summary>
    [JsonProperty("tipoPessoaPagador")]
    public int TipoPessoaPagador { get; set; }

    /// <summary>
    /// Número do CPF ou CNPJ do pagador do Pix.
    /// </summary>
    [JsonProperty("idPagador")]
    public int DocumentoPagador { get; set; }
}

/// <summary>
/// Classe que representa os dados gerados do QR Code.
/// </summary>
public class QrCodeBoleto
{
    /// <summary>
    /// URL do payload do QR Code Pix.
    /// </summary>
    [JsonProperty("url")]
    public string Url { get; set; }

    /// <summary>
    /// Código que identifica a transação Pix - transactionID.
    /// </summary>
    [JsonProperty("txId")]
    public string TransacaoId { get; set; }

    /// <summary>
    /// BR Code no padrão EMV. Sequência de caracteres correspondente ao payload do QR Code Pix.
    /// </summary>
    [JsonProperty("emv")]
    public string CodigoEmv { get; set; }

    /// <summary>
    /// Código do tipo de QR Code do Pix.
    /// Este valor pode ser 1 para Estático ou 2 para Dinâmico.
    /// </summary>
    [JsonProperty("tipo", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Tipo { get; set; }
}