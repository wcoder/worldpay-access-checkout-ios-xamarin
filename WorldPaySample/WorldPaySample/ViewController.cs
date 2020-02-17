using Foundation;
using System;
using System.Globalization;
using AccessCheckoutSDK;
using CoreFoundation;
using UIKit;

namespace WorldPaySample
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            var baseUrl = new NSUrl("https://try.access.worldpay.com");
            var accessCheckoutDiscovery = new AccessCheckoutDiscovery(baseUrl);
            accessCheckoutDiscovery.Discover(NSUrlSession.SharedSession, () =>
            {
                var accessCheckoutClient = new AccessCheckoutClient(accessCheckoutDiscovery, "<MERCHANT_ID>");

                accessCheckoutClient.CreateSession(
                    pan: "4444333322221111",
                    expiryMonth: 1,
                    expiryYear: 2022,
                    cvv: "123",
                    NSUrlSession.SharedSession,
                    result =>
                    {
                        DispatchQueue.MainQueue.DispatchAsync(() =>
                        {
                            switch ((ResultStatus)result)
                            {
                                case ResultStatus.Success:
                                    // Session is returned here
                                    var session = result.Success;
                                    break;
                                case ResultStatus.Failure:
                                    // Error handling
                                    if (result.Failure is AccessCheckoutClientError accessCheckoutClientError)
                                    {
                                        switch (accessCheckoutClientError.ErrorName)
                                        {
                                            case AccessCheckoutClientErrors.BodyDoesNotMatchSchema:
                                                // Handle validation errors
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        // handle other errors
                                    }
                                    break;
                            }
                        });
                    });
            });
        }
    }
}