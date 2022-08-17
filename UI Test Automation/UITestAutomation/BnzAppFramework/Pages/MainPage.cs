using BnzAppFramework.Common;
using BnzAppFramework.Components;
using OpenQA.Selenium;

namespace BnzAppFramework.Pages
{
    public class MainPage : BasePage
    {
        // Constants
        private const string URL = "https://www.demo.bnz.co.nz/client/";

        // Locators
        private readonly By menuButtonLocator = By.XPath("//*[@id='left']/div[1]/div/button");

        // Constructor
        public MainPage(WebDriver webDriver)
            : base(webDriver)
        {}

        // Functions
        protected override bool EvaluateLoadedStatus()
        {
            if (URL == WebDriver.Url)
                return true;

            return false;
        }

        protected override void ExecuteLoad()
        {
            WebDriver.Navigate().GoToUrl("https://www.demo.bnz.co.nz/client/");
        }

        public NavigationMenu ClickMenuButton()
        {
            ClickElement(menuButtonLocator);
            return new NavigationMenu(WebDriver);
        }

        public bool TransferSuccessfulAlertIsDisplayed()
        {
            throw new NotImplementedException();
        }
    }
}