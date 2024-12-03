using Consommation.Domain.Interfaces.Business;
using Consommation.Domain.Interfaces.Manager;
using Consommation.Domain.Models;
using Consommation.Domain.Models.Requests;

namespace Consommation.Domain.Business
{
    public class RechargeBusiness : IRechargeBusiness
    {
        public IRechargeManager _rechargeManager;

        public RechargeBusiness(IRechargeManager rechargeManager)
        {
            _rechargeManager = rechargeManager;
        }

        public RechargeModel CreateRecharge(AddRechargeRequest request)
        {
            var AddToRecharge = new RechargeModel
            {
                Durée = request.Durée,
                KwChargé = request.KwChargé,
                PrixKwh = request.PrixKwh,
                PuChargéKwH = request.PuChargéKwH,
                Coût = request.Coût,
                RatioBatterie = request.RatioBatterie
            };
            if(_rechargeManager == null)
            {
                throw new Exception();
            }
            return _rechargeManager.CreateRecharge(AddToRecharge);
        }

        public bool DeleteRecharge(int? id)
        {
            return _rechargeManager.DeleteRecharge(id);
        }

        public List<RechargeModel> GetAllRecharges()
        {
            return _rechargeManager.GetAllRecharges();
        }

        public RechargeModel? GetRechargeById(int? id)
        {
            return _rechargeManager.GetRechargeById(id);
        }

        public RechargeModel? UpdateRecharge(int? id, AddRechargeRequest request)
        {
            var RechargeToEdit = new RechargeModel
            {
                Durée = request.Durée,
                KwChargé = request.KwChargé,
                PrixKwh = request.PrixKwh,
                PuChargéKwH = request.PuChargéKwH,
                Coût = request.Coût,
                RatioBatterie = request.RatioBatterie
            };
            return _rechargeManager.UpdateRecharge(id, RechargeToEdit);
        }
    }
}
