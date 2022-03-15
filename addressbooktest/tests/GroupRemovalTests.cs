using NUnit.Framework;

namespace WebAddressbookTests 

{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {        
        [Test]
        public void GroupRemovalTest()
        {
            if (!applicationManager.Group.GroupCheck())
            {
                GroupData group = new GroupData("aaa");
                group.Header = "ddd";
                group.Footer = "ddd";
                applicationManager.Group.Create(group);
            }
            applicationManager.Group.Remove(1);
        }
    }
}
