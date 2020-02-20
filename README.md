# Access Checkout iOS SDK

![version](http://img.shields.io/badge/original-v1.2.1-brightgreen.svg?style=flat)
[![NuGet Badge](https://buildstats.info/nuget/Xamarin.iOS.Worldpay.Access.Checkout?includePreReleases=true)](https://www.nuget.org/packages/Xamarin.iOS.Worldpay.Access.Checkout/)

Port of [Worldpay/access-checkout-ios](https://github.com/Worldpay/access-checkout-ios) SDK for Xamarin.iOS.

A lightweight library and sample app that generates a Worldpay session reference from payment card data.
It includes, optionally, custom iOS views that identifies card brands and validates payment cards and card expiry dates.

## Setup

#### NuGet:

```
Install-Package Xamarin.iOS.Worldpay.Access.Checkout
```

## Integration

https://beta.developer.worldpay.com/docs/access-worldpay/checkout/ios

Also you can see Xamarin.iOS sample [here](samples/Porting/).

### Create an `AccessCheckoutClient` instance

```cs
var baseUrl = new NSUrl("<ACCESS_CHECKOUT_BASE_URL>");
var accessCheckoutDiscovery = new AccessCheckoutDiscovery(baseUrl);

accessCheckoutDiscovery.Discover(NSUrlSession.SharedSession, () =>
{
    var accessCheckoutClient = new AccessCheckoutClient(accessCheckoutDiscovery, "<MERCHANT_ID>");

});
```

### Submitting Form and getting `sessionState`

```cs
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
```

Continue: https://beta.developer.worldpay.com/docs/access-worldpay/checkout/ios/create-sessionstate-ios

## Development

Xamarin.iOS Worldpay Checkout SDK exists in two versions:

- Binding - Binding native Swift library via Objective-C to Xamarin (WIP)
  - TODO
- Porting - Porting Swift source code to equivalent C# code (WIP)
  - TODO
