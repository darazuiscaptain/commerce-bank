using System;
using System.Collections.Generic;

namespace cs451_commerce_bank_project.Models
{
    public class User
    {
        public int Id { get; set; }

        public String Name { get; set; }

        public String EmailAddress { get; set; }

        public String Password { get; set; }

        public List<Transaction> Transactions { get; set; }

        public List<NotificationRule> NotificationRules { get; set; }
    }
}
