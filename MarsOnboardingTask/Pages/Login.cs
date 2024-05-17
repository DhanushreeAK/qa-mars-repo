using FluentAssertions.Execution;
using MarsOnboardingTask.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using static MarsOnboardingTask.Utils.Driver;
using static MarsOnboardingTask.Utils.Helpers;

namespace MarsOnboardingTask.Pages
{


    public class Login
    {

        public void LoginInToApplication()
        {
            driver.Navigate().GoToUrl(Url);
            try
            {
                IWebElement signIn = driver.FindElement(By.XPath("/html/body/div/div/div/div/div/div[1]/div/a"));
                signIn.Click();

                IWebElement emailId = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
                emailId.SendKeys("dhanushreeak@gmail.com");

                IWebElement passwordTextBox = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));
                passwordTextBox.SendKeys("March@2024");

                IWebElement loginButton = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
                loginButton.Click();

            }
            catch (Exception ex)
            {

            }

        }

        /*   : Driver
       {
           private IWebElement signInButton => Driver.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/div[1]/div/a"));
           private static IWebElement emailAddressTextBox =>Driver.driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
           private IWebElement passwordTextBox => Driver.driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));
           private IWebElement loginButton => Driver.driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));


           public void LoginInToApplication(IWebDriver driver)
           {
               Driver.NavigateToApplicationUrl(driver);
               signInButton.Click();
               emailAddressTextBox.SendKeys("dhanushreeak@gmail.com");
               passwordTextBox.SendKeys("March@2024");
               loginButton.Click();
           }


       }

   */

    }
}


