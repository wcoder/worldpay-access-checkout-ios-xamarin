using ObjCRuntime;
using Foundation;
using UIKit;

namespace Xamarin.iOS.Worldpay.Access.Checkout
{
    [BaseType(typeof(NSObject), Name = "_TtC17AccessCheckoutSDK12MySuperClass")]
    interface MySuperClass
    {
        // -(NSString * _Nonnull)getValue;
        [Export("getValue")]
        string Value { get; }

        [Export("doWorkWithA:b:")]
        string DoWork(string a, string b);
    }

    // @interface CVVView : UIView
    [BaseType(typeof(UIView), Name = "_TtC17AccessCheckoutSDK7CVVView")]
    interface CVVView
    {
        // -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((objc_designated_initializer));
        //[Export("initWithCoder:")]
        //[DesignatedInitializer]
        //IntPtr Constructor(NSCoder aDecoder);

        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        //[Export("initWithFrame:")]
        //[DesignatedInitializer]
        //IntPtr Constructor(CGRect frame);
    }

    // @interface AccessCheckoutSDK_Swift_217 (CVVView) <UITextFieldDelegate>
    //[Category]
    //[BaseType(typeof(CVVView))]
    //interface CVVView_AccessCheckoutSDK_Swift_217 : IUITextFieldDelegate
    //{
    //    // -(void)textFieldDidEndEditing:(UITextField * _Nonnull)textField;
    //    [Export("textFieldDidEndEditing:")]
    //    void TextFieldDidEndEditing(UITextField textField);

    //    // -(BOOL)textField:(UITextField * _Nonnull)textField shouldChangeCharactersInRange:(NSRange)range replacementString:(NSString * _Nonnull)string __attribute__((warn_unused_result));
    //    [Export("textField:shouldChangeCharactersInRange:replacementString:")]
    //    bool TextField(UITextField textField, NSRange range, string @string);
    //}

    // @interface ExpiryDateView : UIView
    [BaseType(typeof(UIView), Name = "_TtC17AccessCheckoutSDK14ExpiryDateView")]
    interface ExpiryDateView
    {
        // -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((objc_designated_initializer));
        //[Export("initWithCoder:")]
        //[DesignatedInitializer]
        //IntPtr Constructor(NSCoder aDecoder);

        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        //[Export("initWithFrame:")]
        //[DesignatedInitializer]
        //IntPtr Constructor(CGRect frame);
    }

    // @interface AccessCheckoutSDK_Swift_235 (ExpiryDateView) <UITextFieldDelegate>
    //[Category]
    //[BaseType(typeof(ExpiryDateView))]
    //interface ExpiryDateView_AccessCheckoutSDK_Swift_235 : IUITextFieldDelegate
    //{
    //    // -(void)textFieldDidEndEditing:(UITextField * _Nonnull)textField;
    //    [Export("textFieldDidEndEditing:")]
    //    void TextFieldDidEndEditing(UITextField textField);

    //    // -(BOOL)textField:(UITextField * _Nonnull)textField shouldChangeCharactersInRange:(NSRange)range replacementString:(NSString * _Nonnull)string __attribute__((warn_unused_result));
    //    [Export("textField:shouldChangeCharactersInRange:replacementString:")]
    //    bool TextField(UITextField textField, NSRange range, string @string);
    //}

    // @interface PANView : UIView
    [BaseType(typeof(UIView), Name = "_TtC17AccessCheckoutSDK7PANView")]
    interface PANView
    {
        // @property (nonatomic, weak) UIImageView * _Null_unspecified imageView __attribute__((iboutlet));
        [Export("imageView", ArgumentSemantic.Weak)]
        UIImageView ImageView { get; set; }

        // -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((objc_designated_initializer));
        //[Export("initWithCoder:")]
        //[DesignatedInitializer]
        //IntPtr Constructor(NSCoder aDecoder);

        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        //[Export("initWithFrame:")]
        //[DesignatedInitializer]
        //IntPtr Constructor(CGRect frame);
    }

    // @interface AccessCheckoutSDK_Swift_255 (PANView) <UITextFieldDelegate>
    //[Category]
    //[BaseType(typeof(PANView))]
    //interface PANView_AccessCheckoutSDK_Swift_255 : IUITextFieldDelegate
    //{
    //    // -(void)textFieldDidEndEditing:(UITextField * _Nonnull)textField;
    //    [Export("textFieldDidEndEditing:")]
    //    void TextFieldDidEndEditing(UITextField textField);

    //    // -(BOOL)textField:(UITextField * _Nonnull)textField shouldChangeCharactersInRange:(NSRange)range replacementString:(NSString * _Nonnull)string __attribute__((warn_unused_result));
    //    [Export("textField:shouldChangeCharactersInRange:replacementString:")]
    //    bool TextField(UITextField textField, NSRange range, string @string);
    //}
}

