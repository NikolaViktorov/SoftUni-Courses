using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        public int Count => Players.Count;

        private readonly List<IPlayer> players;
        public IReadOnlyCollection<IPlayer> Players => players.AsReadOnly();

        public void Add(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }
            if (players.Any(p => p.Username == player.Username))
            {
                throw new ArgumentException($"Player {player.Username} already exists!");
            }
            players.Add(player);
        }

        public IPlayer Find(string username) => players.FirstOrDefault(p => p.Username == username);

        public PlayerRepository()
        {
            players = new List<IPlayer>();
        }

        public bool Remove(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }
            return players.Remove(player);
        }
    }
}
