namespace BBNetCore.Constants;

/// <summary>
/// Classe com variaveis constantes de permissões
/// </summary>
public abstract class Permissao
{
    /// <summary>
    /// Permissão para alteração de cobranças
    /// </summary>
    public const string CobWrite = "cob.write";

    /// <summary>
    /// Permissão para consulta de cobranças
    /// </summary>
    public const string CobRead = "cob.read";

    /// <summary>
    /// Permissão para alteração de cobranças com vencimento
    /// </summary>
    public const string CobvWrite = "cobv.write";

    /// <summary>
    /// Permissão para consulta de cobranças com vencimento
    /// </summary>
    public const string CobvRead = "cobv.read";

    /// <summary>
    /// Permissão para consulta de pix
    /// </summary>
    public const string PixRead = "pix.read";

    /// <summary>
    /// Permissão para alteração de PixPaid
    /// </summary>
    public const string PixWrite = "pix.write";

    /// <summary>
    /// Permissão para consulta de lotes de cobranças com vencimento
    /// </summary>
    public const string LotecobvRead = "lotecobv.read";

    /// <summary>
    /// Permissão para alteração de lotes de cobranças com vencimento
    /// </summary>
    public const string LotecobvWrite = "lotecobv.write";

    /// <summary>
    /// Permissão para consulta do webhook
    /// </summary>
    public const string WebhookRead = "webhook.read";

    /// <summary>
    /// Permissão para alteração do webhook
    /// </summary>
    public const string WebhookWrite = "webhook.write";

    /// <summary>
    /// Permissão para consulta de payloads
    /// </summary>
    public const string PayloadLocationRead = "payloadlocation.read";

    /// <summary>
    /// Permissão para alteração de payloads
    /// </summary>
    public const string PayloadLocationWrite = "payloadlocation.write";

    /// <summary>
    /// Permite registrar e baixar boletos de cobrança
    /// </summary>
    public const string CobrancasBoletosWrite = "cobrancas.boletos-requisicao";

    /// <summary>
    /// Permite consultar detalhes de boletos de cobrança
    /// </summary>
    public const string CobrancasBoletosRead = "cobrancas.boletos-info";
}