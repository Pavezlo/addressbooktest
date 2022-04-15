using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests

{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30))
                {
                    Midlename = GenerateRandomString(30),
                    Address = GenerateRandomString(30)
                });
            }

            return contacts;
        }
        
        [Test, TestCaseSource("RandomContactDataProvider")]
        public void ContactCreationTest(ContactData contactData)
        {
            List<ContactData> oldContact = applicationManager.Contact.GetContactList();
            applicationManager.Contact.Create(contactData);
            Assert.AreEqual(oldContact.Count + 1, applicationManager.Contact.GetContactCount());

            List<ContactData> newContact = applicationManager.Contact.GetContactList();
            oldContact.Add(contactData);
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);
        }
    }
}
