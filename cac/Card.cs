using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAC
{
    public class Card
    {
        public string Expansion;
        public string Text;

        public Card(string expansion, string text)
        {
            this.Expansion = expansion;
            this.Text = text;
        }
    }
}
