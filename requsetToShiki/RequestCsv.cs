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
            var storageDataAnime = await GetRecordByName(Path, name);

            if (storageDataAnime == null)
            {
                return null;
            }

            var anime = new Anime()
            {
                Name = storageDataAnime.Name,
                Description = storageDataAnime.Description
            };

            return anime;

        }
        public Task<StudioWithTopAnime> StudioByName(string name)
        {
            throw new NotImplementedException();
        }
        public async Task<StorageData> GetRecordByName(string requestPath, string name)
        {

            var record = await this.client.GetStreamAsync(requestPath);
            using var streamReader = new StreamReader(record);
            using var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture);
            var animeRecords = csvReader.GetRecords<StorageData>();
            var foundAnime = animeRecords.FirstOrDefault(anim => anim.Name.Contains(
                name, StringComparison.InvariantCultureIgnoreCase));
            return foundAnime;


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
