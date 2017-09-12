using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Xamarin.UITest.Android;

namespace XamarinTests.StepsDefinitions
{
    class Hooks
    {
        [SetUp]
        public void BeforeEachTest()
        {
            BaseClass.app = ConfigureApp.Android
                .ApkFile(@"D:\Apps\TD.Xamarin.apk")
                .DeviceSerial("0123456789ABCDEFG")
                .PreferIdeSettings()
                .EnableLocalScreenshots()
                .StartApp();
        }
    }
}
