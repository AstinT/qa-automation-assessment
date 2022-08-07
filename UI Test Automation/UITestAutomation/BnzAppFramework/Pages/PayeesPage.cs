using BnzAppFramework.Common;
using OpenQA.Selenium;

namespace BnzAppFramework.Pages
{
    public class PayeesPage : BasePage
    {
        // Constants
        private const string URL = "https://www.demo.bnz.co.nz/client/payees";

        // Locators
        private readonly By payeesTitleLocator = By.XPath("//*[@id='YouMoney']/div/div/div[3]/section/header/h1/span");

        // Constructor
        public PayeesPage(WebDriver webDriver) 
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
            WebDriver.Navigate().GoToUrl("https://www.demo.bnz.co.nz/client/payees");
        }

        public string GetPayeesTitleText()
        {
            return GetElementText(payeesTitleLocator);
        }
    }
}