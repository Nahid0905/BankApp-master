using BankApp.AdminPanel.DataContext;
using BankApp.AdminPanel.Model;
using BankApp.AdminPanel.ViewModel.Controls;
using BankApp.AdminPanel.ViewModel.Controls.ExchangeControls;
using BankApp.AdminPanel.Views.Controls.ExchangeControls;
using BankApp.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Commands.ExchangeCommand
{
    public class CalculateCommand : BaseCommand
    {
        private readonly ExchangeControlViewModel viewModel;

        public CalculateCommand(ExchangeControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            viewModel.CenterGrid.Children.Clear();

            CalculateControlViewModel calculateControlViewModel = new CalculateControlViewModel(Kernel.DB);


            CalculateControl calculateControl = new CalculateControl();

            calculateControlViewModel.CenterGrid = calculateControl.grdCenter;

            calculateControl.DataContext = calculateControlViewModel;
            viewModel.CenterGrid.Children.Add(calculateControl);
        }
    }
}
