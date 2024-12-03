using System.ComponentModel.DataAnnotations;

namespace Consommation.Domain.Models.Requests
{
    public class AddVoitureRequest
    {
        [Required]
        public int DistanceTot { get; set; }
        [Required]
        public int DistanceCumul { get; set; }
        [Required]
        public int ChargeBatterie { get; set; }
        public int Autonomie { get; set; }
        public bool Reset { get; set; }
    }
}