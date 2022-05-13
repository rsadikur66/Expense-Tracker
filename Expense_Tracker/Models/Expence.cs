using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Expense_Tracker.Models
{
    public class Expence
    {
        [Key]
        public int Id { get; set; }

        //[DataType(DataType.Date)]
        //[ValidExpenseDate(ErrorMessage ="invalid date")]
        //[ValidExpenseDate(ErrorMessage = "No future date allowed")]
        public DateTime ExpenseDate { get; set; }

        [RegularExpression(@"^\d+(?:\.\d+)?$", ErrorMessage = "Amount must be integer or decimal number.")]
        public string Amount { get; set; }

        public virtual int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual ExpenceCategory ExpenceCategories { get; set; }

        [NotMapped]
        public string CategoryName { get; set; }
    }

}
