using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Expense_Tracker.Models
{
    public class ExpensesViewModel
    {
        public int? Id { get; set; }

        [DataType(DataType.Date)]
        //[ValidExpenseDate(ErrorMessage ="invalid date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode =true)]
      
        [DateLessThanOrEqualToToday]
        public DateTime? ExpenseDate { get; set; }
        [RegularExpression(@"^\d+(?:\.\d+)?$", ErrorMessage = "Amount must be integer or decimal number.")]
        public string Amount { get; set; }
        public virtual int CategoryId { get; set; }    
        public string CategoryName { get; set; }
    }
}
