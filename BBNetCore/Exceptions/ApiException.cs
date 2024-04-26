using System;
using BBNetCore.Models;
using Newtonsoft.Json;

namespace BBNetCore.Exceptions;

/// <summary>
/// Classe de exceção básica da biblioteca.
/// </summary>
public class ApiException : Exception
{
    /// <summary>
    /// Erros reportados pelo serviço.
    /// </summary>
    public ApiErro[] Errors { get; set; }

    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="ApiException"/>.
    /// </summary>
    /// <param name="message">Mensagem à ser definida na excessão.</param>
    public ApiException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="ApiException"/>.
    /// </summary>
    /// <param name="ex">Os dados da execção.</param>
    public ApiException(HttpException ex)
        : base(ex.Content)
    {
        try
        {
            Errors = JsonConvert.DeserializeObject<ApiErro[]>(ex.Content);
        }
        catch
        {
            // ignored
        }
    }
}