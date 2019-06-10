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
            var pageTitle = driver.FindElement(By.Id("editable-title-span")).Text;
            Assert.IsTrue(pageTitle == "Broken (on purpose) Tic Tac Toe");
        }

        [Test]
        public void TicTacToeGridDisplayed()
        {
            driver.SwitchTo().Frame(driver.FindElement(By.Id("result")));
            driver.FindElement(By.Id("number")).SendKeys("3");
            driver.FindElement(By.XPath(@"//button[@id='start']")).Click();
            bool tableDisplayed = driver.FindElement(By.Id("table")).Displayed;
            Assert.IsTrue(tableDisplayed);

            int countSqures = driver.FindElements(By.XPath("//td")).Count-1;
            int i = 0;
            while (i <= countSqures)
            {
                bool endGame = driver.FindElement(By.Id("endgame")).Displayed;
                if (!endGame)
                {
                    driver.FindElement(By.Id("" + i + "")).Click();
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
