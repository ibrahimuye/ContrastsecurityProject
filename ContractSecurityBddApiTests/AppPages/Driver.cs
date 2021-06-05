using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContractSecurityBddApiTests.AppPages
{
    public class Driver : BasePage
    {
        private static List<IWebDriver> _iWebDrivers = new List<IWebDriver>();
        private static readonly ChromeOptions Option = new ChromeOptions();

        public static IWebDriver GetDriver(int index = 0)
        {
            if (_iWebDrivers.ElementAtOrDefault(index) == null)
            {
                switch (GetJsonConfigurationValue("Browser"))
                {
                    case "chrome":
                        _iWebDrivers.Insert(index, new ChromeDriver());
                        _iWebDrivers[index].Manage().Window.Maximize();
                        break;
                    case "chromeHeadless":
                        Option.AddArgument("--headless");
                        Option.AddArgument("--no-sandbox");
                        Option.AddArgument("window-size=1920x1080");
                        Option.AddArgument("--disable-dev-shm-usage");
                        _iWebDrivers.Insert(index, new ChromeDriver(Option));
                        break;
                    case "IE":
                        _iWebDrivers.Insert(index, new InternetExplorerDriver(new InternetExplorerOptions()
                        {
                            IgnoreZoomLevel = true
                        }));
                        _iWebDrivers[index].Manage().Window.Maximize();
                        break;
                    case "firefox":
                        _iWebDrivers.Insert(index, new FirefoxDriver());
                        _iWebDrivers[index].Manage().Window.Maximize();
                        break;
                    case "edge":
                        _iWebDrivers.Insert(index, new EdgeDriver());
                        _iWebDrivers[index].Manage().Window.Maximize();
                        break;
                    default:
                        throw new NotSupportedException("not supported browser " + GetJsonConfigurationValue("Browser"));
                }
            }
            return _iWebDrivers[index];
        }

        public static void CloseDriver()
        {
            for (int index = 0; index < _iWebDrivers.Count; ++index)
            {
                if (_iWebDrivers[index] != null)
                {
                    _iWebDrivers[index].Quit();
                    _iWebDrivers[index] = null;
                }
            }
        }
    }
}
