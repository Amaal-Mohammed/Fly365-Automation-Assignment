using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Pages
{
    class ContactUsPage
    {
        IWebDriver driver;
        public ContactUsPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void setCategory()
        {


            try
            {
                TimeSpan span = new TimeSpan(0, 0, 0, 20, 500);
                WebDriverWait wait = new WebDriverWait(driver, span);
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//ul[@class='el-scrollbar__view el-select-dropdown__list']")));

                ReadOnlyCollection<IWebElement> L1 = driver.FindElements(By.XPath("//ul[@class='el-scrollbar__view el-select-dropdown__list']"));
                foreach (IWebElement e in L1)
                {
                    if (e.Text.Equals("General Question"))
                    {
                        e.Click();
                        e.Click();
                    }
                }
            }
            catch (Exception e)
            {
                //ignore exception
            }
            driver.FindElement(By.XPath("//span[contains(text(),'General Question')]")).Click();

        }

        public IWebElement getContactUs()
        {

       IWebElement con=     driver.FindElement(By.LinkText("Contact us"));
            return con;
          }


        public IWebElement getSend()
        {
            IWebElement w = driver.FindElement(By.XPath("//button[text()='SEND']"));
            return w;
        }

        public IWebElement getCategory()
        {
         IWebElement g=   driver.FindElement(By.XPath("//input[@placeholder='Select Category']"));
            return g;
        }

        public IWebElement getEmail()
        {
            IWebElement g = driver.FindElement(By.XPath("//input[@type='email']"));
            return g;
        }
        
        public IWebElement getFullName()
        {
            TimeSpan span2 = new TimeSpan(0, 0, 0, 20, 500);
            WebDriverWait wait2 = new WebDriverWait(driver, span2);
            wait2.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@placeholder='Full name']")));

            IWebElement fullname = driver.FindElement(By.XPath("//input[@placeholder='Full name']"));

            return fullname;
        }
        public IWebElement getMessage()
        {
            IWebElement m = driver.FindElement(By.TagName("textarea"));

            return m;
        }

    }
}
