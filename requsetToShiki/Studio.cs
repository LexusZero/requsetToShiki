using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RequestToShiki
{
    internal class Studio

    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonPropertyName("filtered_name")]
        public string filteredName { get; set; }

    }


}