using Consommation.Domain.Models;

namespace Consommation.Domain.Interfaces.Manager
{
    public interface IVoitureManager
    {
        List<VoitureModel> GetAllVoitures();
        VoitureModel? GetVoitureById(int? id);
        VoitureModel CreateVoiture(VoitureModel voitureModel);
        bool DeleteVoiture(int? id);
        VoitureModel? UpdateVoiture(int? id, VoitureModel voitureModel);
    }
}
