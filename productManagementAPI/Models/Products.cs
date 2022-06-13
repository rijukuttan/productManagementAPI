using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace productManagementAPI.Models
{
    public class Products
    {
        [Key]
        [Display(Name = "Product ID")]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Product Name")]
        public string? ProductName { get; set; }
        [Column(TypeName = "nvarchar(1000)")]
        [Display(Name = "Image Url")]
        public string? ImageUrl { get; set; }
        [Required]
        [Display(Name = "Product Price")]
        public int? ProductPrice { get; set; }
        [Display(Name = "Create Date")]
        public DateTime? CreateDate { get; set; }
        [Display(Name = "Create Modify")]
        public DateTime? ModifyDate { get; set; }
        // public byte[] Photo { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string? Describtion { get; set; }
    }
}
