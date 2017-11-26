using System.Web;
using EncryptionLibrary;

namespace Assignment_5.Managers
{
    // System utilizes encryption and xml access methods
    // Credentials manager bundles both into one class to
    // provide an interface where for each pubic method, only username and password are 
    // necessary parameters
    public class CredentialsManager
    {
        private XmlAccessObject m_XmlAccess;

        public CredentialsManager()
        {
            m_XmlAccess = new XmlAccessObject();
        }

        // If successful, return id
        // else return null
        public string TryLoginStaff(string userName, string password)
        {
            string id = null;
            if (AuthenticateStaff(userName, password))
            {
                id = EncDec.Encrypt(userName + password);
            }

            
            return id;
        }

        public string TryLoginMember(string userName, string password)
        {
            string id = null;
            if (AuthenticateMember(userName, password))
            {
                id = EncDec.Encrypt(userName + password);
            }

            return id;
        }

        public bool AuthenticateMember(string userName, string password)
        {
            string encryptedUName = EncDec.Encrypt(userName);
            string encryptedPw = EncDec.Encrypt(password);

            return m_XmlAccess.AuthenticateMember(encryptedUName, encryptedPw);
        }

        public bool AuthenticateStaff(string userName, string password)
        {
            string encryptedUName = EncDec.Encrypt(userName);
            string encryptedPw = EncDec.Encrypt(password);

            return m_XmlAccess.AuthenticateStaff(encryptedUName, encryptedPw);
        }

        public bool RegisterMember(string userName, string password)
        {
            string encryptedUName = EncDec.Encrypt(userName);
            string encryptedPw = EncDec.Encrypt(password);

            return m_XmlAccess.RegisterMember(encryptedUName, encryptedPw); ;
        }

        public bool RegisterStaff(string userName, string password)
        {
            string encryptedUName = EncDec.Encrypt(userName);
            string encryptedPw = EncDec.Encrypt(password);

            return m_XmlAccess.RegisterStaff(encryptedUName, encryptedPw); ;
        }
    }
}