using RequestToShiki;
namespace RequestToShiki.Test

    
{
    public class UnitTest1
    {
        [Fact]
        public async Task CheckTrigger()
        {
            // arrange
            string name = "Trigger";
            StudioWithTopAnime expected = new StudioWithTopAnime();
            expected.Studio.Name = "Trigger";
            // act
            var result = await Request.StudioByName(name);
            // assert
            Assert.Equal(expected.Studio.Name, result.Studio.Name);
        }
    }
}