using Foundation;
using System;
using AccessCheckoutSDK;
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
                
            });
        }
    }
}