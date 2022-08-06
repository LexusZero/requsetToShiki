﻿using System.Globalization;
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
        public async Task<StudioWithTopAnime> StudioByName(string name)
        {
            var foundStudio = await GetRecordByStudioName(Path, name);
            if (foundStudio.Count == 0)
            {
                return null;
            }
            var studio = new Studio()
            {
                Name = foundStudio[0].StudioName,
            };
            var topAnimes = foundStudio.Select(ConvertToAnime).ToList();
            return new StudioWithTopAnime { Studio = studio, TopAnimes = topAnimes };
        }

        private async Task<StorageData> GetRecordByName(string requestPath, string name)
        {
            var record = await this.client.GetStreamAsync(requestPath);
            using var streamReader = new StreamReader(record);
            using var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture);
            var records = csvReader.GetRecords<StorageData>();
            var foundAnime = records.FirstOrDefault(record => record.Name.Contains(
                name, StringComparison.OrdinalIgnoreCase));
            return foundAnime;
        }

        private async Task<List<StorageData>> GetRecordByStudioName(string requestPath, string name)
        {
            var record = await this.client.GetStreamAsync(requestPath);
            using var streamReader = new StreamReader(record);
            using var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture);
            var records = csvReader.GetRecords<StorageData>();
            var storageDatas = new List<StorageData>();
            foreach (var rec in records)
            {
                if (rec.StudioName.Contains(name, StringComparison.OrdinalIgnoreCase))
                {
                    storageDatas.Add(rec);
                }
            }
            return storageDatas;
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