using System;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using ApplicationCore.Models.Requests;

namespace WebApi.Configs.JsonConverters
{
    public class RegisterAthleteRequestJsonConverter : JsonConverter<RegisterAthleteRequest>
    {
        public override bool CanConvert(Type typeToConvert) => typeof(RegisterAthleteRequest).IsAssignableFrom(typeToConvert);

        public override RegisterAthleteRequest Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            reader.Read();
            if (reader.TokenType != JsonTokenType.PropertyName)
            {
                throw new JsonException();
            }

            string propertyName = reader.GetString();
            if (propertyName.ToLower() != nameof(RegisterAthleteRequest.AthleteType).ToLower())
            {
                throw new JsonException();
            }

            reader.Read();
            if (reader.TokenType != JsonTokenType.Number)
            {
                throw new JsonException();
            }

            AthleteType typeDiscriminator = (AthleteType)reader.GetInt32();
            RegisterAthleteRequest athlete = typeDiscriminator switch
            {
                AthleteType.Athlete => new RegisterAthleteRequest(),
                AthleteType.Lifter => new RegisterLifterRequest(),
                AthleteType.Sprinter => new RegisterSprinterRequest(),
                _ => throw new JsonException()
            };


            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    return athlete;
                }

                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    propertyName = reader.GetString();
                    reader.Read();
                    SetValueOnType(athlete, propertyName, reader);
                }
            }

            throw new JsonException();
        }

        private void SetValueOnType(RegisterAthleteRequest athlete, string propertyName, Utf8JsonReader reader)
        {
            string propertyNameCamelCase = propertyName.First().ToString().ToUpper() + propertyName.Substring(1);
            PropertyInfo propertyInfo = athlete.GetType().GetProperty(propertyNameCamelCase);
            var type = propertyInfo.PropertyType.Name;

            object value;
            switch (type.ToLower())
            {
                case "bool":
                    value = reader.GetBoolean();
                    propertyInfo.SetValue(athlete, value);
                    break;
                case "byte":
                    value = reader.GetByte();
                    propertyInfo.SetValue(athlete, value);
                    break;
                case "sbyte":
                    value = reader.GetSByte();
                    propertyInfo.SetValue(athlete, value);
                    break;
                // może nie zadziałać
                case "char":
                    value = reader.GetString();
                    propertyInfo.SetValue(athlete, value);
                    break;
                case "decimal":
                    value = reader.GetDecimal();
                    propertyInfo.SetValue(athlete, value);
                    break;
                case "double":
                    value = reader.GetDouble();
                    propertyInfo.SetValue(athlete, value);
                    break;
                case "float":
                    value = reader.GetSingle();
                    propertyInfo.SetValue(athlete, value);
                    break;
                case "int":
                    value = reader.GetInt32();
                    propertyInfo.SetValue(athlete, value);
                    break;
                case "uint":
                    value = reader.GetUInt32();
                    propertyInfo.SetValue(athlete, value);
                    break;
                case "nuint":
                    throw new JsonException("Our custom converter sucks with type of nuint - IntPrt");
                case "long":
                    value = reader.GetInt64();
                    propertyInfo.SetValue(athlete, value);
                    break;
                case "ulong":
                    value = reader.GetUInt64();
                    propertyInfo.SetValue(athlete, value);
                    break;
                case "short":
                    value = reader.GetInt16();
                    propertyInfo.SetValue(athlete, value);
                    break;
                case "ushort":
                    value = reader.GetUInt16();
                    propertyInfo.SetValue(athlete, value);
                    break;
                case "string":
                    value = reader.GetString();
                    propertyInfo.SetValue(athlete, value);
                    break;
                case "single":
                    value = reader.GetSingle();
                    propertyInfo.SetValue(athlete, value);
                    break;
                case "dateTime":
                    value = reader.GetDateTime();
                    propertyInfo.SetValue(athlete, value);
                    break;
                case "datetimeoffset":
                    value = reader.GetDateTimeOffset();
                    propertyInfo.SetValue(athlete, value);
                    break;
                case "guid":
                    value = reader.GetGuid();
                    propertyInfo.SetValue(athlete, value);
                    break;

                default:
                    throw new JsonException($"Our custom converter sucks with type of {type.ToLower()}");
            }
        }

        public override void Write(Utf8JsonWriter writer, RegisterAthleteRequest registerRequest, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            //if (person is Customer customer)
            //{
            //    writer.WriteNumber("TypeDiscriminator", (int)TypeDiscriminator.Customer);
            //    writer.WriteNumber("CreditLimit", customer.CreditLimit);
            //}
            //else if (person is Employee employee)
            //{
            //    writer.WriteNumber("TypeDiscriminator", (int)TypeDiscriminator.Employee);
            //    writer.WriteString("OfficeNumber", employee.OfficeNumber);
            //}

            writer.WriteString("Name", registerRequest.Name);
            writer.WriteEndObject();
        }
    }
}
