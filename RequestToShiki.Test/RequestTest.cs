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
            // act
            var result = await Request.StudioByName(name);
            // assert
            Assert.Equal(name, result.Studio.Name);
        }

        [Fact]
        public async Task StudioByNameDoesntExists()
        {
            // arrange
            string name = "ASDSDSDF";
            // act
            var result = await Request.StudioByName(name);
            // assert
            Assert.Null(result);
        }

        [Fact]
        public async Task AnimesByNameExist()
        {
            // arrange
            string name = "Kill la Kill And Something";
            // act
            var result = await Request.AnimesByName(name);
            // assert
            Assert.Equal("Kill la Kill", result.Name);
        }
        [Fact]
        public async Task AnimesByNameNotExist()
        {
            // arrange
            string name = "Asdasd";
            // act
            var result = await Request.AnimesByName(name);
            // assert
            Assert.Null(result);
        }
    }
}