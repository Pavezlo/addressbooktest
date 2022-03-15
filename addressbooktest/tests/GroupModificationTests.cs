using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            if (!applicationManager.Group.GroupCheck())
            {
                GroupData group = new GroupData("aaa");
                group.Header = "ddd";
                group.Footer = "ddd";
                applicationManager.Group.Create(group);                
            }
            GroupData newData = new GroupData("zzz");
            newData.Header = "ttt";
            newData.Footer = "qqq";
            applicationManager.Group.Modify(0,newData);
        }
    }
}
