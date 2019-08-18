using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace HttpClientDemo013
{
    public class MyHttpClientHandler:DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //处理request
            var response= base.SendAsync(request, cancellationToken);
            //处理response

            return response;
        }
    }
}
