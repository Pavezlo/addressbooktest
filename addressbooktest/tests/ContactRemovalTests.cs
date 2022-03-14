using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            ContactData contactData = new ContactData("", "", "b", "aaa");
            contactData.Address = "";
            applicationManager.Contact.Create(contactData);
            applicationManager.Contact.Remove("b");
        }
    }
}
