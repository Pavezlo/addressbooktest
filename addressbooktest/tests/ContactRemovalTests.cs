using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class ContactRemovalTests :TestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            applicationManager.Contact.Remove(1);
        }
    }
}
