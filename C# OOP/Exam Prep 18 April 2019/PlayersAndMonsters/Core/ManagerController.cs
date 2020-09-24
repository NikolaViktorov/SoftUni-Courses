    namespace PlayersAndMonsters.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using Contracts;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Models.BattleFields;
    using PlayersAndMonsters.Models.Cards;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Players;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories;
    using PlayersAndMonsters.Repositories.Contracts;

    public class ManagerController : IManagerController
    {
        private IPlayerRepository playerRepository;
        private ICardRepository cardRepository;
        private BattleField battleField;

        public ManagerController(IPlayerRepository playerRepository, ICardRepository cardRepository)
        {
            this.playerRepository = playerRepository;
            this.cardRepository = cardRepository;
            battleField = new BattleField();
        }

        public string AddPlayer(string type, string username)
        {
            if (type == "Beginner")
            {
                IPlayer player = new Beginner(new CardRepository(), username);
                this.playerRepository.Add(player);
            }
            else if (type == "Advanced")
            {
                IPlayer player = new Advanced(new CardRepository(), username);
                this.playerRepository.Add(player);
            }
            return string.Format(ConstantMessages.SuccessfullyAddedPlayer
                , type
                , username);
        }

        public string AddCard(string type, string name)
        {
            if (type == "Trap")
            {
                ICard card = new TrapCard(name);
                this.cardRepository.Add(card);
            }
            else if (type == "Magic")
            {
                ICard card = new MagicCard(name);
                this.cardRepository.Add(card);
            }
            return string.Format(ConstantMessages.SuccessfullyAddedCard
                , type
                , name);
        }

        public string AddPlayerCard(string username, string cardName)
        {
            IPlayer player = playerRepository.Find(username);
            ICard card = cardRepository.Find(cardName);
            player.CardRepository.Add(card);
            // maybe mistake
            return string.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards
                , cardName
                , username);
        }

        public string Fight(string attackUser, string enemyUser)
        {
            IPlayer attacker = playerRepository.Find(attackUser);
            IPlayer enemy = playerRepository.Find(enemyUser);
            battleField.Fight(attacker, enemy);

            return string.Format(ConstantMessages.FightInfo
                , attacker.Health
                , enemy.Health);
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();
            foreach (IPlayer player in playerRepository.Players)
            {
                result.AppendLine(string.Format(ConstantMessages.PlayerReportInfo
                    , player.Username
                    , player.Health
                    , player.CardRepository.Cards.Count));

                foreach (ICard card in player.CardRepository.Cards)
                {
                    result.AppendLine(string.Format(ConstantMessages.CardReportInfo
                    , card.Name
                    , card.DamagePoints));
                }
                
                result.AppendLine(ConstantMessages.DefaultReportSeparator);
            }

            return result.ToString().TrimEnd();
        }
    }
}
