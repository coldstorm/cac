using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cah
{
    public class Game
    {
        private List<Player> _players;
        private GameState _state;

        public Game(string[] settings)
        {
            this._state = GameState.None;
        }

        public void Start()
        {
            this._state = GameState.Lobby;
        }

        public void AddPlayer(Player player)
        {
            if (!this._players.Contains(player))
            {
                this._players.Add(player);
            }
        }

        public void RemovePlayer(Player player)
        {
            if (this._players.Contains(player))
            {
                this._players.Remove(player);
            }
        }
    }
}
