using System;
using System.Runtime.Serialization;

    [Serializable]
    internal class InvalidMapLayoutException : InvalidOperationException
{
        public InvalidMapLayoutException()
        {
        }

        public InvalidMapLayoutException(string message) : base(message)
        {
        }

        public InvalidMapLayoutException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidMapLayoutException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
