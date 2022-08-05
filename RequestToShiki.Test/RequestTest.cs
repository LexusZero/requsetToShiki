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

    [Fact]
    public async Task AnimesByNameExist()
    {
        // arrange
        var name = "Kill la Kill";
        // act
        var result = await this.request.AnimesByName(name);
        // assert
        Assert.Equal("Kill la Kill", result.Name);
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
