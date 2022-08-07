using BnzAppFramework.Common;
using OpenQA.Selenium;

namespace BnzAppFramework.Pages
{
    public class PaymentsPage : BasePage
    {
        // Constants
        private const string URL = "https://www.demo.bnz.co.nz/client/payees";

        // Locators

        // Constructor
        public PaymentsPage(WebDriver webDriver)
            : base(webDriver)
        {}

        // Functions
        protected override bool EvaluateLoadedStatus()
        {
            throw new NotImplementedException();
        }

        protected override void ExecuteLoad()
        {
            throw new NotImplementedException();
        }
    }
}
