using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData contactData = new ContactData("Garyda", "Oldmanda", "Newmanda", "zzzda");
            contactData.Address = "st. Pushkina da";
            applicationManager.Contact.Modification(contactData, 1);
        }
    }
}
