using System;
using System.Linq;
using System.Text.RegularExpressions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Selenium
{
    public class Program
    {
        public  IWebDriver driver;

        [SetUp]
        public  void Setup()
        {

            System.Environment.SetEnvironmentVariable("webdriver.chrome.driver", "/usr/bin/chromedriver");
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--no-sandbox");
            driver = new ChromeDriver(chromeOptions);

        }

    
        public void Login(string login, string pass){
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
            driver.FindElement(By.Id("txtUsername")).SendKeys(login);
            driver.FindElement(By.Id("txtPassword")).SendKeys(pass);
            driver.FindElement(By.Id("btnLogin")).Click();

        }

        public void NavigateToUserSection(){
            driver.FindElement(By.Id("menu_admin_viewAdminModule")).Click();
        }
        public void AddUser(string username, string employeeName, string password ){

            driver.FindElement(By.Id("btnAdd")).Click();            
            driver.FindElement(By.Id("systemUser_employeeName_empName")).SendKeys(employeeName);
            driver.FindElement(By.Id("systemUser_userName")).SendKeys(username);
            driver.FindElement(By.Id("systemUser_password")).SendKeys(password);
            driver.FindElement(By.Id("systemUser_confirmPassword")).SendKeys(password);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.FindElement(By.Id("btnSave")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        }
    private bool IsElementPresent(By by)
    {
        try
        {
            driver.FindElement(by);
            return true;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }
        public void SearchUser(string username){

            driver.FindElement(By.Id("searchSystemUser_userName")).SendKeys(username);
            driver.FindElement(By.Id("searchBtn")).Click();

            var isUserFound = IsElementPresent(By.XPath("//*[@id=\"resultTable\"]/tbody/tr/td[2]/a"));
            Assert.IsTrue(isUserFound);
            
        }

          public void CheckUserInGrid(string username){
            driver.FindElement(By.Id("resetBtn")).Click();
            var isUserInGrid = driver.FindElement(By.LinkText(username)).ToString();
            Assert.IsNotEmpty(isUserInGrid);
            

        }

        public void DeleteUser(string username){

            Regex re = new Regex(@"\d+");

            string link =  driver.FindElement(By.LinkText(username)).GetAttribute("href");
            string index = re.Match(link).ToString();
            driver.FindElement(By.Id("ohrmList_chkSelectRecord_"+index)).Click();
            driver.FindElement(By.Id("btnDelete")).Click();
            driver.FindElement(By.Id("dialogDeleteBtn")).Click();


            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            var isUserInGrid = driver.FindElement(By.LinkText(username)).ToString();
            Assert.IsEmpty(isUserInGrid);
            driver.Close();

        }

        [Test]
        public void testLogin(){

            string Username = "JohnDorian1";
            string EmployeeName = "Orange Test";
            string Password = "itsAWeakPass";
            Login("Admin", "admin123");
            NavigateToUserSection();
            AddUser(Username, EmployeeName, Password );
            SearchUser(Username);
            CheckUserInGrid(Username);
            DeleteUser(Username);
            
        }


    }
}

