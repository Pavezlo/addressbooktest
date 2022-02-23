using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCretionTests : TestBase
    {

        [Test]
        public void GroupCreationTest()
        {
            navigationHelper.GoToHomePage();
            loginHelper.Login(new AccountData("admin","secret"));
            navigationHelper.GoToGroupsPage();
            groupHelper.InitNewGroupCreation();
            GroupData group = new GroupData("aaa");
            group.Header = "ddd";
            group.Footer = "ddd";
            groupHelper.FillGroupForm(group);
            groupHelper.SubmitGroupCreation();
            groupHelper.ReturnToGroupPage();
        }
    }
}
