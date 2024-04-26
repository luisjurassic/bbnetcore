using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BBNetCore.Enumerators;

namespace BBNetCore.Test
{
    [TestClass]
    public class AutenticacaoTestes
    {
        private static readonly Pix _pix = new(VersaoApi.V1, Configuracao.ConfiguracoesApiBb);

        [TestMethod]
        public async Task Auth()
        {
            try
            {
                var retorno = await _pix.AutenticarAsync();

                Assert.IsFalse(retorno, "Erro ao autenticar na API");

                Console.WriteLine("Autenticação realizada com sucesso");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}