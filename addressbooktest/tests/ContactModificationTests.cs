using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData contactData1 = new ContactData("", "", "c", "zzz");
            contactData1.Address = "st. Pushkina";
            applicationManager.Contact.Create(contactData1);
            ContactData contactData2 = new ContactData("", "", "g", "zzz");
            contactData2.Address = "st. Pushkina da";
            applicationManager.Contact.Modification(contactData2, "c");
        }
    }
}
