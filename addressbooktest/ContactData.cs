using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    class ContactData
    {
        private string firstname;
        private string midlename;
        private string lastname;
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
        
        public ContactData(string firstname, string midlename, string lastname)
        {
            this.firstname = firstname;
            this.midlename = midlename;
            this.lastname = lastname;
        }

        public ContactData(string firstname, string midlename, string lastname, string birthdayday, string birthdaymonth, string birthdayyear)
        {
            this.firstname = firstname;
            this.midlename = midlename;
            this.lastname = lastname;
            this.birthdayday = birthdayday;
            this.birthdaymonth = birthdaymonth;
            this.birthdayyear = birthdayyear;
        }

        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }

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

        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }

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
    }
}
