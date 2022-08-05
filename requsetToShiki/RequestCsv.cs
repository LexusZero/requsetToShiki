using System.Globalization;
using CsvHelper;

namespace RequestToShiki
{
    public class GistCsvRequest : IRequest
    {
        private const string Path = "/xill47/a1255ce9b6f7a3482405e7141fb5cf25/raw/95a2fbcc54385d6636e915afd2bee96e9422ca52/animes.csv";
        private readonly HttpClient client = new() { BaseAddress = new Uri("https://gist.githubusercontent.com") };
        // /xill47/a1255ce9b6f7a3482405e7141fb5cf25/raw/95a2fbcc54385d6636e915afd2bee96e9422ca52/animes.csv
        public async Task<Anime> AnimesByName(string name)
        {
            var animeRecords = await GetRecord(Path);
            var foundAnime = animeRecords.FirstOrDefault(anim => anim.Name == name);
            if (foundAnime == null)
            {
                return null;
            }
            var anime = new Anime()
            {
                Name = foundAnime.Name,
                Description = foundAnime.Description
            };
            return anime;

        }
        public Task<StudioWithTopAnime> StudioByName(string name)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<StorageData>> GetRecord(string requestPath)
        {

            var record = await this.client.GetStreamAsync(requestPath);
            using var streamReader = new StreamReader(record);
            using var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture);
            return csvReader.GetRecords<StorageData>().ToList();

        }
    }



    public class StorageData
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string StudioName { get; set; }
        public int PopularityRating { get; set; }
    }
}
