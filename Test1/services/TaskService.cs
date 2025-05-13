using Test1.contracts.responses;
using Test1.entities;
using Test1.mappers;
using Test1.repositories.abstractions;
using Test1.services.abstractions;

namespace Test1.services;

public class TaskService: ITaskService
{
    private ItaskRepository _taskRepository;
    private ITeamMemberRepository _teamMemberRepository;
    public TeamMemberResponseMapper _teamMemberResponseMapper;

    public TaskService(ItaskRepository taskRepository, ITeamMemberRepository teamMemberRepository)
    {
        this._taskRepository = taskRepository;
        this._teamMemberRepository = teamMemberRepository;
        this._teamMemberResponseMapper = new TeamMemberResponseMapper();
    }

    public async Task<TeamMemberResponse> GetTeamMemberInfo(int id)
    {
        var teamMember = _teamMemberRepository.findTeamMember(id);
        var tasks = _taskRepository.findTasks(id);
        TeamMemberResponse teamMemberResponse = _teamMemberResponseMapper.map(teamMember, tasks);
        return teamMemberResponse;
    }
}