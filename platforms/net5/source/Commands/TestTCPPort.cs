using Microsoft.AspNetCore.Http;
using System;
using System.Net.Sockets;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace NetWebAppSample.Commands
{
    public class TestTCPPort
    {
        public static async Task Execute(HttpContext context)
        {
            var host = context.Request.Query["host"];
            var port = context.Request.Query["port"];

            try
            {
                if (string.IsNullOrEmpty(host))
                {
                    throw new Exception("A valid \"host\" parameter must be specified.");
                }

                if (string.IsNullOrEmpty(port))
                {
                    throw new Exception("A valid \"port\" parameter must be specified.");
                }

                using (var tcpClient = new TcpClient())
                {
                    tcpClient.Connect(host, int.Parse(port));
                }

                await context.Response.WriteAsync(Web.GetStandardHtml($"<h1>Test succeeded</h1><p>The TCP port test succeeded.</p>"));
            }
            catch (Exception ex)
            {
                await context.Response.WriteAsync(Web.GetErrorHtml(ex));
            }
        }
    }
}