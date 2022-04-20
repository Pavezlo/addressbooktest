using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Mime;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper Create(ContactData contactData)
        {
            InitNewContact();
            EditContactInformation(contactData);
            ClickEnterContact();
            ClickLogoAddressBook();
            return this;
        }

        public ContactHelper Remove(int a)
        {
            ClickEditContact(a);
            ClickRemoveContact();
            ClickLogoAddressBook();
            return this;
        }
        
        public ContactHelper Remove(ContactData contact)
        {
            ClickEditContact(contact.Id);
            ClickRemoveContact();
            ClickLogoAddressBook();
            return this;
        }

        public ContactHelper Modification(ContactData contactData, int a)
        {
            ClickEditContact(a);
            ModificationContactInformation(contactData);
            ClickModificationContact();
            ClickLogoAddressBook();
            return this;
        }
        
        public ContactHelper Modification(ContactData contactData, ContactData oldcontactData)
        {
            ClickEditContact(oldcontactData.Id);
            ModificationContactInformation(contactData);
            ClickModificationContact();
            ClickLogoAddressBook();
            return this;
        }

        public ContactHelper ClickEnterContact()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper EditContactInformation(ContactData contactdata)
        {
            Type(By.Name("firstname"), contactdata.Firstname);
            Type(By.Name("middlename"), contactdata.Midlename);
            Type(By.Name("lastname"), contactdata.Lastname);
            Type(By.Name("nickname"), contactdata.Nickname);
            Type(By.Name("title"), contactdata.Title);
            Type(By.Name("company"), contactdata.Company);
            Type(By.Name("address"), contactdata.Address);
            Type(By.Name("home"), contactdata.Telephonehome);
            Type(By.Name("mobile"), contactdata.Telephonemobile);
            Type(By.Name("work"), contactdata.Telephonework);
            Type(By.Name("fax"), contactdata.Telephonefax);
            Type(By.Name("email"), contactdata.Email);
            Type(By.Name("email2"), contactdata.Email2);
            Type(By.Name("email3"), contactdata.Email3);
            Type(By.Name("homepage"), contactdata.Homepage);
            driver.FindElement(By.Name("bday")).Click();
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(contactdata.Birthdayday);
            driver.FindElement(By.Name("bmonth")).Click();
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(contactdata.Birthdaymonth);
            Type(By.Name("byear"), contactdata.Birthdayyear);
            driver.FindElement(By.Name("aday")).Click();
            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(contactdata.Anniversaryday);
            driver.FindElement(By.Name("amonth")).Click();
            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(contactdata.Anniversarymonth);
            Type(By.Name("ayear"), contactdata.Anniversaryyear);
            driver.FindElement(By.Name("new_group")).Click();
            if(IsElementPresent(By.XPath("//option[text()='"+ contactdata.Group + "']"))){
                new SelectElement(driver.FindElement(By.Name("new_group"))).SelectByText(contactdata.Group);
            }
            else
            {
                new SelectElement(driver.FindElement(By.Name("new_group"))).SelectByText("[none]");
            }
            Type(By.Name("address2"), contactdata.Secondaryaddress);
            Type(By.Name("phone2"), contactdata.Secondaryhome);
            Type(By.Name("notes"), contactdata.Secondarynotes);
            return this;
        }

        public ContactHelper ModificationContactInformation(ContactData contactdata)
        {
            Type(By.Name("firstname"), contactdata.Firstname);
            Type(By.Name("middlename"), contactdata.Midlename);
            Type(By.Name("lastname"), contactdata.Lastname);
            Type(By.Name("nickname"), contactdata.Nickname);
            Type(By.Name("title"), contactdata.Title);
            Type(By.Name("company"), contactdata.Company);
            Type(By.Name("address"), contactdata.Address);
            Type(By.Name("home"), contactdata.Telephonehome);
            Type(By.Name("mobile"), contactdata.Telephonemobile);
            Type(By.Name("work"), contactdata.Telephonework);
            Type(By.Name("fax"), contactdata.Telephonefax);
            Type(By.Name("email"), contactdata.Email);
            Type(By.Name("email2"), contactdata.Email2);
            Type(By.Name("email3"), contactdata.Email3);
            Type(By.Name("homepage"), contactdata.Homepage);
            driver.FindElement(By.Name("bday")).Click();
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(contactdata.Birthdayday);
            driver.FindElement(By.Name("bmonth")).Click();
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(contactdata.Birthdaymonth);
            Type(By.Name("byear"), contactdata.Birthdayyear);
            driver.FindElement(By.Name("aday")).Click();
            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(contactdata.Anniversaryday);
            driver.FindElement(By.Name("amonth")).Click();
            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(contactdata.Anniversarymonth);
            Type(By.Name("ayear"), contactdata.Anniversaryyear);
            Type(By.Name("address2"), contactdata.Secondaryaddress);
            Type(By.Name("phone2"), contactdata.Secondaryhome);
            Type(By.Name("notes"), contactdata.Secondarynotes);
            return this;
        }

        public ContactHelper InitNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper ClickRemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper ClickEditContact(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
            return this;
        }
        
        public ContactHelper ClickEditContact(string id)
        {
            driver.FindElement(By.XPath("//a[@href='edit.php?id="+id+"']")).Click();
            return this;
        }

        public ContactHelper ClickModificationContact()
        {
            driver.FindElement(By.XPath("//input[@value='Update'][2]")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper ClickLogoAddressBook()
        {
            driver.FindElement(By.XPath("//img[@title='Addressbook']/..")).Click();
            return this;
        }

        public bool ContactCheck()
        {
            return IsElementPresent(By.XPath("//tbody//input[@type='checkbox']"));
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
                foreach (IWebElement element in elements)
                {
                    IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                    contactCache.Add(new ContactData()
                    {
                        AllPhones = cells[5].Text,
                        AllEmails = cells[4].Text,
                        Address = cells[3].Text,
                        Firstname = cells[2].Text,
                        Lastname = cells[1].Text,
                        Id = element.FindElement(By.XPath("//td/input")).GetAttribute("value")
                    });
                }
            }
            return new List<ContactData>(contactCache);
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();

            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;
            
            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllEmails = allEmails,
                AllPhones = allPhones
            };
        }

        public ContactData GetContactInformationFromEditFormForTable(int index)
        {
            manager.Navigator.GoToHomePage();
            ClickEditContact(index);

            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            string email1 = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            string phone2 = driver.FindElement(By.Name("phone2")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                Telephonehome = homePhone,
                Telephonemobile = mobilePhone,
                Telephonework = workPhone,
                Email = email1,
                Email2 = email2,
                Email3 = email3,                
                Secondaryhome = phone2
            };
        }

        public ContactData GetContactInformationFromEditFormForDetails(int index)
        {
            manager.Navigator.GoToHomePage();
            ClickEditContact(index);

            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string middlename = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string nickname = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");

            string email1 = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            string homepage = driver.FindElement(By.Name("homepage")).GetAttribute("value");

            string bday = driver.FindElement(By.XPath("//select[@name='bday']/option[@selected='selected']")).Text;
            string bmonth = driver.FindElement(By.XPath("//select[@name='bmonth']/option[@selected='selected']")).Text;
            string byear = driver.FindElement(By.Name("byear")).GetAttribute("value");

            string aday = driver.FindElement(By.XPath("//select[@name='aday']/option[@selected='selected']")).Text;
            string amonth = driver.FindElement(By.XPath("//select[@name='amonth']/option[@selected='selected']")).Text;
            string ayear = driver.FindElement(By.Name("ayear")).GetAttribute("value");

            string address2 = driver.FindElement(By.Name("address2")).GetAttribute("value");
            string secondhomePhone = driver.FindElement(By.Name("phone2")).GetAttribute("value");
            string notes = driver.FindElement(By.Name("notes")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Midlename = middlename,
                Nickname = nickname,
                Company = company,
                Title = title,
                Address = address,
                Telephonehome = homePhone,
                Telephonemobile = mobilePhone,
                Telephonework = workPhone,
                Telephonefax = fax,
                Email = email1,
                Email2 = email2,
                Email3 = email3,
                Homepage = homepage,
                Birthdayday = bday,
                Birthdaymonth = bmonth,
                Birthdayyear = byear,
                Anniversaryday = aday,
                Anniversarymonth = amonth,
                Anniversaryyear = ayear,
                Secondaryaddress = address2,
                Secondaryhome = secondhomePhone,
                Secondarynotes = notes
            };
        }

        public int GetContactCount()
        {
            return driver.FindElements(By.XPath("//tr[@name='entry']")).Count;
        }

        public int GetNumberOfSearchResults()
        {
            manager.Navigator.GoToHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }

        public ContactHelper ClickDetailsContact(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[6]
                .FindElement(By.TagName("a")).Click();
            return this;
        }

        public ContactData GetContactInformationFromDetails(int index)
        {
            manager.Navigator.GoToHomePage();
            ClickDetailsContact(index);
            string allInformationContact = driver.FindElement(By.Id("content")).Text.Trim();

            return new ContactData()
            {
                ContactDetailsInformation = allInformationContact
            };
        }

        public void AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            CleareGroupFilter();
            SelectContact(contact.Id);
            SelectGroupToAdd(group.Id);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d =>
                d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        private void CleareGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }
        
        private void SelectContact(string contactId)
        {
            driver.FindElement(By.Id(contactId)).Click();
        }

        private void SelectGroupToAdd(string groupName)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByValue(groupName);
        }
        
        private void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        public void RemovalContactFromGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            CleareGroupFilter();
            SelectGroupToContactPage(group.Id);
            SelectContact(contact.Id);
            CommitRemovalContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d =>
                d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }
        
        public void SelectGroupToContactPage(string groupId)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByValue(groupId);
        }
        
        public void CommitRemovalContactToGroup()
        {
            driver.FindElement(By.Name("remove")).Click();
        }

        public bool AllGroupFullContainContacts(List<GroupData> groups, List<ContactData> contacts)
        {
            foreach (GroupData group in groups)
            {
                List<ContactData> contactInGroup = group.GetContacts();
                if (contactInGroup.Count != contacts.Count) return false;
            }
            return true;
        }
        
        public bool AllGroupNotContainContacts(List<GroupData> groups)
        {
            foreach (GroupData group in groups)
            {
                List<ContactData> contactInGroup = group.GetContacts();
                if (contactInGroup.Count != 0) return false;
            }
            return true;
        }
    }
}
