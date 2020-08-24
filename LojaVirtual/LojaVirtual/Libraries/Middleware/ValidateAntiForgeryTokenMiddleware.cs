using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries.Middleware
{
    public class ValidateAntiForgeryTokenMiddleware
    {
        private RequestDelegate _next;
        private IAntiforgery _antiForgery;

        public ValidateAntiForgeryTokenMiddleware(RequestDelegate next, IAntiforgery antiForgery)
        {
            _next = next;
            _antiForgery = antiForgery;
        }

        public async Task Invoke(HttpContext context)
        {
            if (HttpMethods.IsPost(context.Request.Method))
            {
                await _antiForgery.ValidateRequestAsync(context);
            }

            await _next(context);
        }
    }
}
