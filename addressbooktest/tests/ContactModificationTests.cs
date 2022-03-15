using NUnit.Framework;

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
            ContactData contactData2 = new ContactData("", "", "g", "zzz");
            contactData2.Address = "st. Pushkina da";
            applicationManager.Contact.Modification(contactData2, 1);
        }
    }
}
