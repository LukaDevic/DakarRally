using System.ComponentModel.DataAnnotations;

namespace WebUI.Races.Models
{
    public class CreateRaceModel
    {
        [Required]
        public int Year { get; set; }
    }
}
