using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;

namespace CsharpInterview
{
    public class AppiumProj
    {
        public static void testMobile()
        {
            // Configure Appium
            var options = new AppiumOptions
            {
                PlatformName = "Android", 
                PlatformVersion = "10.0",
                DeviceName = "emulator-5554",
                App = "com.example.trialapp", 
            };

            try
            {
                // Init
                string address = "http://localhost:PORT/address:-]";
                
                using (var driver = new AndroidDriver<AndroidElement>(new Uri(address), options))
                {
                    // Log in
                    var usernameField = driver.FindElement(By.Id("com.example.trialapp:id/username"));
                    var passwordField = driver.FindElement(By.Id("com.example.trialapp:id/password"));
                    var loginButton = driver.FindElement(By.Id("com.example.trialapp:id/login_button"));

                    usernameField.SendKeys("your_username");
                    passwordField.SendKeys("your_password");
                    loginButton.Click();

                    // Go to settings
                    var settingsButton = driver.FindElement(By.Id("com.example.trialapp:id/settings_button"));
                    settingsButton.Click();

                    // Update profile
                    var profileNameField = driver.FindElement(By.Id("com.example.trialapp:id/profile_name"));
                    profileNameField.Clear();
                    profileNameField.SendKeys("Brian");
                    var saveButton = driver.FindElement(By.Id("com.example.trialapp:id/save_button"));
                    saveButton.Click();

                    // Verification (e.g., check if the profile was updated)
                    var updatedName = driver.FindElement(By.Id("com.example.trialapp:id/profile_name")).Text;
                    if (updatedName == "Brian")
                    {
                        Console.WriteLine("Update was successful");
                    }
                    else
                    {
                        Console.WriteLine("Update failed");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
