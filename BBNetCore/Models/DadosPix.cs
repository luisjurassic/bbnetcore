using BBNetCore.Converters;
using BBNetCore.Enumerators;
using Newtonsoft.Json;

namespace BBNetCore.Models;

/// <summary>
/// Classe que representa os dados enviados para criação ou alteração da cobrança imediata.
/// </summary>
public class DadosPix
{
    /// <summary>
    /// Informações a respeito de controle de tempo da cobrança.
    /// </summary>
    [JsonProperty("calendario")]
    public DadosCalendario Calendar { get; set; }

    /// <summary>
    /// Identificador da transação.
    /// <para>
    /// O campo txid, obrigatório, determina o identificador da transação.
    /// O objetivo desse campo é ser um elemento que possibilite ao PSP do
    /// recebedor apresentar ao usuário recebedor a funcionalidade de conciliação de pagamentos.
    /// </para>
    /// <para>
    /// Na pacs.008, é referenciado como TransacaoIdentification ou idConciliacaoRecebedor.
    /// </para>
    /// <para>
    /// Em termos de fluxo de funcionamento, o txid é lido pelo aplicativo do PSP do pagador e,
    /// depois de confirmado o pagamento, é enviado para o SPI via pacs.008.
    /// Uma pacs.008 também é enviada ao PSP do recebedor, contendo, além de
    /// todas as informações usuais do pagamento, o txid. Ao perceber um recebimento dotado de txid,
    /// o PSP do recebedor está apto a se comunicar com o usuário recebedor,
    /// informando que um pagamento específico foi liquidado.
    /// </para>
    /// <para>
    /// O txid é criado exclusivamente pelo usuário recebedor e está sob sua responsabilidade.
    /// O txid, no contexto de representação de uma cobrança, é único por CPF/CNPJ do usuário recebedor.
    /// Cabe ao PSP recebedor validar essa regra na API PixPaid.
    /// </para>
    /// </summary>
    [JsonProperty("txid")]
    public string TransacaoId { get; set; }

    /// <summary>
    /// Revisão da cobrança. Sempre começa em zero. Sempre varia em acréscimos de 1.
    /// </summary>
    [JsonProperty("revisao", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int Revisao { get; set; }

    /// <summary>
    /// Identificador da localização do payload.
    /// </summary>
    [JsonProperty("loc", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public DadosLocalizacao Localizacao { get; set; }

    /// <summary>
    /// Localização do payload
    /// </summary>
    [JsonProperty("location", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string LocalizacaoPayload { get; set; }

    /// <summary>
    /// BillingStatus da Cobrança
    /// </summary>
    [JsonProperty("status", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(StatusCobrancaConverter))]
    public StatusCobranca StatusCobranca { get; set; }

    /// <summary>
    /// Identificam o devedor, ou seja, a pessoa ou a instituição a quem a cobrança está endereçada.
    /// Não identifica, necessariamente, quem irá efetivamente realizar o pagamento.
    /// Um CPF pode ser o devedor de uma cobrança, mas pode acontecer de outro CPF realizar, efetivamente, o pagamento do documento.
    /// Não é permitido que o campo devedor.cpf e campo devedor.cnpj estejam preenchidos ao mesmo tempo.
    /// Se o campo devedor.cnpj está preenchido, então o campo devedor.cpf não pode estar preenchido, e vice-versa.
    /// Se o campo devedor.nome está preenchido, então deve existir ou um devedor.cpf ou um campo devedor.cnpj preenchido.
    /// </summary>
    [JsonProperty("devedor", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public DadosDevedor Devedor { get; set; }

    /// <summary>
    /// Valores monetários referentes à cobrança.
    /// </summary>
    [JsonProperty("valor")]
    public DadosValores Valores { get; set; }

    /// <summary>
    /// Chave DICT do recebedor
    /// <remarks>
    /// <para>
    /// Formato do campo chave
    /// </para>
    /// <para>O campo chave, obrigatório, determina a chave PixPaid registrada no DICT que será utilizada para a cobrança.
    /// Essa chave será lida pelo aplicativo do PSP do pagador para consulta ao DICT,
    /// que retornará a informação que identificará o recebedor da cobrança.
    /// </para>
    /// <para>
    /// Os tipos de chave podem ser: telefone, e-mail, cpf/cnpj ou EVP.
    /// </para>
    /// <para>
    /// O formato das chaves pode ser encontrado na seção "Formatação das chaves do DICT no BR Code"
    /// do Manual de Padrões para iniciação do PixPaid(https://www.bcb.gov.br/estabilidadefinanceira/pix).
    /// </para>
    /// </remarks>
    /// </summary>
    [JsonProperty("chave")]
    public string ChavePix { get; set; }

    /// <summary>
    /// Solicitação ao pagador
    /// <para>
    /// O campo solicitacaoPagador, opcional, determina um texto a ser apresentado ao pagador para que
    /// ele possa digitar uma informação correlata, em formato livre, a ser enviada ao recebedor.
    /// Esse texto será preenchido, na pacs.008, pelo PSP do pagador, no campo RemittanceInformation.
    /// O tamanho do campo na pacs.008 está limitado a 140 caracteres.
    /// </para>
    /// </summary>
    [JsonProperty("solicitacaoPagador", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string DecricaoCobranca { get; set; }

    /// <summary>
    /// Informações adicionais. Cada respectiva informação adicional contida na lista (nome e valor) deve ser apresentada ao pagador.
    /// </summary>
    [JsonProperty("infoAdicionais", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public DadosInformacoesAdicionais[] InformacoesAdicionais { get; set; }

    /// <summary>
    /// Conteudo da imagem do QR Code para usar no copiar e colar.
    /// </summary>
    [JsonProperty("pixCopiaECola", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string PixCopiaCola { get; set; }

    /// <summary>
    /// Dados de pagamento efetuado
    /// </summary>
    [JsonProperty("pix", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public DadosPagamentoPix[] DadosPagamentoPix { get; set; }
}