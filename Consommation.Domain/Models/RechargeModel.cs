using Consommation.Domain.Interfaces.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consommation.Domain.Models
{
    public class RechargeModel
    {
        public int Id { get; set; }
        public int Durée { get; set; }
        public int KwChargé { get; set; }
        public int PrixKwh { get; set; }
        public int PuChargéKwH { get; set; }
        public int Coût { get; set; }
        public int RatioBatterie { get; set; }
        public int? CommentaireId { get; set; }
    }
}
