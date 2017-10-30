using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace IStest
{
    public class SeleniumTest
    {
        IWebDriver driver;

        [Test]
        public void FirstTest()
        {
            driver = new FirefoxDriver();
            // Navigating into the requested URL.
            driver.Navigate().GoToUrl("http://newtours.demoaut.com");
            // Getting elements and performing required actiona
            // introducing username & pass
            driver.FindElement(By.Name("userName")).SendKeys("ingsoftware");
            driver.FindElement(By.Name("password")).SendKeys("ingsoftware");
            // Click on login button
            driver.FindElement(By.Name("login")).Click();
            // Waiting for 2 seconds to load
            Thread.Sleep(2000);
            // Setting depart and arrive dropdowns
            new SelectElement(driver.FindElement(By.Name("fromPort"))).SelectByValue("London");
            new SelectElement(driver.FindElement(By.Name("toPort"))).SelectByValue("Paris");
            // Selecting first class radio button.
            driver.FindElements(By.Name("servClass")).First(e => e.GetAttribute("value") == "First").Click();
            // Clicking on Continue button.
            driver.FindElement(By.Name("findFlights")).Click();
            // Waiting for 2 seconds to load
            Thread.Sleep(2000);
            // Clicking on continue button on select flight view.
            driver.FindElement(By.Name("reserveFlights")).Click();
            // Waiting for 2 seconds to load
            Thread.Sleep(2000);
            // Filling required text data
            driver.FindElement(By.Name("passFirst0")).SendKeys("MiNombre");
            driver.FindElement(By.Name("passLast0")).SendKeys("MiApellido");
            driver.FindElement(By.Name("creditnumber")).SendKeys("123456");
            // Click on Secure Purchase button.
            driver.FindElement(By.Name("buyFlights")).Click();
            // Waiting for 2 seconds to load
            Thread.Sleep(2000);
            // Clicking on SIGN OFF button.
            driver.FindElement(By.CssSelector("[href='mercurysignoff.php']")).Click();
            // Verifying that the last loaded page is the expected.
            Assert.IsTrue(driver.Url.Contains("mercurysignon.php"));
            // Disposing the browser and closing the driver.
            driver.Close();
            driver.Quit();
        }

        [Test]
        public void SecondTest()
        {
            driver = new FirefoxDriver();
            // Navigating into the requested URL.
            driver.Navigate().GoToUrl("http://newtours.demoaut.com");
            // Getting elements and performing required actiona
            // introducing username & pass
            driver.FindElement(By.Name("userName")).SendKeys("ingsoftware");
            driver.FindElement(By.Name("password")).SendKeys("ingsoftware");
            // Click on login button
            driver.FindElement(By.Name("login")).Click();
            // Waiting for 2 seconds to load
            Thread.Sleep(2000);
            // Verifying that the last loaded page contains the sign out link
            IWebElement SignOffLink = null;
            try
            {
                SignOffLink = driver.FindElement(By.CssSelector("[href='mercurysignoff.php']"));
            }
            catch (NoSuchElementException)
            { 
                // Bypassing this exception to verify by assertion
            }            
            Assert.IsTrue(SignOffLink != null);
            // Disposing the browser and closing the driver.
            driver.Close();
            driver.Quit();
        }
    }
}
