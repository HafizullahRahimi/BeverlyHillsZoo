using BeverlyHillsZoo.Web.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace BeverlyHillsZoo.Web.Models
{
    public abstract class Animal 
    {
        [Key]
        public int Id { get ; set ; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        public int Type { get; set; }

        public bool IsDeleted { get; set; }

        public virtual void Move(){}
    }
}
