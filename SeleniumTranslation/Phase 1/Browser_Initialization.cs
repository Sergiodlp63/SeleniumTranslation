using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTests.Phase2;
using SeleniumTranslation.Phase2;

namespace SeleniumTranslation.Phase1
{
    [TestFixture]
    public class Browser_Initialization
    {
        private IWebDriver Mydriver;

        [SetUp] // This is an NUnit attribute, indicating setup before each test
        public void Setup()
        {
            // Initialize the ChromeDriver
            Mydriver = new ChromeDriver();

        }


        [Test]
        public void Run_RegressionTC001()
        {
            // Navigate to the desired URL
            Mydriver.Navigate().GoToUrl("https://www.amazon.com/"); //This is the application under test. 

            TestResultsHandler MyE2ETest = new TestResultsHandler();
            TestBuilder_RegressionTC001 Phase1_Instance;
            Phase1_Instance = new TestBuilder_RegressionTC001();

            Phase1_Instance.TB_SanityTest01_HomePage(MyE2ETest);

            if (MyE2ETest.MyResultsSummary != null)
            {
                Assert.Fail(MyE2ETest.MyResultsSummary);
            }
            else
            {
                TestContext.WriteLine(Convert.ToString(MyE2ETest.MySuccessCount) + "successful testable actions!");
            }


        }

        public TestContext TestContext
        {
            get 
            {
                return TestContext;
            }
            set
            { 
                TestContext = value;
            }
        }


        [TearDown]
        public void TearDown()
        {
           Mydriver.Close();
        }

    } //end of class
} //end of namespace
