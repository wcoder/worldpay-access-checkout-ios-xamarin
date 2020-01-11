//
//  ViewController.m
//  AccessCheckoutSDKBinding
//
//  Created by Yauheni Pakala on 1/11/20.
//  Copyright © 2020 Yauheni Pakala. All rights reserved.
//

#import "ViewController.h"

#import <AccessCheckoutSDK-Swift.h>

@interface ViewController ()

@end

@implementation ViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    // Do any additional setup after loading the view.
    
    
//    PANView *pv= [[PANView alloc] init];
        
    MySuperClass *sc = [[MySuperClass alloc] init];

    [sc testLog];
    
//    NSString *s = [sc getValue];
}


@end
