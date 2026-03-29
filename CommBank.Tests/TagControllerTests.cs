using Xunit;
using Microsoft.AspNetCore.Mvc;
using CommBank.Models;
using CommBank.Services;
using CommBank.Tests.Fake;

namespace CommBank.Controllers;

public class TagControllerTests
{
    private readonly FakeCollections collections;

    public TagControllerTests()
    {
        collections = new();
    }

    [Fact]
    public async Task GetAll()
    {
        var tags = collections.GetTags();
        ITagsService service = new FakeTagsService(tags, tags[0]);
        TagController controller = new(service);

        var result = await controller.Get();

        var returnedTags = Assert.IsAssignableFrom<IEnumerable<Tag>>(result);
        Assert.Equal(tags.Count, returnedTags.Count());
    }
}
