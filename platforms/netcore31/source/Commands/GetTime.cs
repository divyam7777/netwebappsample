using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace NetWebAppSample.Commands
{
    public class GetTime
    {
        public static async Task Execute(HttpContext context)
        {
            var referenceDateTime = DateTime.Now;

            await context.Response.WriteAsync(Web.GetStandardHtml($"<h1>Time</h1><p>{referenceDateTime:yyyy-MM-dd HH':'mm':'ss'.'fff zzz}</p>"));
        }
    }
}