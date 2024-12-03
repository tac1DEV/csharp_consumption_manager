using System.ComponentModel.DataAnnotations;

namespace Consommation.Domain.Models.Requests
{
    public class AddTrajetRequest
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Action { get; set; }
        [Required]
        public string Destination { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public int VitesseMoy { get; set; }
        [Required]
        public int ConsoMoy100 { get; set; }
        public int ConsoCumul { get; set; }
        public int? EnergieRecup { get; set; }
        public int? ConsoClim { get; set; }
    }
}
