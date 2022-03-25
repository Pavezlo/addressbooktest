using NUnit.Framework;
using System.Collections.Generic;

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
            List<GroupData> oldGroups = applicationManager.Group.GetGroupList();
            GroupData toBeRemoved = oldGroups[0];
            applicationManager.Group.Remove(0);
            Assert.AreEqual(oldGroups.Count - 1, applicationManager.Group.GetGroupCount());
            List<GroupData> newGroups = applicationManager.Group.GetGroupList();
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}
