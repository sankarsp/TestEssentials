using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using TestAutomationEssentials.MSTest;

namespace TestAutomationEssentials.Selenium.UnitTests
{
    [TestClass]
    [DeploymentItem("chromedriver.exe")]
    public class SeleniumTestBase : TestBase
    {
        protected Browser OpenBrowserWithPage(string pageSource)
        {
            var filename = Path.GetTempFileName();
            File.Move(filename, filename += ".html");
            File.WriteAllText(filename, pageSource);
            TestContext.AddResultFile(filename);
            var driver = new ChromeDriver();
            var browser = new Browser("test browser", driver);
            browser.NavigateToUrl(new Uri(filename).AbsoluteUri);
            return browser;
        }
    }
}