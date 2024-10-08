using System.Text.Json.Serialization;

namespace EntityFramework8Relationsihps.Models
{
    public class Weapon
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int CharacterId { get; set; }
        [JsonIgnore]
        public Character? Character { get; set; }
    }
}