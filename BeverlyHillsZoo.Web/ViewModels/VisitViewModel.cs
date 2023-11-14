
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeverlyHillsZoo.Web.ViewModels
{
    public class VisitViewModel
    {
        public int Id { get; set; }

       public int NumberOfVisitor { get; set; }

        [DataType(DataType.Date)]
        public DateTime VisitDate { get; set; }
        public bool IsVisited { get; set; }
        public bool AtMorning { get; set; }
        public bool AtAfternoon { get; set; }
        public int AnimalId { get; set; }
        public int VisitorId { get; set; }
        public int GuideId { get; set; }

    }
}
