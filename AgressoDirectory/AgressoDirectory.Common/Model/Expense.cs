using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgressoDirectory.Common.Model
{
   public class Expense
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public int ExpenseTypeId { get; set; }
        public Decimal Amount { get; set; }
        public DateTime ApprovedDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public int StatusId { get; set; }
        public string ApproverId { get; set; }

        public int Project { get; set; }
        public int ProjectCode { get; set; }

        public string ExpenseType { get; set; }

        public string Status { get; set; }

        public string Approver { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
        public string ApproverComment { get; set; }

        public string Attachment { get; set; }
    }
}
