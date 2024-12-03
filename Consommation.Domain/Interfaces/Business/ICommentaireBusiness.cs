using Consommation.Domain.Models;
using Consommation.Domain.Models.Requests;

namespace Consommation.Domain.Interfaces.Business
{
    public interface ICommentaireBusiness

    {
        List<CommentaireModel> GetAllCommentaires();
        CommentaireModel? GetCommentaireById(int? id);
        CommentaireModel CreateCommentaire(AddCommentaireRequest request);
        bool DeleteCommentaire(int? id);
        CommentaireModel? UpdateCommentaire(int? id, AddCommentaireRequest request);
    
    }
}
