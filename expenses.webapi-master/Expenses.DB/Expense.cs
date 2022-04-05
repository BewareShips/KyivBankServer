using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Expenses.DB
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }

        public string ToAccount { get; set; }
        public string DateCreated { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public Expense()
        {
            DateCreated = DateTime.Now.ToString("yyyy-mm-dd");
        }
    }
}
