using BnzAppFramework.Common;
using BnzAppFramework.Components;
using OpenQA.Selenium;

namespace BnzAppFramework.Pages
{
    public class PaymentsPage : BasePage
    {
        // Constants
        private const string URL = "https://www.demo.bnz.co.nz/client/payments";

        // Locators
        private readonly By fromLocator = By.XPath("/html/body/div[7]/div/div/div/div/div[1]/div/div[1]/button");
        private readonly By toLocator = By.XPath("/html/body/div[7]/div/div/div/div/div[1]/div/div[2]/button");
        private readonly By fromAccountBalanceLocator = By.XPath("/html/body/div[7]/div/div/div/div/div[1]/div/div[1]/button/div/div/div[2]/p[2]");
        private readonly By toAccountBalanceLocator = By.XPath("/html/body/div[7]/div/div/div/div/div[1]/div/div[2]/button/div/div/div[2]/p[2]");
        private readonly By amountTextBoxLocator = By.XPath("//*[@id='field-bnz-web-ui-toolkit-9']");
        private readonly By TransferButtonLocator = By.XPath("//*[@id='paymentForm']/div[4]/div/button[1]");

        // Constructor
        public PaymentsPage(WebDriver webDriver)
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

        public AccountsModal ClickFrom()
        {
            ClickElement(fromLocator);
            return new AccountsModal(WebDriver);
        }

        public AccountsModal ClickTo()
        {
            ClickElement(toLocator);
            return new AccountsModal(WebDriver);
        }

        public double GetFromAccountBalance()
        {
            throw new NotImplementedException();

            //string fromAccountBalance = GetElementText(fromAccountBalanceLocator);
            //// Remove Avl.
            //string strippedFromAccountBalance = fromAccountBalance.Remove(fromAccountBalance.Length - 5, 5);

            //// Remove $
            //strippedFromAccountBalance = strippedFromAccountBalance.Replace('$', '');

            //// Remove ,
            //strippedFromAccountBalance = strippedFromAccountBalance.Remove(0, 1);

            //return Convert.ToDouble(strippedFromAccountBalance);
        }

        public double GetToAccountBalance()
        {
            throw new NotImplementedException();

            //string toAccountBalance = GetElementText(toAccountBalanceLocator);
            //string strippedFromAccountBalance = toAccountBalance.Remove(toAccountBalance.Length - 5, 5);
            //return Convert.ToDouble(strippedFromAccountBalance);
        }

        public void FillAmountTextBox(string amount)
        {
            FillElement(amountTextBoxLocator, amount);
        }

        public MainPage ClickTransferButton()
        {
            ClickElement(TransferButtonLocator);
            return new MainPage(WebDriver);
        }
    }
}
