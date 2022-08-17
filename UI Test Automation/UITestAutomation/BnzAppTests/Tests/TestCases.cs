using BnzAppFramework.Components;
using BnzAppFramework.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace BnzAppTests.Tests
{
    [TestFixture]
    public class TestCases
    {
        private WebDriver webDriver;

        [SetUp]
        public void SetUp()
        {         
            string browser = TestContext.Parameters["browser"];
            webDriver = GetDriver(browser);
        }

        [TearDown]
        public void TearDown()
        {
            webDriver.Quit();
        }

        private static WebDriver GetDriver(string browser)
        {
            WebDriver webDriver;

            switch (browser)
            {
                case "Chrome":
                    webDriver = new ChromeDriver();
                    break;
                case "Firefox":
                    webDriver = new FirefoxDriver();
                    break;
                case "Edge":
                    webDriver = new EdgeDriver();
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
            // Open main page
            MainPage mainPage = new(webDriver);

            // Open navigation menu
            NavigationMenu navigationMenu = mainPage.ClickMenuButton();

            // Open payees page
            PayeesPage payeesPage = navigationMenu.ClickPayeesButton();

            string actual = payeesPage.GetPayeesTitleText();

            Assert.That(actual, Is.EqualTo("Payees"));
        }

        [Test]
        public void VerifyYouCanAddNewPayeeInThePayeesPage()
        {
            string payeeName = "Bob Smith";

            // Open payees page
            PayeesPage payeesPage = new(webDriver);

            // Open payees modal
            PayeeModal payeeModal = payeesPage.ClickAddButton();
            
            // Fill modal and add
            // TODO: Make the next 3 functions, 1 function?
            payeeModal.FillPayeeName(payeeName);
            payeeModal.FillBankAccountNumber("01-1234-1234567-001");
            payeeModal.ClickAddButton();

            // Back on payees page
            bool actual = payeesPage.PayeeAddedAlertLocatorIsDisplayed() 
                && payeesPage.IsPayeeDisplayed(payeeName);

            Assert.That(actual, Is.True);
        }

        [Test]
        public void VerifyPayeeNameIsARequiredField()
        {
            // Open payees page
            PayeesPage payeesPage = new(webDriver);

            // Open payee modal
            PayeeModal payeeModal = payeesPage.ClickAddButton();

            // Trigger errors
            payeeModal.ClickAddButton();
            
            bool firstActual = payeeModal.PayeeNameValidationIsDisplayed();
            Assert.That(firstActual, Is.True);

            // Fill payee name field
            payeeModal.FillPayeeName("Bob Smith");

            bool secondActual = payeeModal.PayeeNameValidationIsDisplayed();
            Assert.That(secondActual, Is.False);
        }

        [Test]
        public void VerifyThatPayeesCanBeSortedByName()
        {
            // Open payees page
            PayeesPage payeesPage = new(webDriver);
            PayeeModal payeeModal = payeesPage.ClickAddButton();

            // Fill modal
            // TODO: Make the next 3 functions, 1 function?
            payeeModal.FillPayeeName("Bob Smith");
            payeeModal.FillBankAccountNumber("01-1234-1234567-001");
            payeeModal.ClickAddButton();

            // Verify default
            bool firstActual = payeesPage.IsPayeesAscending();          
            Assert.That(firstActual, Is.True);

            // Clicking name sort button
            payeesPage.ClickNameSort();

            // Verify after clicking
            bool secondActual = payeesPage.IsPayeesDescending();
            Assert.That(secondActual, Is.True);
        }

        [Test]
        public void NavigateToPaymentsPage()
        {
            // Transfer amount
            int transferAmount = 500;

            // Load payments page
            PaymentsPage paymentsPage = new(webDriver);

            // Click From
            AccountsModal fromAccountsModal = paymentsPage.ClickFrom();
            // Type Everyday to filter list
            fromAccountsModal.FillSearch("Everyday");
            // Select Everyday
            fromAccountsModal.ClickFromFirstAccount();

            // Click To
            AccountsModal toAccountsModal = paymentsPage.ClickTo();
            // Type Bills to filter list
            toAccountsModal.FillSearch("Bills");
            // Select Bills
            toAccountsModal.ClickToFirstAccount();

            // Transfer $500 dollars
            paymentsPage.FillAmountTextBox(transferAmount.ToString());

            // Click transfer
            MainPage mainPage = paymentsPage.ClickTransferButton();            

            //// Check transfer success
            //bool firstActual = mainPage.TransferSuccessfulAlertIsDisplayed();
            //Assert.That(firstActual, Is.True);

            //// Verify current balance
            //double everyBillsBalanceAfterTransfer = paymentsPage.GetFromAccountBalance();
            //double expected = everyBillsBalanceAfterTransfer - transferAmount;            
            
            //Assert.Equals(expected, everyBillsBalanceAfterTransfer);
        }
    }
}
