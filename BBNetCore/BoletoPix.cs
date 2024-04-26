using System;
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
public class BoletoPix : ServicosBase
{
    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="BoletoPix"/>.
    /// </summary>
    /// <param name="versaoApi">Versão da API.</param> 
    /// <param name="configuracoesApiBb">Configurações do serviço.</param> 
    public BoletoPix(VersaoApi versaoApi, ConfiguracoesApiBB configuracoesApiBb)
        : base(TipoApi.Boletos, versaoApi, configuracoesApiBb)
    {
    }

    /// <summary>
    /// Gerar Pix vinculado a um boleto de cobrança através de um QRCode Dinâmico ou Estático.
    /// </summary>
    /// <param name="nossoNumero">Número do boleto bancário (único e exclusivo) que identifica o título e é usado para pagá-lo.</param>
    /// <param name="convenio">Identificador determinado pelo sistema de boleto bancário usado para emissão e liquidação do boleto e, portanto, usado para creditar o Beneficiário.</param>
    /// <returns>Dados da cobrança</returns>
    public RespostaBoletoPix Gerar(string nossoNumero, int convenio)
    {
        RespostaBoletoPix result = GerarAsync(nossoNumero, convenio).Result;
        return result;
    }

    /// <summary>
    /// Gerar Pix vinculado a um boleto de cobrança através de um QRCode Dinâmico ou Estático como uma operação assíncrona.
    /// </summary>
    /// <param name="nossoNumero">Número do boleto bancário (único e exclusivo) que identifica o título e é usado para pagá-lo.</param>
    /// <param name="convenio">Identificador determinado pelo sistema de boleto bancário usado para emissão e liquidação do boleto e, portanto, usado para creditar o Beneficiário.</param>
    /// <param name="cancellationToken">Token de notificação de cancelamento de threads gerenciadas.</param>
    /// <returns>Dados da cobrança</returns>
    public async Task<RespostaBoletoPix> GerarAsync(string nossoNumero, int convenio, CancellationToken cancellationToken = default)
    {
        try
        {
            await AutenticarAsync();

            ApiHttpClient client = CriarInstancia();

            RespostaBoletoPix result = await client
                .PrepareClient($"boletos/{nossoNumero}/gerar-pix", $"gw-dev-app-key={ConfiguracoesApiBb.ChaveApp}")
                .PostAsync<RespostaBoletoPix>(new { numeroConvenio = convenio }, MimeTypes.Json, cancellationToken);

            return result;
        }
        catch (HttpException ex)
        {
            throw new ApiException(ex);
        }
        catch (Exception ex)
        {
            throw new ApiException(ex.Message);
        }
    }

    /// <summary>
    /// Gerar Pix vinculado a um boleto de cobrança registrado por troca de arquivo, através de um QRCode Dinâmico ou Estático.
    /// </summary>
    /// <param name="nossoNumero">Número do boleto bancário (único e exclusivo) que identifica o título e é usado para pagá-lo.</param>
    /// <param name="convenio">Identificador determinado pelo sistema de boleto bancário usado para emissão e liquidação do boleto e, portanto, usado para creditar o Beneficiário.</param>
    /// <returns>Dados da cobrança</returns>
    public RespostaBoletoManualPix GerarManual(string nossoNumero, int convenio)
    {
        RespostaBoletoManualPix result = GerarManualAsync(nossoNumero, convenio).Result;
        return result;
    }

    /// <summary>
    /// Gerar Pix vinculado a um boleto de cobrança registrado por troca de arquivo, através de um QRCode Dinâmico ou Estático como uma operação assíncrona.
    /// </summary>
    /// <param name="nossoNumero">Número do boleto bancário (único e exclusivo) que identifica o título e é usado para pagá-lo.</param>
    /// <param name="convenio">Identificador determinado pelo sistema de boleto bancário usado para emissão e liquidação do boleto e, portanto, usado para creditar o Beneficiário.</param>
    /// <param name="cancellationToken">Token de notificação de cancelamento de threads gerenciadas.</param>
    /// <returns>Dados da cobrança</returns>
    public async Task<RespostaBoletoManualPix> GerarManualAsync(string nossoNumero, int convenio, CancellationToken cancellationToken = default)
    {
        try
        {
            await AutenticarAsync();

            ApiHttpClient client = CriarInstancia();

            RespostaBoletoManualPix result = await client
                .PrepareClient($"boletos/{nossoNumero}/gerar-pix", $"gw-dev-app-key={ConfiguracoesApiBb.ChaveApp}")
                .PostAsync<RespostaBoletoManualPix>(new { numeroConvenio = convenio }, MimeTypes.Json, cancellationToken);

            return result;
        }
        catch (HttpException ex)
        {
            throw new ApiException(ex);
        }
        catch (Exception ex)
        {
            throw new ApiException(ex.Message);
        }
    }

    /// <summary>
    /// Cancelar Pix vinculado a um boleto de cobrança existente.
    /// </summary>
    /// <param name="nossoNumero">Número do boleto bancário (único e exclusivo) que identifica o título e é usado para pagá-lo.</param>
    /// <param name="convenio">Identificador determinado pelo sistema de boleto bancário usado para emissão e liquidação do boleto e, portanto, usado para creditar o Beneficiário.</param>
    /// <returns>Dados da cobrança</returns>
    public string Cancelar(string nossoNumero, int convenio)
    {
        var result = CancelarAsync(nossoNumero, convenio).Result;
        return result;
    }

