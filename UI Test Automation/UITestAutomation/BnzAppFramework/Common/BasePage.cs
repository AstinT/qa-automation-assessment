using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BnzAppFramework.Common
{
    public abstract class BasePage : LoadableComponent<BasePage>
    {
        // Constants
        private const int DEFAULT_WAIT = 5;

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
            WebDriverWait defaultWait = GetDefaultWait(DEFAULT_WAIT);
            return defaultWait.Until(x => x.FindElement(locator));
        }

        protected ReadOnlyCollection<IWebElement> FindElements(By locator)
        {
            WebDriverWait defaultWait = GetDefaultWait(DEFAULT_WAIT);
            return defaultWait.Until(x => x.FindElements(locator));
        }

        protected bool IsElementDisplayed(By locator)
        {
            IWebElement element = FindElement(locator);
            return element.Displayed;
        }

        protected bool WaitUntilElementIsDisplayed(By locator)
        { 
            ReadOnlyCollection<IWebElement> webElements = FindElements(locator);

            if (webElements.Count > 0)
                return webElements.First().Displayed;

            return false;
        }

        protected void ClickElement(By locator)
        {
            IWebElement webElement = FindElement(locator);
            webElement.Click();
        }

        protected string GetElementText(By locator)
        {
            IWebElement webElement = FindElement(locator);
            return webElement.Text;
        }

        protected void FillElement(By locator, string value)
        {
            IWebElement webElement = FindElement(locator);
            webElement.SendKeys(value);
        }

        private WebDriverWait GetDefaultWait(int timeOut)
        {
            return new(WebDriver, TimeSpan.FromSeconds(timeOut));
        }
    }
}