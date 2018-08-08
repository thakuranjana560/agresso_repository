using System;

namespace AgressoDirectory.Common.ViewModel
{
    public class EmployeeViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Id { set; get; }
        public DateTime DateOfBirth { get; set; }
        public string DesignationCode { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public int CountryCode { get; set; }
        public int StateCode { get; set; }
        public int CityCode { get; set; }
        public string EmailID { get; set; }
        public Int64 ContactNumber { get; set; }
        public string Skills { get; set; }
        public int Experience { get; set; }
        public Boolean IsActive { get; set; }
        public string Username { get; set; }
        public string password { get; set; }
        public string ProjectName { get; set; }
    }
}
