using NUnit.Framework;

namespace WebAddressbookTests 

{
    [TestFixture]
    public class GroupRemovalTests :TestBase
    {
        
        [Test]
        public void GroupRemovalTest()
        {
            applicationManager.Group.Remove(1);
        }
    }
}
