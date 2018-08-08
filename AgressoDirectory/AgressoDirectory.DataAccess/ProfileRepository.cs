using AgressoDirectory.Common.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgressoDirectory.DataAccess
{
    public class ProfileRepository
    {
        public Profile GetProfileById(string profileId)
        {
            Profile result = new Profile();

            //Create the SQL Query for returning an article category based on its primary key
            string sqlQuery = String.Format(@"SELECT employee.FirstName,employee.LastName,employee.EmailId, Designation.DesignationCode as Designation
                                            FROM((employee
                                            INNER JOIN Designation ON Designation.DesignationCode = employee.EmpDesignationCode))
                                            where employee.UserId = '"+ profileId+"'");

            //Create and open a connection to SQL Server 
            SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(sqlQuery, connection);

            SqlDataReader dataReader = command.ExecuteReader();

            //load into the result object the returned row from the database
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    result.FirstName = dataReader["FirstName"].ToString();
                    result.LastName = dataReader["LastName"].ToString();
                    result.EmailId = dataReader["EmailId"].ToString();
                    result.Designation = dataReader["Designation"].ToString();

                }
            }

            return result;
        }

        public void UpdateUserProfile(Profile profileId)
        {
            //Create the SQL Query for returning an article category based on its primary key
            string sqlQuery = String.Format(@"Update employee SET FirstName = '{0}',LastName = '{1}',EmailId = '{2}' Where userID = '{3}' "
              , profileId.FirstName, profileId.LastName,profileId.EmailId,profileId.id);

            //Create and open a connection to SQL Server 
            SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(sqlQuery, connection);

            SqlDataReader dataReader = command.ExecuteReader();
        }
        public DataSet GetDesignationType()
        {
            SqlConnection con = new SqlConnection(DatabaseHelper.ConnectionString);
            con.Open();
            SqlDataAdapter Adp = new SqlDataAdapter((@"SELECT * from Designation"), con);
            DataSet ds = new DataSet();
            Adp.Fill(ds);
            return ds;
        }
    }
}
