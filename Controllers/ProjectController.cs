using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProjectController : ControllerBase
{
    private readonly IProjectRepository _projectRepository;

    public ProjectController(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProjects()
    {
        var projects = await _projectRepository.GetAllAsync();
        return Ok(projects);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProjectById(int id)
    {
        var project = await _projectRepository.GetByIdAsync(id);
        if (project == null)
        {
            return NotFound();
        }
        return Ok(project);
    }

    [HttpPost]
    public async Task<IActionResult> AddProject([FromBody] Project project)
    {
        var newProject = await _projectRepository.AddAsync(project);
        return CreatedAtAction(nameof(GetProjectById), new { id = newProject.Id }, newProject);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProject(int id, [FromBody] Project project)
    {
        if (id != project.Id)
        {
            return BadRequest();
        }

        var updatedProject = await _projectRepository.UpdateAsync(project);
        return Ok(updatedProject);
    }

    [HttpGet("{id}/allocated-members")]
    public async Task<IActionResult> GetProjectAllocatedMembers(int id)
    {
        var projectWithMembers = await _projectRepository.ProjectAllocatedMemebers(id);
        if (projectWithMembers == null)
        {
            return NotFound();
        }
        return Ok(projectWithMembers);
    }
}