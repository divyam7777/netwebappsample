using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace NetWebAppSample.Commands
{
    public class GetFileSystemEntries
    {
        public static async Task Execute(HttpContext context)
        {
            var path = context.Request.Query["path"];

            try
            {
                if (string.IsNullOrEmpty(path))
                {
                    var drives = DriveInfo.GetDrives();

                    await context.Response.WriteAsync(Web.GetStandardHtml($"<h1>Drives</h1>{((drives != null) && (drives.Length > 0) ? $"<p>{string.Join(string.Empty, drives.OrderBy(x => x.Name).Select(x => $"<a href=\"/GetFileSystemEntries?path={x.RootDirectory.FullName}\">{HtmlEncoder.Default.Encode(x.Name)}<br/>"))}</p>" : "<p>None</p>")}"));

                    return;
                }

                if (File.Exists(path))
                {
                    await context.Response.SendFileAsync(path);

                    return;
                }

                if (Directory.Exists(path))
                {
                    var directories = Directory.GetDirectories(path);

                    var files = Directory.GetFiles(path);

                    await context.Response.WriteAsync(Web.GetStandardHtml($"<h1>{HtmlEncoder.Default.Encode(path)}</h1><h2>Directories</h2>{((directories != null) && (directories.Length > 0) ? $"<p>{string.Join(string.Empty, directories.OrderBy(x => x).Select(x => $"<a href=\"/GetFileSystemEntries?path={x}\">{HtmlEncoder.Default.Encode(x)}</a><br/>"))}</p>" : "<p>None</p>")}<h2>Files</h2>{((files != null) && (files.Length > 0) ? $"<p>{string.Join(string.Empty, files.OrderBy(x => x).Select(x => $"<a href=\"/GetFileSystemEntries?path={x}\">{HtmlEncoder.Default.Encode(x)}</a><br/>"))}</p>" : "<p>None</p>")}"));

                    return;
                }

                await context.Response.WriteAsync(Web.GetStandardHtml($"<h1>{HtmlEncoder.Default.Encode(path)}</h1><p>Looks like the above path is either inaccessible or invalid.</p>"));
            }
            catch (Exception ex)
            {
                await context.Response.WriteAsync(Web.GetErrorHtml(ex));
            }
        }
    }
}