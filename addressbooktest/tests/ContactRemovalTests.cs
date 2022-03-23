using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            if (!applicationManager.Contact.ContactCheck())
            {
                ContactData contactData = new ContactData("", "", "b", "aaa");
                contactData.Address = "";
                applicationManager.Contact.Create(contactData);
            }
            List<ContactData> oldContact = applicationManager.Contact.GetContactList();
            applicationManager.Contact.Remove(1);
            List<ContactData> newContact = applicationManager.Contact.GetContactList();
            oldContact.RemoveAt(0);
            Assert.AreEqual(oldContact, newContact);
        }
    }
}
