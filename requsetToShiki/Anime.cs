using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestToShiki
{
    internal class Anime
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Russian { get; set; }
        public string Description { get; set; }
        public string[] English { get; set; }
        public string[] Japanese { get; set; }

    }
}
