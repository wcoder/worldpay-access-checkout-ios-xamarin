//
// IDiscovery.cs
//
// Author:
//       Yauheni Pakala <evgeniy.pakalo@gmail.com>
//
// Copyright (c) 2020 Yauheni Pakala
//
using System;
using Foundation;

namespace AccessCheckoutSDK
{
    /// <summary>
    /// Discovery of the Access Worldpay Verified Tokens Session service
    /// </summary>
    public interface IDiscovery
    {
        /// <summary>
        /// The discovered verified tokens session service endpoint
        /// </summary>
        NSUrl VerifiedTokensSessionEndpoint { get; }

        /// <summary>
        /// Starts discovery of services
        /// </summary>
        /// <param name="urlSession"></param>
        /// <param name="onComplete"></param>
        void Discover(NSUrlSession urlSession, Action onComplete);
    }
}