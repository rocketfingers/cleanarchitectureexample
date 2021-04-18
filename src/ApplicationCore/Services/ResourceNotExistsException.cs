using System;
using System.Runtime.Serialization;

namespace ApplicationCore.Exceptions
{
    [Serializable]
    public class ResourceNotExistsException : Exception
    {
        public ResourceNotExistsException()
        {
        }

        public ResourceNotExistsException(string message) : base(message)
        {
        }

        public ResourceNotExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ResourceNotExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}