using BankApp.AdminPanel.Model;
using BankApp.Core.Domain.Entities;

namespace BankApp.AdminPanel.Mappers
{
    public class CardMapper : BaseMapper<Card, CardModel>
    {
        public override Card Map(CardModel model)
        {
            var card = new Card()
            {
                Id = model.Id,
                TypeCard = model.TypeCard,
                CardNumber = model.CardNumber,
                EndDate = model.EndDate,
            };

            if (model.Client != null)
            {
                var clientMapper = new ClientMapper();

                card.Client.Card = null;
                card.Client = clientMapper.Map(model.Client);
                card.Client.Card = card;
            }

            return card;
        }

        public override CardModel Map(Card entity)
        {
            var card = new CardModel()
            {
                Id = entity.Id,
                TypeCard = entity.TypeCard,
                CardNumber = entity.CardNumber,
                EndDate = entity.EndDate,
            };

            if (entity.Client != null)
            {
                var clientMapper = new ClientMapper();

                entity.Client.Card = null;
                card.Client = clientMapper.Map(entity.Client);
                card.Client.Card = card;
            }

            return card;
        }
    }
}