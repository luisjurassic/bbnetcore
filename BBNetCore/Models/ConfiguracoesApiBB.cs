using System.Security.Cryptography.X509Certificates;
using BBNetCore.Constants;
using BBNetCore.Enumerators;

namespace BBNetCore.Models;

/// <summary>
/// Classe responsavel pela configuração e preparação da comunicação da API.
/// </summary>
public class ConfiguracoesApiBB
{
    /// <summary>
    /// É a credencial para acionar as APIS do Banco do Brasil.
    /// </summary>
    public string ChaveApp { get; set; }

    /// <summary>
    /// É o identificador público e único no OAuth do Banco do Brasil.
    /// </summary>    
    public string ClienteId { get; set; }

    /// <summary>
    /// É conhecido apenas para sua aplicação e o servidor de autorização. Por isso, tome muito cuidado com seu armazenamento.
    /// Em caso de suspeita de fraude, deverá acessar suas Credenciais dentro da sua Aplicação e realizar a troca do mesmo.
    /// </summary>    
    public string ClienteSecret { get; set; }

    /// <summary>
    /// Typo de fluxo de requisição. Padrão 'client_credentials'.
    /// </summary>
    public string TipoFluxo { get; set; } = "client_credentials";

    /// <summary>
    /// Permissões de acesso aos recursos da API.
    /// </summary>
    public string[] Permissoes { get; private set; } =
    [
        Permissao.CobRead,
        Permissao.CobWrite,
        Permissao.CobvRead,
        Permissao.CobvWrite,
        Permissao.PixRead,
        Permissao.PixWrite,
        Permissao.CobrancasBoletosRead,
        Permissao.CobrancasBoletosWrite
    ];

    /// <summary>
    /// Tipo de ambiente.
    /// </summary>    
    public AmbienteApi AmbienteApi { get; set; } = AmbienteApi.Desenvolvimento;

    /// <summary>
    /// Certficado de assinatura digital
    /// </summary>
    public X509Certificate2 Certificado { get; set; }
}