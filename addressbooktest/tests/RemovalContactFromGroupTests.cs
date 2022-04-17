using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class RemovalContactFromGroupTests :AuthTestBase
    {
        [Test]
        public void TestRemovalContactGroup()
        {
            if (GroupData.GetAll()[0].GetContacts().Count == 0)
            {
                applicationManager.Contact.AddContactToGroup(ContactData.GetAll()[0], GroupData.GetAll()[0]);
            }
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldlist = group.GetContacts();
            ContactData contact = oldlist.First();

            applicationManager.Contact.RemovalContactFromGroup(contact, group);

            Assert.AreEqual(oldlist.Count - 1, GroupData.GetAll()[0].GetContacts().Count);
            
            List<ContactData> newList = group.GetContacts();
            oldlist.RemoveAt(0);
            newList.Sort();
            oldlist.Sort();
            Assert.AreEqual(oldlist,newList);
        }
    }
}