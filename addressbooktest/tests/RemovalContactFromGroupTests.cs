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
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldlist = group.GetContacts();
            ContactData contact = ContactData.GetAll().Except(oldlist).First();

            applicationManager.Contact.RemovalContactFromGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldlist.Add(contact);
            newList.Sort();
            oldlist.Sort();
            Assert.AreEqual(oldlist,newList);
        }
    }
}