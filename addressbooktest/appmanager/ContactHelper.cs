using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

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
            return this;
        }

        public ContactHelper Remove(int a)
        {
            ClickEditContact(a);
            ClicRemoveContact();
            ClickLogoAddressBook();
            return this;
        }

        public ContactHelper Modification(ContactData contactData, int a)
        {
            ClickEditContact(a);
            ModificationContactInformation(contactData);
            ClickModificationContact();
            ClickGoToHomePage();
            return this;
        }

        public ContactHelper ClickEnterContact()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            ClickGoToHomePage();
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

        public ContactHelper ClicRemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        public ContactHelper ClickEditContact(int v)
        {
            string xpath = "//tbody//input[@type='checkbox'][" + v + "]/../..//img[@title='Edit']/..";
            driver.FindElement(By.XPath(xpath)).Click();
            return this;
        }

        public ContactHelper ClickModificationContact()
        {
            driver.FindElement(By.XPath("//input[@value='Update'][2]")).Click();
            return this;
        }

        public ContactHelper ClickGoToHomePage()
        {
            driver.FindElement(By.XPath("//a[text()='home page']")).Click();
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

        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            List<string> lastName = new List<string>();
            List<string> firstName = new List<string>();
            ICollection<IWebElement> elementsLastName = driver.FindElements(By.XPath("//tr[@name='entry']/td[2]"));
            ICollection<IWebElement> elementsFirstName = driver.FindElements(By.XPath("//tr[@name='entry']/td[3]"));
            
            foreach(IWebElement element in elementsLastName)
            {
                lastName.Add(element.Text);
            }

            foreach (IWebElement element in elementsFirstName)
            {
                firstName.Add(element.Text);
            }

            for (int i = 0; i < lastName.Count; i++)
            {
                contacts.Add(new ContactData(firstName[i], lastName[i]));
            }
            return contacts;
        }
    }
}
