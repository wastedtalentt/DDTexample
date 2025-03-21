using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Utilities;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium;

namespace ExampleProject.Framework.Tests
{
    [TestFixture]   
    internal class BaseTest
    {
        protected Browser browser;
        protected static readonly JsonSettingsFile settings = new("config.json");
        //protected static readonly JsonSettingsFile testdata = new("testdata.json");
        protected static JObject testdata = JObject.Parse(System.IO.File.ReadAllText("testdata.json"));

        [OneTimeSetUp]                  //use this instead of Setup
        public void SetUp()
        {
            browser = AqualityServices.Browser;
            browser.Maximize();
            browser.GoTo(settings.GetValue<string>("url"));
        }

        [OneTimeTearDown]           //instead of TearDown
        public void TearDown()
        {
            browser.Quit();
        }
    }
}
