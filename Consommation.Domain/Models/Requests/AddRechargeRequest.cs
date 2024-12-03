using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consommation.Domain.Models.Requests
{
    public class AddRechargeRequest
    {
        [Required]
        public int Durée { get; set; }

        [Required]
        public int KwChargé { get; set; }

        [Required]
        public int PrixKwh { get; set; }

        [Required]
        public int PuChargéKwH { get; set; }
        public int Coût { get; set; }

        [Required]
        public int RatioBatterie { get; set; }
    }
}
