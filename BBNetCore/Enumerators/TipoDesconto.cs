namespace BBNetCore.Enumerators;

/// <summary>
/// Enum contendo códigos para identificar de desconto do boleto de cobrança.
/// </summary>
public enum TipoDesconto
{
    /// <summary>
    /// Sem desconto.
    /// </summary>
    SemDesconto = 0,

    /// <summary>
    /// Valor fixo até a data informada.
    /// </summary>
    ValorFixo = 1,

    /// <summary>
    /// Percentual até a data informada.
    /// </summary>
    Percentual = 2,

    /// <summary>
    /// Desconto por dia de antecipação.
    /// </summary>
    PorDiaDeAntecipacao = 3
}