using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using System.Security.Claims;

namespace EXP.Functions.OAuth.API
{
    public static class WebAPI
    {
        [FunctionName("WebAPI")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            string name = ClaimsPrincipal.Current.Identity.Name;
            string message = $"'{name}' is asking";

            log.Info(message);

            return req.CreateResponse(HttpStatusCode.OK, message);
        }
    }
}
