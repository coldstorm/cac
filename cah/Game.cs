using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cah
{
    public class Game
    {
        private List<Player> Players;
        private GameState State;
        private BlackCard CurrentCard;
        private List<WhiteCard> WhiteDeck;
        private List<BlackCard> BlackDeck;

        public Game(string[] settings)
        {
            this.Players = new List<Player>();
            this.State = GameState.Lobby;
            this.WhiteDeck = new List<WhiteCard>();
            this.BlackDeck = new List<BlackCard>();
        }

        public void Start()
        {
            // Players should have already joined the game by this point.
            this.State = GameState.Dealing;
        }

        public void AddPlayer(Player player)
        {
            if (!this.Players.Contains(player))
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
    }
}
