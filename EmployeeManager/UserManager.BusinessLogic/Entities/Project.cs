namespace UserManager.BusinessLogic.Entities;

public class Project
{
    public int Id { get; set; }

    public string Name { get; set; }

    public DateTime StartsOn { get; set; }

    public DateTime EndsOn { get; set; }

    public ICollection<EmployeeProject> EmployeeProjects { get; set; }
}
