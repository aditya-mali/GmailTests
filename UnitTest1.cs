using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace GmailActivity
{
    class DeleteUnwantedGmails
    {
        String test_url = "https://www.gmail.com";

        IWebDriver driver;

        [SetUp]
        public void start_Browser()
        {
            // Local Selenium WebDriver 
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void test_search()
        {
            //launch URL
            driver.Url = test_url;

            System.Threading.Thread.Sleep(2000);

            IWebElement emailEnter = driver.FindElement(By.XPath("//input[@type='email']"));

            emailEnter.SendKeys("Aditya.XXXX@XXXXX.XXXXX");
            System.Threading.Thread.Sleep(500);
            driver.FindElement(By.XPath("(//*[contains(text(),'Next')])[2]")).Click();
            System.Threading.Thread.Sleep(2000);
            IWebElement passwordENter = driver.FindElement(By.XPath("//input[@type='password']"));
            passwordENter.SendKeys("XXXXXXXXXXXX");
            driver.FindElement(By.XPath("(//*[contains(text(),'Next')])[2]")).Click();
            System.Threading.Thread.Sleep(10000);
            driver.FindElement(By.XPath("(//*[contains(text(),'NSS')])[1]")).Click();
            System.Threading.Thread.Sleep(5000);
            for (int i = 0; i < 6; i++)
            {
                //Click till the total mails in the folder ends //Number of Iterations
                driver.FindElement(By.XPath("(//*[@role='checkbox'])[2]")).Click();
                System.Threading.Thread.Sleep(500);
                driver.FindElement(By.XPath("(//div[@data-tooltip='Delete'])[1]")).Click();
                System.Threading.Thread.Sleep(4000);
            }
            Console.WriteLine("Test Passed");
        }

        [TearDown]
        public void close_Browser()
        {
            if(driver != null)
            { 
                driver.Quit();
            }
            
        }
    }
}