using System;
using System.Text;
using System.Collections.Generic;
using System.Web;
using Assignment_5.Models;
using EncryptionLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestProject.XmlAccess;

namespace UnitTestProject
{
    /// <summary>
    /// Summary description for CredentialsManagerTest
    /// </summary>
    [TestClass]
    public class CredentialsManagerTest
    {
        public CredentialsManager CredManager { get; set; }
        public Random Rand { get; set; }
        public CredentialsManagerTest()
        {
            
            CredManager = new CredentialsManager();
            Rand = new Random(DateTime.Now.Millisecond);
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void AuthenticateStaff_ReturnsTrueForValidCreds()
        {
            string userName = "TA";
            string password = "Cse445ta!";
            bool successfulAuth = CredManager.AuthenticateStaff(userName, password);
            Assert.IsTrue(successfulAuth);
        }

        [TestMethod]
        public void AuthenticateMember_ReturnsFalseForWrongPW()
        {
            string userName = "TA";
            string password = "not right";
            bool successfulAuth = CredManager.AuthenticateStaff(userName, password);
            Assert.IsFalse(successfulAuth);
        }

        [TestMethod]
        public void AuthenticateStaff_ReturnsFalseForInvalidUserName()
        {
            string userName = "TA guy";
            string password = "not right";
            bool successfulAuth = CredManager.AuthenticateStaff(userName, password);
            Assert.IsFalse(successfulAuth);
        }

        [TestMethod]
        public void RegisterMember_CanRegisterAndAuthenticate()
        {
            string userName = "testUser" + Rand.Next(1000);
            string password = Rand.Next(1000000).ToString();

            CredManager.RegisterMember(userName, password);
            bool successfulAuth = CredManager.AuthenticateMember(userName, password);
            Assert.IsTrue(successfulAuth);
        }

        [TestMethod]
        public void RegisterStaff_CanRegisterAndAuthenticate()
        {
            string userName = "testUser" + Rand.Next(1000000);
            string password = Rand.Next(1000000).ToString();

            CredManager.RegisterStaff(userName, password);
            bool successfulAuth = CredManager.AuthenticateStaff(userName, password);
            Assert.IsTrue(successfulAuth);
        }

        [TestMethod]
        public void Login_Success_ValidCreds()
        {
            string userName = "TA";
            string password = "Cse445ta!";
            
            string expectedID = EncDec.Encrypt(userName + password);
            HttpCookie authCookie = CredManager.LoginStaff(userName, password);
            string retrievedId = authCookie["userID"];
            Assert.AreEqual(retrievedId, expectedID);

            bool validID = CredManager.IsValidAuthCookie(authCookie, expectedID);
            Assert.IsTrue(validID);
        }

        [TestMethod]
        public void IsValidCookId_Fail_ExpiredCookie()
        {
            string userName = "TA";
            string password = "Cse445ta!";
            string expectedID = EncDec.Encrypt(userName + password);
            HttpCookie authCookie = CredManager.LoginStaff(userName, password);
            string retrievedId = authCookie["userID"];
            Assert.AreEqual(retrievedId, expectedID);

            authCookie.Expires = DateTime.Now.AddMinutes(-45);
            bool validID = CredManager.IsValidAuthCookie(authCookie, expectedID);
            Assert.IsFalse(validID);
        }
    }
}
