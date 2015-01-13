using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AcTraining.Controllers
{
    public class CattyController : ApiController
    {
        public HttpResponseMessage GetImage()
        {
            var msg = new HttpResponseMessage
                      {
                          Content = new StringContent("ich bin ein Bild")
                      };
            msg.Content.Headers.Expires = DateTime.UtcNow.AddDays(7);

            return msg;
        }
    }
}
