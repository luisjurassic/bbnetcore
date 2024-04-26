namespace BBNetCore.Enumerators;

/// <summary>
/// Enum contendo os códigos para identificação das ocorrências de retorno do cartório.
/// </summary>
public enum OcorrenciasCartorio
{
    /// <summary>
    /// Título protocolado - Antigo "TEC"
    /// </summary>
    TituloProtocoladoTec = 0,

    /// <summary>
    /// Título pago em cartório
    /// </summary>
    TituloPagoEmCartorio = 1,

    /// <summary>
    /// Título protestado - Antigo "DDP"
    /// </summary>
    TituloProtestadoDdp = 2,

    /// <summary>
    /// Título retirado cartório - Antigo DDS
    /// </summary>
    TituloRetiradoCartorioDds = 3,

    /// <summary>
    /// Título sustado judicialmente
    /// </summary>
    TituloSustadoJudicialmente = 4,

    /// <summary>
    /// Título recusado sem custas
    /// </summary>
    TituloRecusadoSemCustas = 5,

    /// <summary>
    /// Título recusado com custas
    /// </summary>
    TituloRecusadoComCustas = 6,

    /// <summary>
    /// Título pago liquidação condicional
    /// </summary>
    TituloPagoLiquidacaoCondicional = 7,

    /// <summary>
    /// Título aceito
    /// </summary>
    TituloAceito = 8,

    /// <summary>
    /// Custas de edital
    /// </summary>
    CustasEdital = 9,

    /// <summary>
    /// LQ. Cartório AG. Semi-Autom.
    /// </summary>
    LiquidadoCartorioSemiAutomatico = 20,

    /// <summary>
    /// CHQ Devolv. Tit. Enc. Prot.
    /// </summary>
    ChequeDevolvidoEncerramentoProtesto = 21,

    /// <summary>
    /// Título sustado definitivo
    /// </summary>
    TituloSustadoDefinitivo = 22,

    /// <summary>
    /// Retirada após sustação judicial
    /// </summary>
    RetiradaAposSustacaoJudicial = 23,

    /// <summary>
    /// Pagto condicional via SELTEC
    /// </summary>
    PagamentoCondicionalSeltec = 59,

    /// <summary>
    /// Título pago em cartório-SELTEC
    /// </summary>
    TituloPagoEmCartorioSeltec = 60
}