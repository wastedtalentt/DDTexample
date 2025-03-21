using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using DDTProjectTest.Pages;
using ExampleProject.Framework.Tests;
using Newtonsoft.Json.Linq;

namespace DDTProjectTest.Tests
{
    internal class LoginTests : BaseTest
    {
        private static readonly LoginPage loginPage = new();

        private static readonly JObject testdata;

        
        static LoginTests()
        {
            string jsonPath = Path.Combine(TestContext.CurrentContext.WorkDirectory, "testdata.json");
            testdata = JObject.Parse(File.ReadAllText(jsonPath));
        }

        public static IEnumerable<TestCaseData> TestData()
        {
            foreach (var item in testdata)
            {
                yield return new TestCaseData(
                    item.Value["Name"]?.ToString(),
                    item.Value["Email"]?.ToString()
                );
            }
        }

        [Test, TestCaseSource(nameof(TestData))]
        public void FillTextBoxAndSubmit(string fullName, string email)
        {
            loginPage.InputUsername(fullName);
            loginPage.InputEmail(email);
            loginPage.ScrollToTheElement();     //im using this step to avoid test failure. without this action can't do next step
            loginPage.ClickSubmit();

            Assert.That(loginPage.AppearedBlock, Does.Contain(fullName),$"Block ain't contains {fullName}");
            Assert.That(loginPage.AppearedBlock, Does.Contain(email), $"Block ain't contains {email}");
        }
    }
}
