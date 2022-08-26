using System.Globalization;
using CsvHelper;

namespace RequestToShiki
{
    public class GistCsvRequest : IRequest
    {
        private const string Path = "https://gist.githubusercontent.com/xill47/a1255ce9b6f7a3482405e7141fb5cf25/raw/95a2fbcc54385d6636e915afd2bee96e9422ca52/animes.csv";
        private readonly HttpClient client = new();
        private readonly Dictionary<string, Studio> studiosByName = new();
        private readonly Dictionary<string, List<Anime>> animesByStudioName = new();
        private readonly List<Anime> allAnimeList = new();
        private bool initialized;

        public async Task<Anime> AnimesByName(string name)
        {
            if (!this.initialized)
            {
                await Initialize();

            }
            Anime foundAnime = null;
            foreach (var anime in this.allAnimeList)
            {
                if (anime.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                {
                    foundAnime = anime;
                }
            }
            return foundAnime;
        }
        public async Task<StudioWithTopAnime> StudioByName(string name)
        {
            if (!this.initialized)
            {
                await Initialize();
            }
            string studioKey = null;
            foreach (var key in this.studiosByName.Keys)
            {
                if (key.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    studioKey = key;
                }
            }
            if (studioKey == null)
            {
                return null;
            }
            var studio = this.studiosByName[studioKey];

            if (!this.animesByStudioName.ContainsKey(studioKey))
            {
                return null;
            }
            var topAnimes = this.animesByStudioName[studioKey];
            return new StudioWithTopAnime { Studio = studio, TopAnimes = topAnimes };
        }
        private void InitializeStudios(StorageData record)
        {
            this.studiosByName[record.StudioName] = new Studio() { Name = record.StudioName };
        }

        private async Task Initialize()
        {
            var record = await this.client.GetStreamAsync(Path);
            using var streamReader = new StreamReader(record);
            using var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture);
            var records = csvReader.GetRecords<StorageData>();
            foreach (var rec in records)
            {
                InitializeStudios(rec);
                InitializeAnimesByStudioName(rec);
                InitializeAllAnimeList(rec);
            }
            this.initialized = true;
        }

        private void InitializeAllAnimeList(StorageData storageData) =>
            this.allAnimeList.Add(ConvertToAnime(storageData));

        private void InitializeAnimesByStudioName(StorageData record)
        {
            if (!this.animesByStudioName.ContainsKey(record.StudioName))
            {
                this.animesByStudioName.Add(record.StudioName, new List<Anime>());
            }
            this.animesByStudioName[record.StudioName].Add(ConvertToAnime(record));
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
