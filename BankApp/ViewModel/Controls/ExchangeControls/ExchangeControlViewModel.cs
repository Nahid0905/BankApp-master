using BankApp.AdminPanel.Commands.ExchangeCommand;
using BankApp.AdminPanel.Commands.ExchangeCommand.Commands;
using BankApp.AdminPanel.Enums;
using BankApp.AdminPanel.Model;
using BankApp.Core.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BankApp.AdminPanel.ViewModel.Controls
{
    public class ExchangeControlViewModel : BaseControlViewModel<ExchangeModel>
    {
        public ExchangeControlViewModel(IUnitOfWork db) : base(db)
        {

        }

        public Grid CenterGrid { get; set; }
        public override string Header => "Exchange";

        #region Command
        public SaveExchangeCommand Save => new SaveExchangeCommand(this);
        public DeleteCommand Delete => new DeleteCommand(this);
        public OpenSearchExchange OpenSearch => new OpenSearchExchange(this);
        public SearchCommand SearchCommand => new SearchCommand(this);
        public ShowAllClients ShowAllClients => new ShowAllClients(this);
        public CalculateCommand CalculateCommand => new CalculateCommand(this);
        #endregion

        #region comboBox properties
        public List<ClientModel> Clients { get; set; }

        private ClientModel selectedClient;
        public ClientModel SelectedClient
        {
            get => selectedClient;
            set
            {
                selectedClient = value;
                OnPropertyChanged(nameof(SelectedClient));
            }
        }
        #endregion
        #region Search
        private string searchTextname;
        public string SearchTextName
        {
            get
            {
                return searchTextname;
            }
            set
            {
                searchTextname = value;
                OnPropertyChanged(SearchTextName);
            }
        }
        
        private string searchTextphone;
        public string SearchTextPhone
        {
            get
            {
                return searchTextphone;
            }
            set
            {
                searchTextphone = value;
            }
        }
        #endregion

    }
}
