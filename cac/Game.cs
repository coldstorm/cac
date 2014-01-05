using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cac
{
    public class Game
    {
        private List<Player> Players;
        private GameState State;
        private BlackCard CurrentCard;
        private List<WhiteCard> WhiteDeck;
        private List<BlackCard> BlackDeck;
        private GameSettings Settings;

        public Game(string[] parameters)
        {
            this.Players = new List<Player>();
            this.State = GameState.Lobby;
            this.WhiteDeck = new List<WhiteCard>();
            this.BlackDeck = new List<BlackCard>();

            this.Settings = new GameSettings(parameters);
        }

        public void Start()
        {
            if (this.Players.Count < Constants.MIN_PLAYERS)
            {
                return;
            }

            // Players should have already joined the game by this point.
            this.State = GameState.Dealing;

            // Shuffle decks
            Helper.Shuffle(WhiteDeck);
            Helper.Shuffle(BlackDeck);

            // Deal cards
            foreach (Player player in this.Players)
            {
                DealCards(player);
            }

            this.State = GameState.Playing;
        }

        public void AddPlayer(Player player)
        {
            if (!this.Players.Contains(player) &&
                this.Players.Count < this.Settings.PlayerLimit)
            {
                this.Players.Add(player);
            }
        }

        public void RemovePlayer(Player player)
        {
            if (this.Players.Contains(player))
            {
                this.Players.Remove(player);
            }
        }

        public void DealCards(Player player)
        {
            while (player.Hand.Count <= Constants.MAX_HAND && 
                   this.WhiteDeck.Count > 0)
            {
                player.Hand.Add(this.WhiteDeck[this.WhiteDeck.Count]);
                this.WhiteDeck.Remove(this.WhiteDeck[this.WhiteDeck.Count]);
            }
        }
    }
}
