using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Consommation.Database.EntityModels
{
    public class Recharge
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Durée { get; set; }
        public int KwChargé { get; set; }
        public int PrixKwh { get; set; }
        public int PuChargéKwH { get; set; }
        public int Coût { get; set; }
        public int RatioBatterie { get; set; }
        public int? CommentaireId { get; set; }
        public virtual Commentaire Commentaire { get; set; }

    }
}
