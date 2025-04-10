using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BBNetCore.Enumerators;
using BBNetCore.Exceptions;
using BBNetCore.Models;
using BBNetCore.Utils;

namespace BBNetCore;

/// <summary>
/// Classe que atua como cliente para os serviços boletos.
/// </summary>
public class Boleto : ServicosBase
{
    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="Boleto"/>.
    /// </summary>
    /// <param name="configuracoesApiBb">Configurações do serviço.</param> 
    public Boleto(ConfiguracoesApiBB configuracoesApiBb)
        : base(TipoApi.Boletos, configuracoesApiBb)
    {
    }

    /// <summary>
    /// Gerar um boleto de cobrança bancário.
    /// </summary>
    /// <param name="boleto">Dados para gerar um boleto bancário.</param>
    /// <returns>Dados da cobrança</returns>
    public RespostaBoleto Gerar(DadosBoleto boleto)
    {
        RespostaBoleto result = GerarAsync(boleto).Result;
        return result;
    }

    /// <summary>
    /// Gerar um boleto de cobrança bancário como uma operação assíncrona.
    /// </summary>
    /// <param name="boleto">Dados para gerar um boleto bancário.</param>
    /// <param name="cancellationToken">Token de notificação de cancelamento de threads gerenciadas.</param>
    /// <returns>Dados da cobrança</returns>
    private async Task<RespostaBoleto> GerarAsync(DadosBoleto boleto, CancellationToken cancellationToken = default)
    {
        await AutenticarAsync();

        ApiHttpClient client = CriarInstancia();

        RespostaBoleto result = await client
            .PrepareClient("boletos/", $"gw-dev-app-key={ConfiguracoesApiBb.ChaveApp}")
            .PostAsync<RespostaBoleto>(boleto, MimeTypes.Json, cancellationToken);

        return result;
    }

    /// <summary>
    /// Consultar o pagamento de um cobrança, através de um e2eid do PixPaid.
    /// </summary>
    /// <param name="nossoNumero">Número do boleto bancário (único e exclusivo) que identifica o título e é usado para pagá-lo.</param>
    /// <param name="convenio">Identificador determinado pelo sistema de boleto bancário usado para emissão e liquidação do boleto e, portanto, usado para creditar o Beneficiário.</param> 
    /// <returns>Dados do pagamento</returns>
    public RespostaConsultaBoleto Consultar(string nossoNumero, int convenio)
    {
        RespostaConsultaBoleto result = ConsultarAsync(nossoNumero, convenio).Result;
        return result;
    }

    /// <summary>
    /// Consultar o pagamento de um cobrança, através de um e2eid do PixPaid como uma operação assíncrona.
    /// </summary>
    /// <param name="nossoNumero">Número do boleto bancário (único e exclusivo) que identifica o título e é usado para pagá-lo.</param>
    /// <param name="convenio">Identificador determinado pelo sistema de boleto bancário usado para emissão e liquidação do boleto e, portanto, usado para creditar o Beneficiário.</param>
    /// <param name="cancellationToken">Token de notificação de cancelamento de threads gerenciadas.</param>
    /// <returns>Dados do pagamento</returns>
    public async Task<RespostaConsultaBoleto> ConsultarAsync(string nossoNumero, int convenio,
        CancellationToken cancellationToken = default)
    {
        await AutenticarAsync();

        ApiHttpClient client = CriarInstancia();

        RespostaConsultaBoleto result = await client
            .PrepareClient($"boletos/{nossoNumero}", $"numeroConvenio={convenio}",
                $"gw-dev-app-key={ConfiguracoesApiBb.ChaveApp}")
            .GetAsync<RespostaConsultaBoleto>(MimeTypes.Json, cancellationToken);

        return result;
    }

