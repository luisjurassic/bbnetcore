namespace BBNetCore.Enumerators;

/// <summary>
/// Enum contendo códigos para identificar o tipo de multa do boleto de cobrança.
/// </summary>
public enum TipoMulta
{
    /// <summary>
    /// Sem multa.
    /// </summary>
    SemMulta = 0,

    /// <summary>
    /// Valor fixo da multa.
    /// </summary>
    ValorFixo = 1,

    /// <summary>
    /// Percentual de multa.
    /// </summary>
    Percentual = 2
}