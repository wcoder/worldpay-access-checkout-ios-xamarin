using AccessCheckoutSDK.Core;
using Newtonsoft.Json;

namespace DebugApiResponse
{
    class Program
    {
        static void Main(string[] args)
        {
            var json = "{\"_links\": {  \"payments:authorize\": {    \"href\": \"https://try.access.worldpay.com/payments/authorizations\"  },  \"service:payments\": {    \"href\": \"https://try.access.worldpay.com/payments\"  },  \"service:tokens\": {    \"href\": \"https://try.access.worldpay.com/tokens\"  },  \"service:verifications/accounts\": {    \"href\": \"https://try.access.worldpay.com/verifications/accounts\"  },  \"service:verifications/customers/3ds\": {    \"href\": \"https://try.access.worldpay.com/verifications/customers/3ds\"  },  \"service:verifiedTokens\": {    \"href\": \"https://try.access.worldpay.com/verifiedTokens\"  },  \"service:payouts\": {    \"href\": \"https://try.access.worldpay.com/payouts\"  },  \"curies\": [    {      \"href\": \"https://try.access.worldpay.com/rels/payments/{rel}\",      \"name\": \"payments\",      \"templated\": true    }  ]}}";

            var obj  = JsonConvert.DeserializeObject<AccessCheckoutResponse>(json);
        }
    }
}