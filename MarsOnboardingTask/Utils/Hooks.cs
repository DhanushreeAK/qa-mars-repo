using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;



namespace MarsOnboardingTask.Utils

{

    [Binding]
    public class Hooks : Driver
    {
        Driver driver = new Driver();
        //Sets up the test execution.
        [BeforeScenario]
        public void Setup()
        {
            driver.Initialize();
        }
        
        // Concludes the test execution.

        [AfterScenario]
        public void CleanUp()
        {
            driver.Close();
        }
        
       
    }
}