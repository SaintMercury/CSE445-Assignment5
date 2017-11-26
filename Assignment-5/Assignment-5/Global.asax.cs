﻿using System;

namespace Assignment_5
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
        }

        protected void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started
            // See if we still got a session
            
        }
        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.
        }
    }
}