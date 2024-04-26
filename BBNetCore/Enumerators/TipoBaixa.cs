namespace BBNetCore.Enumerators;

/// <summary>
/// Enum contendo os códigos para identificação do tipo de baixa do boleto.
/// </summary>
public enum TipoBaixa
{
    /// <summary>
    /// Baixado por solicitação
    /// </summary>
    BaixadoPorSolicitacao = 1,

    /// <summary>
    /// Entrega franco pagamento
    /// </summary>
    EntregaFrancoPagamento = 2,

    /// <summary>
    /// Comandada banco
    /// </summary>
    ComandadaBanco = 9,

    /// <summary>
    /// Comandada cliente - Arquivo
    /// </summary>
    ComandadaClienteArquivo = 10,

    /// <summary>
    /// Comandada cliente - On-line
    /// </summary>
    ComandadaClienteOnline = 11,

    /// <summary>
    /// Decurso prazo - Cliente
    /// </summary>
    DecursoPrazoCliente = 12,

    /// <summary>
    /// Decurso prazo - Banco
    /// </summary>
    DecursoPrazoBanco = 13,

    /// <summary>
    /// Protestado
    /// </summary>
    Protestado = 15,

    /// <summary>
    /// Liquidado anteriormente
    /// </summary>
    LiquidadoAnteriormente = 31,

    /// <summary>
    /// Habilitado em processo
    /// </summary>
    HabilitadoEmProcesso = 32,

    /// <summary>
    /// Transferido para perdas
    /// </summary>
    TransferidoParaPerdas = 35,

    /// <summary>
    /// Registrado indevidamente
    /// </summary>
    RegistradoIndevidamente = 51,

    /// <summary>
    /// Baixa automática
    /// </summary>
    BaixaAutomatica = 90
}