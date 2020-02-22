//
// CardConfiguration.cs
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
    /// Representation of a payment card's brands, defaults and validation rules
    /// </summary>
    public class CardConfiguration
    {
        public CardConfiguration()
        {
        }

        // TODO:


        // line: 32
        public class CardValidationRule
        {
            public string Matcher { get; set; }
            public int? MinLength { get; set; }
            public int? MaxLength { get; set; }
            public int? ValidLength { get; set; }
            public CardValidationRule[] SubRules { get; set; }
        }

        // line: 40
        public class CardDefaults
        {
            public CardValidationRule Pan { get; set; }
            public CardValidationRule Cvv { get; set; }
            public CardValidationRule Month { get; set; }
            public CardValidationRule Year { get; set; }

            public static CardDefaults BaseDefaults
            {
                get
                {
                    var panValidationRule = new CardValidationRule()
                    {
                        Matcher = "^\\d{0,19}$",
                        MinLength = 13,
                        MaxLength = 19,
                        ValidLength = null,
                        SubRules = null
                    };

                    var cvvValidationRule = new CardValidationRule()
                    {
                        Matcher = "^\\d{0,4}$",
                        MinLength = 3,
                        MaxLength = 4,
                        ValidLength = null,
                        SubRules = null
                    };

                    var monthValidationRule = new CardValidationRule()
                    {
                        Matcher = "^0[1-9]{0,1}$|^1[0-2]{0,1}$",
                        MinLength = 2,
                        MaxLength = 2,
                        ValidLength = null,
                        SubRules = null
                    };

                    var yearValidationRule = new CardValidationRule()
                    {
                        Matcher = "^\\d{0,2}$",
                        MinLength = 2,
                        MaxLength = 2,
                        ValidLength = null,
                        SubRules = null
                    };

                    return new CardDefaults
                    {
                        Pan = panValidationRule,
                        Cvv = cvvValidationRule,
                        Month = monthValidationRule,
                        Year = yearValidationRule
                    };
                }
            }
        }
    }
}
