using Consommation.Database.EntityModels;
using Consommation.Domain.Interfaces.Manager;
using Consommation.Domain.Models;

namespace Consommation.Database.Managers
{
    public class RechargeManager : IRechargeManager

    {
        private readonly DatabaseContext _databasecontext;

        public RechargeManager(DatabaseContext databasecontext) 
        {
            _databasecontext = databasecontext;
        }

        public RechargeModel CreateRecharge(RechargeModel rechargeModel)
        {
            var recharge = new Recharge
            {
                Id = rechargeModel.Id,
                Durée = rechargeModel.Durée,
                KwChargé = rechargeModel.KwChargé,
                PrixKwh = rechargeModel.PrixKwh,
                PuChargéKwH = rechargeModel.PuChargéKwH,
                Coût = rechargeModel.Coût,
                RatioBatterie = rechargeModel.RatioBatterie,
                CommentaireId = rechargeModel.CommentaireId
            };

            _databasecontext.Add(recharge);
            _databasecontext.SaveChanges();
            return rechargeModel;
        }

        public bool DeleteRecharge(int? Id)
        {
            if(!Id.HasValue)
            {
                return false;
            }

            var recharge = _databasecontext.Recharges
                .Where(x => x.Id == Id)
                .FirstOrDefault();

            if(recharge == null)
            {
                return false;
            }

            _databasecontext.Recharges.Remove(recharge);
            _databasecontext.SaveChanges();
            return true;
        }

        public List<RechargeModel> GetAllRecharges()
        {
            return _databasecontext.Recharges.Select(x => new RechargeModel
            {
                Id = x.Id,
                Durée = x.Durée,
                KwChargé = x.KwChargé,
                PrixKwh = x.PrixKwh,
                PuChargéKwH = x.PuChargéKwH,
                Coût = x.Coût,
                RatioBatterie = x.RatioBatterie,
                CommentaireId = x.CommentaireId
            }).ToList();
        }

        public RechargeModel? GetRechargeById(int? id)
        {
            if(!id.HasValue)
            {
                return null;
            }

            var recharge = _databasecontext.Recharges
                .Select(x => new RechargeModel
                {
                    Id = x.Id,
                    Durée = x.Durée,
                    KwChargé = x.KwChargé,
                    PrixKwh = x.PrixKwh,
                    PuChargéKwH = x.PuChargéKwH,
                    Coût = x.Coût,
                    RatioBatterie = x.RatioBatterie,
                    CommentaireId = x.CommentaireId
                })
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if(recharge == null)
            {
                return null;
            }
            return recharge;

        }

        public RechargeModel? UpdateRecharge(int? Id, RechargeModel rechargeModel)
        {
            if (!Id.HasValue)
            {
                return null;
            }

            var recharge = _databasecontext.Recharges
                .Where(x => x.Id == Id)
                .FirstOrDefault();

            if( recharge == null)
            {
                return null;
            }

            recharge.Durée = rechargeModel.Durée;
            recharge.KwChargé = rechargeModel.KwChargé;
            recharge.PrixKwh = rechargeModel.PrixKwh;
            recharge.PuChargéKwH = rechargeModel.PuChargéKwH;
            recharge.Coût = rechargeModel.Coût;
            recharge.RatioBatterie = rechargeModel.RatioBatterie;
            recharge.CommentaireId = rechargeModel.CommentaireId;

            _databasecontext.SaveChanges();
            recharge.Id= rechargeModel.Id;

            return rechargeModel;
        }
    }
}
