using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData fromTable = applicationManager.Contact.GetContactInformationFromTable(0);
            ContactData fromForm = applicationManager.Contact.GetContactInformationFromEditFormForTabel(0);

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
            Assert.AreEqual(fromDetails.Fio, fromForm.Fio);
            Assert.AreEqual(fromDetails.NickTiComAd, fromForm.NickTiComAd);
            Assert.AreEqual(fromDetails.Telephonehome, fromForm.Telephonehome);
            Assert.AreEqual(fromDetails.Telephonemobile, fromForm.Telephonemobile);
            Assert.AreEqual(fromDetails.Telephonework, fromForm.Telephonework);
            Assert.AreEqual(fromDetails.Telephonefax, fromForm.Telephonefax);
            Assert.AreEqual(fromDetails.Emails, fromForm.Emails);
            Assert.AreEqual(fromDetails.Homepage, fromForm.Homepage);
            Assert.AreEqual(fromDetails.Birthday, fromForm.Birthday);
            Assert.AreEqual(fromDetails.Anniversary, fromForm.Anniversary);
            Assert.AreEqual(fromDetails.Secondaryaddress, fromForm.Secondaryaddress);
            Assert.AreEqual(fromDetails.Secondaryhome, fromForm.Secondaryhome);
            Assert.AreEqual(fromDetails.Secondarynotes, fromForm.Secondarynotes);
        }
    }
}
