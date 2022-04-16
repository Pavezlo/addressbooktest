using System;
using WebAddressbookTests;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;

namespace addressbook_test_data_generators
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string type = args[0];
            int count = Convert.ToInt32(args[1]);
            string filename = args[2];
            string format = args[3];
            StreamWriter writer = new StreamWriter(filename);
            if (type == "group")
            {
                List<GroupData> groups = new List<GroupData>();
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header = TestBase.GenerateRandomString(10),
                        Footer = TestBase.GenerateRandomString(10)
                    });
                }
                if (format == "xml")
                { 
                    writeGroupsToXmlFile(groups,writer);
                } else if (format == "json")
                { 
                    writeGroupsToJsonFile(groups,writer);
                }
                else
                { 
                    System.Console.Out.Write("Неверный формат");
                }
                writer.Close();
            } else if (type == "contacts")
            {
                List<ContactData> contacts = new List<ContactData>();
                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new ContactData()
                    {
                        Firstname = TestBase.GenerateRandomString(10),
                        Midlename = TestBase.GenerateRandomString(10),
                        Lastname = TestBase.GenerateRandomString(10),
                        Nickname = TestBase.GenerateRandomString(10),
                        Company = TestBase.GenerateRandomString(10),
                        Title = TestBase.GenerateRandomString(10),
                        Address = TestBase.GenerateRandomString(10),
                        Birthdayday = "-",
                        Birthdaymonth = "-",
                        Anniversaryday = "-",
                        Anniversarymonth = "-",
                        Group = "[none]"
                    });
                }
                if (format == "xml")
                { 
                    writeContactsToXmlFile(contacts,writer);
                } else if (format == "json")
                { 
                    writeContactsToJsonFile(contacts,writer);
                }
                else
                { 
                    System.Console.Out.Write("Неверный формат");
                }
                writer.Close();
            }
            else
            {
                System.Console.Out.Write("Неверный тип данных");
            }
        }

        static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer,groups);
        }
        
        static void writeGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups));
        }
        
        static void writeContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer,contacts);
        }
        
        static void writeContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts));
        }
    }
}

