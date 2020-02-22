//
// ICard.cs
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
    /// A payment card. Manages card input and validation.
    /// </summary>
    public interface ICard : ICardViewDelegate
    {
        /// <summary>
        /// View capturing the card number
        /// </summary>
        ICardTextView PanView { get; }

        // View capturing the card expiry date
        //var expiryDateView: CardDateView { get }

        /// <summary>
        /// View capturing the card CVV
        /// </summary>
        ICardTextView CvvText { get; }

        // The `Card`'s delegate
        //var cardDelegate: CardDelegate? { get set }

        // The card validator
        //var cardValidator: CardValidator? { get set }

        /// <summary>
        /// Returns: Whether the input captured by the `Card` views represent a valid payment card.
        /// </summary>    
        bool IsValid();
    }
}
