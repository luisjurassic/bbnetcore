namespace BBNetCore.Enumerators;

/// <summary>
/// Enum contendo os status de cobrança
/// </summary>
public enum StatusCobranca
{
    /// <summary>
    /// Cobrança ativa
    /// </summary>
    Ativa = 1,

    /// <summary>
    /// Cobrança concluida
    /// </summary>
    Concluida= 2,

    /// <summary>
    /// Removida pelo usuário recebedor
    /// </summary>
    RemovedPeloRecebedor = 3,

    /// <summary>
    /// Removida pelo usuário PSP
    /// </summary>
    RemovedPeloPsp = 4
}