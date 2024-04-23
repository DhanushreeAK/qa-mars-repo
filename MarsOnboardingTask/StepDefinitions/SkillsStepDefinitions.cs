using MarsOnboardingTask.Pages;
using MarsOnboardingTask.Utils;
using NUnit.Framework;

namespace MarsOnboardingTask.StepDefinitions
{
    [Binding]
    public class SkillsStepDefinitions : Hooks
    {
        Login loginPageObj = new Login();
        Skills skillsObj = new Skills();

        [When(@"User clicks on the Skills tab")]
        public void WhenUserClicksOnTheSkillsTab()
        {
            skillsObj.ClickOnTheSkillsTab(driver);
        }


        [When(@"User adds '([^']*)' skill with '([^']*)' experience level into the Skills list")]
        public void WhenUserAddsSkillWithExperienceLevelIntoTheSkillsList(string skill, string experienceLevel)
        {
            skillsObj.AddSkillsWithExperienceLevel(driver, skill, experienceLevel);
        }


        [Then(@"The '([^']*)' skill with '([^']*)' experience level should be added to Skills list")]
        public void ThenTheSkillWithExperienceLevelShouldBeAddedToSkillsList(string skill, string experienceLevel)
        {
            if (skillsObj.VerifyTheSkillAdded(driver, skill, experienceLevel))
            {
                Assert.Pass(skill + " skill " + " with experience level " + experienceLevel + " has been added successfully.");
            }
            else
            {
                Assert.Fail(skill + " skill " + " with experience level " + experienceLevel + " has not been added successfully.");
            }
        }

        [When(@"User edits the '([^']*)' skill with '([^']*)' experience level")]
        public void WhenUserEditsTheSkillWithExperienceLevel(string skill, string experienceLevel)
        {
            skillsObj.EditSkillExperienceLevel(driver, skill, experienceLevel);
        }

        [Then(@"The experience level for '([^']*)' skill should be updated to '([^']*)'")]
        public void ThenTheExperienceLevelForSkillShouldBeUpdatedTo(string skill, string experienceLevel)
        {
            if (skillsObj.VerifyUpdatedSkillExperienceLevel(driver, skill, experienceLevel))
            {
                Assert.Pass("Experience level and skill has been updated successfully");
            }
            else
            {
                Assert.Fail("Experience level and skill has not been updated ");
            }
        }


        [When(@"User deletes the skill '([^']*)'")]
        public void WhenUserDeletesTheSkill(string skill)
        {
            skillsObj.DeleteSkill(driver, skill);

        }

        [Then(@"The skill '([^']*)' should be deleted successfully")]
        public void ThenTheSkillShouldBeDeletedSuccessfully(string skill)
        {
            if (skillsObj.VerifyTheSkillIsDeleted(driver, skill))
            {
                Assert.Pass(skill + " skill " + " has been deleted successfully.");
            }
            else
            {
                Assert.Fail(skill + " skill " + " has not been deleted successfully.");
            }
        }

      

        [When(@"User adds skill '([^']*)' with '([^']*)' experience level that is already present in their skills list")]
        public void WhenUserAddsSkillWithExperienceLevelThatIsAlreadyPresentInTheirSkillsList(string skill, string experienceLevel)
        {
            skillsObj.DuplicatedSkill(driver, skill, experienceLevel);
        }

        [Then(@"The skill '([^']*)' should not be added again in the skills list")]
        public void ThenTheSkillShouldNotBeAddedAgainInTheSkillsList(string skill)
        {
            if (skillsObj.VerifySkillIsNotDuplicated(driver, skill))
            {
                Assert.Pass(skill + " skill " + " is already exist in your skill list.");
            }
            else
            {
                Assert.Fail(skill + " skill " + " has been added to your list");
            }
        }

        //invalid data scenario

        [Then(@"Invalid '([^']*)' should not be added and error message should be displayed")]
        public void ThenInvalidShouldNotBeAddedAndErrorMessageShouldBeDisplayed(string skill)
        {
            if (skillsObj.EmptyStringValueDisplaysAnErrorMessageInTheSkill(driver, skill))
            {
                Assert.Pass("Skill cannot be created with an empty value.");
            }
            else
            {
                Assert.Fail("Skill has been created with an empty value.");
            }
        }

    }
}
