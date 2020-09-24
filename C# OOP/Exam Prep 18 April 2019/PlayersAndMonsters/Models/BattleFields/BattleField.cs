using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }
            UpgradeIfBeginner(attackPlayer);
            UpgradeIfBeginner(enemyPlayer);

            UpgradePlayer(attackPlayer);
            UpgradePlayer(enemyPlayer);

            int attackPlayerDmg = GetPlayerDamage(attackPlayer);
            int enemyPlayerDmg = GetPlayerDamage(enemyPlayer);

            while (true)
            {
                enemyPlayer.TakeDamage(attackPlayerDmg);
                if (enemyPlayer.IsDead)
                {
                    break;
                }
                attackPlayer.TakeDamage(enemyPlayerDmg);
                if (attackPlayer.IsDead)
                {
                    break;
                }
            }
        }
        public int GetPlayerDamage(IPlayer player)
        {
            return player
                .CardRepository
                .Cards
                .Sum(c => c.DamagePoints);
        }

        public void UpgradePlayer(IPlayer player)
        {
            int playerBonusHP = player
                .CardRepository
                .Cards
                .Sum(c => c.HealthPoints);
            player.Health += playerBonusHP;
        }
        public void UpgradeIfBeginner(IPlayer player)
        {
            if (player is Beginner)
            {
                player.Health += 40;
                foreach (ICard card in player.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }
        }
    }
}
