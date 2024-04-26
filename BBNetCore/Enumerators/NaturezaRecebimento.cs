namespace BBNetCore.Enumerators;

/// <summary>
/// Enum contendo códigos para identificar as ocorrências (rejeições, tarifas, custas, liquidação e baixas) do boleto.
/// </summary>
public enum NaturezaRecebimento
{
    /// <summary>
    /// Estado normal da conta
    /// </summary>
    Normal = 1,

    /// <summary>
    /// Por conta
    /// </summary>
    PorConta = 2,

    /// <summary>
    /// Por saldo
    /// </summary>
    PorSaldo = 3,

    /// <summary>
    /// Cheque a compensar
    /// </summary>
    ChequeACompensar = 4,

    /// <summary>
    /// Liquidado na apresentação
    /// </summary>
    LiquidadoNaApresentacao = 7,

    /// <summary>
    /// Por conta em cartório
    /// </summary>
    PorContaEmCartorio = 8,

    /// <summary>
    /// Em cartório
    /// </summary>
    EmCartorio = 9
}