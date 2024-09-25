using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTests.Phase2;
using SeleniumTranslation.Phase2;


namespace SeleniumTranslation.Phase1AND3
{
    [TestFixture]
    public class Setup_And_TearDown
    {
        // Declare WebDriver as a private field
        private IWebDriver Mydriver;

        // This is an NUnit attribute, indicating setup before each test
        [SetUp]
        public void Setup()
        {
            // Initialize the ChromeDriver
            Mydriver = new ChromeDriver();
        }

        [Test]
        public void Run_RegressionTC001()
        {
            // Navigate to the desired URL
            Mydriver.Navigate().GoToUrl("https://www.amazon.com/"); // This is the application under test

            // Initialize test result handler and test case objects
            var MyTestHandler = new TestResultsHandler();
            var LocalTestInstance = new TestBuilder_RegressionTC001(Mydriver, MyTestHandler);

            // Run test actions
            LocalTestInstance.TB_SanityTest01_HomePage(MyTestHandler);

            // Check test results and assert(s) if needed
            if (MyTestHandler.MyResultsSummary != null)
            {
                Assert.Fail(MyTestHandler.MyResultsSummary);
            }
            else
            {
                TestContext.WriteLine(
                    $"{MyTestHandler.MySuccessCount} successful testable actions!"
                );
            }
        }

        // Property to access TestContext for NUnit output
        public TestContext TestContext { get; set; }

        // TearDown method to close WebDriver after tests run
        [TearDown]
        public void TearDown()
        {
            Mydriver?.Quit();
        }
    }
}
