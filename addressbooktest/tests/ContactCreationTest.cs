using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace WebAddressbookTests

{
    [TestFixture]
    public class ContactCreationTests : ContactTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(10), GenerateRandomString(10))
                {
                    Midlename = GenerateRandomString(10),
                    Address = GenerateRandomString(10)
                });
            }

            return contacts;
        }
        
        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            return (List<ContactData>) new XmlSerializer(typeof(List<ContactData>)).Deserialize(
                new StreamReader(@"contacts.xml"));
        }
        
        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(File.ReadAllText(@"contacts.json"));
        }
        
        [Test, TestCaseSource("ContactDataFromXmlFile")]
        public void ContactCreationTest(ContactData contactData)
        {
            List<ContactData> oldContact = ContactData.GetAll();
            applicationManager.Contact.Create(contactData);
            Assert.AreEqual(oldContact.Count + 1, applicationManager.Contact.GetContactCount());

            List<ContactData> newContact = ContactData.GetAll();
            oldContact.Add(contactData);
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);
        }
    }
}
