using AgressoDirectory.Common.Model;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;


namespace AgressoDirectory.DataAccess
{
    public class ExpenseRepository
    {
        public void SaveExpensess(Expense model)
        {
            string createQuery = String.Format("Insert into Expenses (ExpenseTypeId,Amount,ApproverId,ProjectCode,UserID,ApproverComment,AttachmentName) Values('{0}', '{1}', '{2}', {3} ,'{4}','{5}','{6}');",
                  model.ExpenseTypeId, model.Amount, model.Approver, model.ProjectCode, model.ApproverId, model.ApproverComment, model.Attachment);

            //Create the SQL Query for updating an article
            //string updateQuery = String.Format("Update Expenses SET ExpenseTypeId='{0}', Amount = '{1}', ApprovedDate ='{2}', ApproverId = {3},StatusId={4},ProjectCode={5},ApproverComment={6} Where ID = {7};"
            //    , model.ExpenseTypeId, model.Amount, model.ApprovedDate.ToString("yyyy-MM-dd"), model.ApproverId, model.StatusId, model.ProjectCode, model.ApproverComment,model.Id);
            string updateQuery = String.Format("Update Expenses SET ExpenseTypeId='{0}' Where ID = {1};"
              , model.ExpenseTypeId, model.Id);

            //Create and open a connection to SQL Server 
            SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString);


            connection.Open();

            //Create a Command object
            SqlCommand command = null;

            if (model.Id > 0)
                command = new SqlCommand(updateQuery, connection);
            else
                command = new SqlCommand(createQuery, connection);

            try
            {
                //Execute the command to SQL Server and return the newly created ID
                var commandResult = command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                //there was a problem executing the script
            }

