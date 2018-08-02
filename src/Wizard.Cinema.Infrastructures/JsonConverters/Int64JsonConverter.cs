using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Wizard.Cinema.Infrastructures.JsonConverters
{
    public class Int64JsonConverter : JsonConverter<long>
    {
        public override long ReadJson(JsonReader reader, Type objectType, long existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var jt = JToken.ReadFrom(reader);

            return jt.Value<long>();
        }

        public override void WriteJson(JsonWriter writer, long value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value.ToString());
        }
    }
}
