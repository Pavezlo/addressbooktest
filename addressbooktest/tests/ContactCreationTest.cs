using NUnit.Framework;

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
            applicationManager.Contact.Create(contactData);
        }
    }
}
