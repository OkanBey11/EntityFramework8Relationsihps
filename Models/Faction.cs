using System.Text.Json.Serialization;

namespace EntityFramework8Relationsihps.Models
{
    public class Faction
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [JsonIgnore]
        public List<Character>? Characters { get; set; }
    }
}