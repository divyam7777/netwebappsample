using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace NetWebAppSample.Commands
{
    public static class GetConnection
    {
        public static async Task Execute(HttpContext context)
        {
            ConnectionInfo connection = null;

            try
            {
                connection = context.Connection;
            }
            catch
            {
            }

            HttpRequest request = null;

            try
            {
                request = context.Request;
            }
            catch
            {
            }

            Dictionary<string, string> requestHeaders = null;

            try
            {
                var rawRequestHeaders = context.Request.Headers;

                if ((rawRequestHeaders != null) && (rawRequestHeaders.Keys.Count > 0))
                {
                    requestHeaders = new Dictionary<string, string>();

                    foreach (var rawRequestHeader in rawRequestHeaders)
                    {
                        requestHeaders.Add(rawRequestHeader.Key, rawRequestHeader.Value.ToString());
                    }
                }
            }
            catch
            {
            }

            await context.Response.WriteAsync(Web.GetStandardHtml($"<h1>Connection</h1><dl><dt>Remote ip address</dt><dd>{((connection != null) ? connection.RemoteIpAddress.ToString() : "Unknown")}</dd><dt>Remote port</dt><dd>{((connection != null) ? connection.RemotePort.ToString() : "Unknown")}</dd><dt>Local ip address</dt><dd>{((connection != null) ? connection.LocalIpAddress.ToString() : "Unknown")}</dd><dt>Local port</dt><dd>{((connection != null) ? connection.LocalPort.ToString() : "(Unknown)")}</dd></dl><h1>Request</h1><dl><dt>Protocol</dt><dd>{((request != null) ? HtmlEncoder.Default.Encode(request.Protocol) : "(Unknown)")}</dd><dt>Scheme</dt><dd>{((request != null) ? request.Scheme : "Unknown")}</dd><dt>IsHttps</dt><dd>{((request != null) ? (request.IsHttps ? "Yes" : "No") : "Unknown")}</dd></dl><h1>Request headers</h1>{((requestHeaders != null) && (requestHeaders.Keys.Count > 0) ? $"<dl>{string.Join(string.Empty, requestHeaders.Keys.Select(x => $"<dt>{HtmlEncoder.Default.Encode(x)}</dt><dd>{HtmlEncoder.Default.Encode(requestHeaders[x])}</dd>"))}</dl>" : "<p>Unknown</p>")}"));
        }
    }
}