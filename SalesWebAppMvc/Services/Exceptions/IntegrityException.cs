using System;

namespace SalesWebAppMvc.Services.Exceptions
{
    public class IntegrityException : ApplicationException
    {
        public IntegrityException (string message) : base(message)
        {
        }
    }
}
