using NUnit.Framework;

namespace WebAddressbookTests
{
    public class TestBase
    {
        protected ApplicationManager applicationManager;

        [SetUp]
        public void SetupTest()
        {
            applicationManager = ApplicationManager.GetInstance();
        }

        [TearDown]
        public void TeardownTest()
        {
        }
    }
}
