using Consommation.Database.EntityModels;
using Consommation.Domain.Interfaces.Manager;
using Consommation.Domain.Models;

namespace Consommation.Database.Managers
{
    public class VoitureManager : IVoitureManager
    {
        private readonly DatabaseContext _databaseContext;

        public VoitureManager(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public VoitureModel CreateVoiture(VoitureModel voitureModel)
        {
            var voiture = new Voiture
            {
                Id = voitureModel.Id,
                DistanceTot = voitureModel.DistanceTot,
                DistanceCumul = voitureModel.DistanceCumul,
                ChargeBatterie = voitureModel.ChargeBatterie,
                Autonomie = voitureModel.Autonomie,
                Reset = voitureModel.Reset
            };

            _databaseContext.Add(voiture);
            _databaseContext.SaveChanges();
            return voitureModel;
        }

        public bool DeleteVoiture(int? Id)
        {
            if (!Id.HasValue)
            {
                return false;
            }

            var voiture = _databaseContext.Voitures
                .Where(x => x.Id == Id)
                .FirstOrDefault();

            if (voiture == null)
            {
                return false;
            }

            _databaseContext.Voitures.Remove(voiture);
            _databaseContext.SaveChanges();

            return true;
        }

        public List<VoitureModel> GetAllVoitures()
        {
            return _databaseContext.Voitures.Select(x => new VoitureModel
            {
                Id = x.Id,
                DistanceTot = x.DistanceTot,
                DistanceCumul = x.DistanceCumul,
                ChargeBatterie = x.ChargeBatterie,
                Autonomie = x.Autonomie,
                Reset = x.Reset
            }).ToList();
        }

        public VoitureModel? GetVoitureById(int? id)
        {
            if (!id.HasValue)
            {
                return null;
            }

            var voiture = _databaseContext.Voitures
                .Select(x => new VoitureModel
                {
                    Id = x.Id,
                    DistanceTot = x.DistanceTot,
                    DistanceCumul = x.DistanceCumul,
                    ChargeBatterie = x.ChargeBatterie,
                    Autonomie = x.Autonomie,
                    Reset = x.Reset,
                })
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (voiture == null)
            {
                return null;
            }
            return voiture;
        }

        public VoitureModel? UpdateVoiture(int? Id, VoitureModel voitureModel)
        {
            if(!Id.HasValue)
            {
                return null;
            }

            var voiture = _databaseContext.Voitures
                .Where(x => x.Id == Id)
                .FirstOrDefault();

            if(voiture == null)
            {
                return null;
            }

            voiture.DistanceTot = voitureModel.DistanceTot;
            voiture.DistanceCumul = voitureModel.DistanceCumul;
            voiture.ChargeBatterie = voitureModel.ChargeBatterie;
            voiture.Autonomie = voitureModel.Autonomie;
            voiture.Reset = voitureModel.Reset;

            _databaseContext.SaveChanges();
            voitureModel.Id = voiture.Id;

            return voitureModel;
        }
    }
}
