using System;
using System.Linq;
using ApplicationCore.Models.Requests;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WebApi.Configs.JsonConverters
{
    public class SecondConverte : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(RegisterAthleteRequest).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);

            const string propertyName = nameof(RegisterAthleteRequest.AthleteType);
            var fixedPropertyName = propertyName.First().ToString().ToLower() + propertyName.Substring(1);
            var athleteType = (AthleteType)(int)jo[fixedPropertyName];

            RegisterAthleteRequest item;
            item = athleteType switch
            {
                AthleteType.Athlete => new RegisterAthleteRequest(),
                AthleteType.Sprinter => new RegisterSprinterRequest(),
                AthleteType.Lifter => new RegisterLifterRequest(),
                _ => throw new JsonException("Shit Happens")
            };

            serializer.Populate(jo.CreateReader(), item);

            return item;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException("");
        }
    }
}
