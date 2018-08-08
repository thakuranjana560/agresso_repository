using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using AgressoDirectory.Common.Model;

namespace AgressoDirectory.DataAccess
{
    public class EmployeeRepository
    {
        /// <summary>
        /// Insert querry for AddEmployee
        /// </summary>
        /// <param name="model"></param>

        //public EmployeeRepository(string connectionString)
        //{
        //    this.connectionString = connectionString;
        //}
        //public EmployeeRepository(string Connectionstring)
        //{
        //    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        //}
        public EmployeeRepository()
        {
            SqlConnection getcon = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString); 
        }
        public void CreateEmployee(EmployeeModel model)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.CommandText = @"Insert into Employee(FirstName,LastName,DateOfBirth,EmpDesignationCode,Gender,Address,EmpCountryCode,EmpStateCode,EmpCityCode,EmailID,MobileNumber,Skills,TotalExperience,ProjectName) 
            Values (@fname,@lname,@dob,@dsg,@gen,@add,@country,@state,@city,@email,@contact,@skills,@exp,@ProjectName)";
            cmd.Connection = con;
            cmd.Parameters.Add("@fname", SqlDbType.NVarChar).Value = model.FirstName;
            cmd.Parameters.Add("@lname", SqlDbType.NVarChar).Value = model.LastName;
            cmd.Parameters.Add("@dob", SqlDbType.Date).Value = model.DateOfBirth.Date;
            cmd.Parameters.Add("@dsg", SqlDbType.Char).Value = model.EmpDesignationCode.ToString();
            cmd.Parameters.Add("@gen", SqlDbType.VarChar).Value = model.Gender;
            cmd.Parameters.Add("@add", SqlDbType.NVarChar).Value = model.Address;
            cmd.Parameters.Add("@country", SqlDbType.Int).Value = model.EmpCountryCode;
            cmd.Parameters.Add("@state", SqlDbType.Int).Value = model.EmpStatecode;
            cmd.Parameters.Add("@city", SqlDbType.Int).Value = model.EmpCityCode;
            cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = model.EmailID;
            cmd.Parameters.Add("@contact", SqlDbType.BigInt).Value = model.MobileNumber;
            cmd.Parameters.Add("@skills", SqlDbType.NVarChar).Value = model.Skills;
            cmd.Parameters.Add("@exp", SqlDbType.Int).Value = model.TotalExperience;
            cmd.Parameters.Add("@ProjectName", SqlDbType.VarChar).Value = model.ProjectName;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }
        /// <summary>
        /// select querry to get employees in DataSet as return type
        /// </summary>
        /// <returns></returns>
        public DataSet GetEmployees()
        {
            SqlDataAdapter adp = new SqlDataAdapter("Select * from Employee where IsActive=1", ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            return ds;
        }

        public DataSet GetProject()
        {
            SqlDataAdapter adp = new SqlDataAdapter("Select * from Project", ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            return ds;
        }

        /// <summary>
        /// Update querry to update data in gridview
        /// </summary>
        /// <param name="objModel"></param>
        public void UpdateEmployee(EmployeeModel objModel)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.CommandText = ("Update Employee set FirstName=@FirstName,LastName=@LastName,DateOfBirth=@DateOfBirth,EmpDesignationCode=@EmpDesignationCode,Gender=@Gender,Address=@Address,EmpCountryCode=@EmpCountryCode,EmpStateCode=@EmpStateCode,EmpCityCode=@EmpCityCode,IsActive=@IsActive,EmailId=@EmailID,MobileNumber=@MobileNumber,Skills=@Skills,TotalExperience=@TotalExperience where ID=@ID");
            cmd.Connection = con;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = objModel.id;
            cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = objModel.FirstName;
            cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = objModel.LastName;
            cmd.Parameters.Add("@DateOfBirth", SqlDbType.Date).Value = (objModel.DateOfBirth);
            cmd.Parameters.Add("@EmpDesignationCode", SqlDbType.Char).Value = objModel.EmpDesignationCode;
            cmd.Parameters.Add("@Gender", SqlDbType.VarChar).Value = objModel.Gender;
            cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = objModel.Address;
            cmd.Parameters.Add("@EmpCountryCode", SqlDbType.Int).Value = objModel.EmpCountryCode;
            cmd.Parameters.Add("@EmpStateCode", SqlDbType.Int).Value = objModel.EmpStatecode;
            cmd.Parameters.Add("@EmpCityCode", SqlDbType.Int).Value = objModel.EmpCityCode;
            cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Convert.ToInt32(objModel.IsActive);
            cmd.Parameters.Add("@EmailID", SqlDbType.NVarChar).Value = objModel.EmailID;
            cmd.Parameters.Add("@MobileNumber", SqlDbType.BigInt).Value = objModel.MobileNumber;
            cmd.Parameters.Add("@skills", SqlDbType.NVarChar).Value = objModel.Skills;
            cmd.Parameters.Add("@TotalExperience", SqlDbType.Int).Value = objModel.TotalExperience;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }
        public int LoginDB(EmployeeModel objModel)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.CommandText = ("SELECT COUNT(*) FROM Login WHERE Username=@Username AND Password=@Password");
            cmd.Connection = con;
            cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = objModel.Username;
            cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = objModel.Password;
            return Convert.ToInt32(cmd.ExecuteScalar());
        }
        public LoginModel LoginAccess(LoginModel objmodel)
        {  
            
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT login.Id, emp.EmpDesignationCode FROM Login login INNER JOIN Employee Emp ON login.Id = emp.UserId WHERE login.UserName=@username AND login.Password=@password", con);
            cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = objmodel.Username;
            cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = objmodel.Password;
            con.Open();
            SqlDataReader objDataReader = cmd.ExecuteReader();
            string uid = string.Empty;
            objmodel.objEmployeeModel = new EmployeeModel();
            if (objDataReader.HasRows)
            {
                while (objDataReader.Read())
                {
                    objmodel.UserId = Convert.ToString(objDataReader["Id"]);
                    objmodel.objEmployeeModel.EmpDesignationCode = Convert.ToString(objDataReader["EmpDesignationCode"]).Trim();
                }
            }
            return objmodel;
        }
    }
}
