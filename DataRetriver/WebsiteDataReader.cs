using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace DataRetriverDLL
{
    public class WebsiteDataReader
    {
        private readonly string _websiteUrl = "https://jobs.dou.ua/vacancies/?category=.NET";

        private readonly string _chromeUrl =
            "C:/Users/Oksana/source/repos/DataRetriver/DataRetriver/bin/Debug/netcoreapp2.1";

        public IEnumerable<JobVacancy> GetDataFromWebsite()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--headless");

            var driver = new ChromeDriver(_chromeUrl, chromeOptions);
            driver.Navigate().GoToUrl(_websiteUrl);

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.FindElement(By.CssSelector("#container")));

            var vacancyElements = driver.FindElements(By.CssSelector(".vacancy"));
            foreach (var vacancyElement in vacancyElements)
            {
                //Thread.Sleep(TimeSpan.FromSeconds(5));
                var vacancy = new JobVacancy
                {
                    Title = vacancyElement.FindElement(By.CssSelector(".title"))?.Text,
                    VacancyUrl = vacancyElement.FindElement(By.CssSelector(".title a.vt"))?.GetAttribute("href"),
                    CompanyName = vacancyElement.FindElement(By.CssSelector(".company"))?.Text,
                    Description = vacancyElement.FindElement(By.CssSelector(".sh-info"))?.Text
                };
                yield return vacancy;
            }

            driver.Close();
        }
    }
}
