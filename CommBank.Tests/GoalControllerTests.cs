using Xunit;
using Microsoft.AspNetCore.Mvc;
using CommBank_Server.Controllers;
using CommBank_Server.Services;
using CommBank_Server.Models;
using CommBank.Tests.Fake;

namespace CommBank.Tests;

public class GoalControllerTests
{
    private readonly FakeCollections collections;

    public GoalControllerTests()
    {
        collections = new();
    }

    [Fact]
    public async Task GetforUser_ReturnCorrectGoals_ForValidUserId()
    {
        var allGoals = collections.GetGoals();
        var targetUserId = allGoals[0].UserId!;
        var expectedGoals = allGoals.Where(g => g.UserId == targetUserId).ToList();

        IGoalsService goalsService = new FakeGoalsService(allGoals, allGoals[0]);
        IUsersService usersService = new FakeUsersService(collections.GetUsers(), null!);
        GoalController controller = new(goalsService, usersService);

        var result = await controller.GetForUser(targetUserId);

        var returnedGoals = Assert.IsAssignableFrom<IEnumerable<Goal>>(result);

        Assert.NotNull(returnedGoals);
        Assert.Equal(expectedGoals.Count, returnedGoals.Count());
        Assert.All(returnedGoals, goal => Assert.Equal(targetUserId, goal.UserId));
    }
}
