using BBNetCore.Converters;
using BBNetCore.Enumerators;
using Newtonsoft.Json;

namespace BBNetCore.Models;

/// <summary>
/// Classe contendo informações da localização do payload.
/// </summary>
public class DadosLocalizacao
{
    /// <summary>
    /// Id da location
    /// </summary>
    [JsonProperty("id")]
    public int Id { get; set; }

    /// <summary>
    /// Localização do payload. Example: http://pix.example.com/qr/v2/2353c790eefb11eaadc10242ac120002
    /// </summary>
    [JsonProperty("location")]
    public string LocalizacaoPayload { get; set; }

    /// <summary>
    /// Tipo da cobrança
    /// </summary>
    [JsonProperty("tipoCob")]
    [JsonConverter(typeof(TipoCobrancaConverter))]
    public TipoCobranca Tipo { get; set; }
}