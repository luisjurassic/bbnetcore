﻿using Newtonsoft.Json;

namespace BBNetCore.Models;

/// <summary>
/// Classe contendo mensagens de erro reportadas pelo serviço.
/// </summary>
public class ApiErro
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("codigo")]
    public string Codigo { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("versao")]
    public string Versao { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("mensagem")]
    public string Mensagem { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("ocorrencia")]
    public string Ocorrencia { get; set; }
}

/// <summary>
/// Classe contendo mensagens de erro reportadas pelo serviço.
/// </summary>
public class ApiErro2
{
    /// <summary>
    /// Código HTTP do status retornado.
    /// </summary>
    [JsonProperty("statusCode")]
    public int CodigoStatus { get; set; }

    /// <summary>
    /// Typo do erro
    /// </summary>
    [JsonProperty("error")]
    public string Erro { get; set; }

    /// <summary>
    /// Mensagem do problema.
    /// </summary>
    [JsonProperty("message")]
    public string Mensagem { get; set; }
}

/// <summary>
/// Classe contendo mensagens de erro reportadas pelo serviço.
/// </summary>
public class ApiErro3
{
    /// <summary>
    /// URI de referência que identifica o tipo de problema. De acordo com a RFC 7807.
    /// </summary>
    [JsonProperty("type")]
    public string Tipo { get; set; }

    /// <summary>
    /// Descrição resumida do problema.
    /// </summary>
    [JsonProperty("title")]
    public string Descricao { get; set; }

    /// <summary>
    /// Código HTTP do status retornado.
    /// </summary>
    [JsonProperty("status")]
    public int Status { get; set; }

    /// <summary>
    /// Descrição completa do problema.
    /// </summary>
    [JsonProperty("detail")]
    public string Detalhes { get; set; }

    /// <summary>
    /// Identificador de correlação do problema para fins de suporte.
    /// </summary>
    [JsonProperty("violacoes")]
    public Violacoes[] Violacoes { get; set; }
}

/// <summary>
/// Classe contendo informações do problema para fins de suporte.
/// </summary>
public class Violacoes
{
    /// <summary>
    /// Descrição do erro
    /// </summary>
    [JsonProperty("razao")]
    public string Razao { get; set; }

    /// <summary>
    /// Nome da propriedade.
    /// </summary>
    [JsonProperty("propriedade")]
    public string Propriedade { get; set; }

    /// <summary>
    /// Valor da propriedade
    /// </summary>
    [JsonProperty("valor")]
    public string Valor { get; set; }
}