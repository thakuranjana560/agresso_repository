using System;

namespace AgressoDirectory.Common.Model
{
  public class EmployeeModel
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string EmpDesignationCode { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public int EmpCountryCode { get; set; }
        public int EmpStatecode { get; set; }
        public int EmpCityCode { get; set; }
        public Boolean IsActive { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string EmailID { get; set; }
        public Int64 MobileNumber { get; set; }
        public string Skills { get; set; }
        public int TotalExperience { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ProjectName { get; set; }
        
    }
}
