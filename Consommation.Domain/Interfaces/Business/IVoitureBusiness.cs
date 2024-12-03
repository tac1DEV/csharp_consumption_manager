using Consommation.Domain.Models.Requests;
using Consommation.Domain.Models;

namespace Consommation.Domain.Interfaces.Business
{
    public interface IVoitureBusiness
    {
        List<VoitureModel> GetAllVoitures();
        VoitureModel? GetVoitureById(int? id);
        VoitureModel CreateVoiture(AddVoitureRequest request);
        bool DeleteVoiture(int? id);
        VoitureModel? UpdateVoiture(int? id, AddVoitureRequest request);

    }
}
