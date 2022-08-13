using BankApp.AdminPanel.Mappers;
using BankApp.Core.DataAccess.Abstract;
using BankApp.WebAdminPanel.Models.Client;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.WebAdminPanel.Controllers
{
    public class ClientController : Controller
    {
        private readonly IUnitOfWork db;

        public ClientController(IUnitOfWork db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var clients = db.ClientRepository.Get();

            ClientMapper clientMapper = new ClientMapper();
            List<ClientModel> clientModels = new List<ClientModel>();

            for (int i = 0; i < clients.Count; i++)
            {
                var client = clients[i];
                var clientModel = clientMapper.Map(client);

                clientModel.NO = i + 1;
                clientModels.Add(clientModel);
            }

            ClientViewModel viewModel = new ClientViewModel()
            {
                ClientModels = clientModels
            };

            return View(viewModel);

        }
        public IActionResult Save(int id)
        {
            if (id == 0)
                return PartialView();

            ClientMapper clientMapper = new ClientMapper();

            var client = db.ClientRepository.Get(id);

            var clientModel = clientMapper.Map(client);
            return PartialView(clientModel);
        }

        [HttpPost]
        public IActionResult Save(ClientModel model)
        {
            ClientMapper clientMapper = new ClientMapper();

            var client = clientMapper.Map(model);

            db.ClientRepository.Insert(client);

            TempData["Message"] = "Operation successfully";

            return RedirectToAction("Index");
        }
    }
}
