//
// CVVView.cs
//
// Author:
//       Yauheni Pakala <evgeniy.pakalo@gmail.com>
//
// Copyright (c) 2020 Yauheni Pakala
//

using CoreGraphics;
using Foundation;
using System;
using UIKit;

namespace AccessCheckoutSDK
{
    public partial class CVVView : UIView, ICardTextView, IUITextFieldDelegate
    {
        /// <summary>
        /// The delegate to handle view events
        /// </summary>
        public ICardViewDelegate CardViewDelegate { get; set; }

        /// <summary>
        /// The CVV represented by the view
        /// </summary>
        public string Text
        {
            get
            {
                if (textField.Text is string text && string.IsNullOrEmpty(text))
                {
                    return text;
                }
                return null;
            }
        }

        /// <summary>
        /// Initialize <see cref="CVVView"/> from storyboard
        /// </summary>
        /// <param name="handle"></param>
        public CVVView(IntPtr handle) : base(handle)
        {
            SetupViewFromNib();
        }

        /// <summary>
        /// Initializer override
        /// </summary>
        /// <param name="frame"></param>
        public CVVView(CGRect frame) : base(frame)
        {
            SetupViewFromNib();
        }

        private void SetupViewFromNib()
        {
            var nib = UINib.FromName(nameof(CVVView), NSBundle.MainBundle);
            var view = nib.Instantiate(this, null)[0] as UIView;
            view.Frame = Bounds;
            view.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
            AddSubview(view);

            textField.WeakDelegate = this;
            textField.EditingChanged += TextFieldDidChange;
        }

        // line: 50
        private void TextFieldDidChange(object sender, EventArgs e)
        {
            if (sender is UITextField txtField && txtField.Text is string cvv)
            {
                CardViewDelegate?.DidUpdate(cvv);
            }
        }

        // line: 58
        #region ICardTextView

        // line: 61
        /// <summary>
        /// View is enabled for editing
        /// </summary>
        public bool IsEnabled
        {
            get => textField.Enabled;
            set => textField.Enabled = value;
        }

        // line: 76
        /// <summary>
        /// The validity of the CVV has updated.
        /// </summary>
        /// <param name="valid">View represents a valid CVV</param>
        public void IsValid(bool valid)
        {
            textField.TextColor = valid ? UIColor.Black : UIColor.Red;
        }

        // line: 81
        /// <summary>
        /// Clears any text input.
        /// </summary>
        public void Clear()
        {
            textField.Text = string.Empty;
        }

        #endregion

        // line: 86
        #region IUITextFieldDelegate

        // line: 87
        [Export("textFieldDidEndEditing:")]
        public void TextFieldDidEndEditing(UITextField textField)
        {
            if (textField.Text is string cvv)
            {
                CardViewDelegate?.DidEndUpdate(cvv);
            }
        }

        // line: 93
        [Export("textField:shouldChangeCharactersInRange:replacementString:")]
        public bool TextFieldChangeCharactersInRangeReplacementString(
            UITextField textField,
            NSRange range,
            string replacementString)
        {
            return CardViewDelegate?.CanUpdate(textField.Text, replacementString, range) ?? false;
        }

        #endregion
    }
}