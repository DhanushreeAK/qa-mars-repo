
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace MarsOnboardingTask.Utils;


public class Driver
{
    public static IWebDriver driver = new ChromeDriver();

    public void Initialize()
    {
        Wait(driver, 10);
        driver.Manage().Window.Maximize();
    }

   
    
    public void Wait(IWebDriver driver, int timeInSeconds)
    {
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeInSeconds);
    }


   
    public static void NavigateToApplicationUrl(IWebDriver driver)
    {
        driver.Navigate().GoToUrl(Helpers.Url);
    }

    public static void Close(IWebDriver driver)
    {
        driver.Quit();
    }
}
