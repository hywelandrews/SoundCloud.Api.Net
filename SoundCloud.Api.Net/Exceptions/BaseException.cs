using System;
using RestSharp;

namespace SoundCloud.Api.Net.Exceptions
{
    public abstract class BaseException : ApplicationException
    {
        public IRestRequest Request { get; private set; }
        public string ErrorMessage { get; private set; }

        protected BaseException(IRestRequest request, string errorMessage)
        {
            Request = request;
            ErrorMessage = errorMessage;
        }
    }
}
