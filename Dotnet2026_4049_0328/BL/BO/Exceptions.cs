using System;
using System.Runtime.Serialization;

namespace BO
{
    [Serializable]
    public class BlException : Exception
    {
        public BlException() { }
        public BlException(string message) : base(message) { }
        public BlException(string message, Exception innerException) : base(message, innerException) { }
        protected BlException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

    [Serializable]
    public class BlIdNotFoundException : BlException
    {
        public BlIdNotFoundException() { }
        public BlIdNotFoundException(string message) : base(message) { }
        public BlIdNotFoundException(string message, Exception innerException) : base(message, innerException) { }
        protected BlIdNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BlIdNotFoundException(int id, string entity, Exception? inner = null)
            : base($"BL: The {entity} with ID {id} was not found.", inner) { }
    }

    [Serializable]
    public class BlAlreadyExistsException : BlException
    {
        public BlAlreadyExistsException() { }
        public BlAlreadyExistsException(string message) : base(message) { }
        public BlAlreadyExistsException(string message, Exception innerException) : base(message, innerException) { }
        protected BlAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BlAlreadyExistsException(int id, string entity, Exception? inner = null)
            : base($"BL: The {entity} with ID {id} already exists.", inner) { }
    }
}
