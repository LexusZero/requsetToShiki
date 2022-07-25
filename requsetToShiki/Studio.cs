namespace RequestToShiki;
using System.Text.Json.Serialization;

public class Studio

{
    public int Id { get; set; }
    public string Name { get; set; }
    [JsonPropertyName("filtered_name")]
    public string filteredName { get; set; }

}
