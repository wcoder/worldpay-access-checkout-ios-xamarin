//
// AccessCheckoutResponse.cs
//
// Author:
//       Yauheni Pakala <evgeniy.pakalo@gmail.com>
//
// Copyright (c) 2020 Yauheni Pakala
//

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AccessCheckoutSDK.Core
{
    // line: 3 
    public class AccessCheckoutResponse
    {
        [JsonProperty(PropertyName = "_links")]
        [JsonConverter(typeof(LinksConverter))]
        public Links Links { get; set; }
    }

    // line: 9
    public class Links
    {
        public List<Curie> Curies { get; set; }
        public Dictionary<string, Link> Endpoints { get; set; }
    }

    // line: 59
    public class Link
    {
        public string Href { get; set; }
    }

    // line: 62
    public class Curie
    {
        public string Href { get; set; }
        public string Name { get; set; }
        public bool Templated { get; set; }
    }

    public class LinksConverter : JsonConverter
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // line: 30 TODO
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var obj = JObject.Load(reader);

            var resultObj = new Links
            {
                Curies = new List<Curie>(),
                Endpoints = new Dictionary<string, Link>()
            };

            foreach (var (key, value) in obj)
            {
                // line: 18
                if (key == "curies")
                {
                    resultObj.Curies = value.ToObject<List<Curie>>();
                }
                else
                {
                    resultObj.Endpoints[key] = value.ToObject<Link>();
                }
            }

            return resultObj;
        }

        public override bool CanConvert(Type objectType) => false;
    }
}