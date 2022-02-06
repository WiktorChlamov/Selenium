using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Selenium
{
    internal class Testing
    {
        private IWebDriver _m_driver;
        public void Run(int expectedResult, string department, params string[] languages)
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            _m_driver = new ChromeDriver(path);
            _m_driver.Url = "https://careers.veeam.ru/vacancies";
            _m_driver.Manage().Window.Maximize();


            DepartmentCheck(department);
            LanguageChecking(languages);
            CheckResult(expectedResult);
            _m_driver.Close();
        }

        private void DepartmentCheck(string department)
        {
            IWebElement course = _m_driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[2]/div[1]/div/div[2]/div/div/button"));
            course.Click();

            ReadOnlyCollection<IWebElement> courseElements = _m_driver.FindElements(By.XPath("//*[@id='root']/div/div[1]/div/div[2]/div[1]/div/div[2]/div/div/div/*"));
            
            bool find = false;
            foreach (IWebElement element in courseElements)
            {
                
                if (string.Equals(element.Text.ToLower(),department.ToLower()))
                {
                    element.Click();
                    find = true;
                    break;
                }
                
            }

            if(!find)
                {
                    Console.WriteLine($"Ошибка. Отдел не найден!: {department}");
                    course.Click();
            }
        }

        private void LanguageChecking(string[] languages)
        {
            IWebElement lang = _m_driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[2]/div[1]/div/div[3]/div/div/button"));
            lang.Click();
            ReadOnlyCollection<IWebElement> languageElements = _m_driver.FindElements(By.XPath("//*[@id='root']/div/div[1]/div/div[2]/div[1]/div/div[3]/div/div/div/*"));
           
            IList<string> languageErrorNames = new List<string>(languages);

            foreach (IWebElement element in languageElements)
            {
                foreach (string language in languages)
                {
                    if (string.Equals(language.ToLower(), element.Text.ToLower()))
                    {
                        element.Click();
                        languageErrorNames.Remove(language);
                        continue;
                    }
                }
            }
            if(languageErrorNames.Count > 0)
            {
                foreach (string language in languageErrorNames)
                {
                    Console.WriteLine($"Ошибка. Язык не найден!: {language}");
                }
            }
            lang.Click();
        }

        private void CheckResult(int expectedResult)
        {
            IWebElement findingElements = _m_driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[2]/div[2]/div"));
            int countElements = findingElements.FindElements(By.XPath("./*")).Count;
            Console.WriteLine("Expected result: " + expectedResult + "//" + "actual result: " + countElements+ "\n");
            string result = expectedResult == countElements ? "Ожидаемый результат равен фактическому" : "ВНИМАНИЕ: Ожидаемый результат НЕ равен фактическому";
            Console.WriteLine(result);  
        }
    }
}
