namespace Test1.entities;

public class TeamMember: Entitie
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public List<Task1> Tasks { get; set; }
}