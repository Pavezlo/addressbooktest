using System;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {

        private string midlename = "ab";
        private string nickname = "noname";
        private string title = "title";
        private string company = "gmail";
        private string address = "internet";
        private string telephonehome = "515";
        private string telephonemobile = "8800553535";
        private string telephonework = "565";
        private string telephonefax = "5151";
        private string email = "gu@gu.gu";
        private string email2 = "shu@shu.su";
        private string email3 = "tu@tu.tu";
        private string homepage = "homepage.ho";
        private string birthdayday = "1";
        private string birthdaymonth = "January";
        private string birthdayyear = "2022";
        private string anniversaryday = "1";
        private string anniversarymonth = "January";
        private string anniversaryyear = "2022";
        private string group = "aaa";
        private string secondaryaddress = "aaa";
        private string secondaryhome = "bbb";
        private string secondarynotes = "ccc";

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
            return "Firstname=" + Firstname + " Lastname=" + Lastname;
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

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public ContactData(string firstname, string midlename, string lastname, string group)
        {
            Firstname = firstname;
            this.midlename = midlename;
            Lastname = lastname;
            this.group = group;
        }

        public ContactData(string firstname, string midlename, string lastname, string birthdayday, string birthdaymonth, string birthdayyear)
        {
            Firstname = firstname;
            this.midlename = midlename;
            Lastname = lastname;
            this.birthdayday = birthdayday;
            this.birthdaymonth = birthdaymonth;
            this.birthdayyear = birthdayyear;
        }

        public ContactData()
        {
        }

        public string Firstname { get; set; }

        public string Midlename
        {
            get
            {
                return midlename;
            }
            set
            {
                midlename = value;
            }
        }

        public string Lastname { get; set; }

        public string Nickname
        {
            get
            {
                return nickname;
            }
            set
            {
                nickname = value;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        public string Company
        {
            get
            {
                return company;
            }
            set
            {
                company = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }

        public string Telephonehome
        {
            get
            {
                return telephonehome;
            }
            set
            {
                telephonehome = value;
            }
        }

        public string Telephonemobile
        {
            get
            {
                return telephonemobile;
            }
            set
            {
                telephonemobile = value;
            }
        }

        public string Telephonework
        {
            get
            {
                return telephonework;
            }
            set
            {
                telephonework = value;
            }
        }

        public string Telephonefax
        {
            get
            {
                return telephonefax;
            }
            set
            {
                telephonefax = value;
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

        private string CleanUpRn(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        public string Email2
        {
            get
            {
                return email2;
            }
            set
            {
                email2 = value;
            }
        }

        public string Email3
        {
            get
            {
                return email3;
            }
            set
            {
                email3 = value;
            }
        }

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

        public string Homepage
        {
            get
            {
                return homepage;
            }
            set
            {
                homepage = value;
            }
        }

        public string Birthdayday
        {
            get
            {
                return birthdayday;
            }
            set
            {
                birthdayday = value;
            }
        }

        public string Birthdaymonth
        {
            get
            {
                return birthdaymonth;
            }
            set
            {
                birthdaymonth = value;
            }
        }

        public string Birthdayyear
        {
            get
            {
                return birthdayyear;
            }
            set
            {
                birthdayyear = value;
            }
        }


        public string Anniversaryday
        {
            get
            {
                return anniversaryday;
            }
            set
            {
                anniversaryday = value;
            }
        }

        public string Anniversarymonth
        {
            get
            {
                return anniversarymonth;
            }
            set
            {
                anniversarymonth = value;
            }
        }

        public string Anniversaryyear
        {
            get
            {
                return anniversaryyear;
            }
            set
            {
                anniversaryyear = value;
            }
        }

        public string Group
        {
            get
            {
                return group;
            }
            set
            {
                group = value;
            }
        }

        public string Secondaryaddress
        {
            get
            {
                return secondaryaddress;
            }
            set
            {
                secondaryaddress = value;
            }
        }

        public string Secondaryhome
        {
            get
            {
                return secondaryhome;
            }
            set
            {
                secondaryhome = value;
            }
        }

        public string Secondarynotes
        {
            get
            {
                return secondarynotes;
            }
            set
            {
                secondarynotes = value;
            }
        }

        public string Id { get; set; }

        private string fio;

        public string Fio
        {
            get
            {
                if (fio != null)
                {
                    return fio;
                }
                else
                {
                    return CleanUpSpace(Firstname) + CleanUpSpace(Midlename) +CleanUp(Lastname);
                }
            }
            set
            {
                fio = value;
            }
        }

        private string CleanUpSpace(string x)
        {
            if (x == null || x == "")
            {
                return "";
            }
            return Regex.Replace(x, "[ -()\"]", "")+ " ";
        }
        
        private string CleanUp(string x)
        {
            if (x == null || x == "")
            {
                return "";
            }
            return Regex.Replace(x, "[ -()\"]", "");
        }

        private string nickComTiAd;

        public string NickTiComAd
        {
            get
            {
                if (nickComTiAd != null)
                {
                    return nickComTiAd;
                }
                else
                {
                    return "\r\n"+ CleanUpRn(Nickname) + CleanUpRn(Title) + CleanUpRn(Company) + CleanUpRn(Address);
                }
            }
            set
            {
                nickComTiAd = value;
            }
        }

        private string emails;

        public string Emails
        {
            get
            {
                if (emails != null)
                {
                    return emails;
                }
                else
                {
                    return CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3);
                }
            }
            set
            {
                emails = value;
            }
        }

        private string birthday;

        public string Birthday
        {
            get
            {
                if (birthday != null)
                {
                    return birthday;
                }
                else
                {
                    return "Birthday " + CleanUpBirthdayDay(Birthdayday) + CleanUpBirthdayMounth(Birthdaymonth) + CleanUp(Birthdayyear);
                }
            }
            set
            {
                birthday = value;
            }
        }

        private string anniversary;

        public string Anniversary
        {
            get
            {
                if (anniversary != null)
                {
                    return anniversary;
                }
                else
                {
                    return ("Anniversary " + CleanUpBirthdayDay(Anniversaryday) + CleanUpBirthdayMounth(Anniversarymonth) + CleanUp(Anniversaryyear));
                }
            }
            set
            {
                anniversary = value;
            }
        }

        private string CleanUpBirthdayDay(string x)
        {
            if (x == null || x == "")
            {
                return "";
            }
            return Regex.Replace(x, "[ -()\"]", "") + ". ";
        }

        private string CleanUpBirthdayMounth(string x)
        {
            if (x == null || x == "")
            {
                return "";
            }
            return Regex.Replace(x, "[ -()\"]", "") + " ";
        }
    }
}
