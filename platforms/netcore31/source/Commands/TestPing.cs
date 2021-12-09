using Microsoft.AspNetCore.Http;
using System;
using System.Net.NetworkInformation;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace NetWebAppSample.Commands
{
    public class TestPing
    {
        public static async Task Execute(HttpContext context)
        {
            var host = context.Request.Query["host"];

            try
            {
                if (string.IsNullOrEmpty(host))
                {
                    throw new Exception("A valid \"host\" parameter must be specified.");
                }

                using (var ping = new Ping())
                {
                    var pingReply = ping.Send(host);

                    if (pingReply.Status == IPStatus.Success)
                    {
                        await context.Response.WriteAsync(Web.GetStandardHtml($"<h1>Test succeeded</h1><p>The ping test succeeded (roundtrip time {pingReply.RoundtripTime} ms).</p>"));
                    }
                    else
                    {
                        await context.Response.WriteAsync(Web.GetStandardHtml($"<h1>Test failed</h1><p>The ping test failed (status {pingReply.Status}).</p>"));
                    }
                }
            }
            catch (Exception ex)
            {
                await context.Response.WriteAsync(Web.GetErrorHtml(ex));
            }
        }
    }
}