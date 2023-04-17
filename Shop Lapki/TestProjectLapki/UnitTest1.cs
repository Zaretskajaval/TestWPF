using Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using Xunit;
using TextBox = System.Windows.Controls.TextBox;
using Microsoft.SmallBasic.Library;

namespace TestProjectLapki
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            bool t = false;
            Regex regexLog = new Regex(@"^Admin$");
            Regex regexPass = new Regex(@"^123$");
            TextBox textboxLogin = new TextBox();
            textboxLogin.Text = "Admin";
            TextBox textboxPassword = new TextBox();
            textboxPassword.Text = "123";
            if (regexLog.IsMatch(textboxLogin.Text) && regexPass.IsMatch(textboxPassword.Text))
            {
                t = true;
            }
        }
    }
}
