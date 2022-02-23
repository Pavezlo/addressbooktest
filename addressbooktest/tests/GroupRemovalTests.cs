using NUnit.Framework;

namespace WebAddressbookTests 

{
    [TestFixture]
    public class GroupRemovalTests :TestBase
    {
        
        [Test]
        public void GroupRemovalTest()
        {
            applicationManager.Navigator.GoToHomePage();
            applicationManager.Auth.Login(new AccountData("admin", "secret"));
            applicationManager.Navigator.GoToGroupsPage();
            applicationManager.Group.SelectGroup(1);
            applicationManager.Group.RemoveGroup();
            applicationManager.Group.ReturnToGroupPage();
            applicationManager.Auth.ReturnToHomePage();
        }
    }
}
