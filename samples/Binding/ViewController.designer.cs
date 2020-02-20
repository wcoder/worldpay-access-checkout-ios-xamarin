// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace SampleApp.iOS
{
    [Register("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode("iOS Designer", "1.0")]
        Xam.iOS.Worldpay.Access.Checkout.CVVView cvvView { get; set; }

        [Outlet]
        [GeneratedCode("iOS Designer", "1.0")]
        Xam.iOS.Worldpay.Access.Checkout.ExpiryDateView expiryDateView { get; set; }

        [Outlet]
        [GeneratedCode("iOS Designer", "1.0")]
        Xam.iOS.Worldpay.Access.Checkout.PANView panView { get; set; }

        [Outlet]
        [GeneratedCode("iOS Designer", "1.0")]
        UIKit.UIActivityIndicatorView spinner { get; set; }

        [Outlet]
        [GeneratedCode("iOS Designer", "1.0")]
        UIKit.UIButton submitButton { get; set; }

        void ReleaseDesignerOutlets()
        {
            if (cvvView != null)
            {
                cvvView.Dispose();
                cvvView = null;
            }

            if (expiryDateView != null)
            {
                expiryDateView.Dispose();
                expiryDateView = null;
            }

            if (panView != null)
            {
                panView.Dispose();
                panView = null;
            }

            if (spinner != null)
            {
                spinner.Dispose();
                spinner = null;
            }

            if (submitButton != null)
            {
                submitButton.Dispose();
                submitButton = null;
            }
        }
    }
}