using NUnit.Framework;
using Shop_Lapki.View;
using System.Text.RegularExpressions;

namespace TestProjectNNNNN
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Regex regexLog = new Regex(@"^Admin$");
            Regex regexPass = new Regex(@"^123$");
            
            var window = new AutorisationWindow();
            var logRegex = new Regex(@"^Admin$");
            window.TextboxLog.Text = "Admin";

            // Act
            var result = logRegex.IsMatch(window.TextboxLog.Text);

            // Assert
            Assert.IsTrue(result);
        }
    }
}