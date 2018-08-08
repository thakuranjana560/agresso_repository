using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgressoDirectory.Common.ViewModel
{
    public class LoginViewModel
    {
        public string Username { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public EmployeeViewModel objEmployeeViewModel { get; set; }
    }
}
