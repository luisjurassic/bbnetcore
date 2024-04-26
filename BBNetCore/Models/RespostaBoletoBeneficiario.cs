using Newtonsoft.Json;

namespace BBNetCore.Models;

/// <summary>
/// Clase que representa os dados do beneficiário.
/// </summary>
public class RespostaBoletoBeneficiario
{
    /// <summary>
    /// Agência do beneficiário.
    /// </summary>
    [JsonProperty("id")]
    public int Agencia { get; set; }

    /// <summary>
    /// Número da conta corrente do beneficiário.
    /// </summary>
    [JsonProperty("contaCorrente")]
    public int ContaCorrente { get; set; }

    /// <summary>
    /// Código do tipo de endereço do beneficiário.
    /// </summary>
    [JsonProperty("tipoEndereco")]
    public int TipoEndereco { get; set; }

    /// <summary>
    /// Nome do logradouro do beneficiário.
    /// </summary>
    [JsonProperty("logradouro")]
    public string Logradouro { get; set; }

    /// <summary>
    /// Bairro do Beneficiário.
    /// </summary>
    [JsonProperty("bairro")]
    public string Bairro { get; set; }

    /// <summary>
    /// Cidade do Beneficiário.
    /// </summary>
    [JsonProperty("cidade")]
    public string Cidade { get; set; }

    /// <summary>
    /// Identificador da cidade do beneficiário.
    /// </summary>
    [JsonProperty("codigoCidade")]
    public int CodigoCidade { get; set; }

    /// <summary>
    /// Sigla do Estado do beneficiário.
    /// </summary>
    [JsonProperty("uf")]
    public string UF { get; set; }

    /// <summary>
    /// Código Postal do Beneficiário.
    /// </summary>
    [JsonProperty("cep")]
    public int CEP { get; set; }

    /// <summary>
    /// Indicador de prova de vida do beneficiário.
    /// </summary>
    [JsonProperty("indicadorComprovacao")]
    public string ProvaDeVida { get; set; }
}