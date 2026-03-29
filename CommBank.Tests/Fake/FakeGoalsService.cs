using Microsoft.Extensions.Options;
using CommBank_Server.Models;
using CommBank_Server.Services;

namespace CommBank.Tests.Fake;

public class FakeGoalsService : IGoalsService
{
    List<Goal> _goals;
    Goal _goal;

    public FakeGoalsService(List<Goal> goals, Goal goal)
    {
        _goals = goals;
        _goal = goal;
    }

    public async Task<List<Goal>> GetAsync() =>
        await Task.FromResult(_goals);

    public async Task<List<Goal>?> GetForUserAsync(string userId) =>
        await Task.FromResult(_goals.Where(g => g.UserId == userId).ToList());

    public async Task<Goal?> GetAsync(string id) =>
        await Task.FromResult(_goal);

    public Task CreateAsync(Goal newGoal) =>
        Task.CompletedTask;
    public Task UpdateAsync(string id, Goal updateGoal) =>
        Task.CompletedTask;

    public Task RemoveAsync(string id) =>
        Task.CompletedTask;
}