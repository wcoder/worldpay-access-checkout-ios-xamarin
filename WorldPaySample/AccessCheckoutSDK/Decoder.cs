//
// Decoder.cs
//
// Author:
//       Yauheni Pakala <evgeniy.pakalo@gmail.com>
//
// Copyright (c) 2020 Yauheni Pakala
//

using Foundation;
using Newtonsoft.Json;

namespace AccessCheckoutSDK
{
    public static class Decoder
    {
        // line: 74 - AccessDiscovery
        public static T DecodeJson<T>(NSData data)
        {
            var json = data.ToString();
            var obj = JsonConvert.DeserializeObject<T>(json);
            return obj;
        }
    }
}