using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace NetWebAppSample.Commands
{
    public class GetEnvironment
    {
        public static async Task Execute(HttpContext context)
        {
            string machineName = "Unknown";

            try
            {
                machineName = Environment.MachineName;
            }
            catch
            {
            }

            int processorCount = -1;

            try
            {
                processorCount = Environment.ProcessorCount;
            }
            catch
            {
            }

            string osVersion = "Unknown";

            try
            {
                osVersion = Environment.OSVersion.ToString();
            }
            catch
            {
            }

            string is64BitOperatingSystem = "Unknown";

            try
            {
                is64BitOperatingSystem = Environment.Is64BitOperatingSystem ? "Yes" : "No";
            }
            catch
            {
            }

            string clrVersion = "Unknown";

            try
            {
                clrVersion = Environment.Version.ToString();
            }
            catch
            {
            }

            string commandLine = "Unknown";

            try
            {
                commandLine = Environment.CommandLine;
            }
            catch
            {
            }

            string currentDirectory = "Unknown";

            try
            {
                currentDirectory = Environment.CurrentDirectory;
            }
            catch
            {
            }

            Dictionary<string, string> environmentVariables = null;

            try
            {
                var rawEnvironmentVariables = Environment.GetEnvironmentVariables();

                if ((rawEnvironmentVariables != null) && (rawEnvironmentVariables.Keys.Count > 0))
                {
                    environmentVariables = new Dictionary<string, string>();

                    foreach (var rawKey in rawEnvironmentVariables.Keys)
                    {
                        environmentVariables.Add(rawKey.ToString(), rawEnvironmentVariables[rawKey].ToString());
                    }
                }
            }
            catch
            {
            }

            await context.Response.WriteAsync(Web.GetStandardHtml($"<h1>Environment</h1><dl><dt>Machine name</dt><dd>{HtmlEncoder.Default.Encode(machineName)}</dd><dt>Processor count</dt><dd>{processorCount}</dd><dt>Operating system version</dt><dd>{HtmlEncoder.Default.Encode(osVersion)}</dd><dt>Is 64-bit operating system</dt><dd>{is64BitOperatingSystem}</dd><dt>CLR version</dt><dd>{HtmlEncoder.Default.Encode(clrVersion)}</dd><dt>Command line</dt><dd>{HtmlEncoder.Default.Encode(commandLine)}</dd><dt>Current directory</dt><dd>{HtmlEncoder.Default.Encode(currentDirectory)}</dd></dl><h1>Environment variables</h1>{((environmentVariables != null) && (environmentVariables.Keys.Count > 0) ? $"<dl>{string.Join(string.Empty, environmentVariables.Keys.OrderBy(x => x).Select(x => $"<dt>{HtmlEncoder.Default.Encode(x)}</dt><dd>{HtmlEncoder.Default.Encode(environmentVariables[x])}</dd>"))}</dl>" : "<p>None</p>")}"));
        }
    }
}