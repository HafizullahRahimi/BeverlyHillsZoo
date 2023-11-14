using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeverlyHillsZoo.Web.Models
{
    public class Visit
    {
        public int Id { get; set; }

        public int NumberOfVisitor { get; set; }

        [DataType(DataType.Date)]
        public DateTime VisitDate { get; set; }
        public bool IsVisited { get; set; }
        public bool AtMorning { get; set; }
        public bool AtAfternoon { get; set; }


        // Relationship

        [ForeignKey("Animal")]
        public int AnimalId { get; set; }

        [ForeignKey("Visitor")]
        public int VisitorId { get; set; }

        [ForeignKey("Guide")]
        public int GuideId { get; set; }

        public Animal Animal { get; set; }
        public Visitor Visitor { get; set; }
        public Guide Guide { get; set; }

    }
}
