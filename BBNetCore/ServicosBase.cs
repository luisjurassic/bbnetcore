using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using BBNetCore.Enumerators;
using BBNetCore.Exceptions;
using BBNetCore.Models;
using BBNetCore.Utils;

namespace BBNetCore;

/// <summary>
/// Classe base para os serviços pix.
/// </summary>
public class ServicosBase
{
    /// <summary>
    /// Chave de api usada na autenticação do serviço.
    /// </summary>
    protected ConfiguracoesApiBB ConfiguracoesApiBb { get; set; }

    /// <summary>
    /// Token de acesso para authenticação.
    /// </summary>
    protected string TokenAccesso { get; private set; }

    /// <summary>
    /// Tipo do token de acesso.
    /// </summary>
    protected string TipoTokenAccesso { get; private set; }

    /// <summary>
    /// Data e hora em que o token de autenticação expira.
    /// </summary>
    private DateTime ExpiracaoTokenAccesso { get; set; }

    /// <summary>
    /// Tipo de serviço a ser usado pela API.
    /// </summary>
    private TipoApi TipoApi { get; set; }

    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="ServicosBase"/>.
    /// </summary>
    /// <param name="tipoApi">Tipo de serviço</param>
    /// <param name="configuracoesApiBb">Configurações do serviço.</param> 
    protected ServicosBase(TipoApi tipoApi, ConfiguracoesApiBB configuracoesApiBb)
    {
        TipoApi = tipoApi;
        ConfiguracoesApiBb = configuracoesApiBb;
    }

    /// <summary>
    /// Cria uma instancia de <see cref="ApiHttpClient"/> pronta para auxiliar nas requisições via HttpClient.
    /// </summary>
    /// <returns>Uma instancia de <see cref="ApiHttpClient"/></returns>
    protected ApiHttpClient CriarInstancia()
    {
        ApiHttpClient client = new(ApiUrlBase.GetBaseUri(ConfiguracoesApiBb.AmbienteApi, TipoApi))
        {
            AuthenticationHeader = new AuthenticationHeaderValue(TipoTokenAccesso, TokenAccesso),
            Certificate = ConfiguracoesApiBb.Certificado
        };
        return client;
    }

    /// <summary>
    /// Método de autenticação da API como uma operação assíncrona.
    /// </summary>
    /// <returns>Se autenticado com sucesso</returns>
    public async Task<bool> AutenticarAsync()
    {
        if (!string.IsNullOrWhiteSpace(TokenAccesso) && ExpiracaoTokenAccesso > DateTime.Now)
            return true;

        if (ConfiguracoesApiBb.Permissoes.Length == 0)
            throw new ArgumentException("Nenhuma permissão de recurso informada. Propriedade 'Scope' da classe 'PixOptions' sem itens.");

        ApiHttpClient client = new(ApiUrlBase.GetOauthUri(ConfiguracoesApiBb.AmbienteApi));

        var credentials = $"{ConfiguracoesApiBb.ClienteId}:{ConfiguracoesApiBb.ClienteSecret}";
        var encodedAuth = Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials));

        client.AuthenticationHeader = new AuthenticationHeaderValue("Basic", encodedAuth);

        TokenAcesso retorno = await client
            .PostAsync<TokenAcesso>(new Dictionary<string, string>
            {
                { "grant_type", ConfiguracoesApiBb.TipoFluxo },
                { "scope", string.Join(" ", ConfiguracoesApiBb.Permissoes) },
            }, MimeTypes.Form);

        TipoTokenAccesso = retorno.TokenType;
        TokenAccesso = retorno.Token;
        ExpiracaoTokenAccesso = DateTime.Now.AddSeconds(retorno.ExpiresIn);

        return false;
    }
}