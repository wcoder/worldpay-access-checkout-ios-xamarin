//
// AccessCheckoutClient.cs
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

namespace AccessCheckoutSDK
{
    /// <summary>
    /// A client for the Access Checkout API
    /// </summary>
    public class AccessCheckoutClient : IAccessClient
    {
        private readonly IDiscovery _discovery;
        private readonly string _merchantIdentifier;

        /// <summary>
        /// Initialises a client for API communication.
        /// </summary>
        /// <param name="discovery">The `IDiscovery` component</param>
        /// <param name="merchantIdentifier">The merchants unique identifier provided by Worldpay</param>
        public AccessCheckoutClient(IDiscovery discovery, string merchantIdentifier)
        {
            _discovery = discovery;
            _merchantIdentifier = merchantIdentifier;
        }

        /// <summary>
        /// Request to create a Verified Tokens Session.
        /// </summary>
        /// <param name="pan"></param>
        /// <param name="expiryMonth"></param>
        /// <param name="expiryYear"></param>
        /// <param name="cvv"></param>
        /// <param name="urlSession"></param>
        /// <param name="completionHandler"></param>
        public void CreateSession(string pan, uint expiryMonth, uint expiryYear, string cvv, NSUrlSession urlSession,
            Action<Result> completionHandler)
        {
            var bundle = NSBundle.MainBundle; // TODO: check bundle
            
            // line: 100
            var url = _discovery.VerifiedTokensSessionEndpoint;
            if (url != null)
            {
                try
                {
                    var request = BuildRequest(url, bundle, pan, expiryMonth, expiryYear, cvv);
                    CreateSession(request, urlSession, completionHandler);
                }
                catch (Exception ex)
                {
                    completionHandler(Result.Failure(ex));
                }
            }
            else
            {
                _discovery.Discover(urlSession, () =>
                {
                    var url2 = _discovery.VerifiedTokensSessionEndpoint;
                    if (url2 != null)
                    {
                        try
                        {
                            var request = BuildRequest(url2, bundle, pan, expiryMonth, expiryYear, cvv);
                            CreateSession(request, urlSession, completionHandler);
                        }
                        catch (Exception ex)
                        {
                            completionHandler(Result.Failure(ex));
                        }
                    }
                    else
                    {
                        completionHandler(Result.Failure(new AccessCheckoutClientError(
                            "Unable to discover services", AccessCheckoutClientErrors.Undiscoverable)));
                    }
                });
            }
        }

        // line: 33
        private NSUrlRequest BuildRequest(NSUrl url, NSBundle bundle, string pan, uint expiryMonth, uint expiryYear, string cvv)
        {
            var request = new NSMutableUrlRequest(url);
            request["Content-Type"] = "application/vnd.worldpay.verified-tokens-v1.hal+json";
            request.HttpMethod = "POST";

            var tokenRequest = new VerifiedTokenRequest
            {
                CardNumber = pan,
                CardExpiryDate = new CardExpiryDate
                {
                    Month = expiryMonth,
                    Year = expiryYear
                },
                Cvc = cvv,
                Identity = _merchantIdentifier
            };
            request.Body = Decoder.Encode(tokenRequest);
            
            // Add user-agent header
            var userAgent = new UserAgent(bundle);
            request[UserAgent.HeaderName] = userAgent.HeaderValue;

            return request;
        }
        
        // line: 58
        private static void CreateSession(NSUrlRequest request, NSUrlSession urlSession,
            Action<Result> completionHandler)
        {
            urlSession.CreateDataTask(request, (data, response, error) =>
            {
                if (data is NSData sessionData)
                {
                    var verifiedTokensResponse = Decoder.DecodeJson<AccessCheckoutResponse>(sessionData);
                    if (verifiedTokensResponse != null && verifiedTokensResponse.Links != null)
                    {
                        var link = verifiedTokensResponse.Links.Endpoints.GetValueOrDefault("verifiedTokens:session");
                        if (link != null && link.Href is string href)
                        {
                            completionHandler(Result.Success(href));
                            return;
                        }
                    }

                    // TODO: check error decode
                    var accessCheckoutClientError = Decoder.DecodeJson<AccessCheckoutClientError>(sessionData);
                    if (accessCheckoutClientError != null)
                    {
                        completionHandler(Result.Failure(accessCheckoutClientError));
                    }
                    else
                    {
                        completionHandler(Result.Failure(new AccessCheckoutClientError(
                            "Failed to decode response data", AccessCheckoutClientErrors.Unknown)));
                    }
                }
                else
                {
                    var ex = error == null
                        ? new AccessCheckoutClientError(
                            "Unexpected response: no data or error returned",
                            AccessCheckoutClientErrors.Unknown)
                        : (Exception)new NSErrorException(error);
                    completionHandler(Result.Failure(ex));
                }
            }).Resume();
        }

        // line: 159
        private class UserAgent
        {
            public const string HeaderName = "X-WP-SDK";
            private const string ValueFormat = "access-checkout-ios/{0}";
            public UserAgent(NSBundle bundle)
            {
                var appVersion = bundle.ObjectForInfoDictionary("CFBundleShortVersionString")?.ToString() ?? "unknown";
                HeaderValue = string.Format(ValueFormat, appVersion);
            }

            public string HeaderValue { get; }
        }

        // line: 136
        private class VerifiedTokenRequest
        {
            public string CardNumber { get; set; }
            public CardExpiryDate CardExpiryDate { get; set; }
            public string Cvc { get; set; }
            public string Identity { get; set; }
        }

        // line: 145
        private class CardExpiryDate
        {
            public uint Month { get; set; }
            public uint Year { get; set; }
        }
    }
}