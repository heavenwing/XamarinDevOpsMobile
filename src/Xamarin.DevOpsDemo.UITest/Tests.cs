using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Xamarin.DevOpsDemo.UITest
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app =AppInitializer.StartApp(platform);
        }

        //[Test]
        //public void Repl()
        //{
        //    // Invoke the REPL so that we can explore the user interface
        //    app.Repl();
        //}

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
        }

        [Test]
        public void TapAddButtonShouldDisplayNewItemPage()
        {
            app.Tap(c => c.Marked("Add Item"));
            var result = app.Query(c => c.Marked("Save"));
            Assert.IsTrue(result.Any(), "NewItemPage is not display");
        }
    }
}

