using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BnzAppFramework.Common
{
    public abstract class BasePage : LoadableComponent<BasePage>
    {
        // Variables
        public WebDriver WebDriver;

        // Constructor
        public BasePage(WebDriver webDriver)
        {
            WebDriver = webDriver;
            Load();
        }

        // Functions
        protected abstract override bool EvaluateLoadedStatus();

        protected abstract override void ExecuteLoad();

        // Common page functions, could probably be wrapped in another class
        protected IWebElement FindElement(By locator)
        {
            DefaultWait<IWebDriver> fluentWait = new(WebDriver)
            {
                Timeout = TimeSpan.FromSeconds(5),
                PollingInterval = TimeSpan.FromMilliseconds(250)
            };

            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element not found!";

            return fluentWait.Until(x => x.FindElement(locator));
        }

        protected bool ElementIsDisplayed(By locator)
        {
            IWebElement webElement = FindElement(locator);
            return webElement.Displayed;
        }

        public void ClickElement(By locator)
        {
            IWebElement webElement = FindElement(locator);
            webElement.Click();
        }

        public string GetElementText(By locator)
        {
            IWebElement webElement = FindElement(locator);
            return webElement.Text;
        }
    }
}
