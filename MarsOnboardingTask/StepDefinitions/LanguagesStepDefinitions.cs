using MarsOnboardingTask.Pages;
using MarsOnboardingTask.Utils;
using NUnit.Framework;


namespace MarsOnboardingTask.StepDefinitions
{
    [Binding]
    public class LanguagesStepDefinitions : Hooks
    {
        Login loginPageObj = new Login();
        Languages languageObj = new Languages();

        [Given(@"User logs into Mars application")]
        public void GivenUserLogsIntoMarsApplication()
        {
            loginPageObj.LoginInToApplication(driver);
        }

        [When(@"User adds '([^']*)' language with '([^']*)' language level into the languages list")]
        public void WhenUserAddsLanguageWithLanguageLevelIntoTheLanguagesList(string language, string languageLevel)
        {
            languageObj.AddLanguageWithlanguageLevel(driver, language, languageLevel);
        }

        [Then(@"The '([^']*)' language with '([^']*)' language level should be added to languages list")]
        public void ThenTheLanguageWithLanguageLevelShouldBeAddedToLanguagesList(string language, string languageLevel)
        {
            string notification = languageObj.VerifytheLanguageAdded(driver, language, languageLevel);
            String Message = language + " has been added to your languages";
            String DuplicateMess = "Duplicated data";

            if (notification == (language + " has been added to your languages"))
            {
                Assert.That(notification, Is.EqualTo(Message), notification);
            }

            else if (notification == "Duplicated data")
            {
                Assert.That(notification, Is.EqualTo(DuplicateMess), notification);
                Console.WriteLine(language + " " + notification);

            }
        }

        [When(@"User updates the '([^']*)' language with '([^']*)' language level from the languages list")]
        public void WhenUserUpdatesTheLanguageWithLanguageLevelFromTheLanguagesList(string language, string languageLevel)
        {
            languageObj.UpdateLanguageLevel(driver, language, languageLevel);
        }

        [Then(@"The language level for '([^']*)' language should be updated to '([^']*)'")]
        public void ThenTheLanguageLevelForLanguageShouldBeUpdatedTo(string language, string languageLevel)
        {
            if (languageObj.VerifyUpdatedLanguageLevel(driver, language, languageLevel))
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
            languageObj.DeleteLanguage(driver, language);
        }

        [Then(@"The language '([^']*)' should not be visible on the profile page")]
        public void ThenTheLanguageShouldNotBeVisibleOnTheProfilePage(string language)
        {
            if (languageObj.VerifyLanguageIsDeleted(driver, language))
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
           
        }

        [Then(@"The language '([^']*)' should not be added again in the languages list")]
        public void ThenTheLanguageShouldNotBeAddedAgainInTheLanguagesList(string language)
        {
          
        }

        [Then(@"'([^']*)' should not be added and error message should be displayed")]
        public void ThenShouldNotBeAddedAndErrorMessageShouldBeDisplayed(string language)
        {
            if (languageObj.EmptyStringValueDisplayAnErrorMessage(driver, language))
            {
                Assert.Pass(language + "cannot be created with an empty value.");
            }
            else
            {
                Assert.Fail(language + "has been created with an empty value.");
            }
        }


    }
}

