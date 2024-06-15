using System.ComponentModel.DataAnnotations;

namespace Ninico.Data.Entities
{
    public class Slide
    {
        [Key]
        public int Id { get; set; }

        public string? Content { get; set; }

        public string Image { get; set; }

        public int Order { get; set; }

        public int Type { get; set; }
    }
}
