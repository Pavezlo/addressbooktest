using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests

{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            
            ContactData contactData = new ContactData("Gary","Oldman","Newman","zzz");
            contactData.Address = "st. Pushkina";
            List<ContactData> oldContact = applicationManager.Contact.GetContactList();
            applicationManager.Contact.Create(contactData);
            List<ContactData> newContact = applicationManager.Contact.GetContactList();
            oldContact.Add(contactData);
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);
        }
    }
}
