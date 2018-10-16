using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace CompanySystem.Web.Filters
{
    public class GlobalExceptionHandler : ExceptionHandler
    {
        private log4net.ILog _logger;
        public async override Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            // Access Exception
            // var exception = context.Exception;
          
            const string genericErrorMessage ="An unexpected error occured";
            var response = context.Request.CreateResponse(HttpStatusCode.InternalServerError,
                new
                {
                    Message = genericErrorMessage
                });

            response.Headers.Add(@"X - Error ", genericErrorMessage);
            _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            _logger.Error(response.Content);
            using (EventLog eventLog = new EventLog("CompanySystem"))
            {
                eventLog.Source = "Application";
                eventLog.WriteEntry(response.Content.ToString(), EventLogEntryType.Information, 101, 1);
            }
            //context.Result = new ResponseMessageResult(response);
        }
    }
}