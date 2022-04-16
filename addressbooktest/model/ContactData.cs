using System;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        #region Settings
        
        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Firstname == other.Firstname && Lastname == other.Lastname;
        }

        public override int GetHashCode()
        {
            return Firstname.GetHashCode();
        }

        public override string ToString()
        {
            return "Firstname=" + Firstname + "\nMidlename=" + Midlename+ "\nLastname=" + Lastname+ "\nAddress=" + Address;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            //return Firstname.CompareTo(other.Firstname);
            var lastCompare = Lastname.CompareTo(other.Lastname);
            if (lastCompare == 0)
            {
                return Firstname.CompareTo(other.Firstname);
            }
            else
            {
                return lastCompare;
            }
        }
        
        #endregion

        #region Constructor
        
        public ContactData()
        {
        }
        
        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public ContactData(string firstname, string midlename, string lastname, string group)
        {
            Firstname = firstname;
            Midlename = midlename;
            Lastname = lastname;
            Group = group;
        }

        public ContactData(string firstname, string midlename, string lastname, string birthdayday, string birthdaymonth, string birthdayyear)
        {
            Firstname = firstname;
            Midlename = midlename;
            Lastname = lastname;
            Birthdayday = birthdayday;
            Birthdaymonth = birthdaymonth;
            Birthdayyear = birthdayyear;
        }
        
        #endregion

        #region InformationContact
        public string Firstname { get; set; }

        public string Midlename { get; set; }
        
        public string Lastname { get; set; }

        public string Nickname { get; set; }
        
        public string Title { get; set; }

        public string Company { get; set; }

        public string Address { get; set; }

        public string Telephonehome { get; set; }

        public string Telephonemobile { get; set; }

        public string Telephonework { get; set; }

        public string Telephonefax { get; set; }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }
        
        public string Homepage { get; set; }

        public string Birthdayday { get; set; }

        public string Birthdaymonth { get; set; }

        public string Birthdayyear { get; set; }
        
        public string Anniversaryday { get; set; }

        public string Anniversarymonth { get; set; }

        public string Anniversaryyear { get; set; }

        public string Group { get; set; }

        public string Secondaryaddress { get; set; }

        public string Secondaryhome { get; set; }

        public string Secondarynotes { get; set; }

        public string Id { get; set; }
        
        #endregion

        #region InformationContactTable
        
        private string allEmails;

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUpRn(Email) + CleanUpRn(Email2) + CleanUpRn(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }
        
        private string allPhones;

        public string AllPhones 
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUpRn(Telephonehome) + CleanUpRn(Telephonemobile) + CleanUpRn(Telephonework) + CleanUpRn(Secondaryhome)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        
        }
        
        private string CleanUpRn(string x)
        {
            if (x == null || x == "")
            {
                return "";
            }
            return Regex.Replace(x, "[ -()]", "") + "\r\n";
        }

        #endregion
        
        #region InformationContactDetails
        
        private string contactDetailsInformation;

        public string ContactDetailsInformation
        {
            get
            {
                if (contactDetailsInformation != null)
                {
                    return contactDetailsInformation;
                }
                else
                {
                    return (CleanUpFirstname(Firstname) + CleanUpMidlename(Midlename) + CleanUpRn(Lastname) +
                            PlusRnSecret(CleanUpRn(Nickname) + CleanUpRn(Title) + CleanUpRn(Company) + CleanUpRn(Address))+
                            PlusRn(CleanUpTelephone(Telephonehome,"H: ") + CleanUpTelephone(Telephonemobile,"M: ") +CleanUpTelephone(Telephonework,"W: ") + CleanUpTelephone(Telephonefax,"F: ")) + 
                            PlusRn(CleanUpRn(Email)+CleanUpRn(Email2)+CleanUpRn(Email3)+CleanUpTelephone(Homepage,"Homepage:\r\n"))+
                            PlusRnSecret(CleanUpBirthAnnive(CleanUpBirthAnniverDay(Birthdayday,Birthdaymonth,Birthdayyear)+CleanUpMonth(Birthdaymonth)+CleanUpYear(Birthdayyear), "Birthday") + 
                                         CleanUpBirthAnnive(CleanUpBirthAnniverDay(Anniversaryday,Anniversarymonth,Anniversaryyear)+CleanUpMonth(Anniversarymonth)+CleanUpYear(Anniversaryyear), "Anniversary"))+
                            PlusRn(CleanUpRn(Secondaryaddress))+
                            PlusRn(CleanUpTelephone(Secondaryhome,"P: "))+ CleanUp(Secondarynotes)).Trim();
                }
            }
            set
            {
                contactDetailsInformation = value;
            }
        }
        
        //Вписывает firstname, оценивая есть ли midlename и lastname
        private string CleanUpFirstname(string x)
        {
            if (x == null || x == "")
            {
                return "";
            }
            if ((Midlename != null && Midlename != "") || (Lastname != null && Lastname != ""))
            {
                return Regex.Replace(x, "[ -()\"]", "")+ " ";
            }
            return Regex.Replace(x, "[ -()]", "") + "\r\n";
        }
        
        //Вписывает midlename, оценивая есть ли lastname
        private string CleanUpMidlename(string x)
        {
            if (x == null || x == "")
            {
                return "";
            }
            if (Lastname != null && Lastname != "")
            {
                return Regex.Replace(x, "[ -()\"]", "") + " ";
            }
            return Regex.Replace(x, "[ -()]", "") + "\r\n";
        }
        
        //Вписывает noties если есть
        private string CleanUp(string x)
        {
            if (x == null || x == "")
            {
                return "";
            }
            return Regex.Replace(x, "[ -()\"]", "");
        }
        
        //вписывает Telephone и homepage
        private string CleanUpTelephone(string x,string telephoneName)
        {
            if (x == null || x == "")
            {
                return "";
            }
            return telephoneName +Regex.Replace(x, "[ -()\"]", "") + "\r\n";
        }

        //вписывает наименование Birthday и Anniversary если есть хоть какая та инфа по ним
        private string CleanUpBirthAnnive(string x, string firstworld)
        {
            if (x == null || x == "")
            {
                return "";
            }
            return String.Format("{0} {1}\r\n",firstworld, x);
        }
        
        //вписывает день с оценкой есть ли месяц и год
        private string CleanUpBirthAnniverDay(string x, string y, string z)
        {
            if (x == null || x == "" || x=="-")
            {
                return "";
            }

            if (y != null && y != "" && y!="-" || z != null && z != "")
            {
                return Regex.Replace(x, "[ -()\"]", "") + ". ";
            }
            return Regex.Replace(x, "[ -()\"]", "") + ".";
        }
        
        //выписывает месяц др
        private string CleanUpMonth(string x)
        {
            if (x == null || x == "" || x=="-")
            {
                return "";
            }
            return Regex.Replace(x, "[ -()\"]", "") + " ";
        }
        
        //выссчитывает количество лет и вписывает год др
        private string CleanUpYear(string x)
        {
            if (x == null || x == "")
            {
                return "";
            }
            return Regex.Replace(x, "[ -()\"]", "") + String.Format(" ({0})",2022-Convert.ToInt32(x));
        }
        
        //прибавляет rn где нужно
        private string PlusRn(string x)
        {
            if (x == null || x == "")
            {
                return "";
            }
            return x + "\r\n";
        }
        
        //прибавляет rn где нужно
        private string PlusRnFIO(string x)
        {
            if (x == null || x == "")
            {
                return "";
            }
            return x + "\r\n";
        }
        
        //прибавляет rn где нудно, т.к. при отсутствии инфы nr появляется
        private string PlusRnSecret(string x)
        {
            if (x == null || x == "")
            {
                return "\r\n";
            }
            return x + "\r\n";
        }
        
        #endregion

    }
}
