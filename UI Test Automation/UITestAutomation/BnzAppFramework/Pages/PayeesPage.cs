using BnzAppFramework.Common;
using BnzAppFramework.Components;
using OpenQA.Selenium;

namespace BnzAppFramework.Pages
{
    public class PayeesPage : BasePage
    {
        // Constants
        private const string URL = "https://www.demo.bnz.co.nz/client/payees";

        // Locators
        private readonly By payeesTitleLocator = By.XPath("//*[@id='YouMoney']/div/div/div[3]/section/header/h1/span");
        private readonly By addButtonLocator = By.XPath("//*[@id='YouMoney']/div/div/div[3]/section/section/div/div[2]/header[2]/div/div[3]/button");
        private readonly By payeeAddedAlertLocator = By.XPath("//*[@id='notification']/div/span[contains(text(),'Payee added')]");
        private readonly By nameSortAscending = By.XPath("//*[local-name()='svg' and @class='Icon IconChevronDownSolid ']");
        private readonly By nameSortDescending = By.XPath("//*[local-name()='svg' and @class='Icon IconChevronUpSolid ']");
        private readonly By nameSort = By.XPath("//*[@id='YouMoney']/div/div/div[3]/section/section/div/div[2]/header[2]/div/div[1]/h3");

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
            WebDriver.Navigate().GoToUrl(URL);
        }

        public string GetPayeesTitleText()
        {
            return GetElementText(payeesTitleLocator);
        }

        public PayeeModal ClickAddButton()
        {
            ClickElement(addButtonLocator);
            return new PayeeModal(WebDriver);
        }

        public void ClickNameSort()
        {
            ClickElement(nameSort);
        }

        public bool PayeeAddedAlertLocatorIsDisplayed()
        { 
            return IsElementDisplayed(By.ClassName("js-notificationShown")) &&
                IsElementDisplayed(payeeAddedAlertLocator);
        }

        public bool IsPayeeDisplayed(string payeeName)
        {
            By locator = By.XPath("//*[contains(text(),'" + payeeName + "')]");
            return IsElementDisplayed(locator);
        }

        public bool IsPayeesAscending()
        {
            return IsElementDisplayed(nameSortAscending);
        }

        public bool IsPayeesDescending()
        {
            return IsElementDisplayed(nameSortDescending);
        }
    }
}