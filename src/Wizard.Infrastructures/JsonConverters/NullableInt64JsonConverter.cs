using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Wizard.Infrastructures.JsonConverters
{
    public class NullableInt64JsonConverter : JsonConverter<long?>
    {
        public override long? ReadJson(JsonReader reader, Type objectType, long? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var jt = JToken.ReadFrom(reader);

            return jt.Value<long?>();
        }

        public override void WriteJson(JsonWriter writer, long? value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value.ToString());
        }
    }
}
