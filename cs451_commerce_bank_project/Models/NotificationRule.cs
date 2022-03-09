using System;

namespace cs451_commerce_bank_project.Models
{
  public class NotificationRule
  {
    public int Id { get; set; }
    
    public String Location { get; set; }

    public String TimeFrame { get; set; }

    public String Category { get; set; }
  }
}
