using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestProject6
{
    public static class Tests
    {

        public static bool ElementIsPresent(this IWebDriver driver, By by)
        {
            try
            {
                return driver.FindElement(by).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }

    public class UnitTest
    {
        [Test]
        //Assert function to check if the icons are visible
        public void FindVisibleIcon()
        {
            var driver = new ChromeDriver(@"C:\Program Files\Java");
            driver.Navigate().GoToUrl("https://www.databoundhealthcare.com/");
            Assert.AreEqual(true, driver.ElementIsPresent(By.Id("container2")));
            driver.Navigate().GoToUrl("https://www.databoundhealthcare.com/");
            Assert.AreEqual(false, driver.ElementIsPresent(By.ClassName("container2")));
            driver.Navigate().GoToUrl("https://www.databoundhealthcare.com/");
            Assert.AreEqual(false, driver.ElementIsPresent(By.ClassName("container2")));

            Console.WriteLine("Icons are visible, Test Passed");

            //Assert function to check the navigation 
            //Page Title
            IList<IWebElement> links = driver.FindElements(By.TagName("a"));
            links.First(element => element.Text == "Learn More").Click();

            String expected_title = "EMUE – Robotic Process Automation Platform from Databound";
            String actual_title = driver.Title;

            Assert.That(actual_title, Does.Contain(expected_title).IgnoreCase);

            Console.WriteLine("Title is present, Test passed");

            //Assert to find the text content on the page

            Assert.IsTrue(driver.PageSource.Contains("Healthcare is a unique space with complex needs that " +
                "exceed those of general industry automation."));
            Console.WriteLine("The text content is present, Test Passed");
        }

    }
}

            
            

            
