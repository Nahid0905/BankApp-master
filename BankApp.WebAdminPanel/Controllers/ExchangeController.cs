using BankApp.AdminPanel.DataContext;
using BankApp.AdminPanel.Mappers;
using BankApp.Core.DataAccess.Abstract;
using BankApp.WebAdminPanel.Models.Exchange;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.WebAdminPanel.Controllers
{
    public class ExchangeController : Controller
    {
        private readonly IUnitOfWork db;
        public ExchangeController(IUnitOfWork db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            /*DataProvider dataProvider = new DataProvider(db);
            var result = dataProvider.GetExchange();*/

            var exchanges = db.ExchangeRepository.Get();
            ExchangeMapper exchangeMapper = new ExchangeMapper();
            List<ExchangeModel> models = new List<ExchangeModel>();

            for (int i = 0; i < exchanges.Count; i++)
            {
                var exchange = exchanges[i];

                var ExchangeModel = exchangeMapper.Map(exchange);
                ExchangeModel.NO = i + 1;

                models.Add(ExchangeModel);
            }


            ExchangeViewModel viewModel = new ExchangeViewModel()
            {
                Exchanges = models
            };

            return View(viewModel);
        }

        public IActionResult Save(int id)
        {
            return PartialView();
        }
    }
}
