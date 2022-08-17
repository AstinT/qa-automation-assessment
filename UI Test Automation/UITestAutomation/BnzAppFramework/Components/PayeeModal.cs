using BnzAppFramework.Common;
using OpenQA.Selenium;

namespace BnzAppFramework.Components
{
    public class PayeeModal : BasePage
    {
        // Locators
        private readonly By payeeNameLocator = By.Id("ComboboxInput-apm-name");
        private readonly By payeeNameConfirmationLocator = By.Id("ComboboxList-apm-name");
        private readonly By bankNumberLocator = By.Id("apm-bank");
        private readonly By addButtonLocator = By.XPath("//*[@id='apm-form']/div[2]/button[3]");
        private readonly By payeeNameValidationLocator = By.XPath("//*[name()='svg' and @class='error-arrow']//following-sibling::label[@for='apm-name']");

        // Constructor
        public PayeeModal(WebDriver webDriver) 
            : base(webDriver)
        {}

        // Functions
        protected override bool EvaluateLoadedStatus()
        {
            return IsElementDisplayed(payeeNameLocator);             
        }

        protected override void ExecuteLoad()
        {
            // We don't load the payees modal directly
        }

        public void FillPayeeName(string payeeName)
        {
            FillElement(payeeNameLocator, payeeName);
            ClickElement(payeeNameConfirmationLocator);
        }

        public void FillBankAccountNumber(string bankAccountNumber)
        {
            string strippedBankAccountNumber = bankAccountNumber.Replace("-", string.Empty);
            FillElement(bankNumberLocator, strippedBankAccountNumber);
        }

        public void ClickAddButton()
        {
            ClickElement(addButtonLocator);
        }

        public bool PayeeNameValidationIsDisplayed()
        {
            return WaitUntilElementIsDisplayed(payeeNameValidationLocator);
        }
    }
}