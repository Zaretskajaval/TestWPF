using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop_Lapki;
using Shop_Lapki.View;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Windows.Controls;
using System.Windows;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Automation.Peers;
using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using System.Data;

namespace LapkiTest
{
    [TestClass]
    public class UnitTest1
    {
       

        [TestMethod]
        public void CheckLoginAndPasswordTest()//������������ ����������� �������� ������ � ������
        {


            CheckForTest checkForTest = new CheckForTest();
            checkForTest.Check();
            if(checkForTest.PassLogIsTrue)
            {
                Assert.IsTrue(true);
            }

        }
        [TestMethod]
        public void CheckButtonExitOnExitTest()//������������ ������ ������ �� ����
        {
            CheckForTest checkForTest = new CheckForTest();
            checkForTest.CheckExitButton();
            if (checkForTest.EXIT==true)
            {
                Assert.IsTrue(true);
            }

        }

        [TestMethod]
        public void CheckCountTryEnterTest()//������������ ������� ���������� ������� ����� ��� �������� �������� ������ ���� ������
        {
            CheckForTest checkForTest = new CheckForTest();
            checkForTest.CheckCountTryEnter();
            Assert.AreEqual(1, checkForTest.countTry);
            Assert.AreEqual(2, checkForTest.countTryOBR);

        }

        [TestMethod]
        public void CheckReadFilesTest()//������������ ������ �� ������
        {
            CheckForTest checkForTest = new CheckForTest();
            checkForTest.ReadFiles();
            if (checkForTest.ReadingFiles==true)
            {
                Assert.IsTrue(true);
            }

        }



    }
    
}
