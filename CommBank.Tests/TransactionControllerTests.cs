using Xunit;
using Microsoft.AspNetCore.Mvc;
using CommBank.Models;
using CommBank.Services;
using CommBank.Tests.Fake;
using CommBank.Controllers;

using Transaction = CommBank.Models.Transaction; 

namespace CommBank.Tests;

public class TransactionControllerTests
{
    private readonly FakeCollections _collections;

    public TransactionControllerTests()
    {
        _collections = new FakeCollections();
    }

    [Fact]
    public async Task GetForUser_ReturnsOnlyTransactionsForThatUser()
    {
        var allTransactions = _collections.GetTransactions();
        var users = _collections.GetUsers();
        var targetUserId = users[0].Id!;

        var service = new FakeTransactionsService(allTransactions, allTransactions[0]);
        var controller = new TransactionController(service);

        var result = await controller.GetForUser(targetUserId);

        var returned = Assert.IsAssignableFrom<IEnumerable<Transaction>>(result);

        Assert.NotNull(returned);
        Assert.All(returned, t => Assert.Equal(targetUserId, t.UserId));
    }
}