    /// <summary>
    /// Cancelar Pix vinculado a um boleto de cobrança existente como uma operação assíncrona.
    /// </summary>
    /// <param name="nossoNumero">Número do boleto bancário (único e exclusivo) que identifica o título e é usado para pagá-lo.</param>
    /// <param name="convenio">Identificador determinado pelo sistema de boleto bancário usado para emissão e liquidação do boleto e, portanto, usado para creditar o Beneficiário.</param>
    /// <param name="cancellationToken">Token de notificação de cancelamento de threads gerenciadas.</param>
    /// <returns>Dados da cobrança</returns>
    public async Task<string> CancelarAsync(string nossoNumero, int convenio, CancellationToken cancellationToken = default)
    {
        try
        {
            await AutenticarAsync();

            ApiHttpClient client = CriarInstancia();

            var result = await client
                .PrepareClient($"boletos/{nossoNumero}/cancelar-pix", $"gw-dev-app-key={ConfiguracoesApiBb.ChaveApp}")
                .PostAsync<string>(new { numeroConvenio = convenio }, MimeTypes.Json, cancellationToken);

            return result;
        }
        catch (HttpException ex)
        {
            throw new ApiException(ex);
        }
        catch (Exception ex)
        {
            throw new ApiException(ex.Message);
        }
    }

    /// <summary>
    /// Cancelar Pix vinculado a um boleto de cobrança existente registrado por troca de arquivo.
    /// </summary>
    /// <param name="nossoNumero">Número do boleto bancário (único e exclusivo) que identifica o título e é usado para pagá-lo.</param>
    /// <param name="convenio">Identificador determinado pelo sistema de boleto bancário usado para emissão e liquidação do boleto e, portanto, usado para creditar o Beneficiário.</param>
    /// <returns>Dados da cobrança</returns>
    public RespostaBoletoManualPix CancelarManual(string nossoNumero, int convenio)
    {
        RespostaBoletoManualPix result = CancelarManualAsync(nossoNumero, convenio).Result;
        return result;
    }

    /// <summary>
    /// Cancelar Pix vinculado a um boleto de cobrança existente registrado por troca de arquivo como uma operação assíncrona.
    /// </summary>
    /// <param name="nossoNumero">Número do boleto bancário (único e exclusivo) que identifica o título e é usado para pagá-lo.</param>
    /// <param name="convenio">Identificador determinado pelo sistema de boleto bancário usado para emissão e liquidação do boleto e, portanto, usado para creditar o Beneficiário.</param>
    /// <param name="cancellationToken">Token de notificação de cancelamento de threads gerenciadas.</param>
    /// <returns>Dados da cobrança</returns>
    public async Task<RespostaBoletoManualPix> CancelarManualAsync(string nossoNumero, int convenio, CancellationToken cancellationToken = default)
    {
        try
        {
            await AutenticarAsync();

            ApiHttpClient client = CriarInstancia();

            RespostaBoletoManualPix result = await client
                .PrepareClient($"boletos/{nossoNumero}/cancelar-pix", $"gw-dev-app-key={ConfiguracoesApiBb.ChaveApp}")
                .PostAsync<RespostaBoletoManualPix>(new { numeroConvenio = convenio }, MimeTypes.Json, cancellationToken);

            return result;
        }
        catch (HttpException ex)
        {
            throw new ApiException(ex);
        }
        catch (Exception ex)
        {
            throw new ApiException(ex.Message);
        }
    }

    /// <summary>
    /// Consultar o pagamento de um cobrança, através de um e2eid do PixPaid.
    /// </summary>
    /// <param name="nossoNumero">Número do boleto bancário (único e exclusivo) que identifica o título e é usado para pagá-lo.</param>
    /// <param name="convenio">Identificador determinado pelo sistema de boleto bancário usado para emissão e liquidação do boleto e, portanto, usado para creditar o Beneficiário.</param>
    /// <returns>Dados do pagamento</returns>
    public RespostaBoletoPix Consultar(string nossoNumero, int convenio)
    {
        RespostaBoletoPix result = ConsultarAsync(nossoNumero, convenio).Result;
        return result;
    }

    /// <summary>
    /// Consultar o pagamento de um cobrança, através de um e2eid do PixPaid como uma operação assíncrona.
    /// </summary>
    /// <param name="nossoNumero">Número do boleto bancário (único e exclusivo) que identifica o título e é usado para pagá-lo.</param>
    /// <param name="convenio">Identificador determinado pelo sistema de boleto bancário usado para emissão e liquidação do boleto e, portanto, usado para creditar o Beneficiário.</param>
    /// <param name="cancellationToken">Token de notificação de cancelamento de threads gerenciadas.</param>
    /// <returns>Dados do pagamento</returns>
    public async Task<RespostaBoletoPix> ConsultarAsync(string nossoNumero, int convenio, CancellationToken cancellationToken = default)
    {
        try
        {
            await AutenticarAsync();

            ApiHttpClient client = CriarInstancia();

            RespostaBoletoPix result = await client
                .PrepareClient($"boletos/{nossoNumero}/pix", $"numeroConvenio={convenio}", $"gw-dev-app-key={ConfiguracoesApiBb.ChaveApp}")
                .GetAsync<RespostaBoletoPix>(MimeTypes.Json, cancellationToken);

            return result;
        }
        catch (HttpException ex)
        {
            throw new ApiException(ex);
        }
        catch (Exception ex)
        {
            throw new ApiException(ex.Message);
        }
    }
}