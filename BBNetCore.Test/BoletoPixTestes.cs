using System;
using BBNetCore.Enumerators;
using BBNetCore.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace BBNetCore.Test
{
    [TestClass]
    public class BoletoPixTestes
    {
        private static readonly BoletoPix _pix = new(Configuracao.ConfiguracoesApiBb);

        [TestMethod]
        public void CriarCobrancaPix()
        {
            try
            {
                RespostaBoletoPix retorno = _pix.Gerar("00029023220000116585", 2902322);

                Assert.IsNotNull(retorno, "Pix de boleto não gerado");

                Console.WriteLine(JsonConvert.SerializeObject(retorno));
                Console.WriteLine($"Pix de boleto gerado. TransacaoId: {retorno.QrCode.TransacaoId}, Url: {retorno.QrCode.Url}");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void CriarCobrancManualPix()
        {
            try
            {
                RespostaBoletoManualPix retorno = _pix.GerarManual("00029023220000116585", 2902322);

                Assert.IsNotNull(retorno, "Pix de boleto não gerado");

                Console.WriteLine(JsonConvert.SerializeObject(retorno));
                Console.WriteLine($"Pix de boleto gerado. TransacaoId: {retorno.TransacaoId}, Url: {retorno.Url}");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void ConsultarCobrancaPix()
        {
            try
            {
                RespostaBoletoPix retorno = _pix.Consultar("00029023220000116585", 2902322);

                Assert.IsNotNull(retorno, "Pix do boleto não foi encontrada");

                Console.WriteLine(JsonConvert.SerializeObject(retorno));
                Console.WriteLine($"Pix de boleto. TransacaoId: {retorno.QrCode.TransacaoId}, Url: {retorno.QrCode.Url}");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void CancelaCobrancaPix()
        {
            try
            {
                var retorno = _pix.Cancelar("00029023220000116585", 2902322);

                Assert.IsNotNull(retorno, "Pix de boleto não cancelado");

                Console.WriteLine(retorno);
                Console.WriteLine("Pix de boleto cancelado.");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void CancelaCobrancaManualPix()
        {
            try
            {
                RespostaBoletoManualPix retorno = _pix.CancelarManual("00029023220000116585", 2902322);

                Assert.IsNotNull(retorno, "Pix de boleto não cancelado");

                Console.WriteLine(retorno);
                Console.WriteLine("Pix de boleto cancelado.");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}