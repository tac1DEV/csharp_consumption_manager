using Consommation.Domain.Models.Requests;
using Consommation.Domain.Models;

namespace Consommation.Domain.Interfaces.Business
{
    public interface ITrajetBusiness
    {
        List<TrajetModel> GetAllTrajets();
        TrajetModel? GetTrajetById(int? id);
        TrajetModel CreateTrajet(AddTrajetRequest request);
        bool DeleteTrajet(int? id);
        TrajetModel? UpdateTrajet(int? id, AddTrajetRequest request);

    }
}
