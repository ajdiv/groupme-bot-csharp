using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GroupmeBot.WebHelpers.Converters
{
    public class UnixDateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            try
            {
                return DateTime.UnixEpoch.AddSeconds(reader.GetInt64());
            }
            catch (ArgumentOutOfRangeException)
            {
                return DateTime.MinValue;
            }
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue((value - DateTime.UnixEpoch).TotalMilliseconds + "000");
        }
    }
}
