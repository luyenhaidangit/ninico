using System.ComponentModel.DataAnnotations;

namespace Ninico.Data.Entities
{
    public class Config
    {
        [Key]
        public string Key { get; set; }

        public string? Value { get; set; }

        public string? Description { get; set; }
    }
}
