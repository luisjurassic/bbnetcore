using System;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using BBNetCore.Enumerators;
using BBNetCore.Exceptions;
using BBNetCore.Models;
using BBNetCore.Utils;

namespace BBNetCore;

/// <summary>
/// Classe que atua como cliente para os serviços pix.
/// </summary>
public class Pix : ServicosBase
{
    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="Pix"/>.
    /// </summary>
    /// <param name="configuracoesApiBb">Configurações do serviço.</param> 
    public Pix(ConfiguracoesApiBB configuracoesApiBb)
        : base(TipoApi.Pix, configuracoesApiBb)
    {
    }

    /// <summary>
    /// Criar uma cobrança imediata, neste caso, o txid deve ser definido pelo PSP.
    /// </summary>
    /// <param name="requestCharge">Dados para criação da cobrança instantânea</param>
    /// <returns>Dados da cobrança</returns>
    public DadosPix Gerar(DadosPix requestCharge)
    {
        DadosPix result = GerarAsync(requestCharge).Result;
        return result;
    }

    /// <summary>
    /// Criar uma cobrança imediata, neste caso, o txid deve ser definido pelo PSP como uma operação assíncrona.
    /// </summary>
    /// <param name="requestCharge">Dados para criação da cobrança instantânea</param>
    /// <param name="cancellationToken">Token de notificação de cancelamento de threads gerenciadas.</param>
    /// <returns>Dados da cobrança</returns>
    public async Task<DadosPix> GerarAsync(DadosPix requestCharge, CancellationToken cancellationToken = default)
    {
        try
        {
            await AutenticarAsync();

            ApiHttpClient client = CriarInstancia();

            DadosPix result = await client
                .PrepareClient("cob/", $"gw-dev-app-key={ConfiguracoesApiBb.ChaveApp}")
                .PostAsync<DadosPix>(requestCharge, MimeTypes.Json, cancellationToken);

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
    /// Consulta uma cobrança imediata pelo transactionId.
    /// </summary>
    /// <param name="transacaoId">Identificador da transação</param>
    /// <returns>Dados da cobrança</returns>
    public DadosPix Consultar(string transacaoId)
    {
        DadosPix result = ConsultarAsync(transacaoId).Result;
        return result;
    }

    /// <summary>
    /// Consulta uma cobrança imediata pelo transactionId como uma operação assíncrona.
    /// </summary>
    /// <param name="transacaoId">Identificador da transação</param>
    /// <param name="cancellationToken">Token de notificação de cancelamento de threads gerenciadas.</param>
    /// <returns>Dados da cobrança</returns>
    public async Task<DadosPix> ConsultarAsync(string transacaoId, CancellationToken cancellationToken = default)
    {
        try
        {
            await AutenticarAsync();

            ApiHttpClient client = CriarInstancia();

            DadosPix result = await client
                .PrepareClient($"cob/{transacaoId}", $"gw-dev-app-key={ConfiguracoesApiBb.ChaveApp}")
                .GetAsync<DadosPix>(MimeTypes.Json, cancellationToken);

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
    /// Atualiza uma cobrança imediata, neste caso, o txid deve ser definido pelo PSP.
    /// </summary>
    /// <param name="requestCharge">Dados para criação da cobrança instantânea</param>
    /// <returns>Dados da cobrança</returns>
    public DadosPix Atualizar(DadosPix requestCharge)
    {
        DadosPix result = AtualizarAsync(requestCharge).Result;
        return result;
    }

    /// <summary>
    /// Atualiza uma cobrança imediata, neste caso, o txid deve ser definido pelo PSP como uma operação assíncrona.
    /// </summary>
    /// <param name="requestCharge">Dados para criação da cobrança instantânea</param>
    /// <param name="cancellationToken">Token de notificação de cancelamento de threads gerenciadas.</param>
    /// <returns>Dados da cobrança</returns>
    public async Task<DadosPix> AtualizarAsync(DadosPix requestCharge, CancellationToken cancellationToken = default)
    {
        try
        {
            await AutenticarAsync();

            ApiHttpClient client = CriarInstancia();

            DadosPix result = await client
                .PrepareClient($"cob/{requestCharge.TransacaoId}", $"gw-dev-app-key={ConfiguracoesApiBb.ChaveApp}")
                .PatchAsync<DadosPix>(requestCharge, MimeTypes.Json, cancellationToken);

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
    /// Solicita a devolução de uma cobrança imediata, através de um e2eid do PixPaid e do ID da devolução.
    /// </summary>
    /// <param name="devolucao">Dados para a devolução da cobrança instantânea</param>
    /// <returns>Dados da cobrança</returns>
    public RespostaDevolucaoPix Devolver(DadosDevolucaoPix devolucao)
    {
        RespostaDevolucaoPix result = DevolverAsync(devolucao).Result;
        return result;
    }

    /// <summary>
    /// Solicita a devolução de uma cobrança imediata, através de um e2eid do PixPaid e do ID da devolução como uma operação assíncrona.
    /// </summary>
    /// <param name="devolucao">Dados para a devolução da cobrança instantânea</param>
    /// <param name="cancellationToken">Token de notificação de cancelamento de threads gerenciadas.</param>
    /// <returns>Dados da cobrança</returns>
    public async Task<RespostaDevolucaoPix> DevolverAsync(DadosDevolucaoPix devolucao, CancellationToken cancellationToken = default)
    {
        try
        {
            await AutenticarAsync();

            ApiHttpClient client = CriarInstancia();

            RespostaDevolucaoPix result = await client
                .PrepareClient($"pix/{devolucao.EndToEndId}/devolucao/{devolucao.Id}", $"gw-dev-app-key={ConfiguracoesApiBb.ChaveApp}")
                .PutAsync<RespostaDevolucaoPix>(devolucao, MimeTypes.Json, cancellationToken);

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
    /// Consulta a devolução de uma cobrança imediata, através de um e2eid do PixPaid e do ID da devolução.
    /// </summary>
    /// <param name="devolucao">Dados para a devolução da cobrança instantânea</param>
    /// <returns>Dados da cobrança</returns>
    public RespostaDevolucaoPix ConsultarDevolucao(DadosDevolucaoPix devolucao)
    {
        RespostaDevolucaoPix result = ConsultarDevolucaoAsync(devolucao).Result;
        return result;
    }

    /// <summary>
    /// Consulta a devolução de uma cobrança imediata, através de um e2eid do PixPaid e do ID da devolução como uma operação assíncrona.
    /// </summary>
    /// <param name="devolucao">Dados para a devolução da cobrança instantânea</param>
    /// <param name="cancellationToken">Token de notificação de cancelamento de threads gerenciadas.</param>
    /// <returns>Dados da cobrança</returns>
    public async Task<RespostaDevolucaoPix> ConsultarDevolucaoAsync(DadosDevolucaoPix devolucao, CancellationToken cancellationToken = default)
    {
        try
        {
            await AutenticarAsync();

            ApiHttpClient client = CriarInstancia();

            RespostaDevolucaoPix result = await client
                .PrepareClient($"pix/{devolucao.EndToEndId}/devolucao/{devolucao.Id}", $"gw-dev-app-key={ConfiguracoesApiBb.ChaveApp}")
                .GetAsync<RespostaDevolucaoPix>(MimeTypes.Json, cancellationToken);

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
    /// Efetua a simulação do pagamento de um QR Code gerado em homologação.
    /// Recurso exclusivo do ambiente de homologação.
    /// </summary>
    /// <param name="qrCode">O Conteudo do campo <see cref="DadosPix.PixCopiaCola"/>, recebido na resposta da criação da cobrança</param>
    /// <returns>Os dados de pagamento</returns>
    public DadosPagamentoPix Pagar(string qrCode)
    {
        DadosPagamentoPix result = PagarAsync(qrCode).Result;
        return result;
    }

    /// <summary>
    /// Efetua a simulação do pagamento de um QR Code gerado em homologação. Recurso exclusivo do ambiente de homologação como uma operação assíncrona.
    /// </summary>
    /// <param name="qrCode">O Conteudo do campo <see cref="DadosPix.PixCopiaCola"/>, recebido na resposta da criação da cobrança</param>
    /// <param name="cancellationToken">Token de notificação de cancelamento de threads gerenciadas.</param>
    /// <returns>Os dados de pagamento</returns>
    public async Task<DadosPagamentoPix> PagarAsync(string qrCode, CancellationToken cancellationToken = default)
    {
        try
        {
            if (ConfiguracoesApiBb.AmbienteApi == AmbienteApi.Producao)
                throw new NotSupportedException("O metodo de pagar, deve ser usado exclusivamente em desenvolvimento, para simular um pagamento com QR Code");

            await AutenticarAsync();

            ApiHttpClient client = new ApiHttpClient("https://api.hm.bb.com.br/testes-portal-desenvolvedor/v1")
            {
                AuthenticationHeader = new AuthenticationHeaderValue(TipoTokenAccesso, TokenAccesso)
            };

            RespostaPagamentoPix result = await client
                .PrepareClient("boletos-pix/pagar", "gw-app-key=95cad3f03fd9013a9d15005056825665")
                .PostAsync<RespostaPagamentoPix>(new { pix = qrCode }, MimeTypes.Json, cancellationToken);

            DadosPagamentoPix Payment = await ConsultarPagamentoAsync(result.EndToEndId, cancellationToken);

            return Payment;
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
    /// <param name="e2eId">O Id fim a fim da transação</param>
    /// <returns>Dados do pagamento</returns>
    public DadosPagamentoPix ConsultarPagamento(string e2eId)
    {
        DadosPagamentoPix result = ConsultarPagamentoAsync(e2eId).Result;
        return result;
    }

    /// <summary>
    /// Consultar o pagamento de um cobrança, através de um e2eid do PixPaid como uma operação assíncrona.
    /// </summary>
    /// <param name="e2eId">O Id fim a fim da transação</param>
    /// <param name="cancellationToken">Token de notificação de cancelamento de threads gerenciadas.</param>
    /// <returns>Dados do pagamento</returns>
    public async Task<DadosPagamentoPix> ConsultarPagamentoAsync(string e2eId, CancellationToken cancellationToken = default)
    {
        try
        {
            await AutenticarAsync();

            ApiHttpClient client = CriarInstancia();

            DadosPagamentoPix result = await client
                .PrepareClient($"pix/{e2eId}", $"gw-dev-app-key={ConfiguracoesApiBb.ChaveApp}")
                .GetAsync<DadosPagamentoPix>(MimeTypes.Json, cancellationToken);

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