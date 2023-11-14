using System.ComponentModel.DataAnnotations;

namespace BeverlyHillsZoo.Web.Models
{
    public class Guide
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [Range(1,3)]
        public int CompetenceType { get; set; }

        public bool IsDeleted { get; set; }

    }
}
