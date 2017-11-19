using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using EncryptionLibrary;

namespace Assignment_5.Models
{
    public class SessionStateManager
    {
        private const string AUTH_COOKIE_NAME = "user";
        private const string AUTH_COOKIE_KEY_ID = "userID";
        private const string AUTH_COOKIE_KEY_IS_STAFF = "staff";


        public static HttpCookie CreateAuthCookie()
        {
            string sessionId = HttpContext.Current.Session.SessionID;
            string encryptedSessionId = EncDec.Encrypt(sessionId);
            HttpCookie authCookie = new HttpCookie(AUTH_COOKIE_NAME)
            {
                Secure = true,
                [AUTH_COOKIE_KEY_ID] = encryptedSessionId,
                Expires = DateTime.Now.AddMinutes(30)
            };

            return authCookie;
        }

        private static bool IsValidAuthCookie(HttpCookie authCookie, bool checkIfStaff = false)
        {
            string expectedId = EncDec.Encrypt(HttpContext.Current.Session.SessionID);
            if (!string.IsNullOrWhiteSpace(expectedId))
            {
                try
                {

                    bool isValid = true;
                    if (checkIfStaff)
                    {
                        string isStaff = authCookie[AUTH_COOKIE_KEY_IS_STAFF];
                        if (isStaff == "0")
                            isValid = false; // only makes invalid if we're trying to validate a staff member
                    }

                    string id = authCookie[AUTH_COOKIE_KEY_ID];
                    if (id == expectedId)
                    {
                        return isValid;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            return false;
        }

        public static bool HasValidAuthCookie(HttpRequest request)
        {
            HttpCookieCollection cookies = request.Cookies;
            HttpCookie authCookie = cookies.Get(AUTH_COOKIE_NAME);

            return IsValidAuthCookie(authCookie);
        }
    }
}