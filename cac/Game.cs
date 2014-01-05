using System;
using System.Collections.Generic;
using System.IO;
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
            this.WhiteDeck = LoadWhiteDeck("/data/white.txt");
            this.BlackDeck = LoadBlackDeck("/data/black.txt");

            this.Settings = new GameSettings(parameters);
        }

        public List<WhiteCard> LoadWhiteDeck(string path)
        {
            List<WhiteCard> deck = new List<WhiteCard>();
            StreamReader sr = new StreamReader(path);

            while (!sr.EndOfStream)
            {
                deck.Add(new WhiteCard("none", sr.ReadLine()));
            }

            return deck;
        }

        public List<BlackCard> LoadBlackDeck(string path)
        {
            List<BlackCard> deck = new List<BlackCard>();
            StreamReader sr = new StreamReader(path);

            while (!sr.EndOfStream)
            {
                deck.Add(new BlackCard("none", sr.ReadLine()));
            }

            return deck;
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
