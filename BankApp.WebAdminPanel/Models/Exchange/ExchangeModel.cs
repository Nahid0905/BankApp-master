﻿using BankApp.WebAdminPanel.Models.Client;

namespace BankApp.WebAdminPanel.Models.Exchange
{
    public class ExchangeModel : BaseModel
    {
        public ClientModel Client { get; set; } = new ClientModel();
        public string Phone { get; set; }
        public int AmountFromExchange { get; set; }
        public int AmountToExchange { get; set; }
        public string ConvertFromCurrency { get; set; }
        public string ConvertToCurrency { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

    }
}
