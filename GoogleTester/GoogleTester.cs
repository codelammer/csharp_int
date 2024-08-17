using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace CsharpInterview
{
    public class GoogleTester
    {
        public static void testCrawlGoogle()
        {
            // Set up ChromeDriver
            using (IWebDriver driver = new ChromeDriver())
            {
                try
                {
                    driver.Navigate().GoToUrl("https://www.google.com");

                    // Find the search box using its name attribute-> 
                    IWebElement searchBox = driver.FindElement(By.Name("q"));

                    searchBox.SendKeys("Test Automation");

                    searchBox.Submit();

                    // Use WebDriverWait to wait for the search results to load
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector("div.g")));

                    // looking for element with id search because the results page had it
                    var searchResults = driver.FindElement(By.Id("search"));
                    if (searchResults != null)
                    {
                        Console.WriteLine("Search is working");
                    }
                    else
                    {
                        Console.WriteLine("No search results was found.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
                finally
                {
                    // Close the browser
                    driver.Quit();
                }
            }
        }
    }
}
