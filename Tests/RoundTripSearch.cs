using Assignment2.Pages;
using Assignment2.Testdata;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment2.Tests
{
    class RoundTripSearch
    {
        IWebDriver driver;
        ChromeOptions options;
        ExtentHtmlReporter r1;
        ExtentReports extent;
        ExtentTest test;

        
        

        [SetUp]
        public void StartTC()
        {

            options = new ChromeOptions();

            options.AddArguments("--disable-notifications");
            options.AddArgument("no-sandbox");
           
            TimeSpan T1 = new TimeSpan(0, 0, 30);
           
            String driverpath= Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //string filepath = @"C:\Users\amal.mohamed\Documents\Visual Studio 2017\Projects\Assignment2\packages\Selenium.Chrome.WebDriver.76.0.0\driver";
            driver = new ChromeDriver(driverpath, options, T1);
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.fly365.com";
            ReadData.setData(driverpath);

            r1 = new ExtentHtmlReporter(driverpath + "\\"+"testresults.html");
            extent = new ExtentReports();
            extent.AttachReporter(r1);
            extent.AddSystemInfo("Opering System", "Windows 10");
            extent.AddSystemInfo("Browser", "Chrome");


        }
   


        [Test, Order(1)]
        public void roundTripSearch()
        {

            RoundTripPage r1 = new RoundTripPage(this.driver);
            test = extent.CreateTest("RounfTrip Search");
            
            IWebElement orgn = r1.findOrigin();
            test.Log(Status.Info, "Insert Origin");
            orgn.SendKeys(ReadData.Origin);
            Thread.Sleep(5000);
            r1.setOrigin(ReadData.Origintown);
            r1.findDestination().SendKeys(ReadData.Destination);
            test.Log(Status.Info, "Insert Destination");
            r1.setDestination(ReadData.Destinationtown);
            test.Log(Status.Info, "Insert departure day and Return day ");
            r1.setDepDay(ReadData.depday);
            r1.setResturnday(ReadData.returnday);
            test.Log(Status.Info, "Click Search");
            r1.findSearch().Click();
            String Expectedresult = ReadData.Expectedeesult;
            String Actualresult = r1.getSearchResult();
            test.Log(Status.Pass, "Teat Passed");
            Assert.AreEqual(Expectedresult, Actualresult);

            
        }




        [Test, Order(2)]
        public void signUp()
        {
            test = extent.CreateTest("signUp");
            String emailtxt = Helpers.Helpers.generateEmail();

            SignUpPage s1 = new SignUpPage(this.driver);
            IWebElement signin = s1.getSignbutton();
            test.Log(Status.Info, "Click Sign In");
            signin.Click();

            IWebElement signup = s1.getSignUpButton();
            test.Log(Status.Info, "Click Sign Up");
            signup.Click();
            IWebElement fname = s1.getFirstName();
            test.Log(Status.Info, "Insert First Namr");
            fname.SendKeys(ReadData.fnametxt);
            IWebElement familyname = s1.getFamilyName();
            test.Log(Status.Info, "Insert Family Name");
            familyname.SendKeys(ReadData.familynametxt);
            IWebElement email = s1.getEmail();
            test.Log(Status.Info, "Insert Email");
            email.SendKeys(emailtxt);
            IWebElement password = s1.getPassword();
            test.Log(Status.Info, "Insert Password");
            password.SendKeys(ReadData.Password);
            IWebElement createaccount = s1.getCreateAccount();
            test.Log(Status.Info, "Click Create Account");
            createaccount.Click();

            bool act = s1.checkMeg();
            bool exp = true;

            test.Log(Status.Pass, "User is Logged on");

            Assert.AreEqual(exp, act);
        }





        [Test, Order(3)]
        public void contactUs()
        {
            var test = extent.CreateTest("contactUs");
            ContactUsPage c1 = new ContactUsPage(this.driver);
            c1.getContactUs().Click(); ;

            test.Log(Status.Info, "Click on Contact Us");
            IWebElement fullname = c1.getFullName();
            fullname.SendKeys(ReadData.fnametxt);

            test.Log(Status.Info, "Insert Full Name");
            IWebElement message = c1.getMessage();
            test.Log(Status.Info, "Insert Message");
            message.SendKeys(ReadData.familynametxt);
            IWebElement email = c1.getEmail();
            email.SendKeys(Helpers.Helpers.generateEmail());
            test.Log(Status.Info, "Insert Email");
            IWebElement category = c1.getCategory();
            category.Click();
            test.Log(Status.Info, "Pick Category");

            c1.setCategory();
            test.Log(Status.Info, "Send");
            c1.getSend().Click();
            test.Log(Status.Pass, "Passed");
            extent.Flush();
        }


        [TearDown]
        public void DerivedTearDown() {

            Thread.Sleep(10000);
            driver.Quit();
            
        }

        [OneTimeTearDown]
        public void endTest()
        {
            extent.Flush();

        }

    }
}
