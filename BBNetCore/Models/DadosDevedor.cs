using Newtonsoft.Json;

namespace BBNetCore.Models;

/// <summary>
/// Classe contendo dados que identificam o devedor, ou seja, a pessoa ou a instituição a quem a cobrança está endereçada.
/// </summary>
public class DadosDevedor
{
    /// <summary>
    /// CNPJ do devedor, para cobranças de pessoa juridica.
    /// </summary>
    [JsonProperty("cnpj", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Cnpj { get; set; }

    /// <summary>
    ///  CPF do devedor, para cobranças de pessoa fisca.
    /// </summary>
    [JsonProperty("cpf", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Cpf { get; set; }

    /// <summary>
    /// Nome do devedor
    /// </summary>
    [JsonProperty("nome")]
    public string Nome { get; set; }

    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="DadosDevedor"/>.
    /// </summary>
    public DadosDevedor()
    {
    }

    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="DadosDevedor"/>.
    /// </summary>
    /// <param name="documento">CPF ou CNPJ do devedor</param>
    /// <param name="nome">Nome do devedor</param>
    public DadosDevedor(string documento, string nome)
    {
        Nome = nome;
        switch (documento.Length)
        {
            case 11:
                Cpf = documento;
                break;
            case 14:
                Cnpj = documento;
                break;
        }
    }
}