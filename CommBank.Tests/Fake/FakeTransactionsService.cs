using CommBank.Models;
using CommBank.Services;

namespace CommBank.Tests.Fake;

public class FakeTransactionsService : ITransactionsService
{
    private readonly List<Transaction> _transactions;
    private readonly Transaction _transaction;

    public FakeTransactionsService(List<Transaction> transactions, Transaction transaction)
    {
        _transactions = transactions;
        _transaction = transaction;
    }

    public async Task<List<Transaction>?> GetForUserAsync(string id) =>
        await Task.FromResult(_transactions.Where(t => t.UserId == id).ToList());

    public async Task<List<Transaction>> GetAsync() =>
        await Task.FromResult(_transactions);

    public async Task<Transaction?> GetAsync(string id) =>
        await Task.FromResult(_transaction);

    public async Task CreateAsync(Transaction newTransaction) =>
        await Task.CompletedTask;

    public async Task UpdateAsync(string id, Transaction updatedTransaction) =>
        await Task.CompletedTask;

    public async Task RemoveAsync(string id) =>
        await Task.CompletedTask;
}