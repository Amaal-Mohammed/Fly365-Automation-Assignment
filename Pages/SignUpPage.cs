using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Pages
{
    class SignUpPage
    {
        IWebDriver driver;
        public SignUpPage(IWebDriver driver)
        {
            this.driver = driver;

        }

        public IWebElement getSignbutton()
        {
            IWebElement signin = driver.FindElement(By.LinkText("SIGN IN"));
            return signin;

        }

        public IWebElement getSignUpButton()
        {
            WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(5000));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@class='text-primary-second link-sign-up font-semibold no-underline']")));
            IWebElement signup = driver.FindElement(By.XPath("//a[@class='text-primary-second link-sign-up font-semibold no-underline']"));
            return signup;
        }

        public IWebElement getFirstName()
        {
            IWebElement fname = driver.FindElement(By.XPath("//input[@placeholder='First Name']"));
            return fname;
        }
        public IWebElement getFamilyName()
        {
            IWebElement familyname = driver.FindElement(By.XPath("//input[@placeholder='Family Name']"));
            return familyname;
        }
        //IWebElement email = driver.FindElement(By.XPath("//input[@type='email']"));
        public IWebElement getEmail()
        {
            IWebElement email = driver.FindElement(By.XPath("//input[@type='email']"));
            return email;
        }

        public IWebElement getPassword()
        {
            IWebElement password = driver.FindElement(By.XPath("//input[@type='password']"));
            return password;
        }

        public IWebElement getCreateAccount()
        {
            IWebElement createaccount = driver.FindElement(By.XPath("//button[text()='CREATE ACCOUNT']"));
            return createaccount;

        }

        public bool checkMeg()
        {
            WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(5000));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='text-center text-white font-bold text-2xl -mt-4 mb-5 capitalize']//span[text()='Hi,']")));
            IWebElement Msg = driver.FindElement(By.XPath("//div[@class='text-center text-white font-bold text-2xl -mt-4 mb-5 capitalize']//span[text()='Hi,']"));
            bool act = driver.FindElement(By.XPath("//div[@class='text-center text-white font-bold text-2xl -mt-4 mb-5 capitalize']//span[text()='Hi,']")).Displayed;
            return act;

        }

    }

}