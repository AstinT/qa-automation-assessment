using BnzAppFramework.Components;
using BnzAppFramework.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BnzAppTests.Tests
{
    [TestFixture]
    public class TestCases
    {
        private WebDriver webDriver;

        [SetUp]
        public void SetUp()
        {         
            string baseUrl = TestContext.Parameters["baseUrl"];
            string browser = TestContext.Parameters["browser"];

            webDriver = GetDriver(browser);
            webDriver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            webDriver.Quit();
        }

        private WebDriver GetDriver(string browser)
        {
            WebDriver webDriver;

            switch (browser)
            {
                case "Chrome":
                    webDriver = new ChromeDriver();
                    break;
                case "Firefox":
                    webDriver = new ChromeDriver();
                    break;
                case "Edge":
                    webDriver = new ChromeDriver();
                    break;
                default:
                    // Default to using Chrome if not speificed
                    webDriver = new ChromeDriver();
                    break;
            }

            return webDriver;
        }

        [Test]
        public void VerifyYouCanNavigateToPayeesPageUsingTheNavigationMenu()
        {
            MainPage mainPage = new MainPage(webDriver);
            NavigationMenu navigationMenu = mainPage.ClickMenuButton();
            PayeesPage payeesPage = navigationMenu.ClickPayeesButton();

            string actual = payeesPage.GetPayeesTitleText();

            Assert.That(actual, Is.EqualTo("Payees"));
        }

        [Test]
        public void VerifyYouCanAddNewPayeeInThePayeesPage()
        {
            PayeesPage page = new PayeesPage(webDriver);
        }

        [Test]
        public void VerifyPayeeNameIsARequiredField()
        {
            MainPage mainPage = new(webDriver);
        }

        [Test]
        public void VerifyThatPayeesCanBeSortedByName()
        {
            MainPage mainPage = new(webDriver);
        }

        [Test]
        public void NavigateToPaymentsPage()
        {
            MainPage mainPage = new(webDriver);
        }
    }
}
