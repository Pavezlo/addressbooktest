using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWhithValidCredentionals()
        {
            //prepare
            applicationManager.Auth.LogOut();
            //acction
            AccountData account = new AccountData("admin", "secret");
            applicationManager.Auth.Login(account);
            //verification
            Assert.IsTrue(applicationManager.Auth.IsLoggedIn(account));
        }

        [Test]
        public void LoginWhithInValidCredentionals()
        {
            //prepare
            applicationManager.Auth.LogOut();
            //acction
            AccountData account = new AccountData("admin", "12345");
            applicationManager.Auth.Login(account);
            //verification
            Assert.IsFalse(applicationManager.Auth.IsLoggedIn(account));
        }
    }
}
