using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CsharpInterview
{
    public class SeleniumTests
    {
        public static void login(string username, string password)
        {
            using var driver = new ChromeDriver();

            try
            {
                // Navigate to the login page
                driver.Navigate().GoToUrl("https://practicetestautomation.com/practice-test-login/");

                // Enter username and password
                var usernameField = driver.FindElement(By.Id("username"));
                var passwordField = driver.FindElement(By.Id("password"));
                var loginBtn = driver.FindElement(By.Id("submit"));

                usernameField.SendKeys(username);
                passwordField.SendKeys(password);
                //here i'm simulating a user click action
                loginBtn.Click();

                // Wait for redirection to the homepage
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                // Verify redirection and welcome message

                // Find all h1 elements
                var h1Elements = driver.FindElements(By.CssSelector("h1.post-title"));

                bool isLoginSuccessfullText = h1Elements.Any(element => element.Text == "Logged In Successfully");


                // ukishapata h1 just check if it has `loggedin successfuly` text like in the original site
                var h1Element = driver.FindElement(By.CssSelector("h1.post-title"));
                string h1Text = h1Element.Text;

                if (h1Text == "Logged In Successfully")
                {
                    Console.WriteLine("Passed test! On Login redirects to Login page");
                }
                else
                {
                    Console.WriteLine("Failed Test!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed due to an exception: {ex.Message}");
            }
            finally
            {
                // Quit the browser
                driver.Quit();
            }
        }
    }
}
