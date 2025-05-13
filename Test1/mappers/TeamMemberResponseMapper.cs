using Test1.contracts.responses;
using Test1.entities;

namespace Test1.mappers;

public class TeamMemberResponseMapper
{
    public TeamMemberResponse map(Task<TeamMember> teamMember,Task<List<Task1>> tasks)
    {
        TeamMemberResponse teamMemberResponse = new TeamMemberResponse();
        teamMemberResponse.FirstName = teamMember.Result.FirstName;
        teamMemberResponse.LastName = teamMember.Result.LastName;
        teamMemberResponse.Email = teamMember.Result.Email;
        teamMemberResponse.Tasks = tasks.Result;
        return teamMemberResponse;
    }
}