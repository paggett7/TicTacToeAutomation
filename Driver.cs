using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendlyAutomation
{
    public class Driver
    {
        public IWebDriver CalendlyDriver;

        [SetUp]
        public void StartDriver()
        {
            CalendlyDriver = new ChromeDriver(@"C:\ChromeDriver");
            CalendlyDriver.Url = "https://codepen.io/jshlfts32/full/bjambP/";
        }

        [TearDown]
        public void CloseBrowser()
        {
            CalendlyDriver.Close();
        }
    }
}
