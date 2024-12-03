using Consommation.Domain.Interfaces.Business;
using Consommation.Domain.Interfaces.Manager;
using Consommation.Domain.Models;
using Consommation.Domain.Models.Requests;

namespace Consommation.Domain.Business
{
    public class VoitureBusiness : IVoitureBusiness
    {
        public IVoitureManager _voitureManager;

        public VoitureBusiness(IVoitureManager voitureManager)
        {
            _voitureManager = voitureManager;
        }

        public VoitureModel CreateVoiture(AddVoitureRequest request)
        {
            var AddToVoiture = new VoitureModel
            {
                DistanceTot = request.DistanceTot,
                DistanceCumul = request.DistanceCumul,
                ChargeBatterie = request.ChargeBatterie,
                Autonomie = request.Autonomie,
                Reset = request.Reset
            };
            if (_voitureManager == null)
            {
                throw new Exception();
            }
            return _voitureManager.CreateVoiture(AddToVoiture);
        }

        public bool DeleteVoiture(int? id)
        {
            return _voitureManager.DeleteVoiture(id);
        }

        public List<VoitureModel> GetAllVoitures()
        {
            return _voitureManager.GetAllVoitures();
        }

        public VoitureModel? GetVoitureById(int? id)
        {
            return _voitureManager.GetVoitureById(id);
        }

        public VoitureModel? UpdateVoiture(int? id, AddVoitureRequest request)
        {
            var VoitureToEdit = new VoitureModel
            {
                DistanceTot = request.DistanceTot,
                DistanceCumul = request.DistanceCumul,
                ChargeBatterie = request.ChargeBatterie,
                Autonomie = request.Autonomie,
                Reset = request.Reset
            };
            return _voitureManager.UpdateVoiture(id, VoitureToEdit);
        }
    }
}
