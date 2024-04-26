using System;
using BBNetCore.Enumerators;
using Newtonsoft.Json;

namespace BBNetCore.Converters;

/// <summary>
/// Classe para conversão do enumerador <see cref="TipoCobranca"/> para json e vice-versa.
/// </summary>
public class TipoCobrancaConverter : JsonConverter
{
    /// <summary>
    /// Método que valida se o tipo informado pode ser convertido.
    /// </summary>
    /// <param name="objectType">Tipo do objeto à ser convertido.</param>
    /// <returns>Verdadeiro caso o objeto possa ser convertido e falso caso contrário.</returns>
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(string);
    }

    /// <summary>
    /// Método que transforma o valor json no objeto referente.
    /// </summary>
    /// <param name="reader">Leitor do arquivo json.</param>
    /// <param name="objectType">tipo do objeto à ser convertido.</param>
    /// <param name="existingValue">Valor existente.</param>
    /// <param name="serializer">Serializador json.</param>
    /// <returns>Objeto referente ao valor informado.</returns>
    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        var value = (string)reader.Value;

        return value switch
        {
            "cobv" => TipoCobranca.CobrancaComVencimento,
            "cob" => TipoCobranca.CobrancaImediata,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    /// <summary>
    /// Método que transforma o objeto em sua representação json referente.
    /// </summary>
    /// <param name="writer">Escritor do arquivo json.</param>
    /// <param name="value">Objeto à ser traduzido.</param>
    /// <param name="serializer">Serializador json.</param>
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        TipoCobranca locale = (TipoCobranca)value;
        switch (locale)
        {
            case TipoCobranca.CobrancaComVencimento:
                writer.WriteValue("cobv");
                break;
            case TipoCobranca.CobrancaImediata:
            default:
                writer.WriteValue("cob");
                break;
        }
    }
}