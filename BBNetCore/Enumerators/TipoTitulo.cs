namespace BBNetCore.Enumerators;

/// <summary>
/// Enum contendo os identificadores do tipo de boleto de cobrança.
/// </summary>
public enum TipoTitulo
{
    /// <summary>
    /// Documento que ordena a um banco que pague uma quantia específica de uma conta específica.
    /// </summary>
    Cheque = 1,

    /// <summary>
    /// Título de crédito emitido por um vendedor com base em uma fatura de venda de mercadorias ou prestação de serviços.
    /// </summary>
    DuplicataMercantil = 2,

    /// <summary>
    /// Duplicata mercantil emitida com base em uma indicação.
    /// </summary>
    DuplicataMercantilPorIndicacao = 3,

    /// <summary>
    /// Título de crédito emitido com base em uma fatura de prestação de serviços.
    /// </summary>
    DuplicataServico = 4,

    /// <summary>
    /// Duplicata de serviço emitida com base em uma indicação.
    /// </summary>
    DuplicataServicoPorIndicacao = 5,

    /// <summary>
    /// Título de crédito emitido com base em uma fatura de venda de produtos agrícolas.
    /// </summary>
    DuplicataRural = 6,

    /// <summary>
    /// Documento que ordena a um indivíduo que pague uma quantia específica a outra pessoa em uma data futura específica.
    /// </summary>
    LetraCambio = 7,

    /// <summary>
    /// Documento emitido por um banco que promete pagar ao portador uma quantia específica.
    /// </summary>
    NotaCreditoComercial = 8,

    /// <summary>
    /// Documento emitido por um banco que promete pagar ao portador uma quantia específica relacionada a uma exportação.
    /// </summary>
    NotaCreditoExportacao = 9,

    /// <summary>
    /// Documento emitido por um banco que promete pagar ao portador uma quantia específica relacionada a uma indústria.
    /// </summary>
    NotaCreditoIndustrial = 10,

    /// <summary>
    /// Documento emitido por um banco que promete pagar ao portador uma quantia específica relacionada a uma atividade rural.
    /// </summary>
    NotaCreditoRural = 11,

    /// <summary>
    /// Documento em que o emissor promete incondicionalmente pagar uma quantia específica a outra pessoa em uma data futura específica.
    /// </summary>
    NotaPromissoria = 12,

    /// <summary>
    ///Nota promissória relacionada a uma atividade rural.
    /// </summary>
    NotaPromissoriaRural = 13,

    /// <summary>
    /// Duplicata mercantil emitida três vezes.
    /// </summary>
    TriplicataMercantil = 14,

    /// <summary>
    /// Duplicata de serviço emitida três vezes.
    /// </summary>
    TriplicataServico = 15,

    /// <summary>
    /// Documento que comprova a existência de um contrato de seguro.
    /// </summary>
    NotaSeguro = 16,

    /// <summary>
    /// Documento que comprova que uma determinada quantia foi recebida.
    /// </summary>
    Recibo = 17,

    /// <summary>
    /// Documento que detalha uma transação entre um vendedor e um comprador.
    /// </summary>
    Fatura = 18,

    /// <summary>
    /// Documento que registra uma dívida que deve ser paga.
    /// </summary>
    NotaDebito = 19,

    /// <summary>
    /// Contrato de seguro.
    /// </summary>
    ApoliceSeguro = 20,

    /// <summary>
    /// Quantia paga mensalmente para uma instituição de ensino.
    /// </summary>
    MensalidadeEscolar = 21,

    /// <summary>
    /// Quantia paga periodicamente por um membro de um consórcio.
    /// </summary>
    ParcelaConsorcio = 22,

    /// <summary>
    /// Dívida devida ao governo federal.
    /// </summary>
    DividaAtivaGovernoFederal = 23,

    /// <summary>
    /// Dívida devida a um governo estadual.
    /// </summary>
    DividaAtivaGovernoEstadual = 24,

    /// <summary>
    /// Dívida devida a um governo municipal.
    /// </summary>
    DividaAtivaGovernoMunicipal = 25,

    /// <summary>
    /// Meio de pagamento eletrônico.
    /// </summary>
    CartaoCredito = 31,

    /// <summary>
    /// Documento que propõe um pagamento.
    /// </summary>
    BoletoProposta = 32,

    /// <summary>
    /// Documento que registra um aporte de recursos.
    /// </summary>
    BoletoAporte = 33,

    /// <summary>
    /// Outros tipos de documentos não listados.
    /// </summary>
    Outros = 99
}
