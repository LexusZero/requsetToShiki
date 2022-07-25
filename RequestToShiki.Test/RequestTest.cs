using RequestToShiki;

namespace RequestToShiki.Test
{
    public class RequestTest
    {
        [Fact]
        public async Task StudioByNameExists()
        {
            // arrange
            string name = "Trigger";
            Request request = new Request();
            // act
            var result = await request.StudioByName(name);
            // assert
            Assert.Equal(name, result.Studio.Name);
        }

        [Fact]
        public async Task StudioByNameDoesntExists()
        {
            // arrange
            string name = "ASDSDSDF";
            Request request = new Request();
            // act
            var result = await request.StudioByName(name);
            // assert
            Assert.Null(result);
        }

        [Fact]
        public async Task AnimesByNameExist()
        {
            // arrange
            string name = "Kill la Kill And Something";
            Request request = new Request();
            // act
            var result = await request.AnimesByName(name);
            // assert
            Assert.Equal("Kill la Kill", result.Name);
        }
        [Fact]
        public async Task AnimesByNameNotExist()
        {
            // arrange
            string name = "Asdasd";
            Request request = new Request();
            // act
            var result = await request.AnimesByName(name);
            // assert
            Assert.Null(result);
        }

    }
}