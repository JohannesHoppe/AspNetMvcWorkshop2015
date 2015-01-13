using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Hosting;
using System.Web.Http;

namespace AcTraining.Controllers
{
    public class CattyController : ApiController
    {
        public HttpResponseMessage GetImage()
        {
            byte[] bytes = File.ReadAllBytes(HostingEnvironment.MapPath("~/Content/cat.jpg"));
            var response = new HttpResponseMessage(HttpStatusCode.OK) { Content = new ByteArrayContent(bytes) };
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
            response.Headers.CacheControl = new CacheControlHeaderValue
                {
                    Public = true,
                    MaxAge = TimeSpan.FromSeconds(24 * 7 * 60)
                };

            return response;
        }
    }
}
