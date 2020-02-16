//
// IAccessClient.cs
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
    /// Entrypoint to Access Checkout API
    /// </summary>
    public interface IAccessClient
    {
        /// <summary>
        /// Request to create a Verified Token session
        /// </summary>
        /// <param name="pan">The card number or 'Primary Account Number'</param>
        /// <param name="expiryMonth">The card expiry date month</param>
        /// <param name="expiryYear">The card expiry date year</param>
        /// <param name="cvv">The card CVV</param>
        /// <param name="urlSession"></param>
        /// <param name="completionHandler"></param>
        void CreateSession(
            string pan,
            uint expiryMonth,
            uint expiryYear,
            string cvv,
            NSUrlSession urlSession,
            Action<Result> completionHandler);
    }
}