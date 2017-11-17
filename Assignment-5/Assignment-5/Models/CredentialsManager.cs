using System;
using System.Web;
using Assignment_5.XmlAccess;
using EncryptionLibrary;

namespace Assignment_5.Models
{
    public class CredentialsManager
    {
        private XmlAccessServiceClient m_svcClient;
        private const string AUTH_COOKIE_NAME = "user";
        private const string AUTH_COOKIE_KEY_NAME = "userID";

        public CredentialsManager()
        {
            m_svcClient = new XmlAccessServiceClient();
        }

        public bool AuthenticateMember(string userName, string password)
        {
            string encryptedUName = EncDec.Encrypt(userName);
            string encryptedPW = EncDec.Encrypt(password);

            return m_svcClient.AuthenticateMember(encryptedUName, encryptedPW);
        }

        public bool AuthenticateStaff(string userName, string password)
        {
            string encryptedUName = EncDec.Encrypt(userName);
            string encryptedPW = EncDec.Encrypt(password);

            return m_svcClient.AuthenticateStaff(encryptedUName, encryptedPW);
        }

        public void RegisterMember(string userName, string password)
        {
            string encryptedUName = EncDec.Encrypt(userName);
            string encryptedPW = EncDec.Encrypt(password);

            m_svcClient.RegisterMember(encryptedUName, encryptedPW);
        }

        public void RegisterStaff(string userName, string password)
        {
            string encryptedUName = EncDec.Encrypt(userName);
            string encryptedPW = EncDec.Encrypt(password);

            m_svcClient.RegisterStaff(encryptedUName, encryptedPW);
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
                authCookie = CreateAuthCookie(id);
            }

            return authCookie;
        }

        // Refactor
        public bool IsLoggedIn(HttpCookie authCookie, string expectedID)
        {
            return IsValidAuthCookie(authCookie, expectedID);
        }

        // 30 minute expiration on cookie
        // need method of refreshing expiration 
        private HttpCookie CreateAuthCookie(string encrypID)
        {
            HttpCookie authCookie = new HttpCookie(AUTH_COOKIE_NAME)
            {
                Secure = true,
                [AUTH_COOKIE_KEY_NAME] = encrypID,
                Expires = DateTime.Now.AddMinutes(30)
            };

            return authCookie;
        }

        public bool IsValidAuthCookie(HttpCookie authCookie, string expectedID)
        {
            bool isNotExpired = DateTime.Now < authCookie.Expires;
            if ( !string.IsNullOrWhiteSpace(expectedID) && isNotExpired)
            {
                try
                {
                    string id = authCookie[AUTH_COOKIE_KEY_NAME];
                    if (id == expectedID)
                    {
                        return true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            return false;
        }
    }
}