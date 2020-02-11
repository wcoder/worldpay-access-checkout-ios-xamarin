using Foundation;
using System;
using UIKit;
using Xamarin.iOS.Worldpay.Access.Checkout;

namespace SampleApp.iOS
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            var a = new PANView();

            var b = new MySuperClass();
            var str = b.Value;

            var r = b.DoWork("C# value1", "C# value2");

            submitButton.TouchUpInside += SubmitButton_TouchUpInside;
        }

        private void SubmitButton_TouchUpInside(object sender, EventArgs e)
        {
            //var pan = panView.Text;
            //var month = expiryDateView.Month;
            //var year = expiryDateView.Year;
            //var cvv = cvvView.Text;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}