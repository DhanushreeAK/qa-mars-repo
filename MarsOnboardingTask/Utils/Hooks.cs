using TechTalk.SpecFlow;
using NUnit.Framework;
namespace MarsOnboardingTask.Utils
{

    [Binding]
    public class Hooks : Driver
    {
        //Sets up the test execution.
        [BeforeScenario]
        public void Setup()
        {
            Initialize();
        }


        // Concludes the test execution.

        [AfterScenario]
        public void Cleanup() 
        { 
           driver.Quit();
        }
        
       
    }
}