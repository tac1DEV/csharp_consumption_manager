using Consommation.Database.EntityModels;
using Consommation.Domain.Interfaces.Manager;
using Consommation.Domain.Models;
using Consommation.Models;
using Microsoft.EntityFrameworkCore;

namespace Consommation.Database.Managers
{
    public class CommentaireManager : ICommentaireManager

    {
        private readonly DatabaseContext _databaseContext;

        public CommentaireManager(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public CommentaireModel CreateCommentaire(CommentaireModel commentaireModel)
        {
            var commentaire = new Commentaire
            {
                Id = commentaireModel.Id,
                Message = commentaireModel.Message
            };

            _databaseContext.Add(commentaire);
            _databaseContext.SaveChanges();
            return commentaireModel;
        }

        public bool DeleteCommentaire(int? Id)
        {
            if (!Id.HasValue)
            {
                return false;
            }

            var commentaire = _databaseContext.Commentaires
                .Where(t => t.Id == Id)
                .FirstOrDefault();

            if (commentaire == null)
            {
                return false;
            }

            _databaseContext.Commentaires.Remove(commentaire);
            _databaseContext.SaveChanges();

            return true;
        }

        public List<CommentaireModel> GetAllCommentaires()
        {
            return _databaseContext.Commentaires.Select(x => new CommentaireModel
            {
                Id = x.Id,
                Message = x.Message
            }).ToList();
        }

        public CommentaireModel? GetCommentaireById(int? id)
        {
            if (!id.HasValue)
            {
                return null;
            }

            var commentaire = _databaseContext.Commentaires
                .Select(x => new CommentaireModel
                {
                    Id = x.Id,
                    Message = x.Message
                })
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (commentaire == null)
            {
                return null;
            }
            return commentaire;
        }

        public CommentaireModel? UpdateCommentaire(int? Id, CommentaireModel commentaireModel)
        {
            if (!Id.HasValue)
            {
                return null;
            }

            var commentaire = _databaseContext.Commentaires
                .Where(t => t.Id == Id)
                .FirstOrDefault();

            if (commentaire == null)
            {
                return null;
            }

            commentaire.Message = commentaireModel.Message;

            _databaseContext.SaveChanges();
            commentaireModel.Id = commentaire.Id;

            return commentaireModel;
        }
    }
}
