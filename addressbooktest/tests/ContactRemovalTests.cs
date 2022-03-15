using NUnit.Framework;

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
            applicationManager.Contact.Remove(1);
        }
    }
}
