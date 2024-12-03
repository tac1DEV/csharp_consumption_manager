using Consommation.Domain.Interfaces.Business;
using Consommation.Domain.Interfaces.Manager;
using Consommation.Domain.Models;
using Consommation.Domain.Models.Requests;

namespace Consommation.Domain.Business
{
    public class CommentaireBusiness : ICommentaireBusiness
    {
        public ICommentaireManager _commentaireManager;

        public CommentaireBusiness(ICommentaireManager commentaireManager)
        {
            _commentaireManager = commentaireManager;
        }

        public CommentaireModel CreateCommentaire(AddCommentaireRequest request)
        {
            var AddToCommentaire = new CommentaireModel
            {
                Message = request.Message
            };
            if (_commentaireManager == null)
            {
                throw new Exception();
            }
            return _commentaireManager.CreateCommentaire(AddToCommentaire);
        }

        public bool DeleteCommentaire(int? id)
        {
            return _commentaireManager.DeleteCommentaire(id);
        }

        public List<CommentaireModel> GetAllCommentaires()
        {
            return _commentaireManager.GetAllCommentaires();
        }

        public CommentaireModel? GetCommentaireById(int? id)
        {
            return _commentaireManager.GetCommentaireById(id);
        }

        public CommentaireModel? UpdateCommentaire(int? id, AddCommentaireRequest request)
        {
            var CommentaireToEdit = new CommentaireModel
            {
                Message = request.Message
            };
            return _commentaireManager.UpdateCommentaire(id, CommentaireToEdit);
        }
    }

}
