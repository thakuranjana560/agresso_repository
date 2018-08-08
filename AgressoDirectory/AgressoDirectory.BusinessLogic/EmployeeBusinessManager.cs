using System.Data;
using AgressoDirectory.Common.Model;
using AgressoDirectory.Common.ViewModel;
using AgressoDirectory.DataAccess;

namespace AgressoDirectory.BusinessLogic
{
    public class EmployeeBusinessManager
    {
        /// <summary>
        /// Access of AddEmployeeView model properties in this method and passing it to AddEmployee Model properties
        /// </summary>
        /// <param name="EmpViewModel"></param>
        public void AddNewEmployee(EmployeeViewModel EmpViewModel)
        {
            EmployeeModel objEmpModel = new EmployeeModel
            {
                FirstName = EmpViewModel.FirstName,
                LastName = EmpViewModel.LastName,
                DateOfBirth = EmpViewModel.DateOfBirth,
                EmpDesignationCode = EmpViewModel.DesignationCode,
                Gender = EmpViewModel.Gender,
                Address = EmpViewModel.Address,
                EmpCountryCode = EmpViewModel.CountryCode,
                EmpStatecode = EmpViewModel.StateCode,
                EmpCityCode = EmpViewModel.CityCode,
                EmailID = EmpViewModel.EmailID,
                MobileNumber = EmpViewModel.ContactNumber,
                Skills = EmpViewModel.Skills,
                TotalExperience = EmpViewModel.Experience,
                ProjectName = EmpViewModel.ProjectName
            };
            EmployeeRepository dal = new EmployeeRepository();
            dal.CreateEmployee(objEmpModel);
        }
        /// <summary>
        /// Accessing DataSet of EmployeeDB.cs select querry in GetAddedEmployees method with return type as DataSet
        /// </summary>
        /// <returns></returns>
        public DataSet GetAddedEmployees()
        {
            DataSet ds = new DataSet();
            EmployeeRepository objEmpDB = new EmployeeRepository();
            ds = objEmpDB.GetEmployees();
            return ds;
        }


        public DataSet GetEmployeeProject()
        {
            DataSet ds = new DataSet();
            EmployeeRepository objEmpDB = new EmployeeRepository();
            ds = objEmpDB.GetProject();
            return ds;
            
        }

        /// <summary>
        /// Accessing AddEmployeeModel properties in UpdateEmployee method to pass the values to AddEmployeeViewModel
        /// </summary>
        /// <param name="UpdViewModel"></param>
        public void UpdateEmployee(EmployeeViewModel UpdViewModel)
        {
            EmployeeModel objUpdModel = new EmployeeModel()
            {
                id = UpdViewModel.Id,
                FirstName = UpdViewModel.FirstName,
                LastName = UpdViewModel.LastName,
                DateOfBirth = UpdViewModel.DateOfBirth,
                EmpDesignationCode = UpdViewModel.DesignationCode,
                Gender = UpdViewModel.Gender,
                Address = UpdViewModel.Address,
                EmpCountryCode = UpdViewModel.CountryCode,
                EmpStatecode = UpdViewModel.StateCode,
                EmpCityCode = UpdViewModel.CityCode,
                EmailID = UpdViewModel.EmailID,
                MobileNumber = UpdViewModel.ContactNumber,
                Skills = UpdViewModel.Skills,
                TotalExperience = UpdViewModel.Experience,
                IsActive = UpdViewModel.IsActive
            };
            EmployeeRepository objDal = new EmployeeRepository();
            objDal.UpdateEmployee(objUpdModel);
        }
        public LoginViewModel UserLogin(LoginViewModel objLoginViewModel)
        {
            LoginModel objLoginModel = new LoginModel()
            {
                Username = objLoginViewModel.Username,
                Password = objLoginViewModel.Password
            };
            EmployeeRepository objDB = new EmployeeRepository();
            objLoginModel = objDB.LoginAccess(objLoginModel);

            objLoginViewModel.UserId = objLoginModel.UserId;
            objLoginViewModel.objEmployeeViewModel = new EmployeeViewModel();
            objLoginViewModel.objEmployeeViewModel.DesignationCode = objLoginModel.objEmployeeModel.EmpDesignationCode;
            return objLoginViewModel;
        }
        //public int Result()
        //{
        //    EmployeeRepository objDB = new EmployeeRepository();
        //    int count = objDB.LoginDB();
        //    return count;
        //}
    }
}