    /// <summary>
    /// Listar títulos de cobrança - Em Ser, Baixados, Liquidados e Com Protesto por Beneficiário.
    /// </summary>
    /// <param name="agencia">Número da agência do beneficiário, sem o dígito verificador.</param>
    /// <param name="conta">Número da conta do beneficiário, sem o dígito verificador.</param>
    /// <param name="indicadorSituacao">Situação do boleto.
    /// <para></para>
    /// A - Em ser (Códigos 1,2,3,4,5, 9 e 13)
    /// <para></para>
    /// B - Baixados/Protestados/Liquidados (Códigos 6, 7,10, 11 e 12)
    /// </param>
    /// <param name="situacaoBoleto">Código da situação atual do boleto.</param>
    /// <returns>Dados do pagamento</returns>
    public List<RespostaConsultaBoleto> Lista(int agencia, int conta, string indicadorSituacao = "B",
        SituacaoBoleto situacaoBoleto = SituacaoBoleto.Liquidado)
    {
        List<RespostaConsultaBoleto> result = ListaAsync(agencia, conta, indicadorSituacao, situacaoBoleto).Result;
        return result;
    }

    /// <summary>
    /// Listar títulos de cobrança - Em Ser, Baixados, Liquidados e Com Protesto por Beneficiário, como uma operação assíncrona.
    /// </summary>
    /// <param name="agencia">Número da agência do beneficiário, sem o dígito verificador.</param>
    /// <param name="conta">Número da conta do beneficiário, sem o dígito verificador.</param>
    /// <param name="indicadorSituacao">Situação do boleto.
    /// <para></para>
    /// A - Em ser (Códigos 1,2,3,4,5, 9 e 13)
    /// <para></para>
    /// B - Baixados/Protestados/Liquidados (Códigos 6, 7,10, 11 e 12)
    /// </param>
    /// <param name="situacaoBoleto">Código da situação atual do boleto.</param>
    /// <param name="cancellationToken">Token de notificação de cancelamento de threads gerenciadas.</param>
    /// <returns>Dados do pagamento</returns>
    public async Task<List<RespostaConsultaBoleto>> ListaAsync(int agencia, int conta, string indicadorSituacao = "B",
        SituacaoBoleto situacaoBoleto = SituacaoBoleto.Liquidado, CancellationToken cancellationToken = default)
    {
        await AutenticarAsync();

        ApiHttpClient client = CriarInstancia();

        List<RespostaConsultaBoleto> result = await client
            .PrepareClient("boletos"
                , $"gw-dev-app-key={ConfiguracoesApiBb.ChaveApp}"
                , $"agenciaBeneficiario={agencia}"
                , $"contaBeneficiario={conta}"
                , $"indicadorSituacao={indicadorSituacao.ToUpper()}"
                , $"codigoEstadoTituloCobranca=06")
            .GetAsync<List<RespostaConsultaBoleto>>(MimeTypes.Json, cancellationToken);

        return result;
    }

    /// <summary>
    /// Gerar um boleto de cobrança bancário.
    /// </summary>
    /// <param name="nossoNumero">Número do boleto bancário (único e exclusivo) que identifica o título e é usado para pagá-lo.</param>
    /// <param name="convenio">Identificador determinado pelo sistema de boleto bancário usado para emissão e liquidação do boleto e, portanto, usado para creditar o Beneficiário.</param>
    /// <returns>Dados da cobrança</returns>
    public RespostaCancelaBoleto Cancelar(string nossoNumero, int convenio)
    {
        RespostaCancelaBoleto result = CancelarAsync(nossoNumero, convenio).Result;
        return result;
    }

    /// <summary>
    /// Gerar um boleto de cobrança bancário como uma operação assíncrona.
    /// </summary>
    /// <param name="nossoNumero">Número do boleto bancário (único e exclusivo) que identifica o título e é usado para pagá-lo.</param>
    /// <param name="convenio">Identificador determinado pelo sistema de boleto bancário usado para emissão e liquidação do boleto e, portanto, usado para creditar o Beneficiário.</param>
    /// <param name="cancellationToken">Token de notificação de cancelamento de threads gerenciadas.</param>
    /// <returns>Dados da cobrança</returns>
    private async Task<RespostaCancelaBoleto> CancelarAsync(string nossoNumero, int convenio,
        CancellationToken cancellationToken = default)
    {
        await AutenticarAsync();

        ApiHttpClient client = CriarInstancia();

        RespostaCancelaBoleto result = await client
            .PrepareClient($"boletos/{nossoNumero}/baixar", $"gw-dev-app-key={ConfiguracoesApiBb.ChaveApp}")
            .PostAsync<RespostaCancelaBoleto>(new { numeroConvenio = convenio }, MimeTypes.Json, cancellationToken);

        return result;
    }
}