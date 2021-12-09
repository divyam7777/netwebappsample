using System;
using System.Text.Encodings.Web;

namespace NetWebAppSample
{
    public static class Web
    {
        private const string AppStyle = "<style>body { font-family: \"Segoe UI\", sans-serif; line-height: 1.4; } dt { font-weight: bold; } a { color: #224477; font-weight: bold; text-decoration: none; } a:hover { text-decoration: underline; }</style>";

        private const string AppTitle = ".NET web app sample";

        public static string GetStandardHtml(string body)
        {
            return ($"<!DOCTYPE html><html><head><meta charset=\"utf-8\"/><meta name=\"viewport\" content=\"width=device-width, initial-scale=1, maximum-scale=1\"/><title>{AppTitle}</title>{AppStyle}</head><body>{body}</body></html>");
        }

        public static string GetErrorHtml(Exception ex)
        {
            return Web.GetStandardHtml($"<h1>An error occurred</h1><p>{HtmlEncoder.Default.Encode(ex.Message + " [" + ex.GetType().ToString() + " @ " + ex.Source + "]")}</p>");
        }
    }
}