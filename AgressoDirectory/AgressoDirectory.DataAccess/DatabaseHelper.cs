using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace AgressoDirectory.DataAccess
{
    class DatabaseHelper
    {


        public static string ConnectionString = (ConfigurationManager.ConnectionStrings["con"].ConnectionString);

    }
}
