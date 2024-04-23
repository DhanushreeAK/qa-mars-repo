
using MarsOnboardingTask.Utils;
using OpenQA.Selenium;


namespace MarsOnboardingTask.Pages
{
    public class Skills : Hooks
    {
        //skill feature related locators
        public static IWebElement skillsTab => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
        public static IWebElement addNewSkillButton => driver.FindElement(By.XPath("//div[@class='ui teal button']"));
        public static IWebElement addSkillTextBox => driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
        public static IWebElement selectBeginnerSkillLevel => driver.FindElement(By.XPath("//option[@value='Beginner']"));
        public static IWebElement selectIntermediateSkillLevel => driver.FindElement(By.XPath("//option[@value='Intermediate']"));
        public static IWebElement selectExpertSkillLevel => driver.FindElement(By.XPath("//option[@value='Expert']"));
        public static IWebElement addSkillButton => driver.FindElement(By.XPath("//input[@value='Add']"));
        public static IWebElement lastAddedSkillAndLevel => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]"));

        //update skill locators
        public static IWebElement editSkillIcon => driver.FindElement(By.XPath("//body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[3]/div[1]/div[2]/div[1]/table[1]/tbody[last()]/tr[1]/td[3]/span[1]"));
        public static IWebElement selectBeginnerLevelForEdit => driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select/option[2]"));
        public static IWebElement selectIntermediateLevelForEdit => driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select/option[3]"));
        public static IWebElement selectExpertLevelForEdit => driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select/option[4]"));
        public static IWebElement updateSkillButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td/div/span/input[1]"));
        public static IWebElement updatedSkillAndLevel => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]"));

        public static IWebElement updateSkillTextBox => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td/div/div[1]/input"));
        //delete locators
        public static IWebElement deleteLastAddedSkill => driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]"));
        public static IWebElement verifySkillIsDeleted => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

        //verify duplicate locators
        public static IWebElement verifySkillNotDuplicated => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

        //verify skill with invalid data locator
        public static IWebElement emptyStringValueDisplayAnErrorMessageInTheSkill => driver.FindElement(By.XPath("/html[1]/body[1]/div[1]"));
        public void ClickOnTheSkillsTab(IWebDriver driver)
        {
            skillsTab.Click();
        }

        public void AddSkillsWithExperienceLevel(IWebDriver driver, string skill, string experienceLevel)
        {
            addNewSkillButton.Click();
            addSkillTextBox.SendKeys(skill);
            selectExperienceLevelForAdd(experienceLevel);
            addSkillButton.Click();

        }
        public Boolean VerifyTheSkillAdded(IWebDriver driver, string skill, string experienceLevel)
        {
            Boolean VerifyAddedSkill = false;
            Thread.Sleep(5000);
            string expectedSkillAndExperience = lastAddedSkillAndLevel.Text;
            if (expectedSkillAndExperience.Contains(skill) && expectedSkillAndExperience.Contains(experienceLevel))
            {
                VerifyAddedSkill = true;
            }

            return VerifyAddedSkill;
        }

        private void selectExperienceLevelForAdd(string experienceLevel)
        {
            if (experienceLevel.Equals("beginner", StringComparison.OrdinalIgnoreCase))
            {
                selectBeginnerSkillLevel.Click();
            }
            if (experienceLevel.Equals("intermediate", StringComparison.OrdinalIgnoreCase))
            {
                selectIntermediateSkillLevel.Click();
            }
            if (experienceLevel.Equals("expert", StringComparison.OrdinalIgnoreCase))
            {
                selectExpertSkillLevel.Click();
            }
        }
        public void EditSkillExperienceLevel(IWebDriver driver, string skill, string experienceLevel)
        {
            Thread.Sleep(2000);
            updateSkillTextBox.Click();
            if (!skill.Equals("existing", StringComparison.OrdinalIgnoreCase))
            {
              updateSkillTextBox.Clear();
                updateSkillTextBox.SendKeys(skill);
            }
            Thread.Sleep(2000);
            selectExperienceLevelForEdit(experienceLevel);
            updateSkillButton.Click();
        }
        private void selectExperienceLevelForEdit(string experienceLevel)
        {
            if (experienceLevel.Equals("beginner", StringComparison.OrdinalIgnoreCase))
            {
                selectBeginnerLevelForEdit.Click();
            }
            if (experienceLevel.Equals("intermediate", StringComparison.OrdinalIgnoreCase))
            {
                selectIntermediateLevelForEdit.Click();
            }
            if (experienceLevel.Equals("expert", StringComparison.OrdinalIgnoreCase))
            {
                selectExpertLevelForEdit.Click();
            }
        }
       
        public Boolean VerifyUpdatedSkillExperienceLevel(IWebDriver driver, string skill, string experienceLevel)
        {
            Boolean VerifyUpdatedSkillExperienceLevel = false;
            Thread.Sleep(2000);
            string updatedSkillAndExperience = updatedSkillAndLevel.Text;
            if (skill.Equals("existing", StringComparison.OrdinalIgnoreCase))
            {
                if (updatedSkillAndExperience.Contains(experienceLevel))
                {
                    VerifyUpdatedSkillExperienceLevel = true;
                }
                else
                {
                    VerifyUpdatedSkillExperienceLevel = false;
                }
            }
            else
            {
                if (updatedSkillAndExperience.Contains(skill) && updatedSkillAndExperience.Contains(experienceLevel))
                {
                    VerifyUpdatedSkillExperienceLevel = true;
                }
                else
                {
                    VerifyUpdatedSkillExperienceLevel = false;
                }
            }

            return VerifyUpdatedSkillExperienceLevel;
        }

        //verify user is able to delete a skill 

        public void DeleteSkill(IWebDriver driver, string skill)
        {
            deleteLastAddedSkill.Click();
            Thread.Sleep(5000);
        }

        public Boolean VerifyTheSkillIsDeleted(IWebDriver driver, string skill)
        {
            Boolean verifyTheSkillIsDeleted = false;
            Thread.Sleep(3000);
            if (verifySkillIsDeleted.Text.Contains("has been deleted", StringComparison.OrdinalIgnoreCase))
            {
                verifyTheSkillIsDeleted = true;
            }

            return verifyTheSkillIsDeleted;
        }

        //Duplicate scenario
        //Verify if user is able to add the already existing skill in the Skills section under Profile page
        public void DuplicatedSkill(IWebDriver driver, string skill, string experienceLevel)
        {
            Thread.Sleep(5000);
            addNewSkillButton.Click();
            Thread.Sleep(5000);
            addSkillTextBox.SendKeys(skill);
            Thread.Sleep(2000);
            selectExperienceLevelForAdd(experienceLevel);
            addSkillButton.Click();
        }

        
        public Boolean VerifySkillIsNotDuplicated(IWebDriver driver, string skill)
        {
            Boolean VerifySkillNotDuplicated = false;
            Thread.Sleep(2000);
            if (verifySkillNotDuplicated.Text.Contains("is already exist in your skill list.", StringComparison.OrdinalIgnoreCase))
            {
                VerifySkillNotDuplicated = true;
            }

            return VerifySkillNotDuplicated;
        }

        //Verify if user is able to add a skill with invalid data

        public Boolean EmptyStringValueDisplaysAnErrorMessageInTheSkill(IWebDriver driver, string skill)
        {
            Boolean EmptyStringDisplaysAnErrorMessageInTheSkill = false;
            Thread.Sleep(3000);
            if (emptyStringValueDisplayAnErrorMessageInTheSkill.Text.Contains("Please enter skill and experience" + " level", StringComparison.OrdinalIgnoreCase))
            {
                EmptyStringDisplaysAnErrorMessageInTheSkill = true;
            }

            return EmptyStringDisplaysAnErrorMessageInTheSkill;
        }
    }
}
