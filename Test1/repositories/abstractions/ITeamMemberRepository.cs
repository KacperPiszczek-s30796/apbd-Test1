using Test1.entities;

namespace Test1.repositories.abstractions;

public interface ITeamMemberRepository
{
    public Task<TeamMember> findTeamMember(int id, CancellationToken token = default);
}