using AgressoDirectory.Common.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgressoDirectory.DataAccess;
using System.Data;

namespace AgressoDirectory.BusinessLogic
{
    public class ExpenseManager
    {
        public void SaveExpenses(Expense model)
        {
           ExpenseRepository dataAccess = new ExpenseRepository();
            dataAccess.SaveExpensess(model);
        }

        public DataTable GetExpenses(string pos,string id)
        {
            ExpenseRepository dataAccess = new ExpenseRepository();
            DataTable datatable = dataAccess.GetExpenses(pos,id);
            return datatable;
        }

        public Expense GetExpenseById(int expenseId)
        {
            ExpenseRepository dataAccess = new ExpenseRepository();
            Expense datatable = dataAccess.GetExpenseById(expenseId);
            return datatable;
        }      

        public DataSet GetExpenseType()
        {
            ExpenseRepository dataAccess = new ExpenseRepository();
            DataSet dataSet = dataAccess.GetExpenseType();
            return dataSet;
        }

        public DataSet GetProject()
        {
            ExpenseRepository dataAccess = new ExpenseRepository();
            DataSet dataSet = dataAccess.GetProject();
            return dataSet;
        }
        public DataSet GetApprover()
        {
            ExpenseRepository dataAccess = new ExpenseRepository();
            DataSet dataSet = dataAccess.GetApprover();
            return dataSet;
        }

        public DataSet GetStatus()
        {
            ExpenseRepository dataAccess = new ExpenseRepository();
            DataSet dataSet = dataAccess.GetStatus();
            return dataSet;
        }

        public void DeletetExpense(string Id)
        {
            ExpenseRepository dataAccess = new ExpenseRepository();
            dataAccess.DeletetExpense(Id);
        }

        public void UpdatetExpense(string Id, string ProjectCode, string Amount, string StatusId, string ApprovedDate, string ExpenseType, string ApproverId, string ApproverComment)
        {
            ExpenseRepository dataAccess = new ExpenseRepository();
            dataAccess.UpdatetExpense(Id, ProjectCode, Amount, StatusId, ApprovedDate, ExpenseType, ApproverId, ApproverComment);
        }

        

    }
}
