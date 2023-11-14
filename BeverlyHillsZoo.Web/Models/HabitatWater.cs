using BeverlyHillsZoo.Web.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace BeverlyHillsZoo.Web.Models
{
    public class HabitatWater : Animal, IMakeSound
    {

        public int DivingDepth { get; set; }

        public string MakeSound()
        {
            return "I swim!";
        }

        public override void Move() { }
    }
}
