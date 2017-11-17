using System;
using System.Text;
using System.Collections.Generic;
using EncryptionLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    /// <summary>
    /// Summary description for EncDecTest
    /// </summary>
    [TestClass]
    public class EncDecTest
    {
        public EncDecTest()
        {
            //
            // TODO: Add constructor logic here
            //
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
        public void EncrpytionGeneratesExpectedValue()
        {
            const string expectedValue = "u6G0Wwyk2G/2TRTKSpR+9w==";
            string plainText = "testUserName";
            string encrypted = EncDec.Encrypt(plainText);
            Assert.AreEqual(encrypted, expectedValue);
        }

        [TestMethod]
        public void DecryptionGeneratesExpectedValue()
        {
            const string expectedValue = "testUserName";
            string encryptedText = "u6G0Wwyk2G/2TRTKSpR+9w==";
            string decryptedTxt = EncDec.Decrypt(encryptedText);
            Assert.AreEqual(decryptedTxt, expectedValue);
        }
    }
}
