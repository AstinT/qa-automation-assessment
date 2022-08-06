using BnzAppFramework.Common;
using BnzAppFramework.Components;
using OpenQA.Selenium;

namespace BnzAppFramework.Pages
{
    public class MainPage : BasePage
    {
        public SideMenu sideMenu;

        public MainPage(WebDriver webDriver)
            : base(webDriver)
        {
            sideMenu = new SideMenu(webDriver);
        }
    }
}
