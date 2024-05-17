
using Docker.DotNet.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace MarsOnboardingTask.Utils;


public class Driver
{
    public static IWebDriver driver;
    public void Initialize()
    {
        driver = new ChromeDriver();
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

    public void Close()
    {
        driver.Quit();
    }

}