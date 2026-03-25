using CommBank_Server.Models;

namespace CommBank_Server.Services;

public interface IGoalsService
{
    Task<List<Goal>> GetAsync();
    Task<List<Goal>?> GetForUserAsync(string id);
    Task<Goal?> GetAsync(string id);
    Task CreateAsync(Goal newGoal);
    Task UpdateAsync(string id, Goal updatedGoal);
    Task RemoveAsync(string id);
}
