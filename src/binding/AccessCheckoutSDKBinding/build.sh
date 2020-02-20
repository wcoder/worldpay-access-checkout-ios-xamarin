

# 2020 Yauheni Pakala | MIT

# 0
# Cleanup
rm -rf ./DerivedData/

# 1
# Build the framework (https://developer.apple.com/library/archive/documentation/DeveloperTools/Reference/XcodeBuildSettingRef/1-Build_Setting_Reference/build_setting_ref.html)
# for device
xcodebuild \
    -sdk "iphoneos" \
    -arch arm64 \
    -workspace AccessCheckoutSDKBinding.xcworkspace \
    -scheme AccessCheckoutSDKBinding \
    -configuration Release \
    -derivedDataPath ./DerivedData

# for simulator
xcodebuild \
    -sdk "iphonesimulator" \
    -arch x86_64 \
    -workspace AccessCheckoutSDKBinding.xcworkspace \
    -scheme AccessCheckoutSDKBinding \
    -configuration Release \
    -derivedDataPath ./DerivedData

# Notes:
#   show available sdsk
# xcodebuild -showsdks

# 2
# Create a fat library
# duplicate framework
cp -R ./DerivedData/Build/Products/Release-iphoneos/AccessCheckoutSDK/AccessCheckoutSDK.framework AccessCheckoutSDK.framework
# make fat binary
lipo \
    -create \
        ./DerivedData/Build/Products/Release-iphonesimulator/AccessCheckoutSDK/AccessCheckoutSDK.framework/AccessCheckoutSDK \
        ./DerivedData/Build/Products/Release-iphoneos/AccessCheckoutSDK/AccessCheckoutSDK.framework/AccessCheckoutSDK \
    -output AccessCheckoutSDK.framework/AccessCheckoutSDK
# add modules
cp ./DerivedData/Build/Products/Release-iphonesimulator/AccessCheckoutSDK/AccessCheckoutSDK.framework/Modules/AccessCheckoutSDK.swiftmodule/* \
    AccessCheckoutSDK.framework/Modules/AccessCheckoutSDK.swiftmodule/

# 4
# Binding
sharpie bind -sdk iphoneos13.2 AccessCheckoutSDK.framework/Headers/AccessCheckoutSDK-Swift.h

# 5
# Swift Dependencies
# otool -l -arch arm64 AccessCheckoutSDK.framework/AccessCheckoutSDK | grep libswift
#
#   name @rpath/libswiftCore.dylib (offset 24)
#   name @rpath/libswiftFoundation.dylib (offset 24)
#   name @rpath/libswiftObjectiveC.dylib (offset 24)


