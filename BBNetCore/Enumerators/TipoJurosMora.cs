namespace BBNetCore.Enumerators;

/// <summary>
/// Enum contendo códigos para identificar o tipo de juros do boleto de cobrança.
/// </summary>
public enum TipoJurosMora
{
    /// <summary>
    /// Dispensar os juros.
    /// </summary>
    Dispenar = 0,

    /// <summary>
    /// Valor por dia de atraso.
    /// </summary>
    ValorPorDiaAtraso = 1,

    /// <summary>
    /// Percentual de juros por mês de atraso.
    /// </summary>
    TaxaMensal = 2,

    /// <summary>
    /// Isento de juros.
    /// </summary>
    Isento = 3
}