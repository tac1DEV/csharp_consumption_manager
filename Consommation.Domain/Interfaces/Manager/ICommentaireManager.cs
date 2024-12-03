using Consommation.Domain.Models;

namespace Consommation.Domain.Interfaces.Manager
{
    public interface ICommentaireManager
    {
        List<CommentaireModel> GetAllCommentaires();
        CommentaireModel? GetCommentaireById(int? id);
        CommentaireModel CreateCommentaire(CommentaireModel commentaireModel);
        bool DeleteCommentaire(int? id);
        CommentaireModel? UpdateCommentaire(int? id, CommentaireModel commentaireModel);
    }
}
