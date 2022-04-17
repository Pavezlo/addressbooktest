using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    class ContactRemovalTests : ContactTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            if (!applicationManager.Contact.ContactCheck())
            {
                ContactData contactData = new ContactData("a", "a", "a", "aaa");
                contactData.Address = "m";
                applicationManager.Contact.Create(contactData);
            }
            List<ContactData> oldContact = ContactData.GetAll();
            ContactData toBeRemoved = oldContact[0];
            applicationManager.Contact.Remove(toBeRemoved);
            Assert.AreEqual(oldContact.Count - 1, applicationManager.Contact.GetContactCount());
            List<ContactData> newContact = ContactData.GetAll();
            oldContact.RemoveAt(0);
            Assert.AreEqual(oldContact, newContact);

            foreach (ContactData contact in newContact)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }
    }
}
