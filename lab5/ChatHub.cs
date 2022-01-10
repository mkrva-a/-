using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace lab4
{
    public class ChatHub : Hub
    {
        private readonly ILogger<ChatHub> log;

        public ChatHub(ILogger<ChatHub> logger)
        {
            log = logger;
        }


        public async Task Send(IAsyncEnumerable<string> stream)
        {
            string outs = "";
            await foreach (var item in stream)
            {
                log.LogInformation($"клиент отправил: {item}");
                outs += item;
            }


            await Clients.All.SendAsync("Receive", outs);
        }


        public async IAsyncEnumerable<string> ReceiveHub(
            string s,
            int delay,
            [EnumeratorCancellation]
            CancellationToken cancellationToken)
        {
            
                cancellationToken.ThrowIfCancellationRequested();
                yield return s+"!";
                await Task.Delay(delay, cancellationToken);

   

        }
    }
}
