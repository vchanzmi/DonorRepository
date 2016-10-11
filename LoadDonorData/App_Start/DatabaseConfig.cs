using LoadDonorData.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LoadDonorData.App_Start
{
    public static class DatabaseConfig
    {
        public static void Config()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());
        }
    }
}