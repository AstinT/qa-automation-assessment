using BnzAppFramework.Common;
using BnzAppFramework.Pages;
using OpenQA.Selenium;

namespace BnzAppFramework.Components
{
    public class NavigationMenu : BasePage
    {
        // Locators
        private readonly By payeesButtonLocator = By.XPath("//*[@id='left']/div[1]/div/div[3]/section/div[2]/nav[1]/ul/li[3]/a");

        // Constructor
        public NavigationMenu(WebDriver webDriver) 
            : base(webDriver)
        {}

        // Functions
        protected override bool EvaluateLoadedStatus()
        {
            return ElementIsDisplayed(payeesButtonLocator);
        }

        protected override void ExecuteLoad()
        {
            // We don't load the Navigation menu directly
        }

        public PayeesPage ClickPayeesButton()
        {
            ClickElement(payeesButtonLocator);
            return new PayeesPage(WebDriver);
        }
    }
}