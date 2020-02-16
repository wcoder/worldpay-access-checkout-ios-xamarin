//
// AccessCheckoutDiscovery.cs
//
// Author:
//       Yauheni Pakala <evgeniy.pakalo@gmail.com>
//
// Copyright (c) 2020 Yauheni Pakala
//

using System;
using System.Collections.Generic;
using AccessCheckoutSDK.Core;
using Foundation;
using Newtonsoft.Json;

namespace AccessCheckoutSDK
{
    /// <summary>
    /// Discovers Access Worldpay Verified Tokens Session service
    /// </summary>
    public class AccessCheckoutDiscovery : IDiscovery
    {
        private readonly NSUrl _baseUrl;
        private const string VerifiedTokensServiceLinkId = "service:verifiedTokens";
        private const string VerifiedTokensSessionLinkId = "verifiedTokens:sessions";
        
        private NSUrlSessionTask _accessRootDiscoveryTask;
        private NSUrlSessionTask _verifiedTokensDiscoveryTask;

        /// <summary>
        /// Initialises discovery with the base URL of Access Worldpay services.
        /// </summary>
        /// <param name="baseUrl">The Access Worldpay services root URL</param>
        public AccessCheckoutDiscovery(NSUrl baseUrl)
        {
            _baseUrl = baseUrl;
        }
        
        /// <inheritdoc />
        public NSUrl VerifiedTokensSessionEndpoint { get; private set; }
        
        /// <summary>
        /// Starts the discovery of the Access Worldpay Verified Tokens Session service.
        /// </summary>
        /// <param name="urlSession">A `URLSession` object</param>
        /// <param name="onComplete">Callback upon discovery completion, successful or otherwise</param>
        public void Discover(NSUrlSession urlSession, Action onComplete)
        {
            // Check for existing tasks running
            if (_accessRootDiscoveryTask?.State == NSUrlSessionTaskState.Running ||
                _verifiedTokensDiscoveryTask?.State == NSUrlSessionTaskState.Running)
            {
                return;
            }
            
            // Discovers the root end-point in verified tokens service
            _accessRootDiscoveryTask = urlSession.CreateDataTask(_baseUrl, (data, response, error) =>
            {
                if (data is NSData jsonData)
                {
                    var vtsRootEndPoint = FetchServiceUrl(VerifiedTokensServiceLinkId, jsonData);
                    if (vtsRootEndPoint != null)
                    {
                        DiscoverSessionsEndPoint(urlSession, vtsRootEndPoint, onComplete);
                    }
                    else
                    {
                        onComplete.Invoke();
                    }
                }
                else
                {
                    onComplete.Invoke();
                }
            });
            _accessRootDiscoveryTask?.Resume();
        }

        // line: 62
        private void DiscoverSessionsEndPoint(NSUrlSession urlSession, NSUrl startUrl, Action onComplete)
        {
            _verifiedTokensDiscoveryTask = urlSession.CreateDataTask(startUrl, (data, response, error) =>
            {
                if (data is NSData jsonData)
                {
                    var vtsSessionUrl = FetchServiceUrl(VerifiedTokensSessionLinkId, jsonData);
                    if (vtsSessionUrl != null)
                    {
                        VerifiedTokensSessionEndpoint = vtsSessionUrl;
                    }
                }
                onComplete.Invoke();
            });
            _verifiedTokensDiscoveryTask?.Resume();
        }

        // line: 78
        private NSUrl FetchServiceUrl(string linkId, NSData jsonData)
        {
            NSUrl resultUrl = null;

            try
            {
                var accessCheckoutResponse = DecodeJson(jsonData);
                if (accessCheckoutResponse != null)
                {
                    var serviceMap = accessCheckoutResponse.Links.Endpoints.GetValueOrDefault(linkId);
                    if (serviceMap != null)
                    {
                        resultUrl = NSUrl.FromString(serviceMap.Href);
                    }
                }
            }
            catch (Exception ex)
            {
                var json = jsonData.ToString();
                Console.WriteLine($"Error parsing JSON: {json}. Exception: {ex}");
            }

            return resultUrl;
        }

        // line: 74
        private static AccessCheckoutResponse DecodeJson(NSData data)
        {
            var json = data.ToString();
            var obj = JsonConvert.DeserializeObject<AccessCheckoutResponse>(json);
            return obj;
        }
    }
}