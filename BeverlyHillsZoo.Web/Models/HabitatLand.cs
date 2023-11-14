using BeverlyHillsZoo.Web.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace BeverlyHillsZoo.Web.Models
{
    public class HabitatLand : Animal, IMakeSound
    {

        public int Speed { get; set; }

        public string MakeSound()
        {
            return "I go!";
        }

        public override void Move(){}
    }
}
