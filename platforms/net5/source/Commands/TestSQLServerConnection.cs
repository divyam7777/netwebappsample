using Microsoft.AspNetCore.Http;
using System;
using System.Data.SqlClient;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace NetWebAppSample.Commands
{
    public class TestSQLServerConnection
    {
        public static async Task Execute(HttpContext context)
        {
            var connectionString = context.Request.Query["connectionString"];

            try
            {
                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new Exception("A valid \"connectionString\" parameter must be specified.");
                }

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                }

                await context.Response.WriteAsync(Web.GetStandardHtml($"<h1>Test succeeded</h1><p>The SQL Server connection test succeeded.</p>"));
            }
            catch (Exception ex)
            {
                await context.Response.WriteAsync(Web.GetErrorHtml(ex));
            }
        }
    }
}