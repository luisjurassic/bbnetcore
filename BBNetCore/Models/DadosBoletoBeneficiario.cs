using BBNetCore.Converters;
using BBNetCore.Enumerators;
using Newtonsoft.Json;

namespace BBNetCore.Models;

/// <summary>
/// Clase que representa os dados do beneficiário final.
/// </summary>
public class DadosBoletoBeneficiario
{
    /// <summary>
    /// Código que identifica o tipo de inscrição do beneficiário final.
    /// Domínios: 1 - CPF; 2 - CNPJ
    /// </summary>
    [JsonProperty("tipoInscricao", Required = Required.Always)]
    [JsonConverter(typeof(TipoInscricaoConverter))]
    public TipoInscricao TipoInscricao { get; set; }

    /// <summary>
    /// Número de registro do beneficiário final. Para o tipo = 1, informar numero do CPF. Para o tipo = 2, informar numero do CNPJ.
    /// </summary>
    [JsonProperty("numeroInscricao", Required = Required.Always)]
    public string NumeroInscricao { get; set; }

    /// <summary>
    /// Nome do beneficiário final
    /// </summary>
    [JsonProperty("nome", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Nome { get; set; }


    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="DadosBoletoBeneficiario"/>.
    /// </summary>
    public DadosBoletoBeneficiario()
    {
    }

    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="DadosBoletoBeneficiario"/>.
    /// </summary>
    /// <param name="tipoInscricao">Tipo de inscrição da pessoa, física ou jurídica.</param>
    /// <param name="numeroInscricao">Número do documento de inscrição (CPF ou CNPJ).</param>
    /// <param name="nome">Nome do beneficiário.</param>
    public DadosBoletoBeneficiario(TipoInscricao tipoInscricao, string numeroInscricao, string nome = null)
    {
        TipoInscricao = tipoInscricao;
        NumeroInscricao = numeroInscricao;
        Nome = nome;
    }
}