using BeverlyHillsZoo.Web.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace BeverlyHillsZoo.Web.Models
{
    public class HabitatAir: Animal, IMakeSound
    {

        public int MaxAltitude { get; set; }

        public override void Move() { }
        public string MakeSound()
        {
            return "I fly!";
        }
    }
}
