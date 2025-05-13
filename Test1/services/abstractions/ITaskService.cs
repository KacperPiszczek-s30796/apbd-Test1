using Test1.contracts.responses;
using Test1.repositories.abstractions;

namespace Test1.services.abstractions;

public interface ITaskService
{
    public Task<TeamMemberResponse> GetTeamMemberInfo(int id);
}