            //Close and dispose
            connection.Close();
            connection.Dispose();

        }
        public DataTable GetExpenses(string pos, string id)
        {
            if (pos.Equals("l9", StringComparison.InvariantCultureIgnoreCase))
            {
                SqlDataAdapter adp = new SqlDataAdapter(@"SELECT Exps.Id, Exps.Amount, Exps.ApprovedDate, Exps.ApproverComment, ExpTyp.ExpenseType,  Stat.[Status], Emp.FirstName + ' '+ Emp.LastName AS Name, Proj.ProjectType
            FROM Expenses Exps
            LEFT JOIN
            Employee Emp ON Exps.ApproverId = Emp.UserID
            LEFT JOIN
            [Status] stat ON Exps.StatusId = stat.StatusId
            LEFT JOIN
            [ExpenseType] ExpTyp ON Exps.ExpenseTypeId = ExpTyp.ExpenseID
            LEFT JOIN
            [Project] Proj ON Exps.ProjectCode = Proj.ProjectId
            WHERE Exps.ApproverId = '" + id + "'", DatabaseHelper.ConnectionString);
                DataTable dataSet = new DataTable();
                adp.Fill(dataSet);
                return dataSet; ;

            }
            else
            {
                SqlDataAdapter adp = new SqlDataAdapter(@"SELECT Exps.Id, Exps.Amount, Exps.ApprovedDate, Exps.ApproverComment, ExpTyp.ExpenseType,  Stat.[Status], Emp.FirstName + ' '+ Emp.LastName AS Name, Proj.ProjectType
            FROM Expenses Exps
            LEFT JOIN
            Employee Emp ON Exps.ApproverId = Emp.UserID
            LEFT JOIN
            [Status] stat ON Exps.StatusId = stat.StatusId
            LEFT JOIN
            [ExpenseType] ExpTyp ON Exps.ExpenseTypeId = ExpTyp.ExpenseID
            LEFT JOIN
            [Project] Proj ON Exps.ProjectCode = Proj.ProjectId
            WHERE Exps.UserID ='" + id + "'", DatabaseHelper.ConnectionString);
                DataTable dataSet = new DataTable();
                adp.Fill(dataSet);
                return dataSet;
            }
        }


        public Expense GetExpenseById(int expenseId)
        {

            Expense result = new Expense();

            //Create the SQL Query for returning an article category based on its primary key
            string sqlQuery = String.Format(@"SELECT ExpenseTypeId,Amount, ApprovedDate , ApproverId,StatusId,ProjectCode,ApproverComment
            FROM expenses where Expenses.Id ={0}", expenseId);

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
                    result.Amount = Convert.ToInt32(dataReader["Amount"]);
                    result.ApprovedDate = Convert.ToDateTime(dataReader["ApprovedDate"]);
                    result.ExpenseTypeId = Convert.ToInt32(dataReader["ExpenseTypeId"]);
                    result.ApproverComment = dataReader["ApproverComment"].ToString();
                    result.ApproverId = Convert.ToString(dataReader["ApproverId"]);
                    result.StatusId = Convert.ToInt32(dataReader["StatusId"]);
                    result.ProjectCode = Convert.ToInt32(dataReader["ProjectCode"]);
                }
            }

            return result;
        }

        public DataSet GetExpenseType()
        {
            SqlConnection con = new SqlConnection(DatabaseHelper.ConnectionString);
            con.Open();
            SqlDataAdapter Adp = new SqlDataAdapter((@"SELECT * from ExpenseType"), con);
            DataSet ds = new DataSet();
            Adp.Fill(ds);
            return ds;
        }
        public DataSet GetProject()
        {
            SqlConnection con = new SqlConnection(DatabaseHelper.ConnectionString);
            con.Open();
            SqlDataAdapter Adp = new SqlDataAdapter((@"SELECT * from Project"), con);
            DataSet ds = new DataSet();
            Adp.Fill(ds);
            return ds;
        }
        public DataSet GetApprover()
        {
            SqlConnection con = new SqlConnection(DatabaseHelper.ConnectionString);
            con.Open();
            SqlDataAdapter Adp = new SqlDataAdapter((@"SELECT FirstName+LastName as name,UserID from Employee where EmpDesignationCode='L9'"), con);
            DataSet ds = new DataSet();
            Adp.Fill(ds);
            return ds;
        }

        public DataSet GetStatus()
        {
            SqlConnection con = new SqlConnection(DatabaseHelper.ConnectionString);
            con.Open();
            SqlDataAdapter Adp = new SqlDataAdapter((@"SELECT * from Status"), con);
            DataSet ds = new DataSet();
            Adp.Fill(ds);
            return ds;
        }

        public void DeletetExpense(string Id)
        {
            SqlConnection conn = new SqlConnection(DatabaseHelper.ConnectionString);
            conn.Open();

            string cmdstr = "delete from Expenses where Id=@projectCode";

            SqlCommand cmd = new SqlCommand(cmdstr, conn);

            cmd.Parameters.AddWithValue("@projectCode", Id);

            cmd.ExecuteNonQuery();

            conn.Close();



        }

        public void UpdatetExpense(string Id, string ProjectCode, string Amount, string StatusId, string ApprovedDate, string ExpenseType, string ApproverId, string ApproverComment)
        {

            SqlConnection conn = new SqlConnection(DatabaseHelper.ConnectionString);

            conn.Open();

            string cmdstr = "update Expenses set Amount=@Amount,StatusId=@StatusId,ApprovedDate=@ApprovedDate,ApproverComment=@ApproverComment where Id=@Id";

            SqlCommand cmd = new SqlCommand(cmdstr, conn);

            //   cmd.Parameters.AddWithValue("@ProjectCode", ProjectCode);

            cmd.Parameters.AddWithValue("@Amount", Convert.ToDecimal(Amount));

            cmd.Parameters.AddWithValue("@StatusId", Convert.ToInt32(StatusId));

            cmd.Parameters.AddWithValue("@ApprovedDate", ApprovedDate);

            // cmd.Parameters.AddWithValue("@ExpenseType", Convert.ToInt32(ExpenseType));

            //   cmd.Parameters.AddWithValue("@ApproverId", Convert.ToString(ApproverId));

            cmd.Parameters.AddWithValue("@ApproverComment", ApproverComment);

            cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(Id));

            cmd.ExecuteNonQuery();

            conn.Close();
        }
    }
}
