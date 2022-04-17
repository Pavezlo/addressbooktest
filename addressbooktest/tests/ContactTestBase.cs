using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class ContactTestBase :AuthTestBase
    {
        [TearDown]
        public void CompareContactUI_DB()
        {
            if (PERFORM_LONG_UI_CHECKS)
            {
                List<ContactData> fromUI = applicationManager.Contact.GetContactList();
                List<ContactData> fromDB = ContactData.GetAll();
                fromUI.Sort();
                fromDB.Sort();                                          
                CollectionAssert.AreEqual(fromUI, fromDB);
            }
        }
    }
}