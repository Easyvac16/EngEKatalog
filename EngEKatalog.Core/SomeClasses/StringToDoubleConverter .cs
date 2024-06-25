using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EngEKatalog.Core.SomeClasses
{
    public class StringToDoubleConverter : JsonConverter<double>
    {
        public override double Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                if (double.TryParse(reader.GetString(), out double result))
                {
                    return result;
                }
                else
                {
                    return 0.0; // або обробіть помилку, як вам потрібно
                }
            }
            else if (reader.TokenType == JsonTokenType.Number && reader.TryGetDouble(out double result))
            {
                return result;
            }

            return 0.0; // або обробіть помилку, як вам потрібно
        }

        public override void Write(Utf8JsonWriter writer, double value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(value);
        }
    }
}
