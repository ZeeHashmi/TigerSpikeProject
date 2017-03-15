using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Safari;
using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace TigerSpike
{
    public class TestBase
    {

        public IWebDriver driver;


        public List<string> listA = new List<String>();
        public List<string> listB = new List<String>();
        public List<string> listC = new List<String>();
        public List<string> listD = new List<String>();

        public void Setbrowser(String browserName)
        {

            if (browserName.Equals("IE"))
                driver = new InternetExplorerDriver();

            if (browserName.Equals("Firefox"))

                driver = new FirefoxDriver();

            if (browserName.Equals("Chrome"))

                driver = new ChromeDriver();

            if (browserName.Equals("Safari"))

                driver = new SafariDriver();

            // Add same statement for other browsers
        }

        /*public static BrowserToNameWith(String browserName)
        {
        String[] browsers = { "Chrome", "Firefox", "IE", "Safari"};
        foreach (String b in browsers)
        {

        yeild return b;
        }
        }
        */

        public void ReadData()
        {
            StreamReader reader = new StreamReader(File.OpenRead(@"C:\Temp\TestData.txt"));
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (!String.IsNullOrWhiteSpace(line))
                {
                    string[] values = line.Split(',');
                    if (values.Length >= 4)
                    {
                        listA.Add(values[0]);
                        listB.Add(values[1]);
                        listC.Add(values[2]);
                        listD.Add(values[3]);
                    }
                    Console.WriteLine(listA);
                }
            }
        }

        public string BrandName()
        {
            return this.listA[0];

            
        }

        public void Closebrowser()
        {
            driver.Quit();
        }
    }
}

