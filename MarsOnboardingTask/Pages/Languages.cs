using MarsOnboardingTask.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace MarsOnboardingTask.Pages
{
    public class Languages : Hooks
    {
        public static IWebElement languageTab => Driver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]"));

        public static IWebElement addNewButton => Driver.driver.FindElement(By.XPath("//div[@data-tab='first']//div[@class ='ui teal button ']"));

      public static IWebElement languageData => Driver.driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));

     public static IWebElement languageLevel_Dropdown => Driver.driver.FindElement(By.XPath("//select[@name='level']"));

       public static IWebElement addLanguage_Button => Driver.driver.FindElement(By.XPath("//input[@value='Add']"));

        //Edit locators

        public static IWebElement edit_icon => Driver.driver.FindElement(By.XPath("//div[@data-tab='first']//tbody[last()]/tr/td[3]/span[1]/i"));

        public static IWebElement editLanguageTextBox => Driver.driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));

        public static IWebElement update_Button => Driver.driver.FindElement(By.XPath("//input[@value='Update']"));

        //Delete locators
        public static IWebElement deleteLastLanguage => Driver.driver.FindElement(By.XPath("//body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[last()]/tr[1]/td[3]/span[2]/i[1]"));
        public static IWebElement verifyLanguageIsDeleted => Driver.driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
        public static IWebElement deleteButton => Driver.driver.FindElement(By.XPath("//div[@data-tab='first']//tbody[last()]/tr/td[3]/span[2]/i"));
        //duplicate scenario

        public static IWebElement languageNotDuplicated => Driver.driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

        // invalid data scenario

        public static IWebElement EmptyStringValueDisplayErrorMessage => Driver.driver.FindElement(By.XPath("/html[1]/body[1]/div[1]"));

        //Popup Locator

        public static IWebElement popup_Message => Driver.driver.FindElement(By.XPath("//div[@class=\"ns-box-inner\"]"));

        public static IWebElement updatedLanguageAndlanguagelevel => Driver.driver.FindElement(By.XPath("//body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[last()]/tr[1]"));
      
        public void AddLanguageWithlanguageLevel(IWebDriver driver, string language, string languageLevel)
        {
            
                addNewButton.Click();
                languageData.SendKeys(language);
                SelectElement selectedLevel = new SelectElement((languageLevel_Dropdown));
                selectedLevel.SelectByValue(languageLevel);
                addLanguage_Button.Click();
            
            
            
              
            
        }
        public string VerifytheLanguageAdded(IWebDriver driver, string language, string languageLevel)
        {

            Thread.Sleep(5000);
            string successMessage = popup_Message.Text;
            return successMessage;
        }
        public void UpdateLanguageLevel(IWebDriver driver, string language, string languageLevel)
        {
            Thread.Sleep(7000);
            edit_icon.Click();
            if (!language.Equals("existing", StringComparison.OrdinalIgnoreCase))
            {
                editLanguageTextBox.Clear();
                editLanguageTextBox.SendKeys(language);
            }
            Thread.Sleep(7000);
            SelectElement selectedLevel = new SelectElement((languageLevel_Dropdown));
            selectedLevel.SelectByValue(languageLevel);
            update_Button.Click();
        }


        //Verify the language updated with new language level.

        public Boolean VerifyUpdatedLanguageLevel(IWebDriver driver, string language, string languageLevel)
        {
            Boolean VerifyUpdatedLanguageLevel = false;
            Thread.Sleep(7000);
            string updatedLanguageAndlevel = updatedLanguageAndlanguagelevel.Text;
            if (language.Equals("existing", StringComparison.OrdinalIgnoreCase))
            {
                if (updatedLanguageAndlevel.Contains(languageLevel))
                {
                    VerifyUpdatedLanguageLevel = true;
                }
                else
                {
                    VerifyUpdatedLanguageLevel = false;
                }
            }
            else
            {
                if (updatedLanguageAndlevel.Contains(language) && updatedLanguageAndlevel.Contains(languageLevel))
                {
                    VerifyUpdatedLanguageLevel = true;
                }
                else
                {
                    VerifyUpdatedLanguageLevel = false;
                }
            }

            return VerifyUpdatedLanguageLevel;
        }

        //verify delete operation
        public void DeleteLanguage(IWebDriver driver, string language)
        {
            deleteLastLanguage.Click();
        }

       
        public Boolean VerifyLanguageIsDeleted(IWebDriver driver, string language)
        {
            Boolean VerifyTheLanguageIsDeleted = false;
            Wait(driver, 2);
            if (verifyLanguageIsDeleted.Text.Contains("has been deleted from your languages", StringComparison.OrdinalIgnoreCase))
            {
                VerifyTheLanguageIsDeleted = true;
            }

            return VerifyTheLanguageIsDeleted;
        }

        // verify if user is able to add the already existing language in the Languages section under Profile page
        // 

        public Boolean AddDuplicateLanguage(IWebDriver driver, string language, string language_level)

        {
            Boolean VerifyLanguageNotDuplicated = false;
            Thread.Sleep(2000);
            if (languageNotDuplicated.Text.Contains("is already exist in your language list.", StringComparison.OrdinalIgnoreCase))
            {
                VerifyLanguageNotDuplicated = true;
            }

            return VerifyLanguageNotDuplicated;


        }

        //Verify if user is able to add the language in the Languages section under Profile page with invalid data       
        public Boolean EmptyStringValueDisplayAnErrorMessage(IWebDriver driver, string language)
        {
            Boolean EmptyStringDisplayAnErrorMessage = false;
            Thread.Sleep(3000);
            if (EmptyStringValueDisplayErrorMessage.Text.Contains("Please enter language and level", StringComparison.OrdinalIgnoreCase))
            {
                EmptyStringDisplayAnErrorMessage = true;
            }

            return EmptyStringDisplayAnErrorMessage;
        }

    }
}
