using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;

namespace Assignment_5.Models
{
    public class XmlAccessObject
    {

        private string PATH_TO_STAFF_XML = HttpContext.Current.Server.MapPath("~/App_Data/Staff.xml");
        private string PATH_TO_MEMBER_XML = HttpContext.Current.Server.MapPath("~/App_Data/Member.xml");
        private const string USER_NAME_KEY = "userName";
        private const string PASSWORD_KEY = "password";

//        public XmlAccessObject(string pathToStaffXml, string pathToMemberXml)
//        {
//            
//        }

        #region Authentication Methods

        public bool AuthenticateMember(string userNameIn, string passwordIn)
        {
            return AuthenticateCredentials(userNameIn, passwordIn, PATH_TO_MEMBER_XML);
        }

        public bool AuthenticateStaff(string userNameIn, string passwordIn)
        {
            return AuthenticateCredentials(userNameIn, passwordIn, PATH_TO_STAFF_XML);
        }

        // Authentication methods utilize same logic with different file path
        private static bool AuthenticateCredentials(string userNameIn, string passwordIn, string filePath)
        {
            try
            {
                using (XmlTextReader reader = new XmlTextReader(filePath))
                {
                    // keep reading til we find matching username
                    // else find none and return false
                    while (reader.Read())
                    {
                        // element with key name username
                        if (reader.NodeType == XmlNodeType.Element && reader.Name == USER_NAME_KEY)
                        {
                            string contents = reader.ReadString();
                            if (contents == userNameIn)
                            {
                                // matched uname, now get password
                                while (reader.Read())
                                {
                                    if (reader.NodeType == XmlNodeType.Element && reader.Name == PASSWORD_KEY)
                                    {
                                        contents = reader.ReadString();
                                        if (contents == passwordIn) // success
                                        {

                                            return true;
                                        }
                                        else
                                        {
                                            return false; // failure
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("something went wrong");
            }

            // unable to match username
            return false;
        }


        #endregion

        #region Registration Methods


        // Registration methods utilize same logic with different file paths
        public void RegisterMember(string userName, string password)
        {
            RegisterUser(userName, password, PATH_TO_MEMBER_XML);
        }

        public void RegisterStaff(string userName, string password)
        {
            RegisterUser(userName, password, PATH_TO_STAFF_XML);
        }

        private static void RegisterUser(string userName, string password, string filePath)
        {
            XmlDocument xd = LoadXml(filePath);

            // Get our root (logins)
            XmlNode root = xd.SelectSingleNode("/*");

            // Create the node for new user
            XmlNode newUserNode = CreateLoginNode(userName, password, xd);

            // append and save
            try
            {
                root.AppendChild(newUserNode);
                xd.Save(filePath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static XmlDocument LoadXml(string pathOrUrl)
        {
            var xd = new XmlDocument();
            xd.Load(pathOrUrl);

            return xd;
        }

        private static XmlNode CreateLoginNode(string userName, string password, XmlDocument xd)
        {
            // login node has 2 child nodes username and password
            XmlNode loginNode = xd.CreateElement("login");

            XmlNode userNameNode = xd.CreateElement("userName");
            userNameNode.InnerText = userName;
            loginNode.AppendChild(userNameNode);

            XmlNode passwordNode = xd.CreateElement("password");
            passwordNode.InnerText = password;
            loginNode.InsertAfter(passwordNode, userNameNode);

            return loginNode;
        }

        #endregion
    }
}