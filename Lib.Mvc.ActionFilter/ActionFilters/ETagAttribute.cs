using System;
using System.IO;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace Lib.Mvc.ActionFilter.ActionFilters
{
    public class ETagAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Filter = new ETagFilter(filterContext);
        }
    }

    class ETagFilter : MemoryStream
    {
        private readonly HttpResponseBase _response;
        private readonly HttpRequestBase _request;
        private readonly Stream _filter;

        public ETagFilter(ControllerContext context)
        {
            _response = context.HttpContext.Response;
            _request = context.HttpContext.Request;
            _filter = context.HttpContext.Response.Filter;
        }

        public ETagFilter(HttpResponseBase response, HttpRequestBase request)
        {
            _response = response;
            _request = request;
            _filter = response.Filter;
        }

        private static string GetToken(Stream stream)
        {
            var checksum = MD5.Create().ComputeHash(stream);
            return Convert.ToBase64String(checksum, 0, checksum.Length);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            var data = new byte[count];
            Buffer.BlockCopy(buffer, offset, data, 0, count);
            var token = GetToken(new MemoryStream(data));

            var clientToken = _request.Headers["If-None-Match"];

            if (token != clientToken)
            {
                _response.Headers["ETag"] = token;
                _filter.Write(data, 0, count);
            }
            else
            {
                _response.SuppressContent = true;
                _response.StatusCode = 304;
                _response.StatusDescription = "Not Modified";
                _response.Headers["Content-Length"] = "0";
            }
        }
    }
}