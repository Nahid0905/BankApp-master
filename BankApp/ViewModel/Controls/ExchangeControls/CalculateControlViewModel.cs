using BankApp.AdminPanel.Commands.ExchangeCommand;
using BankApp.AdminPanel.Model;
using BankApp.Core.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BankApp.AdminPanel.ViewModel.Controls.ExchangeControls
{
    public class CalculateControlViewModel : BaseControlViewModel<ExchangeModel>
    {
        public CalculateControlViewModel(IUnitOfWork db) : base(db)
        {

        }

        public Grid CenterGrid { get; set; }

        #region Command

        public override string Header => "Exchange";
        #endregion
    }
}
