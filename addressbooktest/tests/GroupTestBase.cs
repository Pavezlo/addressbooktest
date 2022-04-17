using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class GroupTestBase :AuthTestBase
    {
        [TearDown]
        public void CompareGroupUI_DB()
        {
            if (PERFORM_LONG_UI_CHECKS)
            {
                List<GroupData> fromUI = applicationManager.Group.GetGroupList();
                List<GroupData> fromDB = GroupData.GetAll();
                fromUI.Sort();
                fromDB.Sort();                                          
                Assert.AreEqual(fromUI, fromDB);
            }
        }
    }
}