using Test1.entities;

namespace Test1.contracts.responses;

public class TeamMemberResponse
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public List<Task1> Tasks { get; set; }
}