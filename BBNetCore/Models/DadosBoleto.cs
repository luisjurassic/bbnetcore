using System;
using BBNetCore.Converters;
using BBNetCore.Enumerators;
using Newtonsoft.Json;

namespace BBNetCore.Models;

/// <summary>
/// Classe que representa os dados de uma solicitação de criação de boletos bancários.
/// </summary>
public class DadosBoleto
{
    /// <summary>
    /// Número do convênio de Cobrança do Cliente. Identificador determinado pelo sistema Cobrança para controlar
    /// a emissão de boletos, liquidação, crédito de valores ao Beneficiário e intercâmbio de dados com o cliente.
    /// </summary>
    [JsonProperty("numeroConvenio", Required = Required.Always)]
    public long Convenio { get; set; }

    /// <summary>
    /// Características do serviço de boleto bancário e como ele deve ser tratado pelo banco.
    /// </summary>
    [JsonProperty("numeroCarteira", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int Carteira { get; set; }

    /// <summary>
    /// Número da variação da carteira do convênio de cobrança.
    /// </summary>
    [JsonProperty("numeroVariacaoCarteira", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int VariacaoCarteira { get; set; }

    /// <summary>
    /// Identifica a característica dos boletos dentro das modalidades de cobrança existentes no banco.
    /// Domínio: 01 - SIMPLES; 04 - VINCULADA
    /// </summary>
    [JsonProperty("codigoModalidade", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(CodigoModalidadeConverter))]
    public CodigoModalidade CodigoModalidade { get; set; }

    /// <summary>
    /// Data de emissão do boleto (formato "dd.mm.aaaaa").
    /// </summary>
    [JsonProperty("dataEmissao", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(FormataDataConverter), "dd.MM.yyyy")]
    public DateTime Emissao { get; set; }

    /// <summary>
    /// Data de vencimento do boleto (formato "dd.mm.aaaaa").
    /// </summary>
    [JsonProperty("dataVencimento", Required = Required.Always)]
    [JsonConverter(typeof(FormataDataConverter), "dd.MM.yyyy")]
    public DateTime Vencimento { get; set; }

    /// <summary>
    /// Valor de cobrança > 0.00, emitido em Real (formato decimal separado por "."). Valor do boleto no registro.
    /// Deve ser maior que a soma dos campos “VALOR DO DESCONTO DO TÍTULO” e “VALOR DO ABATIMENTO DO TÍTULO”, se informados.
    /// Informação não passível de alteração após a criação.
    /// No caso de emissão com valor equivocado, sugerimos cancelar e emitir novo boleto.
    /// </summary>
    [JsonProperty("valorOriginal", Required = Required.Always)]
    [JsonConverter(typeof(FormataDecimalConverter))]
    public decimal Valor { get; set; }

    /// <summary>
    /// Valor de dedução do boleto >= 0.00 (formato decimal separado por ".").
    /// </summary>
    [JsonProperty("valorAbatimento")]
    [JsonConverter(typeof(FormataDecimalConverter))]
    public decimal ValorAbatimento { get; set; }

    /// <summary>
    /// Quantos dias após a data de vencimento do boleto para iniciar o processo de cobrança através de protesto.
    /// (valor inteiro >= 0).
    /// </summary>
    [JsonProperty("quantidadeDiasProtesto")]
    public int QtdDiasProtesto { get; set; }

    /// <summary>
    /// Quantos dias após a data de vencimento do boleto para iniciar o processo de negativação através da opção escolhida no campo orgaoNegativador.
    /// (valor inteiro >= 0).
    /// </summary>
    [JsonProperty("quantidadeDiasNegativacao")]
    public int QtdDiasNegativacao { get; set; }

    /// <summary>
    /// Código do Órgão Negativador.
    /// Domínio: 10 - SERASA
    /// </summary>
    [JsonProperty("orgaoNegativador")]
    public int OrgaoNegativador { get; set; }

    /// <summary>
    /// Indicador de que o boleto pode ou não ser recebido após o vencimento. Campo não obrigatório.
    /// Se não informado, será assumido a informação de limite de recebimento que está definida no convênio.
    /// <para></para> 
    /// Quando informado "S" em conjunto com o campo "numeroDiasLimiteRecebimento", será definido a quantidade de dias (corridos) que este boleto ficará disponível para pagamento após seu vencimento. Obs.: Se definido "S" e o campo "numeroDiasLimiteRecebimento" ficar com valor zero também será assumido a informação de limite de recebimento que está definida no convênio.
    /// <para></para>
    /// Quando informado "N", fica definindo que o boleto NÃO permite pagamento em atraso, portanto só aceitará pagamento até a data do vencimento ou o próximo dia útil, quando o vencimento ocorrer em dia não útil.
    /// <para></para>
    /// Quando informado qualquer valor diferente de "S" ou "N" será assumido a informação de limite de recebimento que está definida no convênio.
    /// </summary>
    [JsonProperty("indicadorAceiteTituloVencido")]
    [JsonConverter(typeof(AbreviacaoBoleanoConverter))]
    public bool AceiteTituloVencido { get; set; }

    /// <summary>
    /// Número de dias limite para recebimento. Informar valor inteiro > 0.
    /// </summary>
    [JsonProperty("numeroDiasLimiteRecebimento")]
    public int DiasLimiteRecebimento { get; set; }

    /// <summary>
    /// Código para identificar se o boleto de cobrança foi aceito (reconhecimento da dívida pelo Pagador).
    /// Domínios: A - ACEITE N - NAO ACEITE
    /// </summary>
    [JsonProperty("codigoAceite", Required = Required.Always)]
    [JsonConverter(typeof(CodigoAceiteConverter))]
    public CodigoAceite CodigoAceite { get; set; }

    /// <summary>
    /// Código para identificar o tipo de boleto de cobrança.
    /// Domínios: 1- CHEQUE 2- DUPLICATA MERCANTIL 3- DUPLICATA MTIL POR INDICACAO 4- DUPLICATA DE SERVICO
    /// 5- DUPLICATA DE SRVC P/INDICACAO 6- DUPLICATA RURAL 7- LETRA DE CAMBIO 8- NOTA DE CREDITO COMERCIAL
    /// 9- NOTA DE CREDITO A EXPORTACAO 10- NOTA DE CREDITO INDULTRIAL 11- NOTA DE CREDITO RURAL 12- NOTA PROMISSORIA
    /// 13- NOTA PROMISSORIA RURAL 14- TRIPLICATA MERCANTIL 15- TRIPLICATA DE SERVICO 16- NOTA DE SEGURO 17- RECIBO
    /// 18- FATURA 19- NOTA DE DEBITO 20- APOLICE DE SEGURO 21- MENSALIDADE ESCOLAR 22- PARCELA DE CONSORCIO
    /// 23- DIVIDA ATIVA DA UNIAO 24- DIVIDA ATIVA DE ESTADO 25- DIVIDA ATIVA DE MUNICIPIO 31- CARTAO DE CREDITO
    /// 32- BOLETO PROPOSTA 33- BOLETO APORTE 99- OUTROS.
    /// </summary>
    [JsonProperty("codigoTipoTitulo", Required = Required.Always)]
    public TipoTitulo TipoTitulo { get; set; }

    /// <summary>
    /// Descrição do tipo de boleto.
    /// </summary>
    [JsonProperty("descricaoTipoTitulo", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string DescricaoTipoTitulo { get; set; }

    /// <summary>
    /// Código para identificação da autorização de pagamento parcial do boleto.
    /// Domínios: S - SIM N - NÃO
    /// </summary>
    [JsonProperty("indicadorPermissaoRecebimentoParcial", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(AbreviacaoBoleanoConverter))]
    public bool PermiteRecebimentoParcial { get; set; }

    /// <summary>
    /// Número de identificação do boleto (correspondente ao SEU NÚMERO), no formato STRING (Limitado a 15 caracteres - Letras Maiúsculas).
    /// </summary>
    [JsonProperty("numeroTituloBeneficiario", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string NumeroTituloBeneficiario { get; set; }

    /// <summary>
    /// Informações adicionais sobre o beneficiário.
    /// </summary>
    [JsonProperty("campoUtilizacaoBeneficiario", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string InformacoesAdicionaisBeneficiario { get; set; }

    /// <summary>
    /// Número de identificação do boleto (correspondente ao NOSSO NÚMERO), no formato STRING, com 20 dígitos,
    /// que deverá ser formatado da seguinte forma:
    /// <para></para>
    /// “000” + (número do convênio com 7 dígitos) + (10 algarismos - se necessário, completar com zeros à esquerda).
    /// </summary>
    [JsonProperty("numeroTituloCliente", Required = Required.Always)]
    public string NossoNumero { get; set; }

    /// <summary>
    /// Mensagem definida pelo beneficiário para ser impressa no boleto. (Limitado a 30 caracteres)
    /// </summary>
    [JsonProperty("mensagemBloquetoOcorrencia", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string MensagemImpressaNoBoleto { get; set; }

    /// <summary>
    /// Define a ausência ou a forma como será concedido o desconto para o Título de Cobrança.
    /// </summary>
    [JsonProperty("desconto", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public DadosBoletoDesconto Desconto { get; set; }

    /// <summary>
    /// Define a ausência ou a forma como será concedido o segundo desconto para o Título de Cobrança.
    /// </summary>
    [JsonProperty("segundoDesconto", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public DadosBoletoSegundoDesconto SegundoDesconto { get; set; }

    /// <summary>
    /// Define a ausência ou a forma como será concedido o terceiro desconto para o Título de Cobrança.
    /// </summary>
    [JsonProperty("terceiroDesconto", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public DadosBoletoTerceiroDesconto TerceiroDesconto { get; set; }

    /// <summary>
    /// Código utilizado pela FEBRABAN para identificar o tipo de taxa de juros, sendo:
    /// 0 - DISPENSAR, 1 - VALOR DIA ATRASO, 2 - TAXA MENSAL, 3 - ISENTO.
    /// Se informado ‘0’ (zero) ou ‘3’ (três), os campos “PERCENTUAL DE JUROS DO TÍTULO” e
    /// “VALOR DO JUROS DO TÍTULO” não devem ser informados ou ser informados igual a ‘0’ (zero).
    /// <para></para>
    /// O valor de juros e multa incidem sobre o valor atual do boleto (valor do boleto - valor de abatimento).
    /// </summary>
    [JsonProperty("jurosMora", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public DadosBoletoJurosMora JurosMora { get; set; }

    /// <summary>
    /// Código utilizado pela FEBRABAN para identificar o tipo de taxa de juros, sendo:
    /// 0 - DISPENSAR, 1 - VALOR DIA ATRASO, 2 - TAXA MENSAL, 3 - ISENTO.
    /// Se informado ‘0’ (zero) ou ‘3’ (três), os campos “PERCENTUAL DE JUROS DO TÍTULO” e
    /// “VALOR DO JUROS DO TÍTULO” não devem ser informados ou ser informados igual a ‘0’ (zero).
    /// <para></para>
    /// O valor de juros e multa incidem sobre o valor atual do boleto (valor do boleto - valor de abatimento).
    /// </summary>
    [JsonProperty("multa", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public DadosBoletoMulta Multa { get; set; }

    /// <summary>
    /// Define os dados do pagador.
    /// </summary>
    [JsonProperty("pagador", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public DadosBoletoPagador Pagador { get; set; }

    /// <summary>
    /// Define os dados do beneficiário final.
    /// </summary>
    [JsonProperty("beneficiarioFinal", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public DadosBoletoBeneficiario Beneficiario { get; set; }

    /// <summary>
    /// Código para informar se o boleto terá um QRCode Pix atrelado. Se informado caracter inválido, assumirá 'N'.
    /// Domínios: 'S' - QRCODE DINAMICO; 'N' - SEM PIX; OUTRO - SEM PIX
    /// </summary>
    [JsonProperty("indicadorPix", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(AbreviacaoBoleanoConverter))]
    public bool GerarPix { get; set; }
}