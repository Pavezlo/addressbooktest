using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCretionTests : TestBase
    {

        [Test]
        public void GroupCreationTest()
        {
            applicationManager.Navigator.GoToHomePage();
            applicationManager.Auth.Login(new AccountData("admin","secret"));
            applicationManager.Navigator.GoToGroupsPage();
            applicationManager.Group.InitNewGroupCreation();
            GroupData group = new GroupData("aaa");
            group.Header = "ddd";
            group.Footer = "ddd";
            applicationManager.Group.FillGroupForm(group);
            applicationManager.Group.SubmitGroupCreation();
            applicationManager.Group.ReturnToGroupPage();
        }
    }
}
