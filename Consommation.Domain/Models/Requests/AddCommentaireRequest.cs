using System.ComponentModel.DataAnnotations;

namespace Consommation.Domain.Models.Requests
{
    public class AddCommentaireRequest
    {
        [Required]
        public string Message { get; set; }
    }
}
