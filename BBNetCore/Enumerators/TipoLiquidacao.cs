namespace BBNetCore.Enumerators;

/// <summary>
/// Enum contendo códigos para identificação do tipo de liquidação.
/// </summary>
public enum TipoLiquidacao
{
    /// <summary>
    /// Caixa
    /// </summary>
    Caixa = 1,

    /// <summary>
    /// Via COMPE
    /// </summary>
    ViaCompe = 2,

    /// <summary>
    /// Em cartório
    /// </summary>
    EmCartorio = 3,

    /// <summary>
    /// PIX
    /// </summary>
    Pix = 4,

    /// <summary>
    /// Título em liquidação - Origem AGE
    /// </summary>
    TituloEmLiquidacaoAge = 5,

    /// <summary>
    /// Título em liquidação - PGT
    /// </summary>
    TituloEmLiquidacaoPgt = 6,

    /// <summary>
    /// Banco Postal
    /// </summary>
    BancoPostal = 7,

    /// <summary>
    /// Título liquidado via COMPE/STR
    /// </summary>
    TituloLiquidadoCompeStr = 8
}