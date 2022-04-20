using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class AddingContactToGroupTests :AuthTestBase
    {
        [Test]
        public void TestAddingContactGroup()
        {
            if (ContactData.GetAll().Count == 0)
            {
                ContactData newContact = new ContactData()
                {
                    Firstname = "hafa"
                };
                applicationManager.Contact.Create(newContact);
            }
            
            if (GroupData.GetAll().Count == 0)
            {
                GroupData newGroup = new GroupData()
                {
                    Name = "hafa"
                };
                applicationManager.Group.Create(newGroup);
            }

            List<GroupData> groups = GroupData.GetAll();
            List<ContactData> contacts = ContactData.GetAll();

            if (applicationManager.Contact.AllGroupFullContainContacts(groups,contacts))
            {
                GroupData newGroup = new GroupData()
                {
                    Name = "hafa"
                };
                applicationManager.Group.Create(newGroup);
                groups = GroupData.GetAll();
                contacts = ContactData.GetAll();
            }
                contacts.Sort();

                foreach (GroupData group in groups)
                {
                    List<ContactData> contactInGroup = group.GetContacts();
                    if (contactInGroup.Count == 0)
                    {
                        foreach (ContactData contact in contacts)
                        {
                            applicationManager.Contact.AddContactToGroup(contact, group);
                            contactInGroup.Add(contact);
                            List<ContactData> newList = group.GetContacts();
                            contactInGroup.Sort();
                            newList.Sort();
                            Assert.AreEqual(contactInGroup, newList);
                        }
                    }else if (contacts.Count > contactInGroup.Count)
                    {
                        contactInGroup.Sort();
                        foreach (ContactData contact in contacts)
                        {
                            bool flag = false;
                            foreach (ContactData contactG in contactInGroup)
                            {
                                if (contact.Id.Equals(contactG.Id))
                                {
                                    flag = false;
                                    break;
                                }
                                flag = true;
                            }
                            
                            if (flag)
                            {
                                applicationManager.Contact.AddContactToGroup(contact, group);
                                contactInGroup.Add(contact);
                            }
                            List<ContactData> newList = group.GetContacts();
                            contactInGroup.Sort();
                            newList.Sort();
                            Assert.AreEqual(contactInGroup, newList);
                        }
                    }
                }
            
            Assert.IsTrue(applicationManager.Contact.AllGroupFullContainContacts(GroupData.GetAll(),ContactData.GetAll()));
        }
    }
}