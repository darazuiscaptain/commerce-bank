using System;

namespace cs451_commerce_bank_project.Models
{
  public class NotificationRule
  {
    public int Id { get; set; }

    public int UserId { get; set; }

    public User User { get; set; }

    public String Name { get; set; }

    public String Type { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public String Location { get; set; }

    public double AmountGreaterThan { get; set; }

    public double AmountLessThan { get; set; }

    public double AmountEquals { get; set; }

    public int CountTriggered { get; set; }
  }
}
