using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace BeverlyHillsZoo.Web.Models
{
    public class Visitor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [Required]
        [Range(190000000000, 999999999999, ErrorMessage ="Person number: yyyymmddnnnn")]     
        public long PersonNumber { get; set; }

        public bool IsDeleted { get; set; }
        
    }
}
