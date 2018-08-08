using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgressoDirectory.Common.Model
{
    public class LoginModel
    {
        public string Username { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public EmployeeModel objEmployeeModel { get; set; }
    }
}
