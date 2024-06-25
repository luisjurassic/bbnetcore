using BBNetCore.Enumerators;

namespace BBNetCore.Utils;

/// <summary>
/// Classe que contem as ulr's padrões conforme o ambiente definido.
/// </summary>
internal abstract class ApiUrlBase
{
    /// <summary>
    /// URL padrão do serviço de sandbox.
    /// </summary>
    private const string SANDBOX_BASE_URL = "https://api.sandbox.bb.com.br";

    /// <summary>
    /// URL de autenticação padrão do serviço de sandbox.
    /// </summary>
    private const string SANDBOX_OAUTH_URL = "https://oauth.sandbox.bb.com.br";
    
    /// <summary>
    /// Url padrão do serviço PIX V2 em produção.
    /// </summary>
    private const string SANDBOX_BASE_URL_PIX = "https://api-pix.hm.bb.com.br";

    /// <summary>
    /// Url padrão do serviço de produção.
    /// </summary>
    private const string PRODUCTION_BASE_URL = "https://api.bb.com.br";

    /// <summary>
    /// Url padrão do serviço PIX V2 em produção.
    /// </summary>
    private const string PRODUCTION_BASE_URL_PIX = "https://api-pix.bb.com.br";

    /// <summary>
    /// URL de autenticação padrão do serviço de produção.
    /// </summary>
    private const string PRODUCTION_OAUTH_URL = "https://oauth.bb.com.br";

    /// <summary>
    /// Método que traz a url correta de acordo com a versão e ambiente definidos.
    /// </summary>
    /// <param name="environment">Ambiente de execução. <see cref="AmbienteApi"/></param>
    /// <param name="type">Tipo de serviço da API.<see cref="TipoApi"/></param>
    /// <returns>Url correta da API</returns>
    internal static string GetBaseUri(AmbienteApi environment, TipoApi type)
    {
        switch (environment)
        {
            default:
            case AmbienteApi.Desenvolvimento:
                return $"{GetUrlBaseHomologacao(type)}/{GetTipoApi(type)}/v2/";
            case AmbienteApi.Producao:
                return $"{GetUrlBaseProducao(type)}/{GetTipoApi(type)}/v2/";
        }
    }

    /// <summary>
    /// Método que identifica a url base de homologação, com base no tipo do serviço da API.
    /// </summary>
    /// <param name="type">Tipo de serviço da API.<see cref="TipoApi"/></param>
    /// <returns>A url base</returns>
    private static string GetUrlBaseHomologacao(TipoApi type)
    {
        switch (type)
        {
            case TipoApi.Pix:
                return SANDBOX_BASE_URL_PIX;
            default:
            case TipoApi.Boletos:
                return SANDBOX_BASE_URL;
        }
    }
    
    /// <summary>
    /// Método que identifica a url base de produção, com base no tipo do serviço da API.
    /// </summary>
    /// <param name="type">Tipo de serviço da API.<see cref="TipoApi"/></param>
    /// <returns>A url base</returns>
    private static string GetUrlBaseProducao(TipoApi type)
    {
        switch (type)
        {
            case TipoApi.Pix:
                return PRODUCTION_BASE_URL_PIX;
            default:
            case TipoApi.Boletos:
                return PRODUCTION_BASE_URL;
        }
    }

    /// <summary>
    /// Método que identifica a path que compoem a url da API, com base no tipo do serviço da API.
    /// </summary>
    /// <param name="type">Tipo de serviço da API.<see cref="TipoApi"/></param>
    /// <returns>Path que compoem a url da API</returns>
    private static string GetTipoApi(TipoApi type)
    {
        switch (type)
        {
            default:
            case TipoApi.Pix:
                return "pix";
            case TipoApi.Boletos:
                return "cobrancas";
        }
    }

    /// <summary>
    /// Método que traz a url de autenticação correta de acordo com a versão e ambiente definidos.
    /// </summary>
    /// <param name="environment">Ambiente de execução.<see cref="AmbienteApi"/></param>
    /// <returns>Url correta da API de autenticação</returns>
    internal static string GetOauthUri(AmbienteApi environment)
    {
        switch (environment)
        {
            default:
            case AmbienteApi.Desenvolvimento:
                return $"{SANDBOX_OAUTH_URL}/oauth/token/";
            case AmbienteApi.Producao:
                return $"{PRODUCTION_OAUTH_URL}/oauth/token/";
        }
    }
}