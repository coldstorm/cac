using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cac
{
    public class GameSettings
    {
        public int ScoreLimit;

        public int PlayerLimit;

        public GameSettings(string[] parameters)
        {
            this.ScoreLimit = Constants.DEFAULT_SCORE_LIMIT;
            this.PlayerLimit = Constants.DEFAULT_PLAYER_LIMIT;
        }
    }
}
