using Consommation.Domain.Models;
using Consommation.Domain.Models.Requests;

namespace Consommation.Domain.Interfaces.Business
{
    public interface IRechargeBusiness

    {
        List<RechargeModel> GetAllRecharges();
        RechargeModel? GetRechargeById(int? id);
        RechargeModel CreateRecharge(AddRechargeRequest request);
        bool DeleteRecharge(int? id);
        RechargeModel? UpdateRecharge(int? id, AddRechargeRequest request);

    }
}
