using MarsOnboardingTask.Utils;
using OpenQA.Selenium;

namespace MarsOnboardingTask.Pages
{

    
    public class Login : Hooks
    {
        private IWebElement signInButton => Driver.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/div[1]/div/a"));
        private IWebElement emailAddressTextBox => Driver.driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
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
}