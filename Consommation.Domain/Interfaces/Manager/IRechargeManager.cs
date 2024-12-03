using Consommation.Domain.Models;

namespace Consommation.Domain.Interfaces.Manager
{
    public interface IRechargeManager
    {
        List<RechargeModel> GetAllRecharges();
        RechargeModel? GetRechargeById(int? id);
        RechargeModel CreateRecharge(RechargeModel rechargeModel);
        bool DeleteRecharge(int? id);
        RechargeModel? UpdateRecharge(int? id, RechargeModel rechargeModel);
    }
}
