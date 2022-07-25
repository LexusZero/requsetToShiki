namespace RequestToShiki.Test;

public class RequestTest
{
    [Fact]
    public async Task StudioByNameExists()
    {
        // arrange
        var name = "Trigger";
        var request = new Request();
        // act
        var result = await request.StudioByName(name);
        // assert
        Assert.Equal(name, result.Studio.Name);
    }

    [Fact]
    public async Task StudioByNameDoesntExists()
    {
        // arrange
        var name = "ASDSDSDF";
        var request = new Request();
        // act
        var result = await request.StudioByName(name);
        // assert
        Assert.Null(result);
    }

    [Fact]
    public async Task AnimesByNameExist()
    {
        // arrange
        var name = "Kill la Kill And Something";
        var request = new Request();
        // act
        var result = await request.AnimesByName(name);
        // assert
        Assert.Equal("Kill la Kill", result.Name);
    }
    [Fact]
    public async Task AnimesByNameNotExist()
    {
        // arrange
        var name = "Asdasd";
        var request = new Request();
        // act
        var result = await request.AnimesByName(name);
        // assert
        Assert.Null(result);
    }

}
