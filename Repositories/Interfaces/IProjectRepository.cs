public interface IProjectRepository
{
    public Task<List<Project>> GetAllAsync();
    public Task<Project?> GetByIdAsync(int id);
    public Task<Project> AddAsync(Project project);
    public Task<Project?> UpdateAsync(Project project);
    public Task<Project?> ProjectAllocatedMemebers(int id);
    
}