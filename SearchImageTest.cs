using OpenQA.Selenium;

namespace GoogleSearchImageNunitTest
{
        public class Tests
        {
            private IWebDriver driver;
            private readonly By _searchField = By.XPath("//input[@class='gLFyf gsfi']");
            private readonly By _imageTab = By.XPath("//div[@class='pvresd LFls2 MBlpC']//img[contains(@id,'dimg')]");
            [SetUp]
            public void Setup()
            {
                driver = new OpenQA.Selenium.Chrome.ChromeDriver();
                driver.Navigate().GoToUrl("https://www.google.com/");
                driver.Manage().Window.Maximize();
            }

            [Test]
            public void SearchImage()
            {
                var search = driver.FindElement(_searchField);
                search.SendKeys("image");
                search.SendKeys(Keys.Enter);
                var image = driver.FindElements(_imageTab);
                Assert.That(image, Is.Not.Empty);
            }

            [TearDown]
            public void TearDown()
            {
                driver.Dispose();
            }
        }
    
}