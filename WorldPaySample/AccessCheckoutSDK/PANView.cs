//
// PANView.cs
//
// Author:
//       Yauheni Pakala <evgeniy.pakalo@gmail.com>
//
// Copyright (c) 2020 Yauheni Pakala
//
using System;
using System.Linq;
using CoreGraphics;
using Foundation;
using UIKit;

namespace AccessCheckoutSDK
{
    [Register(nameof(PANView))]
    public class PANView : UIView
    {
        //UITextField textField;
        //UIImageView imageView;

        //public PAN? Text
        //{
        //    get
        //    {
        //        var text = textField.Text;
        //        return text;
        //    }
        //}

        public PANView(NSCoder coder) : base(coder)
        {
            setupViewFromNib();
        }

        public PANView(CGRect frame) : base(frame)
        {
            setupViewFromNib();
        }

        private void setupViewFromNib()
        {
            var bundle = NSBundle.FromClass(Class); // TODO: check
            var nib = UINib.FromName(nameof(PANView), bundle);
            var view = nib.Instantiate(this, null).First() as UIView;
            view.Frame = Bounds;
            view.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
            AddSubview(view);

            //textField.Placeholder = TODO: add view
            //textField.Delegate =
            //textField.AddTarget

        }
    }
}
