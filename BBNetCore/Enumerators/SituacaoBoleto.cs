namespace BBNetCore.Enumerators;

/// <summary>
/// Enum contendo os códigos da situação atual do boleto.
/// </summary>
public enum SituacaoBoleto
{
    /// <summary>
    /// Estado normal do título
    /// </summary>
    Normal = 1,

    /// <summary>
    /// Título com movimento de cartório
    /// </summary>
    MovimentoCartorio = 2,

    /// <summary>
    /// Título em cartório
    /// </summary>
    EmCartorio = 3,

    /// <summary>
    /// Título com ocorrência de cartório
    /// </summary>
    TituloComOcorrenciaCartorio = 4,

    /// <summary>
    /// Título protestado eletronicamente
    /// </summary>
    ProtestadoEletronico = 5,

    /// <summary>
    /// Título liquidado
    /// </summary>
    Liquidado = 6,

    /// <summary>
    /// Título baixado
    /// </summary>
    Baixado = 7,

    /// <summary>
    /// Título com pendência de cartório
    /// </summary>
    TituloComPendenciaCartorio = 8,

    /// <summary>
    /// Título protestado manualmente
    /// </summary>
    TituloProtestadoManual = 9,

    /// <summary>
    /// Título baixado/pago em cartório
    /// </summary>
    TituloBaixadoPagoCartorio = 10,

    /// <summary>
    /// Título liquidado/protestado
    /// </summary>
    TituloLiquidadoProtestado = 11,

    /// <summary>
    /// Título liquidado/pago em cartório
    /// </summary>
    TituloLiquidadoProtestadoCartorio = 12,

    /// <summary>
    /// Título protestado aguardando baixa
    /// </summary>
    TituloProtestadoAguardandoBaixa = 13,

    /// <summary>
    /// Título em liquidação
    /// </summary>
    TituloEmLiquidacao = 14,

    /// <summary>
    /// Título agendado
    /// </summary>
    TituloAgendado = 15,

    /// <summary>
    /// Título creditado
    /// </summary>
    TituloCreditado = 16,

    /// <summary>
    /// Pago em cheque - aguardando liquidação
    /// </summary>
    PagoEmChequeAguardandoLiquidacao = 17,

    /// <summary>
    /// Pago parcialmente
    /// </summary>
    PagoParcialmente = 18,

    /// <summary>
    /// Pago parcialmente creditado
    /// </summary>
    PagoParcialmenteCreditado = 19,

    /// <summary>
    /// Título agendado COMPE
    /// </summary>
    TituloAgendadoCompe = 21,

    /// <summary>
    /// Em processamento (estado transitório)
    /// </summary>
    EmProcessamento = 80
}
