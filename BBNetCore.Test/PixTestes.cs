using System;
using BBNetCore.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace BBNetCore.Test
{
    [TestClass]
    public class PixTestes
    {
        private static readonly Pix _pix = new(Configuracao.ConfiguracoesApiBb);

        [TestMethod]
        public void CriarCobranca()
        {
            try
            {
                DadosPix retorno = _pix.Gerar(new DadosPix()
                {
                    Calendar = new DadosCalendario(3600),
                    Valores = new DadosValores(9.90M),
                    ChavePix = "9e881f18-cc66-4fc7-8f2c-a795dbb2bfc1",
                    Devedor = new DadosDevedor
                    {
                        Cnpj = "12345678000195",
                        Nome = "Empresa de Serviços SA"
                    },
                    DecricaoCobranca = "Serviço prestado"
                });

                Assert.IsNotNull(retorno, "A cobrança não foi criada");

                Console.WriteLine(JsonConvert.SerializeObject(retorno));
                Console.WriteLine($"Cobrança registrada. txid: {retorno.TransacaoId} pixCopiaECola: {retorno.PixCopiaCola}");
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
                DadosPix retorno = _pix.Consultar("QEBTWpwGL2yT7ul3AVWdKCZ8hF");

                Assert.IsNotNull(retorno, "A cobrança não foi encontrada");

                Console.WriteLine(JsonConvert.SerializeObject(retorno));
                Console.WriteLine($"Cobrança encontrada. txid: {retorno.TransacaoId}");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void RevisarCobranca()
        {
            try
            {
                DadosPix retorno = _pix.Atualizar(new DadosPix()
                {
                    Calendar = new DadosCalendario(3600),
                    Valores = new DadosValores(12),
                    TransacaoId = "QEBTWpwGL2yT7ul3AVWdKCZ8hF",
                    ChavePix = "9e881f18-cc66-4fc7-8f2c-a795dbb2bfc1",
                    Devedor = new DadosDevedor
                    {
                        Cnpj = "12345678000195",
                        Nome = "Empresa de Serviços SA"
                    }
                });

                Assert.IsNotNull(retorno, "A cobrança não foi atualizada");

                Console.WriteLine($"Cobrança atualizada. txid: {retorno.TransacaoId}");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void Pagar()
        {
            try
            {
                DadosPix consulta = _pix.Consultar("QEBTWpwGL2yT7ul3AVWdKCZ8hF");

                Assert.IsNotNull(consulta, "A cobrança não foi encontrada");

                DadosPagamentoPix retorno = _pix.Pagar(consulta.PixCopiaCola);

                Assert.IsNotNull(retorno, "Pagamento não foi realizado");

                Console.WriteLine($"Cobrança paga. e2eId: {retorno.EndToEndId}");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void ConsultaPagamento()
        {
            try
            {
                DadosPagamentoPix retorno = _pix.ConsultarPagamento("endToEndId");

                Assert.IsNotNull(retorno, "Pagamento não foi encontrado");

                Console.WriteLine($"Cobrança paga. e2eId: {retorno.EndToEndId} txid: {retorno.TransacaoId}");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void Devolucao()
        {
            try
            {
                var idDevolucao = Guid.NewGuid().ToString();
                RespostaDevolucaoPix retorno = _pix.Devolver(new DadosDevolucaoPix
                {
                    Id = idDevolucao, //Id unico por devolução
                    EndToEndId = "endToEndId", //Esse cód. é gerado pelo PSP após o pagamento da cobrança 
                    Valor = 10
                });

                Assert.IsNotNull(retorno, "Devolução não foi realziada");

                Console.WriteLine($"Cobrança devolvida. rtrId: {retorno.DevolucaoId} status: {retorno.StatusDevolucao}");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void ConsultarDevolucao()
        {
            try
            {
                RespostaDevolucaoPix retorno = _pix.ConsultarDevolucao(new DadosDevolucaoPix()
                {
                    Id = "idDevolucao", //Id da solicitação de devolução
                    EndToEndId = "endToEndId" //Esse cód. é gerado pelo PSP após o pagamento da cobrança
                });

                Assert.IsNotNull(retorno, "Devolução não foi encontrada");
                Console.WriteLine($"Cobrança devolvida. rtrId: {retorno.DevolucaoId} status: {retorno.StatusDevolucao}");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}