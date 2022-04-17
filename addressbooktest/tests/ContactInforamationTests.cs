using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTests : ContactTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData fromTable = applicationManager.Contact.GetContactInformationFromTable(0);
            ContactData fromForm = applicationManager.Contact.GetContactInformationFromEditFormForTable(0);

            // verification
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }

        [Test]
        public void TestContactInformationDetails()
        {
            ContactData fromDetails = applicationManager.Contact.GetContactInformationFromDetails(0);
            ContactData fromForm = applicationManager.Contact.GetContactInformationFromEditFormForDetails(0);

            // verification
            Assert.AreEqual(fromDetails.ContactDetailsInformation, fromForm.ContactDetailsInformation);
        }
    }
}
