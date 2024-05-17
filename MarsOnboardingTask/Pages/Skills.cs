using OpenQA.Selenium.Chrome;
using MarsOnboardingTask.Utils;
using OpenQA.Selenium;
using static MarsOnboardingTask.Utils.Driver;


namespace MarsOnboardingTask.Pages
{
    public class Skills : Driver
    {


        //skill feature related locators
        public static IWebElement skillsTab => Driver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
        public static IWebElement addNewSkillButton => Driver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
        public static IWebElement addSkillTextBox => Driver.driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
        public static IWebElement addSkillButton => Driver.driver.FindElement(By.XPath("//input[@value='Add']"));
        public static IWebElement selectBeginnerSkillLevel => Driver.driver.FindElement(By.XPath("//option[@value='Beginner']"));
        public static IWebElement selectIntermediateSkillLevel => Driver.driver.FindElement(By.XPath("//option[@value='Intermediate']"));
        public static IWebElement selectExpertSkillLevel => Driver.driver.FindElement(By.XPath("//option[@value='Expert']"));



        //update skill locators
        public static IWebElement editSkillIcon => Driver.driver.FindElement(By.XPath("//body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[3]/div[1]/div[2]/div[1]/table[1]/tbody[last()]/tr[1]/td[3]/span[1]"));
        public static IWebElement selectBeginnerLevelForEdit => Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select/option[2]"));
        public static IWebElement selectIntermediateLevelForEdit => Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select/option[3]"));

        public static IWebElement selectExpertLevelForEdit => Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select/option[4]"));
        public static IWebElement updateSkillButton => Driver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td/div/span/input[1]"));
        public static IWebElement updatedSkillAndLevel => Driver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]"));

        public static IWebElement updateSkillTextBox => Driver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td/div/div[1]/input"));
        //delete locators
        public static IWebElement deleteLastAddedSkill => Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]"));
        public static IWebElement verifySkillIsDeleted => Driver.driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

        //verify duplicate locators
        public static IWebElement verifySkillNotDuplicated => Driver.driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

        //verify skill with invalid data locator
        public static IWebElement emptyStringValueDisplayAnErrorMessageInTheSkill => Driver.driver.FindElement(By.XPath("/html[1]/body[1]/div[1]"));
        public void ClickOnTheSkillsTab()
        {
            Thread.Sleep(3000);
            skillsTab.Click();
        }

        public void AddSkillsWithExperienceLevel(string skill, string experienceLevel)
        {

            addNewSkillButton.Click();

            addSkillTextBox.SendKeys(skill);
            selectExperienceLevelForAdd(experienceLevel);

            addSkillButton.Click();

        }
        public Boolean VerifyTheSkillAdded(string skill, string experienceLevel)
        {

            Boolean VerifyAddedSkill = false;
            Thread.Sleep(5000);
            IWebElement lastAddedSkillAndLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]"));
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
        public void EditSkillExperienceLevel(string skill, string experienceLevel)
        {
            Thread.Sleep(2000);
            editSkillIcon.Click();
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

        public Boolean VerifyUpdatedSkillExperienceLevel(string skill, string experienceLevel)
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

        public void DeleteSkill(string skill)
        {
            deleteLastAddedSkill.Click();
            Thread.Sleep(5000);
        }

        public Boolean VerifyTheSkillIsDeleted(string skill)
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
        public void DuplicatedSkill(string skill, string experienceLevel)
        {
            Thread.Sleep(5000);
            IWebElement addNewSkillButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addNewSkillButton.Click();
            Thread.Sleep(5000);
            addSkillTextBox.SendKeys(skill);
            Thread.Sleep(2000);
            selectExperienceLevelForAdd(experienceLevel);
            addSkillButton.Click();
        }


        public Boolean VerifySkillIsNotDuplicated(string skill)
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

        public Boolean EmptyStringValueDisplaysAnErrorMessageInTheSkill(string skill)
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


