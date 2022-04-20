using System;
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
            if (GroupData.GetAll().Count == 0)
            {
                applicationManager.Group.Create(new GroupData()
                {
                    Name = "hafa"
                });
            }

            if (ContactData.GetAll().Count == 0)
            {
                applicationManager.Contact.Create(new ContactData()
                {
                    Firstname = "afasdsa",
                    Lastname = "dffgfdgd"
                });
            }

            List<GroupData> groups = GroupData.GetAll();

            if (applicationManager.Contact.AllGroupNotContainContacts(groups))
            {
                ContactData contact = ContactData.GetAll().First();
                applicationManager.Contact.AddContactToGroup(contact, groups[0]);
            }

            foreach (GroupData group in groups)
            {
                List<ContactData> contactInGroup = group.GetContacts();
                if (contactInGroup.Count > 0)
                {
                    contactInGroup.Sort();
                    List<ContactData> contactInGroup1 = group.GetContacts();
                    foreach (ContactData contactG in contactInGroup1)
                    {
                        applicationManager.Contact.RemovalContactFromGroup(contactG, group);
                        contactInGroup.Remove(contactG);
                    }

                    List<ContactData> newList = group.GetContacts();
                    contactInGroup.Sort();
                    newList.Sort();
                    Assert.AreEqual(contactInGroup, newList);
                }
            }
            
            Assert.True(applicationManager.Contact.AllGroupNotContainContacts(GroupData.GetAll()));
        }
    }
}