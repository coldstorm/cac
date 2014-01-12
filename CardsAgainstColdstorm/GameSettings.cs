using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsAgainstColdstorm
{
    public class GameSettings
    {
        public int ScoreLimit;

        public int PlayerLimit;

        public List<string> AllowedExpansions;

        public GameSettings(string[] parameters)
        {
            this.ScoreLimit = Constants.DefaultScoreLimit;
            this.PlayerLimit = Constants.DefaultPlayerLimit;
        }
    }
}
