using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CalendlyAutomation
{
    public class TestClass : Driver
    {

        [Test]
        public void CheckPageTitle()
        {
            Thread.Sleep(3000);
            var pageTitle = CalendlyDriver.FindElement(By.Id("editable-title-span")).Text;
            Assert.IsTrue(pageTitle == "Broken (on purpose) Tic Tac Toe");
        }

        [Test]
        public void TicTacToeGridDisplayed()
        {
            CalendlyDriver.SwitchTo().Frame(CalendlyDriver.FindElement(By.Id("result")));
            CalendlyDriver.FindElement(By.Id("number")).SendKeys("3");
            CalendlyDriver.FindElement(By.XPath(@"//button[@id='start']")).Click();
            bool tableDisplayed = CalendlyDriver.FindElement(By.Id("table")).Displayed;
            Assert.IsTrue(tableDisplayed);

            int countSqures = CalendlyDriver.FindElements(By.XPath("//td")).Count-1;
            int i = 0;
            while (i <= countSqures)
            {
                bool endGame = CalendlyDriver.FindElement(By.Id("endgame")).Displayed;
                if (!endGame)
                {
                    CalendlyDriver.FindElement(By.Id("" + i + "")).Click();
                    i++;
                }
                else
                {
                    break;
                }
            }
            Thread.Sleep(5000);
        }
    }
}
