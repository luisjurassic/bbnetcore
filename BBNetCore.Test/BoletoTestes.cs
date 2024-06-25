using System;
using BBNetCore.Enumerators;
using BBNetCore.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace BBNetCore.Test
{
    [TestClass]
    public class BoletoTestes
    {
        private static readonly Boleto _boleto = new(Configuracao.ConfiguracoesApiBb);

        [TestMethod]
        public void CriarCobranca()
        {
            try
            {
                RespostaBoleto retorno = _boleto.Gerar(new DadosBoleto
                {
                    AceiteTituloVencido = false,
                    Beneficiario = new DadosBoletoBeneficiario(TipoInscricao.CNPJ, "74910037000193", "TECIDOS FARIA DUARTE"),
                    Carteira = 17,
                    CodigoAceite = CodigoAceite.Aceite,
                    CodigoModalidade = CodigoModalidade.Simples,
                    Convenio = 3128557,
                    DiasLimiteRecebimento = 3,
                    Emissao = DateTime.Now.Date,
                    GerarPix = true,
                    JurosMora = new DadosBoletoJurosMora(TipoJurosMora.TaxaMensal, 2.50M),
                    MensagemImpressaNoBoleto = "Teste geração boleto PIX",
                    Multa = new DadosBoletoMulta(TipoMulta.ValorFixo, 2.0M, DateTime.Now.Date.AddDays(13)),
                    NossoNumero = "00031285570099930003",
                    OrgaoNegativador = 10,
                    Pagador = new DadosBoletoPagador
                    {
                        TipoInscricao = TipoInscricao.CNPJ,
                        NumeroInscricao = "74910037000193",
                        Nome = "Odorico Paraguassu",
                        Endereco = "Avenida Dias Gomes 1970",
                        CEP = "77458000",
                        Cidade = "Sucupira",
                        Bairro = "Centro",
                        UF = "TO"
                    },
                    PermiteRecebimentoParcial = false,
                    TipoTitulo = TipoTitulo.DuplicataMercantil,
                    Valor = 10.92M,
                    VariacaoCarteira = 35,
                    Vencimento = DateTime.Now.Date.AddDays(10),
                });

                Assert.IsNotNull(retorno, "Boleto bancário não gerado");

                Console.WriteLine(JsonConvert.SerializeObject(retorno));
                Console.WriteLine($"Boleto bancário gerado. LinhaDigitavel: {retorno.LinhaDigitavel}, CodigoBarra: {retorno.CodigoBarras}");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void ConsultaCobranca()
        {
            try
            {
                RespostaConsultaBoleto retorno = _boleto.Consultar("00031285570099930002", 3128557);

                Assert.IsNotNull(retorno, "Boleto bancário não encontrado");

                Console.WriteLine(JsonConvert.SerializeObject(retorno));
                Console.WriteLine($"Boleto bancário encontrado. LinhaDigitavel: {retorno.LinhaDigitavel}, CodigoBarra: {retorno.CodigoBarras}");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void Cancelar()
        {
            try
            {
                RespostaCancelaBoleto retorno = _boleto.Cancelar("00031285570099930002", 3128557);

                Assert.IsNotNull(retorno, "Boleto bancário não cancelado");

                Console.WriteLine(JsonConvert.SerializeObject(retorno));
                Console.WriteLine($"Boleto bancário cancelado. NumeroContrato: {retorno.NumeroContrato}, Data: {retorno.Data}");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}