//
// AccessCheckoutClientError.cs
//
// Author:
//       Yauheni Pakala <evgeniy.pakalo@gmail.com>
//
// Copyright (c) 2020 Yauheni Pakala
//

using System;
using System.Collections.Generic;

namespace AccessCheckoutSDK.Core
{
    /// <summary>
    /// Describes an Access Checkout error
    /// </summary>
    public class AccessCheckoutClientError : Exception
    {
        public AccessCheckoutClientError(string message, AccessCheckoutClientErrors error) : base(message)
        {
            ErrorName = error;
        }

        public AccessCheckoutClientErrors ErrorName { get; set; }
        public List<ValidationError> ValidationErrors { get; set; }
    }

    public class ValidationError
    {
        public AccessCheckoutClientValidationError ErrorName { get; set; }
        public string Message { get; set; }
        public string JsonPath { get; set; }
    }

    public enum AccessCheckoutClientErrors
    {
        // MARK: Client errors

        /// <summary>
        /// The body within the request is empty
        /// </summary>
        BodyIsEmpty,

        /// <summary>
        /// The body within the request is not valid json
        /// </summary>
        BodyIsNotJson,

        /// <summary>
        /// The json body provided does not match the expected schema
        /// </summary>
        BodyDoesNotMatchSchema,

        /// <summary>
        /// Requested resource was not found
        /// </summary>
        ResourceNotFound,

        /// <summary>
        /// Requested endpoint was not found
        /// </summary>
        EndpointNotFound,

        /// <summary>
        /// Requested method is not allowed
        /// </summary>
        MethodNotAllowed,

        /// <summary>
        /// Accept header is not supported
        /// </summary>
        UnsupportedAcceptHeader,

        /// <summary>
        /// Content-type header is not supported
        /// </summary>
        UnsupportedContentType,

        // MARK: Other errors

        /// <summary>
        /// Session could not be found
        /// </summary>
        SessionNotFound,

        /// <summary>
        /// Too many tokens created for this namespace
        /// </summary>
        TooManyTokensForNamespace,

        /// <summary>
        /// The card brand is not recognized
        /// </summary>
        UnrecognizedCardBrand,

        /// <summary>
        /// Token expiry exceeds maximum time range
        /// </summary>
        TokenExpiryDateExceededMaximum,

        /// <summary>
        /// Card brand is not supported
        /// </summary>
        UnsupportedCardBrand,

        /// <summary>
        /// Reference must be a valid value
        /// </summary>
        FieldHasInvalidValue,

        /// <summary>
        /// Verification currency is not supported
        /// </summary>
        UnsupportedVerificationCurrency,

        /// <summary>
        /// Maximum number of updates for this token exceeded
        /// </summary>
        MaximumUpdatesExceeded,

        /// <summary>
        /// API rate limit exceeded
        /// </summary>
        ApiRateLimitExceeded,

        // MARK: Auth errors

        /// <summary>
        /// Unauthorized
        /// </summary>
        Unauthorized,

        /// <summary>
        /// Invalid authentication credentials
        /// </summary>
        InvalidCredentials,

        /// <summary>
        /// Access to the requested resource has been denied
        /// </summary>
        AccessDenied,

        // MARK: Server errors

        /// <summary>
        /// Internal server error
        /// </summary>
        InternalServerError,

        /// <summary>
        /// Payment instrument cannot be tokenized
        /// </summary>
        NotTokenizable,

        /// <summary>
        /// Internal error: token not created
        /// </summary>
        InternalErrorTokenNotCreated,

        // MARK: Discovery

        /// <summary>
        /// Access Checkout services undiscoverable
        /// </summary>
        Undiscoverable,

        /// <summary>
        /// Unknown error
        /// </summary>
        Unknown
    }
}