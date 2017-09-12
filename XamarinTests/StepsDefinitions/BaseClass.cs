using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Xamarin.UITest.Android;

namespace XamarinTests.StepsDefinitions
{
    public static class BaseClass
    {
        public static AndroidApp app = ConfigureApp.Android
                .ApkFile(@"D:\Apps\StarMDC.Xamarin.TD_2017_09_11.apk")
                .DeviceSerial("0123456789ABCDEFG")
                .PreferIdeSettings()
                .EnableLocalScreenshots()
                .StartApp();
    }
}
