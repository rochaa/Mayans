using Mayans.Domain._Base;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Mayans.Api._Base
{
    public class HandlingMiddleware
    {
        private readonly RequestDelegate next;

        public HandlingMiddleware(RequestDelegate next) => this.next = next;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            List<string> errors;

            if (exception is DomainException)
            {
                var exDomain = exception as DomainException;
                code = HttpStatusCode.BadRequest;             
                errors = exDomain.Messages;
            }
            else
            {
                errors = new List<string>();
                errors.Add(exception.Message);
            }

            var result = JsonConvert.SerializeObject(new { errors });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}