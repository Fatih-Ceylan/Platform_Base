namespace Platform.Api.Middlewares
{
    public class RefererCheckMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _allowedReferer;

        //public RefererCheckMiddleware(RequestDelegate next, string allowedReferer)
        //{
        //    _next = next;
        //    _allowedReferer = allowedReferer;
        //}

        //public async Task Invoke(HttpContext context)
        //{
        //    if (context.Request.Headers.TryGetValue("Referer", out var refererValues))
        //    {

        //        var referer = context.Request.Headers["Referer"].ToString();
        //        if (referer == _allowedReferer)
        //        {
        //            await _next(context);
        //              context.Response.StatusCode = StatusCodes.Status200OK;
                    
        //        }
        //        else
        //        {
        //            context.Response.StatusCode = 403; // Forbidden
        //            await context.Response.WriteAsync("Forbidden");
        //        }
        //    }

        //    //context.Response.StatusCode = StatusCodes.Status403Forbidden;
        //    //await context.Response.WriteAsync("Forbidden");
        //}
    }
}
