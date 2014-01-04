using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetIRC;

namespace cah
{
    public class Player
    {
        private User _user;
        public List<WhiteCard> Hand;

        public Player(User user)
        {
            this._user = user;
            this.Hand = new List<WhiteCard>();
        }
    }
}
