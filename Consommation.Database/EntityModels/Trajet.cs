using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Consommation.Database.EntityModels;

namespace Consommation.Models
{
    public class Trajet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Action { get; set; }
        public string Destination { get; set; }
        public string Type { get; set; }
        public int VitesseMoy { get; set; }
        public int ConsoMoy100 { get; set; }
        public int ConsoCumul { get; set; }
        public int? EnergieRecup { get; set; }
        public int? ConsoClim { get; set; }
        public int? CommentaireId { get; set; }
        public virtual Commentaire Commentaire { get; set; }
    }
}
