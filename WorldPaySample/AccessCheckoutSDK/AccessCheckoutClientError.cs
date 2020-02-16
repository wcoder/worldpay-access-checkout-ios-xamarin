//
// AccessCheckoutClientError.cs
//
// Author:
//       Yauheni Pakala <evgeniy.pakalo@gmail.com>
//
// Copyright (c) 2020 Yauheni Pakala
//

using System;

namespace AccessCheckoutSDK
{
    /// <summary>
    /// Describes an Access Checkout error
    /// </summary>
    public class AccessCheckoutClientError : Exception
    {
        public AccessCheckoutClientError(string message, AccessCheckoutClientErrors error): base(message)
        {
            Error = error;
        }

        public AccessCheckoutClientErrors Error { get; }
    }

    public enum AccessCheckoutClientErrors
    {
        #region Client errors

        /// <summary>
        /// The body within the request is empty
        /// </summary>
        BodyIsEmpty,
        BodyIsNotJson,
        BodyDoesNotMatchSchema,
        ResourceNotFound,
        EndpointNotFound,
        MethodNotAllowed,
        UnsupportedAcceptHeader,
        UnsupportedContentType,

        #endregion
        
        // Other errors
        
        // TODO: add all errors
        
        
        #region Discovery

        /// <summary>
        /// Access Checkout services undiscoverable
        /// </summary>
        Undiscoverable,
        
        /// <summary>
        /// Unknown error
        /// </summary>
        Unknown

        #endregion
    }
}