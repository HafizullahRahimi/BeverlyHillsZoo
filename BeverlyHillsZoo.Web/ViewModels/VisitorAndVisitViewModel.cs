
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeverlyHillsZoo.Web.ViewModels
{
    public class VisitorAndVisitViewModel
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime VisitDate { get; set; }
        public bool AtMorning { get; set; }
        public bool AtAfternoon { get; set; }
        public int AnimalId { get; set; }
        public string AnimalName { get; set; }

        [Required]
        [MaxLength(250)]
        public string UserName { get; set; }

        [Required]
        [Range(190000000000, 999999999999, ErrorMessage = "Person number: yyyymmddnnnn")]
        public long PersonNumber { get; set; }

    }
}
