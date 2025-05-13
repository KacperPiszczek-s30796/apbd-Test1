using Microsoft.AspNetCore.Mvc;
using Test1.services.abstractions;

namespace Test1.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class TaskController: ControllerBase
{
    private readonly ITaskService _taskService;

    private TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }
    [HttpGet]
    [Route("/Tasks/{id}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(_taskService.GetTeamMemberInfo(id));
    }
}