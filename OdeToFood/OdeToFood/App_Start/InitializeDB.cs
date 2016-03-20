using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.WebData;

namespace OdeToFood.App_Start
{
    public static class InitializeDB
    {

        public static void InitialiseDatabaseConnection()
        {

            WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
        }
    }
}