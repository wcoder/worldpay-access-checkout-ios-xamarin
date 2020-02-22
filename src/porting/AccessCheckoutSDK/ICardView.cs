//
// ICardView.cs
//
// Author:
//       Yauheni Pakala <evgeniy.pakalo@gmail.com>
//
// Copyright (c) 2020 Yauheni Pakala
//

using Foundation;

namespace AccessCheckoutSDK
{
    /// <summary>
    /// A view managed by a `Card`
    /// </summary>
    public interface ICardView
    {
        /// <summary>
        /// Is enabled for editing
        /// </summary>
        bool IsEnabled { get; set; }

        /// <summary>
        /// A delegate property
        /// </summary>
        ICardViewDelegate CardViewDelegate { get; set; }

        /// <summary>
        /// Called when a <see cref="ICardView"/> validity changes
        /// </summary>
        /// <param name="valid"></param>
        void IsValid(bool valid);

        /// <summary>
        /// Clear the contents of any view input
        /// </summary>
        void Clear();
    }

    /// <summary>
    /// A view representing a text field
    /// </summary>
    public interface ICardTextView : ICardView
    {
        /// <summary>
        /// The text
        /// </summary>
        string Text { get; }
    }

    /// <summary>
    /// A view representing a date field
    /// </summary>
    public interface ICardDateView : ICardView
    {
        /// <summary>
        /// The date's month
        /// </summary>
        string Month { get; }

        /// <summary>
        /// The date's year
        /// </summary>
        string Year { get; }
    }

    /// <summary>
    /// Delegate to handle <see cref="ICardView"/> events
    /// </summary>
    public interface ICardViewDelegate
    {
        /// <summary>
        /// The value has been updated
        /// </summary>
        /// <param name="value"></param>
        void DidUpdate(string value);

        /// <summary>
        /// The value updates are complete
        /// </summary>
        /// <param name="value"></param>
        void DidEndUpdate(string value);

        /// <summary>
        /// Request permission to update value with changes
        /// </summary>
        /// <param name="value"></param>
        /// <param name="text"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        bool CanUpdate(string value, string text, NSRange range);
    }
}
