using System;
using BBNetCore.Enumerators;
using Newtonsoft.Json;

namespace BBNetCore.Converters;

/// <summary>
/// Classe para conversão do enumerador <see cref="CodigoModalidade"/> para json e vice-versa.
/// </summary>
public class CodigoModalidadeConverter : JsonConverter
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
        var parse = Enum.ToObject(typeof(CodigoModalidade), reader.Value);
        return parse;
    }

    /// <summary>
    /// Método que transforma o objeto em sua representação json referente.
    /// </summary>
    /// <param name="writer">Escritor do arquivo json.</param>
    /// <param name="value">Objeto à ser traduzido.</param>
    /// <param name="serializer">Serializador json.</param>
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        var parse = Enum.TryParse(value?.ToString() ?? string.Empty, out CodigoModalidade aceite);

        writer.WriteValue(((int)(parse ? aceite : CodigoModalidade.Simples)).ToString());
    }
}