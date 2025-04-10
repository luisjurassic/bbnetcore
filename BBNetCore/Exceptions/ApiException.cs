using System;
using System.Net;
using System.Net.Http.Headers;
using BBNetCore.Models;
using Newtonsoft.Json;

namespace BBNetCore.Exceptions;

/// <summary>
/// Classe de exceção de requisições HTTP.
/// </summary>
public class ApiException : Exception
{
    /// <summary>
    /// O método HTTP.
    /// </summary> 
    public string Verb { get; }

    /// <summary>
    /// Os cabeçalhos da solicitação enviada.
    /// </summary>
    public HttpRequestHeaders Headers { get; }

    /// <summary>
    /// Frase de motivo que normalmente é enviada pelos servidores junto com o código de status.
    /// </summary>
    public string ReasonPhrase { get; }

    /// <summary>
    /// A representação da URL
    /// </summary>
    public Uri Uri { get; }

    /// <summary>
    /// O conteudo do erro
    /// </summary>
    public string Content { get; }

    /// <summary>
    /// Os cabeçalhos da resposta da solicitação.
    /// </summary>
    public HttpResponseHeaders ResponseHeaders { get; }

    /// <summary>
    /// O status da requisição.
    /// </summary>
    public HttpStatusCode StatusCode { get; }

    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="ApiException"/>.
    /// </summary>
    /// <param name="uri">A representação da URL.</param>
    /// <param name="verb">O método HTTP usado pela mensagem de solicitação.</param>
    /// <param name="reasonPhrase">The reason phrase.</param>
    /// <param name="headers">The headers of the request.</param>
    /// <param name="content">The content.</param>
    /// <param name="statusCode">The status code.</param>
    /// <param name="responseHeaders">The headers of response.</param>
    /// <param name="ex">The ex.</param>
    public ApiException(Uri uri,
        string verb,
        string reasonPhrase,
        HttpRequestHeaders headers,
        string content,
        HttpStatusCode statusCode,
        HttpResponseHeaders responseHeaders,
        Exception ex)
        : base($"Response status code does not indicate success. Url : {uri}, Verb : {verb}, StatusCode : {statusCode}, ReasonPhrase : {reasonPhrase}", ex)
    {
        Verb = verb;
        Uri = uri;
        Content = content;
        StatusCode = statusCode;
        ReasonPhrase = reasonPhrase;
        Headers = headers;
        ResponseHeaders = responseHeaders;
    }
}