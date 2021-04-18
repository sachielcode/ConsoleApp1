using System;
using WebSocketSharp;
using WebSocketSharp.Server;
namespace Example {
    public class Echo : WebSocketBehavior {
        protected override void OnMessage(MessageEventArgs e) {
            var msg = System.Text.Encoding.UTF8.GetString(e.RawData);
            Console.WriteLine("Got Message: " + msg);
            Send(msg);
        }
    }

    public class Program {
        public static void Main(string[] args) {
            var wssv = new WebSocketServer(8080);
            wssv.AddWebSocketService<Echo>("/");
            wssv.Start();
            Console.Read();
            wssv.Stop();
        }
    }
}