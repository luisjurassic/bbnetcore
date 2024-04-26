using System;
using BBNetCore.Converters;
using BBNetCore.Enumerators;
using Newtonsoft.Json;

namespace BBNetCore.Models;

/// <summary>
/// Classe que representa os dados de resposta de uma solicitação de detalhamento de boletos bancários.
/// </summary>
public class RespostaConsultaBoleto
{
    /// <summary>
    /// Campo correpondente à linha digitável do boleto.
    /// </summary>
    [JsonProperty("codigoLinhaDigitavel", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string LinhaDigitavel { get; set; }

    /// <summary>
    /// E-mail do Pagador.
    /// </summary>
    [JsonProperty("textoEmailPagador", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string textoEmailPagador { get; set; }

    /// <summary>
    /// Mensagem para ser impressa no boleto.
    /// </summary>
    [JsonProperty("textoMensagemBloquetoTitulo", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string MensagemImpressaBoleto { get; set; }

    /// <summary>
    /// Código para identificação do tipo de multa para o Título de Cobrança.
    /// Domínios: 0 - Sem multa 1 - Valor da Multa 2 - Percentual da Multa.
    /// </summary>
    [JsonProperty("codigoTipoMulta", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(TipoMultaConverter))]
    public TipoMulta TipoMulta { get; set; }

    /// <summary>
    /// Código para identificação da forma de pagamento que foi pago o boleto.
    /// O primeiro dígito é:
    /// 1 Espécie
    /// 2 Débito em conta
    /// 3 Cartão de crédito
    /// 4 Cheque
    /// <para></para>
    /// Os dois últimos:
    /// 01 Agencias - Postos tradicionais
    /// 02 Terminal de Auto-atendimento
    /// 03 Internet (home / office banking)
    /// 05 Correspondente bancário
    /// 06 Central de atendimento(Call Center)
    /// 07 Arquivo Eletrônico
    /// 08 DDA
    /// 61 Pix
    /// </summary>
    [JsonProperty("codigoCanalPagamento", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(FormaPagamentoConverter))]
    public FormaPagamento FormaPagamento { get; set; }

    /// <summary>
    /// Código adotado pelo Banco para identificar o Contrato entre este e a Empresa Cliente.
    /// </summary>
    [JsonProperty("numeroContratoCobranca", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public long NumeroContrato { get; set; }

    /// <summary>
    /// Código que identifica o tipo de inscrição da Empresa ou Pessoa Física perante uma Instituição governamental.
    /// Domínios: 1 - CPF 2 - CNPJ
    /// </summary>
    [JsonProperty("codigoTipoInscricaoSacado", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(TipoInscricaoConverter))]
    public TipoInscricao TipoInscricao { get; set; }

    /// <summary>
    /// Número de inscrição da Empresa ou Pessoa Física perante uma Instituição governamental.
    /// </summary>
    [JsonProperty("numeroInscricaoSacadoCobranca", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string NumeroInscricao { get; set; }

    /// <summary>
    /// Código da situação atual do boleto.
    /// Domínios:
    /// 1 - NORMAL
    /// 2 - MOVIMENTO CARTORIO
    /// 3 - EM CARTORIO
    /// 4 - TITULO COM OCORRENCIA DE CARTORIO
    /// 5 - PROTESTADO ELETRONICO
    /// 6 - LIQUIDADO
    /// 7 - BAIXADO
    /// 8 - TITULO COM PENDENCIA DE CARTORIO
    /// 9 - TITULO PROTESTADO MANUAL
    /// 10 - TITULO BAIXADO/PAGO EM CARTORIO
    /// 11 - TITULO LIQUIDADO/PROTESTADO
    /// 12 - TITULO LIQUID/PGCRTO
    /// 13 - TITULO PROTESTADO AGUARDANDO BAIXA
    /// 14 - TITULO EM LIQUIDACAO
    /// 15 - TITULO AGENDADO
    /// 16 - TITULO CREDITADO
    /// 17 - PAGO EM CHEQUE - AGUARD.LIQUIDACAO
    /// 18 - PAGO PARCIALMENTE
    /// 19 - PAGO PARCIALMENTE CREDITADO
    /// 21 - TITULO AGENDADO COMPE
    /// 80 - EM PROCESSAMENTO (ESTADO TRANSITÓRIO)
    /// </summary>
    [JsonProperty("codigoEstadoTituloCobranca", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(SituacaoBoletoConverter))]
    public SituacaoBoleto SituacaoBoleto { get; set; }

    /// <summary>
    /// Código para identificar o tipo de boleto de cobrança.
    /// Domínios:
    /// 1 - CHEQUE 2 - DUPLICATA MERCANTIL 3 - DUPLICATA MTIL POR INDICACAO 4 - DUPLICATA DE SERVICO
    /// 5 - DUPLICATA DE SRVC P/INDICACAO 6 - DUPLICATA RURAL 7 - LETRA DE CAMBIO 8 - NOTA DE CREDITO COMERCIAL
    /// 9 - NOTA DE CREDITO A EXPORTACAO 10 - NOTA DE CREDITO INDULTRIAL 11 - NOTA DE CREDITO RURAL
    /// 12 - NOTA PROMISSORIA 13 - NOTA PROMISSORIA RURAL 14 - TRIPLICATA MERCANTIL 15 - TRIPLICATA DE SERVICO
    /// 16 - NOTA DE SEGURO 17 - RECIBO 18 - FATURA 19 - NOTA DE DEBITO 20 - APOLICE DE SEGURO 21 - MENSALIDADE ESCOLAR
    /// 22 - PARCELA DE CONSORCIO 23 - DIVIDA ATIVA DA UNIAO 24 - DIVIDA ATIVA DE ESTADO 25 - DIVIDA ATIVA DE MUNICIPIO
    /// 31 - CARTAO DE CREDITO 32 - BOLETO PROPOSTA 99 - OUTROS
    /// </summary>
    [JsonProperty("codigoTipoTituloCobranca", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(TipoTituloConverter))]
    public TipoTitulo TipoTitulo { get; set; }

    /// <summary>
    /// Código para identificar a característica dos boletos dentro das modalidades de cobrança existentes no banco.
    /// Domínios: 1 - SIMPLES 4 - VINCULADA
    /// </summary>
    [JsonProperty("codigoModalidadeTitulo", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(CodigoModalidadeConverter))]
    public int codigoModalidadeTitulo { get; set; }

    /// <summary>
    /// Código para identificar se o boleto de cobrança foi aceito (reconhecimento da dívida pelo Pagador).
    /// Domínios: A - ACEITE N - NAO ACEITE
    /// </summary>
    [JsonProperty("codigoAceiteTituloCobranca", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(CodigoAceiteConverter))]
    public CodigoAceite codigoAceiteTituloCobranca { get; set; }

    /// <summary>
    /// Código agência da praça do pagador (endereço).
    /// </summary>
    [JsonProperty("codigoPrefixoDependenciaCobrador", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int CodigoPrefixoDependenciaCobrador { get; set; }

    /// <summary>
    /// Código para identificar a moeda referenciada no boleto.
    /// Domínios: 0 - NENHUM 1 - FAJTR 2 - DOLAR 3 - EURO 4 - IENE 5 - MARCO ALEMAO 6 - FTR 7 - IDTR 8 - UFIR
    /// 9 - REAL 10 - SELIC 11 - IGP-M 12 - INPC 13 - TR (BESC)
    /// </summary>
    [JsonProperty("codigoIndicadorEconomico", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(TipoMoedaConverter))]
    public TipoMoeda codigoIndicadorEconomico { get; set; }

    /// <summary>
    /// Campo destinado para uso da Empresa Beneficiário para identificação do boleto.
    /// Equivalente ao SEU NÚMERO ou ao numeroTituloBeneficiario do request do registro
    /// </summary>
    [JsonProperty("numeroTituloCedenteCobranca", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string SeuNumero { get; set; }

    /// <summary>
    /// Código utilizado pela FEBRABAN para identificar o tipo de taxa de juros.
    /// Domínios: 0 - DISPENSAR 1 - VALOR DIA ATRASO 2 - TAXA MENSAL 3 - ISENTO
    /// </summary>
    [JsonProperty("codigoTipoJuroMora", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(TipoJurosMoraConverter))]
    public TipoJurosMora TipoJurosMora { get; set; }

    /// <summary>
    /// Data de emissão do boleto.
    /// </summary>
    [JsonProperty("dataEmissaoTituloCobranca", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(FormataDataConverter), "dd.MM.yyyy")]
    public DateTime DataEmissao { get; set; }

    /// <summary>
    /// Data de registro do boleto.
    /// </summary>
    [JsonProperty("dataRegistroTituloCobranca", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(FormataDataConverter), "dd.MM.yyyy")]
    public DateTime DataRegistrado { get; set; }

    /// <summary>
    /// Data de vencimento do boleto.
    /// </summary>
    [JsonProperty("dataVencimentoTituloCobranca", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(FormataDataConverter), "dd.MM.yyyy")]
    public DateTime DataVencimento { get; set; }

    /// <summary>
    /// Valor original do boleto indicado quando do registro.
    /// </summary>
    [JsonProperty("valorOriginalTituloCobranca", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(FormataDecimalConverter))]
    public decimal Valor { get; set; }

    /// <summary>
    /// Valor atualizado do boleto, considerando possíveis multa, juros, mora, descontos, etc., que incidiram sob o valor original
    /// </summary>
    [JsonProperty("valorAtualTituloCobranca", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(FormataDecimalConverter))]
    public decimal ValorAtual { get; set; }

    /// <summary>
    /// Valores já recebidos em pagamentos parciais.
    /// </summary>
    [JsonProperty("valorPagamentoParcialTitulo", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(FormataDecimalConverter))]
    public decimal ValorPagamento { get; set; }

    /// <summary>
    /// Valor do abatimento (redução do valor do documento, devido a algum problema), expresso em moeda corrente.
    /// </summary>
    [JsonProperty("valorAbatimentoTituloCobranca", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(FormataDecimalConverter))]
    public decimal ValorAbatimento { get; set; }

    /// <summary>
    /// Percentual do IOF - Imposto sobre Operações Financeiras - de um boleto prêmio de seguro na sua data de emissão, expresso de acordo com o tipo de moeda.
    /// </summary>
    [JsonProperty("percentualImpostoSobreOprFinanceirasTituloCobranca", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(FormataDecimalConverter))]
    public decimal PercentualImposto { get; set; }

    /// <summary>
    /// Valor do IOF - Imposto sobre Operações Financeiras - de um boleto prêmio de seguro na sua data de emissão, expresso de acordo com o tipo de moeda.
    /// </summary>
    [JsonProperty("valorImpostoSobreOprFinanceirasTituloCobranca", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(FormataDecimalConverter))]
    public decimal ValorImposto { get; set; }

    /// <summary>
    /// Valor do boleto expresso em moeda variável.
    /// </summary>
    [JsonProperty("valorMoedaTituloCobranca", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(FormataDecimalConverter))]
    public decimal ValorMoeda { get; set; }

    /// <summary>
    /// Porcentagem sobre o valor do boleto a ser cobrada de juros de mora.
    /// </summary>
    [JsonProperty("percentualJuroMoraTitulo", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(FormataDecimalConverter))]
    public decimal PercentualJuroMora { get; set; }

    /// <summary>
    /// Valor sobre o valor do boleto a ser cobrado de juros de mora.
    /// </summary>
    [JsonProperty("valorJuroMoraTitulo", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(FormataDecimalConverter))]
    public decimal ValorJuroMora { get; set; }

    /// <summary>
    /// Porcentagem sobre o valor do boleto a ser cobrada de multa.
    /// </summary>
    [JsonProperty("percentualMultaTitulo", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(FormataDecimalConverter))]
    public decimal PercentualMulta { get; set; }

    /// <summary>
    /// Valor sobre o valor do boleto a ser cobrado de multa.
    /// </summary>
    [JsonProperty("valorMultaTituloCobranca", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(FormataDecimalConverter))]
    public decimal ValorMulta { get; set; }

    /// <summary>
    /// Quantidade de parcela do boleto.
    /// </summary>
    [JsonProperty("quantidadeParcelaTituloCobranca", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int QuantidadeParcela { get; set; }

    /// <summary>
    /// Data da baixa automática do boleto, conforme cadastrado no convênio.
    /// </summary>
    [JsonProperty("dataBaixaAutomaticoTitulo", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(FormataDataConverter), "dd.MM.yyyy")]
    public DateTime DataBaixaAutomatica { get; set; }

    /// <summary>
    /// Texto de observações destinado ao envio de mensagens livres, a serem impressas no campo de instruções da ficha de compensação do Boleto de Pagamento.
    /// </summary>
    [JsonProperty("textoCampoUtilizacaoCedente", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string ObservacoesUtilizacaoCedente { get; set; }

    /// <summary>
    /// Código para identificação de Rateio de Crédito (partilhamento).
    /// Domínios: S - SIM  N - NÃO
    /// </summary>
    [JsonProperty("indicadorCobrancaPartilhadoTitulo", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(AbreviacaoBoleanoConverter))]
    public bool CobrancaPartilhada { get; set; }

    /// <summary>
    /// Nome que identifica a pessoa, física ou jurídica, a qual se quer fazer referência.
    /// </summary>
    [JsonProperty("nomeSacadoCobranca", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string NomeSacado { get; set; }

    /// <summary>
    /// Texto referente a localização da rua/avenida, número, complemento para entrega de correspondência.
    /// </summary>
    [JsonProperty("textoEnderecoSacadoCobranca", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string EnderecoSacado { get; set; }

    /// <summary>
    /// Texto referente ao bairro para entrega de correspondência.
    /// </summary>
    [JsonProperty("nomeBairroSacadoCobranca", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string BairroSacado { get; set; }

    /// <summary>
    /// Texto referente ao nome do município componente do endereço utilizado para entrega de correspondência.
    /// </summary>
    [JsonProperty("nomeMunicipioSacadoCobranca", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string MunicipioSacado { get; set; }

    /// <summary>
    /// Código do estado, unidade da federação componente do endereço utilizado para entrega de correspondência.
    /// </summary>
    [JsonProperty("siglaUnidadeFederacaoSacadoCobranca", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string UnidadeFederacaoSacado { get; set; }

    /// <summary>
    /// Código adotado pelos Correios, para identificação de logradouros.
    /// </summary>
    [JsonProperty("numeroCepSacadoCobranca", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public long CepSacado { get; set; }

    /// <summary>
    /// Valor da moeda do abatimento.
    /// </summary>
    [JsonProperty("valorMoedaAbatimentoTitulo", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(FormataDecimalConverter))]
    public decimal ValorMoedaAbatimento { get; set; }

    /// <summary>
    /// Data para inicialização do processo de cobrança via protesto.
    /// </summary>
    [JsonProperty("dataProtestoTituloCobranca", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(FormataDataConverter), "dd.MM.yyyy")]
    public DateTime DataProtesto { get; set; }

    /// <summary>
    /// Código que identifica o tipo de inscrição do Beneficiário original do boleto de cobrança.
    /// Domínios: 1 - CPF 2 - CNPJ
    /// </summary>
    [JsonProperty("codigoTipoInscricaoSacador", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(TipoInscricaoConverter))]
    public TipoInscricao TipoInscricaoSacador { get; set; }

    /// <summary>
    /// Número de inscrição do Beneficiário original do boleto de cobrança.
    /// </summary>
    [JsonProperty("numeroInscricaoSacadorAvalista", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public long NumeroInscricaoSacadorAvalista { get; set; }

    /// <summary>
    /// Nome que identifica a entidade, pessoa física ou jurídica, Beneficiário original do boleto de cobrança.
    /// </summary>
    [JsonProperty("nomeSacadorAvalistaTitulo", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string NomeSacadorAvalista { get; set; }

    /// <summary>
    /// Percentual de desconto a ser concedido sobre o boleto de cobrança.
    /// </summary>
    [JsonProperty("percentualDescontoTitulo", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(FormataDecimalConverter))]
    public decimal PercentualDesconto { get; set; }

    /// <summary>
    /// Data limite do desconto do boleto de cobrança.
    /// </summary>
    [JsonProperty("dataDescontoTitulo", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(FormataDataConverter), "dd.MM.yyyy")]
    public DateTime DataDesconto { get; set; }

    /// <summary>
    /// Valor de desconto a ser concedido sobre o boleto de cobrança.
    /// </summary>
    [JsonProperty("valorDescontoTitulo", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(FormataDecimalConverter))]
    public decimal ValorDescontoTitulo { get; set; }

    /// <summary>
    /// Código para identificação do tipo de desconto que deverá ser concedido.
    /// Domínios:
    /// 0 - SEM DESCONTO
    /// 1 - VLR FIXO ATE A DATA INFORMADA
    /// 2 - PERCENTUAL ATE A DATA INFORMADA
    /// 3 - DESCONTO POR DIA DE ANTECIPACAO
    /// </summary>
    [JsonProperty("codigoDescontoTitulo", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(TipoDescontoConverter))]
    public TipoDesconto TipoDesconto { get; set; }

    /// <summary>
    /// Percentual do segundo desconto a ser concedido sobre o boleto de cobrança.
    /// </summary>
    [JsonProperty("percentualSegundoDescontoTitulo", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(FormataDecimalConverter))]
    public decimal PercentualSegundoDesconto { get; set; }

    /// <summary>
    /// Data limite do segundo desconto do boleto de cobrança.
    /// </summary>
    [JsonProperty("dataSegundoDescontoTitulo", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(FormataDataConverter), "dd.MM.yyyy")]
    public DateTime DataSegundoDesconto { get; set; }

    /// <summary>
    /// Valor do segundo desconto a ser concedido sobre o boleto de cobrança.
    /// </summary>
    [JsonProperty("valorSegundoDescontoTitulo", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(FormataDecimalConverter))]
    public decimal ValorSegundoDesconto { get; set; }

    /// <summary>
    /// Código para identificação do tipo do segundo desconto que deverá ser concedido.
    /// Domínios:
    /// 0 - SEM DESCONTO
    /// 1 - VLR FIXO ATE A DATA INFORMADA
    /// 2 - PERCENTUAL ATE A DATA INFORMADA
    /// 3 - DESCONTO POR DIA DE ANTECIPACAO
    /// </summary>
    [JsonProperty("codigoSegundoDescontoTitulo", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(TipoDescontoConverter))]
    public TipoDesconto TipoSegundoDesconto { get; set; }

    /// <summary>
    /// Percentual do terceiro desconto a ser concedido sobre o boleto de cobrança.
    /// </summary>
    [JsonProperty("percentualTerceiroDescontoTitulo", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(FormataDecimalConverter))]
    public decimal PercentualTerceiroDesconto { get; set; }

    /// <summary>
    /// Data limite do terceiro desconto do boleto de cobrança.
    /// </summary>
    [JsonProperty("dataTerceiroDescontoTitulo", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(FormataDataConverter), "dd.MM.yyyy")]
    public DateTime DataTerceiroDesconto { get; set; }

    /// <summary>
    /// Valor do terceiro desconto a ser concedido sobre o boleto de cobrança.
    /// </summary>
    [JsonProperty("valorTerceiroDescontoTitulo", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(FormataDecimalConverter))]
    public decimal ValorTerceiroDesconto { get; set; }

    /// <summary>
    /// Código para identificação do tipo do terceiro desconto que deverá ser concedido.
    /// Domínios:
    /// 0 - SEM DESCONTO
    /// 1 - VLR FIXO ATE A DATA INFORMADA
    /// 2 - PERCENTUAL ATE A DATA INFORMADA
    /// 3 - DESCONTO POR DIA DE ANTECIPACAO
    /// </summary>
    [JsonProperty("codigoTerceiroDescontoTitulo", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(TipoDescontoConverter))]
    public TipoDesconto TipoTerceiroDesconto { get; set; }

    /// <summary>
    /// Data para início da cobrança da multa.
    /// </summary>
    [JsonProperty("dataMultaTitulo", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(FormataDataConverter), "dd.MM.yyyy")]
    public DateTime DataMulta { get; set; }

    /// <summary>
    /// Número da carteira do convênio de cobrança.
    /// </summary>
    [JsonProperty("numeroCarteiraCobranca", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int Carteira { get; set; }

    /// <summary>
    /// Número da variação da carteira do convênio de cobrança.
    /// </summary>
    [JsonProperty("numeroVariacaoCarteiraCobranca", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int VariacaoCarteira { get; set; }

    /// <summary>
    /// Número de dias decorrentes após a data de vencimento para inicialização do processo de cobrança via protesto.
    /// </summary>
    [JsonProperty("quantidadeDiaProtesto", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int QtdDiasProtesto { get; set; }

    /// <summary>
    /// Número de dias corridos para recebimento do boleto após a data de vencimento.
    /// </summary>
    [JsonProperty("quantidadeDiaPrazoLimiteRecebimento", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int QtdDiaPrazoLimiteRecebimento { get; set; }

    /// <summary>
    /// Data limite para recebimento do boleto após a data de vencimento.
    /// </summary>
    [JsonProperty("dataLimiteRecebimentoTitulo", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(FormataDataConverter), "dd.MM.yyyy")]
    public DateTime DataLimiteRecebimento { get; set; }

    /// <summary>
    /// Código para identificação da autorização de pagamento parcial do boleto.
    /// Domínios: S - SIM N - NAO
    /// </summary>
    [JsonProperty("indicadorPermissaoRecebimentoParcial", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(AbreviacaoBoleanoConverter))]
    public bool PermiteRecebimentoParcial { get; set; }

    /// <summary>
    /// Código de barras do boleto.
    /// </summary>
    [JsonProperty("textoCodigoBarrasTituloCobranca", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string CodigoBarras { get; set; }

    /// <summary>
    /// Código para identificação das ocorrências de retorno do cartório.
    /// Domínios:
    /// 0 - TITULO PROTOCOLADO - ANTIGO "TEC"
    /// 1 - TITULO PAGO EM CARTORIO
    /// 2 - TITULO PROTESTADO - ANTIGO "DDP"
    /// 3 - TITULO RETIRADO CARTORIO - ANT. DDS
    /// 4 - TITULO SUSTADO JUDICIALMENTE
    /// 5 - TITULO RECUSADO SEM CUSTAS
    /// 6 - TITULO RECUSADO COM CUSTAS
    /// 7 - TITULO PAGO LIQUIDACAO CONDICIONAL
    /// 8 - TITULO ACEITO
    /// 9 - CUSTAS DE EDITAL
    /// 20 - LQ. CARTORIO AG. SEMI-AUTOM.
    /// 21 - CHQ DEVOLV. TIT. ENC. PROT.
    /// 22 - TITULO SUSTADO DEFINITIVO
    /// 23 - RETIRADA APÓS SUSTAÇÃO JUDICIAL
    /// 59 - PAGTO CONDICIONAL VIA SELTEC
    /// 60 - TITULO PAGO EM CARTORIO-SELTEC
    /// </summary>
    [JsonProperty("codigoOcorrenciaCartorio", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(OcorrenciasCartorioConverter))]
    public OcorrenciasCartorio OcorrenciasCartorio { get; set; }

    /// <summary>
    /// Valor do IOF recebido.
    /// </summary>
    [JsonProperty("valorImpostoSobreOprFinanceirasRecebidoTitulo", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(FormataDecimalConverter))]
    public decimal ValorImpostoRecebido { get; set; }

    /// <summary>
    /// Valor do abatimento concedido.
    /// </summary>
    [JsonProperty("valorAbatimentoTotal", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(FormataDecimalConverter))]
    public decimal ValorAbatimentoTotal { get; set; }

    /// <summary>
    /// Valor dos juros recebidos.
    /// </summary>
    [JsonProperty("valorJuroMoraRecebido", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(FormataDecimalConverter))]
    public decimal ValorJuroMoraRecebido { get; set; }

    /// <summary>
    /// Valor de desconto utilizado pelo pagador.
    /// </summary>
    [JsonProperty("valorDescontoUtilizado", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(FormataDecimalConverter))]
    public decimal ValorDescontoUtilizado { get; set; }

    /// <summary>
    /// Valor pago.
    /// </summary>
    [JsonProperty("valorPagoSacado", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(FormataDecimalConverter))]
    public decimal ValorPagoSacado { get; set; }

    /// <summary>
    /// Valor líquido creditado ao beneficiário.
    /// </summary>
    [JsonProperty("valorCreditoCedente", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(FormataDecimalConverter))]
    public decimal ValorCreditado { get; set; }

    /// <summary>
    /// Código para identificação do tipo de liquidação.
    /// Domínios: 1 CAIXA 2 VIA COMPE 3 EM CARTORIO 4 PIX 5 TITULO EM LIQUIDACAO - ORIGEM AGE
    /// 6 TITULO EM LIQUIDACAO - PGT 7 BANCO POSTAL 8 TITULO LIQUIDADO VIA COMPE/STR
    /// </summary>
    [JsonProperty("codigoTipoLiquidacao", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(TipoLiquidacaoConverter))]
    public TipoLiquidacao TipoLiquidacao { get; set; }

    /// <summary>
    /// Data a qual será creditado o valor inerente ao título (este campo só será preenchido após a liquidação, ou seja,
    /// após codigoEstadoTituloCobranca = 6).
    /// </summary>
    [JsonProperty("dataCreditoLiquidacao", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(FormataDataConverter), "dd.MM.yyyy")]
    public DateTime DataCreditoLiquidacao { get; set; }

    /// <summary>
    /// Data para a qual foi agendado o recebimento/pagamento do título.
    /// </summary>
    [JsonProperty("dataRecebimentoTitulo", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(FormataDataConverter), "dd.MM.yyyy")]
    public DateTime DataRecebimento { get; set; }

    /// <summary>
    /// Código agência da praça do recebimento do boleto.
    /// </summary>
    [JsonProperty("CodigoPrefixoDependenciaRecebedor", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int CodigoPrefixoDependenciaRecebedor { get; set; }

    /// <summary>
    /// Código para identificar as ocorrências (rejeições, tarifas, custas, liquidação e baixas) do boleto.
    /// Domínios: 1 - NORMAL 2 - POR CONTA 3 - POR SALDO 4 - CHEQUE A COMPENSAR 7 - LIQUIDADO NA APRESENTACAO
    /// 8 - POR CONTA EM CARTORIO 9 - EM CARTORIO
    /// </summary>
    [JsonProperty("codigoNaturezaRecebimento", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(NaturezaRecebimentoConverter))]
    public NaturezaRecebimento NaturezaRecebimento { get; set; }

    /// <summary>
    /// Número de identidade do sacado do título.
    /// </summary>
    [JsonProperty("numeroIdentidadeSacadoTituloCobranca", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string NumeroIdentidadeSacado { get; set; }

    /// <summary>
    /// Código para identificação do sistema/usuário responsável pela atualização do boleto.
    /// </summary>
    [JsonProperty("codigoResponsavelAtualizacao", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string CodigoResponsavelAtualizacao { get; set; }

    /// <summary>
    /// Código para identificação do tipo de baixa do boleto.
    /// Domínios:
    /// 1 - BAIXADO POR SOLICITACAO 2 - ENTREGA FRANCO PAGAMENTO 9 - COMANDADA BANCO 10 - COMANDADA CLIENTE - ARQUIVO
    /// 11 - COMANDADA CLIENTE - ON-LINE 12 - DECURSO PRAZO - CLIENTE 13 - DECURSO PRAZO - BANCO 15 - PROTESTADO
    /// 31 - LIQUIDADO ANTERIORMENTE 32 - HABILITADO EM PROCESSO 35 - TRANSFERIDO PARA PERDAS
    /// 51 - REGISTRADO INDEVIDAMENTE 90 - BAIXA AUTOMATICA
    /// </summary>
    [JsonProperty("codigoTipoBaixaTitulo", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(TipoBaixaConverter))]
    public TipoBaixa codigoTipoBaixaTitulo { get; set; }

    /// <summary>
    ///  Valor de multa recebido.
    /// </summary>
    [JsonProperty("valorMultaRecebido", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(FormataDecimalConverter))]
    public decimal ValorMultaRecebido { get; set; }

    /// <summary>
    /// Valor do reajuste (índice econômico).
    /// </summary>
    [JsonProperty("valorReajuste", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(FormataDecimalConverter))]
    public decimal ValorReajuste { get; set; }

    /// <summary>
    /// Outros valores recebidos.
    /// </summary>
    [JsonProperty("valorOutroRecebido", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(FormataDecimalConverter))]
    public decimal valorOutroRecebido { get; set; }

    /// <summary>
    /// Código do índice econômico utilizado para o cálculo de juros/multa.
    /// </summary>
    [JsonProperty("codigoIndicadorEconomicoUtilizadoInadimplencia", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int CodigoIndicadorEconomicoInadimplencia { get; set; }
}