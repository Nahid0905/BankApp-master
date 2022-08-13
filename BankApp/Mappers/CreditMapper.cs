using BankApp.AdminPanel.Model;
using BankApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Mappers
{
    public class CreditMapper : BaseMapper<Credit, CreditModel>
    {
        private readonly ClientMapper clientMapper = new ClientMapper();

        private readonly BranchMapper branchMapper = new BranchMapper();

        public override Credit Map(CreditModel model)
        {
            return new Credit()
            {
                Id = model.Id,
                Amount = model.Amount,
                CreditPercent = model.CreditPercent,
                AmountReturn = model.AmountReturn,
                GiveDate = model.GiveDate,
                ReturnDate =model.ReturnDate,
                Client = clientMapper.Map(model.Client),
                Branch = branchMapper.Map(model.Branch)
            };
        }

        public override CreditModel Map(Credit entity)
        {
            return new CreditModel()
            {
                Id = entity.Id,
                Amount = entity.Amount,
                CreditPercent = entity.CreditPercent,
                AmountReturn = entity.AmountReturn,
                GiveDate = entity.GiveDate,
                ReturnDate = entity.ReturnDate,
                Client = clientMapper.Map(entity.Client),
                Branch = branchMapper.Map(entity.Branch)
            };
        }
    }
}
