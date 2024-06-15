using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ninico.Data.Entities
{
    public class ProductCategory
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public string Slug { get; set; }

        public string? Icon { get; set; }

        public int? ParentId { get; set; }

        public int Order { get; set; }

        #region Relationship
        [ForeignKey("ParentId")]
        public virtual ProductCategory? Parent { get; set; }

        public virtual ICollection<ProductCategory>? Childrens { get; set; }
        #endregion
    }
}
