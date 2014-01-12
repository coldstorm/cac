using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CardsAgainstColdstorm
{
    public class Game
    {
        private List<Player> Players;
        private GameState State;
        private BlackCard CurrentCard;
        private List<WhiteCard> WhiteDeck;
        private List<BlackCard> BlackDeck;
        private List<List<WhiteCard>> Table;
        private GameSettings Settings;
        private Thread GameThread;

        public Game(string[] parameters)
        {
            this.Players = new List<Player>();
            this.State = GameState.Lobby;
            this.WhiteDeck = this.LoadWhiteDeck("/data/white.txt");
            this.BlackDeck = this.LoadBlackDeck("/data/black.txt");
            this.Table = new List<List<WhiteCard>>();

            this.Settings = new GameSettings(parameters);
            this.GameThread = new Thread(DealingState);
        }

        private List<WhiteCard> LoadWhiteDeck(string path)
        {
            List<WhiteCard> deck = new List<WhiteCard>();
            StreamReader sr = new StreamReader(path);

            while (!sr.EndOfStream)
            {
                deck.Add(new WhiteCard("none", sr.ReadLine()));
            }

            return deck;
        }

        private List<BlackCard> LoadBlackDeck(string path)
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
            if (this.Players.Count < Constants.MinPlayers)
            {
                return;
            }

            // Shuffle decks
            this.WhiteDeck.Shuffle();
            this.BlackDeck.Shuffle();

            this.GameThread.Start();
        }

        private void DealingState()
        {
            this.State = GameState.Dealing;

            // Deal cards
            foreach (Player player in this.Players)
            {
                this.DealCards(player);
            }

            // Choose current black card
            this.CurrentCard = this.BlackDeck[this.BlackDeck.Count];
            this.BlackDeck.RemoveAt(this.BlackDeck.Count);

            this.PlayingState();
        }

        private void PlayingState()
        {
            this.State = GameState.Playing;

            while(this.Table.Count < this.Players.Count)
            {
                // Wait for players to submit their cards
            }

            this.JudgingState();
        }

        private void JudgingState()
        {
            this.State = GameState.Judging;
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

        private void DealCards(Player player)
        {
            while (player.Hand.Count <= Constants.MaxHand && 
                   this.WhiteDeck.Count > 0)
            {
                player.Hand.Add(this.WhiteDeck[this.WhiteDeck.Count]);
                this.WhiteDeck.RemoveAt(this.WhiteDeck.Count);
            }
        }
    }
}
