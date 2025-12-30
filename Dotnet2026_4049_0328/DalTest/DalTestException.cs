using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalTest
{
    [Serializable]
    internal class DalTestException : Exception
    {
        public DalTestException(string? message) : base(message)
        {
            message = "DalTestException: " + message;
        }

        public class isNotFound() : DalTestException
        {
            public isNotFound(string? message) : base(message)
            {
                message = "isNotFound: " + message;
            }

            public isNotFound(string? message, Exception? innerException) : base(message, innerException)
            {
            }
        }




    }
}



namespace Dal
{
    [Serializable]
    internal class isNotFound : Exception
    {
        public isNotFound()
        {
        }

        public isNotFound(string? message) : base(message)
        {
        }

        public isNotFound(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}