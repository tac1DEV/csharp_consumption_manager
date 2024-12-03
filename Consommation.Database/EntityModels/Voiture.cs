using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Consommation.Database.EntityModels
{
    public class Voiture
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int DistanceTot { get; set; }
        public int DistanceCumul { get; set; }
        public int ChargeBatterie { get; set; }
        public int Autonomie { get; set; }
        public bool Reset { get; set; }
    }
}
