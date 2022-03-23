using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            if (!applicationManager.Contact.ContactCheck())
            {
                ContactData contactData1 = new ContactData("", "", "c", "zzz");
                applicationManager.Contact.Create(contactData1);
            }
            ContactData contactData2 = new ContactData("1", "1", "1", "zzz");
            contactData2.Address = "st. Pushkina da";

            List<ContactData> oldContact = applicationManager.Contact.GetContactList();

            applicationManager.Contact.Modification(contactData2, 1);

            List<ContactData> newContact = applicationManager.Contact.GetContactList();
            oldContact[0].Firstname = contactData2.Firstname;
            oldContact[0].Lastname = contactData2.Lastname;
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);
        }
    }
}
