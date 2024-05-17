using MarsOnboardingTask.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using RazorEngine;
using static MarsOnboardingTask.Utils.Driver;




namespace MarsOnboardingTask.StepDefinitions
{
    [Binding]
    public class LanguagesStepDefinitions : Login
    {

        Login loginPageObj;

        Languages languageObj;

       public LanguagesStepDefinitions()
        {
            loginPageObj = new Login();
            languageObj = new Languages();
        }
        

        [Given(@"User logs into Mars application")]
        public void GivenUserLogsIntoMarsApplication()
        {
            loginPageObj.LoginInToApplication();
            ClearLanguagesAdded();

        }

        [When(@"User adds '([^']*)' language with '([^']*)' language level into the languages list")]
        public void WhenUserAddsLanguageWithLanguageLevelIntoTheLanguagesList(string language, string languageLevel)
        {
            languageObj.AddLanguageWithlanguageLevel(language, languageLevel);
        }

        [Then(@"The '([^']*)' language with '([^']*)' language level should be added to languages list")]
        public void ThenTheLanguageWithLanguageLevelShouldBeAddedToLanguagesList(string language, string languageLevel)
        {
            if (languageObj.VerifytheLanguageAdded(language, languageLevel)) {
               
                Assert.Pass(language + " has been added successfully");
            } else
            {
                Assert.Fail(language + " has not been added successfully");
            }
        }

        [When(@"User updates the '([^']*)' language with '([^']*)' language level from the languages list")]
        public void WhenUserUpdatesTheLanguageWithLanguageLevelFromTheLanguagesList(string language, string languageLevel)
        {
            languageObj.UpdateLanguageLevel(language, languageLevel);
        }

        [Then(@"The language level for '([^']*)' language should be updated to '([^']*)'")]
        public void ThenTheLanguageLevelForLanguageShouldBeUpdatedTo(string language, string languageLevel)
        {
            if (languageObj.VerifyUpdatedLanguageLevel(language, languageLevel))
            {
                Assert.Pass("Language with new language level has been updated successfully");
            }
            else
            {
                Assert.Fail("Language with new language level has not been updated successfully");
            }
        }
        [When(@"The User deletes the language '([^']*)'")]
        public void WhenTheUserDeletesTheLanguage(string language)
        {
            languageObj.DeleteLanguage(language);
        }

        [Then(@"The language '([^']*)' should not be visible on the profile page")]
        public void ThenTheLanguageShouldNotBeVisibleOnTheProfilePage(string language)
        {
            if (languageObj.VerifyLanguageIsDeleted(language))
            {
                Assert.Pass(language + " language " + " has been deleted successfully");
            }
            else
            {
                Assert.Fail(language + " language " + " has not been deleted successfully");
            }
        }
        //duplicate scenario

        [When(@"User adds language '([^']*)' with '([^']*)' language level that is already displayed in languages list")]
        public void WhenUserAddsLanguageWithLanguageLevelThatIsAlreadyDisplayedInLanguagesList(string language, string languagelevel)
        {
            languageObj.AddLanguageWithlanguageLevel(language, languagelevel);
        }

        [Then(@"The language '([^']*)' should not be added again in the languages list")]
        public void ThenTheLanguageShouldNotBeAddedAgainInTheLanguagesList(string language)
        {
            languageObj.AddDuplicateLanguage(language);
        }

        [Then(@"'([^']*)' should not be added and error message should be displayed")]
        public void ThenShouldNotBeAddedAndErrorMessageShouldBeDisplayed(string language)
        {
            if (languageObj.EmptyStringValueDisplayAnErrorMessage(language))
            {
                Assert.Pass(language + "cannot be created with an empty value.");
            }
            else
            {
                Assert.Fail(language + "has been created with an empty value.");
            }
        }



        private void ClearLanguagesAdded()
        {
           
            var recordTables = driver.FindElements(By.TagName("table"));

            for(int i = 0; i < recordTables.Count;i++)
            {
                try
                {
                    var tbody = recordTables[i].FindElement(By.TagName("tbody"));

                    if (tbody != null)
                    {
                        var rows = tbody.FindElements(By.TagName("tr"));

                        for(int j = 0; j < rows.Count; j++)
                        {
                            var deleteIcon = driver.FindElement(By.CssSelector(".remove.icon"));
                            deleteIcon.Click();
                            Thread.Sleep(2000);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No languages found");
                    }
                }
                catch (NoSuchElementException ex)
                {
                    Console.WriteLine("No tbody found in this table." + ex.Message);
                    break;
                }
            }
        }
    }
}

