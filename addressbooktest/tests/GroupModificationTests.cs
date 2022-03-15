using NUnit.Framework;
using System.Collections.Generic;

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

            List<GroupData> oldGroups = applicationManager.Group.GetGroupList();

            applicationManager.Group.Modify(0,newData);

            List<GroupData> newGroups = applicationManager.Group.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
