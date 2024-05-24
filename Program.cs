using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Microsoft.VisualBasic;
namespace Ds_bot
{
    class Programm
    {
        DiscordSocketClient client = new DiscordSocketClient();
        static void Main(string[] args)
          => new Programm().MainAsync().GetAwaiter().GetResult();

        private async Task MainAsync()
        {
            client = new DiscordSocketClient();
            client.MessageReceived += CommandsHandler;
            client.Log += Log;

            var token = "MTI0MzMwMTExNDExMjM4MTE2OA.GirRQi.UIKiPMkWIO_w0bedpyBSxRJPXKVmdR39_fECDQ";

            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();

            Console.ReadLine();
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;  
        }

        private async Task CommandsHandler(SocketMessage msg)
        {
            if (!msg.Author.IsBot)
            {
                var likeEmoji = new Emoji("👍");
                await msg.AddReactionAsync(likeEmoji);
            }
        }
    }
}
