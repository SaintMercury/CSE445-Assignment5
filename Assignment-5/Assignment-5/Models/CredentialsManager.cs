using System;
using System.Web;
using Assignment_5.XmlAccess;
using EncryptionLibrary;

namespace Assignment_5.Models
{
    public class CredentialsManager
    {
        private XmlAccessObject m_XmlAccess;
        private SessionStateManager m_SessionStateManager;
        private const string AUTH_COOKIE_NAME = "user";
        private const string AUTH_COOKIE_KEY_ID = "userID";
      

        public CredentialsManager()
        {
            m_XmlAccess = new XmlAccessObject();
            m_SessionStateManager = new SessionStateManager();
            
        }

        public bool AuthenticateMember(string userName, string password)
        {
            string encryptedUName = EncDec.Encrypt(userName);
            string encryptedPW = EncDec.Encrypt(password);

            return m_XmlAccess.AuthenticateMember(encryptedUName, encryptedPW);
        }

        public bool AuthenticateStaff(string userName, string password)
        {
            string encryptedUName = EncDec.Encrypt(userName);
            string encryptedPW = EncDec.Encrypt(password);

            return m_XmlAccess.AuthenticateStaff(encryptedUName, encryptedPW);
        }

        public void RegisterMember(string userName, string password)
        {
            string encryptedUName = EncDec.Encrypt(userName);
            string encryptedPW = EncDec.Encrypt(password);

            m_XmlAccess.RegisterMember(encryptedUName, encryptedPW);
        }

        public void RegisterStaff(string userName, string password)
        {
            string encryptedUName = EncDec.Encrypt(userName);
            string encryptedPW = EncDec.Encrypt(password);

            m_XmlAccess.RegisterStaff(encryptedUName, encryptedPW);
        }

        // Login method will try to authenticate
        // if success, then return a cookie
        // else return null
        public HttpCookie LoginStaff(string userName, string password)
        {
            HttpCookie authCookie = null;
            if (AuthenticateStaff(userName, password))
            {
                string id = EncDec.Encrypt(userName + password);
                authCookie = SessionStateManager.CreateAuthCookie();
            }

            return authCookie;
        }

        // pass our request in and check for our cookie 
        public bool IsLoggedIn(HttpRequest request)
        {
            return SessionStateManager.HasValidAuthCookie(request);
        }
    }
}