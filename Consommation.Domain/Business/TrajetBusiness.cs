using Consommation.Domain.Interfaces.Business;
using Consommation.Domain.Interfaces.Manager;
using Consommation.Domain.Models;
using Consommation.Domain.Models.Requests;

namespace Consommation.Domain.Business
{
    public class TrajetBusiness : ITrajetBusiness
    {
        public ITrajetManager _trajetManager;

        public TrajetBusiness(ITrajetManager trajetManager)
        {
            _trajetManager = trajetManager;
        }

        public TrajetModel CreateTrajet(AddTrajetRequest request)
        {
            var AddToTrajet = new TrajetModel
            {
                Date = request.Date,
                Action = request.Action,
                Destination = request.Destination,
                Type = request.Type,
                VitesseMoy = request.VitesseMoy,
                ConsoMoy100 = request.ConsoMoy100,
                ConsoCumul = request.ConsoCumul,
                EnergieRecup = request.EnergieRecup,
                ConsoClim = request.ConsoClim
            };
            if (_trajetManager == null)
            {
                throw new Exception();
            }
            return _trajetManager.CreateTrajet(AddToTrajet);
        }

        public bool DeleteTrajet(int? id)
        {
            return _trajetManager.DeleteTrajet(id);
        }

        public List<TrajetModel> GetAllTrajets()
        {
            return _trajetManager.GetAllTrajets();
        }

        public TrajetModel? GetTrajetById(int? id)
        {
            return _trajetManager.GetTrajetById(id);
        }

        public TrajetModel? UpdateTrajet(int? id, AddTrajetRequest request)
        {
            var TrajetToEdit = new TrajetModel
            {
                Date = request.Date,
                Action = request.Action,
                Destination = request.Destination,
                Type = request.Type,
                VitesseMoy = request.VitesseMoy,
                ConsoMoy100 = request.ConsoMoy100,
                ConsoCumul = request.ConsoCumul,
                EnergieRecup = request.EnergieRecup,
                ConsoClim = request.ConsoClim
            };
            return _trajetManager.UpdateTrajet(id, TrajetToEdit);
        }
    }
}
