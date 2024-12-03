using Consommation.Domain.Models.Requests;
using Consommation.Domain.Models;

namespace Consommation.Domain.Interfaces.Manager
{
    public interface ITrajetManager
    {
        List<TrajetModel> GetAllTrajets();
        TrajetModel? GetTrajetById(int? id);
        TrajetModel CreateTrajet(TrajetModel trajetModel);
        bool DeleteTrajet(int? Id);
        TrajetModel? UpdateTrajet(int? id, TrajetModel trajetModel);
    }
}
