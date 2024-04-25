namespace UserManager.BusinessLogic.Entities;

public class EmployeeProject
{
    public int Id { get; set; }

    public int ProjectId { get; set; }
    public Project Project { get; set; }

    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
    
    public DateTime StartsOn { get; set; }

    public DateTime? EndsOn { get; set; }
}
