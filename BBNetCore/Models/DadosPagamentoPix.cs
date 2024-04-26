using System;
using BBNetCore.Converters;
using Newtonsoft.Json;

namespace BBNetCore.Models;

/// <summary>
/// Classe que representa os dados de um pagamento.
/// </summary>
public class DadosPagamentoPix
{
    /// <summary>
    /// Id fim a fim da transação
    /// </summary>
    [JsonProperty("endToEndId")]
    public string EndToEndId { get; set; }

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
    /// Valor do PixPaid.
    /// </summary>
    [JsonProperty("valor")]
    [JsonConverter(typeof(FormataDecimalConverter))]
    public decimal Valor { get; set; }

    /// <summary>
    /// Horário em que o PixPaid foi processado no PSP.
    /// </summary>
    [JsonProperty("horario")]
    [JsonConverter(typeof(FormataDataConverter), "yyyy-MM-ddTHH:mm:ss")]
    public DateTime DataProcessamento { get; set; }

    /// <summary>
    /// Informação livre do pagador
    /// </summary>
    [JsonProperty("infoPagador")]
    public string InfoPagador { get; set; }

    /// <summary>
    /// Dados da devolução
    /// </summary>
    [JsonProperty("devolucoes")]
    public DadosDevolucoes[] devolucoes { get; set; }
}

