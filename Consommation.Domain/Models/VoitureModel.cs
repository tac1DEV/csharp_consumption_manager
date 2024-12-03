using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consommation.Domain.Models
{
    public class VoitureModel
    {
        public int Id { get; set; }
        public int DistanceTot { get; set; }
        public int DistanceCumul { get; set; }
        public int ChargeBatterie { get; set; }
        public int Autonomie { get; set; }
        public bool Reset { get; set; }
    }
}
