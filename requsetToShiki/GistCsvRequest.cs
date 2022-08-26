using System.Globalization;
using CsvHelper;

namespace RequestToShiki
{
    public class GistCsvRequest : IRequest
    {
        private const string Path = "https://gist.githubusercontent.com/xill47/a1255ce9b6f7a3482405e7141fb5cf25/raw/95a2fbcc54385d6636e915afd2bee96e9422ca52/animes.csv";
        private readonly HttpClient client = new();
        private Dictionary<string, Studio> studiosByName;
        private Dictionary<string, List<Anime>> animesByStudioName;
        private List<Anime> allAnimeList;

        public async Task<Anime> AnimesByName(string name)
        {
            if (this.allAnimeList == null)
            {
                await Initialize();

            }

            return this.allAnimeList
                .FirstOrDefault(anime => anime.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
        }
        public async Task<StudioWithTopAnime> StudioByName(string name)
        {
            if (this.allAnimeList == null)
            {
                await Initialize();
            }

            return this.studiosByName.Keys
                .Where(key => key.Contains(name, StringComparison.OrdinalIgnoreCase))
                .Select(key => new StudioWithTopAnime { Studio = this.studiosByName[key], TopAnimes = this.animesByStudioName[key] })
                .FirstOrDefault();
        }

        private async Task Initialize()
        {
            var record = await this.client.GetStreamAsync(Path);
            using var streamReader = new StreamReader(record);
            using var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture);
            var records = csvReader.GetRecords<StorageData>().ToList();

            this.allAnimeList = records.Select(ConvertToAnime).ToList();

            this.studiosByName = records
                .GroupBy(x => x.StudioName)
                .Select(g => g.First())
                .ToDictionary(x => x.StudioName, x => new Studio { Name = x.StudioName });

            this.animesByStudioName = records
                .GroupBy(x => x.StudioName)
                .ToDictionary(g => g.Key, g => g.Select(ConvertToAnime).ToList());
        }

        private static Anime ConvertToAnime(StorageData storageData) => new()
        {
            Name = storageData.Name,
            Description = storageData.Description
        };
    }

    public class StorageData
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string StudioName { get; set; }
        public int PopularityRating { get; set; }
    }
}
