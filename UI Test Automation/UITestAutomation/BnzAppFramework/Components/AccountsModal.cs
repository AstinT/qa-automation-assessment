using BnzAppFramework.Common;
using OpenQA.Selenium;

namespace BnzAppFramework.Components
{
    public class AccountsModal : BasePage
    {
        // Locators
        private readonly By searchLocator = By.XPath("/html/body/div[7]/div/div/div[2]/div/div/div/span/span[1]/input");
        private readonly By firstFromAccountLocator = By.XPath("/html/body/div[7]/div/div/div[2]/div/div/ul/li/button/div/div/div[2]/p[2]");
        private readonly By firstToAccountLocator = By.XPath("/html/body/div[7]/div/div/div[2]/div/div/section/ul/li/button/div/div/div[2]/p[2]");

        // Constructor
        public AccountsModal(WebDriver webDriver)
            : base(webDriver)
        { }

        // Functions
        protected override bool EvaluateLoadedStatus()
        {
            return IsElementDisplayed(searchLocator);
        }

        protected override void ExecuteLoad()
        {
            // We don't load the payees modal directly
        }
        
        public void FillSearch(string searchValue)
        {
            FillElement(searchLocator, searchValue);
        }

        public void ClickFromFirstAccount()
        {
            IWebElement account = FindElement(firstFromAccountLocator);
            IJavaScriptExecutor js = WebDriver;
            js.ExecuteScript("arguments[0].click()", account);
        }

        public void ClickToFirstAccount()
        {
            IWebElement account = FindElement(firstToAccountLocator);
            IJavaScriptExecutor js = WebDriver;
            js.ExecuteScript("arguments[0].click()", account);
        }
    }
}
