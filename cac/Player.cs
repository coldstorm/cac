using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetIRC;

namespace CAC
{
    public class Player
    {
        public User User { get;  private set; }
        public List<WhiteCard> Hand;
        public int Points;

        public Player(User user)
        {
            this.User = user;
            this.Hand = new List<WhiteCard>();
            this.Points = 0;
        }
    }
}
