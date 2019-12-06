using System;

namespace InterviewProject.Domain.Exceptions
{
    public class NetworkException : Exception
    {
        public NetworkException(string message) : base(message) { }
    }
}