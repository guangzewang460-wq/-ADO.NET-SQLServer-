using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Configuration;
using Microsoft.IdentityModel.Protocols;
using System.Threading.Channels;

namespace StudentsProject.Utils
{
    internal class DBHelper
    {
        private static string connectionStr = ConfigurationManager.ConnectionStrings["localString"].ConnectionString;
        
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionStr);
        }
    }
}
