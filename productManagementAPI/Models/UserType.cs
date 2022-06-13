using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace productManagementAPI.Models
{
    public class UserType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "User Type")]
        public string Users { get; set; }     
       
    }
}
