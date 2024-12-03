using Consommation.Database.EntityModels;
using Consommation.Domain.Interfaces.Manager;
using Consommation.Domain.Models;
using Consommation.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Consommation.Database.Managers
{
    public class TrajetManager : ITrajetManager
    {
        private readonly DatabaseContext _databaseContext;

        public TrajetManager(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public TrajetModel CreateTrajet(TrajetModel trajetModel)
        {
            var trajet = new Trajet
            {
                Id = trajetModel.Id,
                Date = trajetModel.Date,
                Action = trajetModel.Action,
                Destination = trajetModel.Destination,
                Type = trajetModel.Type,
                VitesseMoy = trajetModel.VitesseMoy,
                ConsoMoy100 = trajetModel.ConsoMoy100,
                ConsoCumul = trajetModel.ConsoCumul,
                EnergieRecup = trajetModel.EnergieRecup,
                ConsoClim = trajetModel.ConsoClim,
                CommentaireId = trajetModel.CommentaireId
            };

            _databaseContext.Add(trajet);
            _databaseContext.SaveChanges();
            return trajetModel;
        }

        public bool DeleteTrajet(int? Id)
        {
            if (!Id.HasValue)
            {
                return false;
            }

            var trajet = _databaseContext.Trajets
                .Where(x => x.Id == Id)
                .FirstOrDefault();

            if (trajet == null)
            {
                return false;
            }

            _databaseContext.Trajets.Remove(trajet);
            _databaseContext.SaveChanges();

            return true;
        }

        public List<TrajetModel> GetAllTrajets()
        {
            return _databaseContext.Trajets.Select(x => new TrajetModel
            {
                Id = x.Id,
                Date = x.Date,
                Action = x.Action,
                Destination = x.Destination,
                Type = x.Type,
                VitesseMoy = x.VitesseMoy,
                ConsoMoy100 = x.ConsoMoy100,
                ConsoCumul = x.ConsoCumul,
                EnergieRecup = x.EnergieRecup,
                ConsoClim = x.ConsoClim,
                CommentaireId = x.CommentaireId
            }).ToList();
        }

        public TrajetModel? GetTrajetById(int? id)
        {
            if(!id.HasValue)
            {
                return null;
            }

            var trajet = _databaseContext.Trajets
                .Select(x => new TrajetModel
                {
                    Id = x.Id,
                    Date = x.Date,
                    Action = x.Action,
                    Destination = x.Destination,
                    Type = x.Type,
                    VitesseMoy = x.VitesseMoy,
                    ConsoMoy100 = x.ConsoMoy100,
                    ConsoCumul = x.ConsoCumul,
                    EnergieRecup = x.EnergieRecup,
                    ConsoClim = x.ConsoClim,
                    CommentaireId = x.CommentaireId
                })
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if(trajet == null)
            {
                return null;
            }
            return trajet;
        }

        public TrajetModel? UpdateTrajet(int? Id, TrajetModel trajetModel)
        {
            if (!Id.HasValue)
            {
                return null;
            }

            var trajet = _databaseContext.Trajets
                .Where(x => x.Id == Id)
                .FirstOrDefault();

            if (trajet == null)
            {
                return null;
            }

            trajetModel.Date = trajet.Date;
            trajetModel.Action = trajet.Action;
            trajetModel.Destination = trajet.Destination;
            trajetModel.Type = trajet.Type;
            trajetModel.VitesseMoy = trajet.VitesseMoy;
            trajetModel.ConsoMoy100 = trajet.ConsoMoy100;
            trajetModel.ConsoCumul = trajet.ConsoCumul;
            trajetModel.EnergieRecup = trajet.EnergieRecup;
            trajetModel.ConsoClim = trajet.ConsoClim;
            trajetModel.CommentaireId = trajet.CommentaireId;

            _databaseContext.SaveChanges();
            trajetModel.Id = trajet.Id;

            return trajetModel;
        }
    }
}
