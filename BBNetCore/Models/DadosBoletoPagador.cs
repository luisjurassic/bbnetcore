using BBNetCore.Converters;
using BBNetCore.Enumerators;
using Newtonsoft.Json;

namespace BBNetCore.Models;

/// <summary>
/// Clase que representa os dados do pagador.
/// </summary>
public class DadosBoletoPagador
{
    /// <summary>
    /// Código que identifica o tipo de inscrição do Pagador.
    /// Domínios: 1 - CPF; 2 - CNPJ
    /// </summary>
    [JsonProperty("tipoInscricao", Required = Required.Always)]
    [JsonConverter(typeof(TipoInscricaoConverter))]
    public TipoInscricao TipoInscricao { get; set; }

    /// <summary>
    /// Número de inscrição do pagador. Para o tipo = 1, informar numero do CPF. Para o tipo = 2, informar numero do CNPJ.
    /// </summary>
    [JsonProperty("numeroInscricao", Required = Required.Always)]
    public string NumeroInscricao { get; set; }

    /// <summary>
    /// Nome do pagador.
    /// </summary>
    [JsonProperty("nome", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Nome { get; set; }

    /// <summary>
    /// Endereço do pagador.
    /// </summary>
    [JsonProperty("endereco", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Endereco { get; set; }

    /// <summary>
    /// Código postal do pagador.
    /// </summary>
    [JsonProperty("cep", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string CEP { get; set; }

    /// <summary>
    /// Cidade do pagador.
    /// </summary>
    [JsonProperty("cidade", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Cidade { get; set; }

    /// <summary>
    /// Bairro do pagador.
    /// </summary>
    [JsonProperty("bairro", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Bairro { get; set; }

    /// <summary>
    /// Sigla do unidade federativa em que o pagador vive.
    /// </summary>
    [JsonProperty("uf", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string UF { get; set; }

    /// <summary>
    /// Número de telefone do pagador.
    /// </summary>
    [JsonProperty("telefone", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Telefone { get; set; }

    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="DadosBoletoPagador"/>.
    /// </summary>
    public DadosBoletoPagador()
    {
    }

    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="DadosBoletoPagador"/>.
    /// </summary>
    /// <param name="tipoInscricao">Tipo de inscrição da pessoa, física ou jurídica.</param>
    /// <param name="numeroInscricao">Número do documento de inscrição (CPF ou CNPJ).</param>
    public DadosBoletoPagador(TipoInscricao tipoInscricao, string numeroInscricao)
    {
        TipoInscricao = tipoInscricao;
        NumeroInscricao = numeroInscricao;
    }
}