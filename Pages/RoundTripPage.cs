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

    class RoundTripPage
    {
        IWebDriver driver;
        public RoundTripPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement findOrigin()
        {
            WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(5000));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Name("origin")));
            IWebElement origin = driver.FindElement(By.Name("origin"));
            return origin;
        }

        public IWebElement findDestination()
        {
            WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(5000));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Name("destination")));
            IWebElement destination = driver.FindElement(By.Name("destination"));
            return destination;
        }

        public IWebElement findSearch()
        {
            WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(5000));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(text(),'search now')]")));
            IWebElement search = driver.FindElement(By.XPath("//button[contains(text(),'search now')]"));
            return search;
        }

        public IWebElement findCalender()
        {
            WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(5000));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Name("d")));
            IWebElement cal = driver.FindElement(By.Name("d"));
            return cal;
            

        }

        public void setOrigin(String o)
        {
            try
            {
                TimeSpan span = new TimeSpan(0, 0, 0, 20, 500);
                WebDriverWait wait = new WebDriverWait(driver, span);
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[3]/div[1]/div[1]/ul[contains(@id,'autocomplete')]/child::li")));

                ReadOnlyCollection<IWebElement> L1 = driver.FindElements(By.XPath("//div[3]/div[1]/div[1]/ul[contains(@id,'autocomplete')]/child::li"));

                foreach (IWebElement e in L1)
                {
                    if (e.Text.Equals(o))
                    {
                        e.Click();
                    }
                }
            }
            catch (Exception e)
            {
                //ignore exception
            }

        }

        public void setDestination(String d)
        {
            try
            {
                TimeSpan span = new TimeSpan(0, 0, 0, 20, 500);
                WebDriverWait wait = new WebDriverWait(driver, span);
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[4]/div[1]/div[1]/ul[contains(@id,'autocomplete')]/child::li")));

                ReadOnlyCollection<IWebElement> L2 = driver.FindElements(By.XPath("//div[4]/div[1]/div[1]/ul[contains(@id,'autocomplete')]/child::li"));

                foreach (IWebElement e in L2)
                {
                    if (e.Text.Equals(d))
                    {
                        e.Click();
                    }
                }
            }
            catch (Exception e)
            {
                //ignore exception
            }


        }


        public void setDepDay(String dday)
        {
            try
            {
                TimeSpan span = new TimeSpan(0, 0, 0, 20, 500);
                WebDriverWait wait = new WebDriverWait(driver, span);
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='el-picker-panel__content el-date-range-picker__content is-left']//td[contains(@class,'available')]//div//span")));

                ReadOnlyCollection<IWebElement> L3 = driver.FindElements(By.XPath("//div[@class='el-picker-panel__content el-date-range-picker__content is-left']//td[contains(@class,'available')]//div//span"));

                foreach (IWebElement e in L3)
                {
                    if (e.Text.Equals(dday))
                    {
                        e.Click();
                    }
                }
            }
            catch (Exception e)
            {
                //ignore exception
            }
        }

        public void setResturnday(String rday)
        {
            try
            {
                TimeSpan span = new TimeSpan(0, 0, 0, 20, 500);
                WebDriverWait wait = new WebDriverWait(driver, span);
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='el-picker-panel__content el-date-range-picker__content is-right']//td[contains(@class,'available')]//div//span")));

                ReadOnlyCollection<IWebElement> L4 = driver.FindElements(By.XPath("//div[@class='el-picker-panel__content el-date-range-picker__content is-right']//td[contains(@class,'available')]//div//span"));

                foreach (IWebElement e in L4)
                {
                    if (e.Text.Equals(rday))
                    {
                        e.Click();
                    }
                }
            }
            catch (Exception e)
            {
                //ignore exception
            }

        }



        public String getSearchResult()
        {
            TimeSpan span = new TimeSpan(0, 0, 0, 20, 500);
            WebDriverWait wait = new WebDriverWait(driver, span);
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/span")));
            String searchresult = driver.FindElement(By.XPath("//div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/span")).Text;
            return searchresult;
        }
    }


  
}
