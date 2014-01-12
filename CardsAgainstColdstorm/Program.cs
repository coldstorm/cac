using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetIRC;

namespace CardsAgainstColdstorm
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            client.Connect("frogbox.es", 6667, false, new User("cah", "FFFFFFCA", "Cards Against Coldstorm"));
            client.OnConnect += client_OnConnect;
            client.OnChannelJoin += client_OnChannelJoin;

            Console.ReadLine();
        }

        static void client_OnConnect(Client client)
        {
            client.JoinChannel(Constants.GameChannelName);
        }

        static void client_OnChannelJoin(Client client, Channel channel)
        {
            channel.OnMessage += channel_OnMessage;
            channel.OnLeave += channel_OnLeave;
        }

        static void channel_OnMessage(Channel source, User user, string message)
        {
            throw new NotImplementedException();
        }

        static void channel_OnLeave(Channel source, User user, string reason)
        {
            throw new NotImplementedException();
        }
    }
}
