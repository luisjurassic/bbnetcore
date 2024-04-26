using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BBNetCore.Converters;

/// <summary>
/// Classe responsável pela conversão da data para um formato específico.
/// </summary>
public class FormataDataConverter : IsoDateTimeConverter
{
    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="FormataDataConverter"/>.
    /// </summary>
    /// <param name="format">Formado de data desejado.</param>
    public FormataDataConverter(string format)
    {
        DateTimeFormat = format;
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
        return string.IsNullOrWhiteSpace(reader.Value?.ToString()) ? DateTime.MinValue : base.ReadJson(reader, objectType, existingValue, serializer);
    }
}