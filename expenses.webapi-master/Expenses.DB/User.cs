using System;
using System.ComponentModel.DataAnnotations;

namespace Expenses.DB
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string AccountNumberGenerated { get; set; }
        public double Balance { get; set; }
        public string ExternalId { get; set; }
        public string ExternalType { get; set; }

        Random rand = new Random();
        public User()
        {
            AccountNumberGenerated = Convert.ToString((long)Math.Floor(rand.NextDouble() * 9_000_000_000L + 1_000_000_000L));
        }
    }
}
