using CommBank.Models;
using CommBank.Services;

namespace CommBank.Tests.Fake;

public class FakeTagsService : ITagsService
{
    List<Tag> _tags;
    Tag _tag;

    public FakeTagsService(List<Tag> tags, Tag tag)
    {
        _tags = tags;
        _tag = tag;
    }

    public async Task<List<Tag>> GetAsync() =>
        await Task.FromResult(_tags);

    public async Task<Tag?> GetAsync(string id) =>
        await Task.FromResult(_tag);

    public Task CreateAsync(Tag newTag) =>
        Task.CompletedTask;

    public Task UpdateAsync(string id, Tag updatedTag) =>
        Task.CompletedTask;

    public Task RemoveAsync(string id) =>
        Task.CompletedTask;
}