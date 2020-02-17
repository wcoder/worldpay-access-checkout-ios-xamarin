//
// AccessCheckoutClientValidationError.cs
//
// Author:
//       Yauheni Pakala <evgeniy.pakalo@gmail.com>
//
// Copyright (c) 2020 Yauheni Pakala
//

namespace AccessCheckoutSDK
{
    /// <summary>
    /// Describes an Access Checkout validation error
    /// </summary>
    public enum AccessCheckoutClientValidationError
    {
        /// <summary>
        /// Field is not recognized
        /// </summary>
        UnrecognizedField,

        /// <summary>
        /// Reference must be a valid value
        /// </summary>
        FieldHasInvalidValue,

        /// <summary>
        /// Mandatory field is missing
        /// </summary>
        FieldIsMissing,

        /// <summary>
        /// String is too short
        /// </summary>
        StringIsTooShort,

        /// <summary>
        /// String is too long
        /// </summary>
        StringIsTooLong,

        /// <summary>
        /// The identified field contains a PAN that has failed the Luhn check
        /// </summary>
        PanFailedLuhnCheck,

        /// <summary>
        /// Field must be an integer
        /// </summary>
        FieldMustBeInteger,

        /// <summary>
        /// Integer is too small
        /// </summary>
        IntegerIsTooSmall,

        /// <summary>
        /// Integer is too large
        /// </summary>
        IntegerIsTooLarge,

        /// <summary>
        /// Field must be numeric
        /// </summary>
        FieldMustBeNumber,

        /// <summary>
        /// String failed regex
        /// </summary>
        StringFailedRegexCheck,

        /// <summary>
        /// Date format invalid
        /// </summary>
        DateHasInvalidFormat,

        /// <summary>
        /// Unknown error
        /// </summary>
        Unknown,
    }
}