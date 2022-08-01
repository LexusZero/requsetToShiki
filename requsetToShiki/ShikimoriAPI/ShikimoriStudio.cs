using System.Text.Json.Serialization;

namespace RequestToShiki.ShikimoriAPI;
internal class ShikimoriStudio

{
    public int Id { get; set; }
    public string Name { get; set; }
    [JsonPropertyName("filtered_name")]
    public string filteredName { get; set; }

}
