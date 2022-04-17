using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests 

{
    [TestFixture]
    public class GroupRemovalTests : GroupTestBase
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
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeRemoved = oldGroups[0];
            applicationManager.Group.Remove(toBeRemoved);
            Assert.AreEqual(oldGroups.Count - 1, applicationManager.Group.GetGroupCount());
            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}
