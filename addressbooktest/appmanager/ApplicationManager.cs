using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebAddressbookTests
{
    public class ApplicationManager
    {

        protected string baseURL;

        private static ThreadLocal <ApplicationManager> applicationManager = new ThreadLocal<ApplicationManager>();

        #region Constructures
        private ApplicationManager()
        {
            driver = new ChromeDriver();
            baseURL = "http://localhost/addressbook";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            loginHelper = new LoginHelper(this);
            navigationHelper = new NavigationHelper(this, baseURL);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);
        }
        #endregion

        public static ApplicationManager GetInstance()
        {
            if (!applicationManager.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigator.GoToHomePage();
                applicationManager.Value = newInstance;                
            }
            return applicationManager.Value;
        }

        //Деструктор
        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        #region Driver
        protected IWebDriver driver;
        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }
        #endregion

        #region Auth
        protected LoginHelper loginHelper;
        public LoginHelper Auth
        {
            get
            {
                return loginHelper;
            }
        }
        #endregion

        #region Navigator
        protected NavigationHelper navigationHelper;
        public NavigationHelper Navigator
        {
            get
            {
                return navigationHelper;
            }
        }
        #endregion

        #region Group
        protected GroupHelper groupHelper;
        public GroupHelper Group
        {
            get
            {
                return groupHelper;
            }
        }
        #endregion

        #region Contact
        protected ContactHelper contactHelper;
        public ContactHelper Contact
        {
            get
            {
                return contactHelper;
            }
        }
        #endregion
    }
}
