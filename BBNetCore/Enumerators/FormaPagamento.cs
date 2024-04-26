namespace BBNetCore.Enumerators;

/// <summary>
/// Enum contendo códigos para identificação da forma de pagamento que o boleto foi pago.
/// </summary>
public enum FormaPagamento
{
    /// <summary>
    /// Pendente.
    /// </summary>
    PagamentoPendente = 0,

    /// <summary>
    /// Espécie, agencias postos tradicionais.
    /// </summary>
    EspecieAgencias = 101,

    /// <summary>
    /// Espécie, terminal de auto-atendimento.
    /// </summary>
    EspecieAutoAtendimento = 102,

    /// <summary>
    /// Espécie, internet (home / office banking).
    /// </summary>
    EspecieInternet = 103,

    /// <summary>
    /// Espécie, correspondente bancário.
    /// </summary>
    EspecieCorrespondenteBancario = 105,

    /// <summary>
    /// Espécie, central de atendimento(call center).
    /// </summary>
    EspecieCallCenter = 106,

    /// <summary>
    /// Espécie, arquivo eletrônico
    /// </summary>
    EspecieArquivo = 107,

    /// <summary>
    /// Espécie, debito direto autorizado.
    /// </summary>
    EspecieDebito = 108,

    /// <summary>
    /// Espécie, pix.
    /// </summary>
    EspeciePix = 161,

    /// <summary>
    /// Débito em conta, agencias postos tradicionais.
    /// </summary>
    DebitoAgencias = 201,

    /// <summary>
    /// Débito em conta, terminal de auto-atendimento.
    /// </summary>
    DebitoAutoAtendimento = 202,

    /// <summary>
    /// Débito em conta, internet (home / office banking).
    /// </summary>
    DebitoInternet = 203,

    /// <summary>
    /// Débito em conta, correspondente bancário.
    /// </summary>
    DebitoCorrespondenteBancario = 205,

    /// <summary>
    /// Débito em conta, central de atendimento(call center).
    /// </summary>
    DebitoCallCenter = 206,

    /// <summary>
    /// Débito em conta, arquivo eletrônico
    /// </summary>
    DebitoArquivo = 207,

    /// <summary>
    /// Débito em conta, debito direto autorizado.
    /// </summary>
    DebitoDebito = 208,

    /// <summary>
    /// Débito em conta, pix.
    /// </summary>
    DebitoPix = 261,

    /// <summary>
    /// Cartão de crédito, agencias postos tradicionais.
    /// </summary>
    CartaoCreditoAgencias = 301,

    /// <summary>
    /// Cartão de crédito, terminal de auto-atendimento.
    /// </summary>
    CartaoCreditoAutoAtendimento = 302,

    /// <summary>
    /// Cartão de crédito, internet (home / office banking).
    /// </summary>
    CartaoCreditoInternet = 303,

    /// <summary>
    /// Cartão de crédito, correspondente bancário.
    /// </summary>
    CartaoCreditoCorrespondenteBancario = 305,

    /// <summary>
    /// Cartão de crédito, central de atendimento(call center).
    /// </summary>
    CartaoCreditoCallCenter = 306,

    /// <summary>
    /// Cartão de crédito, arquivo eletrônico
    /// </summary>
    CartaoCreditoArquivo = 307,

    /// <summary>
    /// Cartão de crédito, debito direto autorizado.
    /// </summary>
    CartaoCreditoDebito = 308,

    /// <summary>
    /// Cartão de crédito, pix.
    /// </summary>
    CartaoCreditoPix = 361,

    /// <summary>
    /// Cheque, agencias postos tradicionais.
    /// </summary>
    ChequeAgencias = 401,

    /// <summary>
    /// Cheque, terminal de auto-atendimento.
    /// </summary>
    ChequeAutoAtendimento = 402,

    /// <summary>
    /// Cheque, internet (home / office banking).
    /// </summary>
    ChequeInternet = 403,

    /// <summary>
    /// Cheque, correspondente bancário.
    /// </summary>
    ChequeCorrespondenteBancario = 405,

    /// <summary>
    /// Cheque, central de atendimento(call center).
    /// </summary>
    ChequeCallCenter = 406,

    /// <summary>
    /// Cheque, arquivo eletrônico
    /// </summary>
    ChequeArquivo = 407,

    /// <summary>
    /// Cheque, debito direto autorizado.
    /// </summary>
    ChequeDebito = 408,

    /// <summary>
    /// Cheque, pix.
    /// </summary>
    ChequePix = 461
}