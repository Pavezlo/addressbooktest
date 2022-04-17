using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    class ContactModificationTests : ContactTestBase
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
            contactData2.Address = "Pushkinada";
            contactData2.Birthdayday = "1";
            contactData2.Birthdaymonth = "January";
            contactData2.Anniversaryday = "1";
            contactData2.Anniversarymonth = "January";

            List<ContactData> oldContact = ContactData.GetAll();
            ContactData oldData = oldContact[0];

            applicationManager.Contact.Modification(contactData2, oldData);
            Assert.AreEqual(oldContact.Count, applicationManager.Contact.GetContactCount());

            List<ContactData> newContact = ContactData.GetAll();
            oldContact[0].Firstname = contactData2.Firstname;
            oldContact[0].Lastname = contactData2.Lastname;
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);

            foreach (ContactData contact in newContact)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(contactData2.Firstname, contact.Firstname);
                    Assert.AreEqual(contactData2.Lastname, contact.Lastname);
                }
            }
        }
    }
}
