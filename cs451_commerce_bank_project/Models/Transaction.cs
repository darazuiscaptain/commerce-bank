using System;

namespace cs451_commerce_bank_project.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        public int UserAccountId { get; set; }

        public User User { get; set; }

        public DateTime ProcessingDate { get; set; }

        public float Balance { get; set; }

        public String Type { get; set; }

        public float Amount { get; set; }

        public String Location { get; set; }

        public String Description { get; set; }
    }
}
