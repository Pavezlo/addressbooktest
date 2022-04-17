using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;
using NUnit.Framework;
using Newtonsoft.Json;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : GroupTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            return (List<GroupData>) new XmlSerializer(typeof(List<GroupData>)).Deserialize(
                new StreamReader(@"groups.xml"));
        }
        
        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(File.ReadAllText(@"groups.json"));
        }
        
        [Test,TestCaseSource("GroupDataFromXmlFile")]
        public void GroupCreationTest(GroupData group)
        {
            List<GroupData> oldGroups = GroupData.GetAll();
            applicationManager.Group.Create(group);
            Assert.AreEqual(oldGroups.Count + 1, applicationManager.Group.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = applicationManager.Group.GetGroupList();
            applicationManager.Group.Create(group);
            Assert.AreEqual(oldGroups.Count + 1, applicationManager.Group.GetGroupCount());

            List<GroupData> newGroups = applicationManager.Group.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void TestDBConnectivity()
        {
            foreach (ContactData contact in ContactData.GetAll())
            {
                System.Console.Out.WriteLine(contact.Deprecated);
            }
        }
    }
}
