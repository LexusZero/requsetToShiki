namespace RequestToShiki.Test;

public class RequestTest
{
    private readonly IRequest request;
    public RequestTest()
    {
        this.request = new GistCsvRequest();

    }

    [Fact]
    public async Task StudioByNameExists()
    {
        // arrange
        var name = "Trigger";
        // act
        var result = await this.request.StudioByName(name);
        // assert
        Assert.Equal(name, result.Studio.Name);
        Assert.True(result.TopAnimes.Count > 2); // there are at least 2 popular anime from Trigger
    }

    [Fact]
    public async Task StudioByNameDoesntExists()
    {
        // arrange
        var name = "ASDSDSDF";
        // act
        var result = await this.request.StudioByName(name);
        // assert
        Assert.Null(result);
    }

    [Theory]
    [InlineData("Kill la Kill")]
    [InlineData("sword")]
    public async Task AnimesByNameExist(string name)
    {
        // act
        var result = await this.request.AnimesByName(name);
        // assert
        Assert.NotNull(result);
    }
    [Fact]
    public async Task AnimesByNameNotExist()
    {
        // arrange
        var name = "Asdasd";
        // act
        var result = await this.request.AnimesByName(name);
        // assert
        Assert.Null(result);
    }

}
