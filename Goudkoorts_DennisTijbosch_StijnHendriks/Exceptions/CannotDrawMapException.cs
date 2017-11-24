using System;
using System.Runtime.Serialization;

    [Serializable]
    internal class CannotDrawMapException : Exception
    {
        public CannotDrawMapException()
        {
        }

        public CannotDrawMapException(string message) : base(message)
        {
        }

        public CannotDrawMapException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CannotDrawMapException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }