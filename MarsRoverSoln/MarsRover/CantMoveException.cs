using System;

namespace MarsRover
{
    public class CantMoveException : Exception
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public CantMoveException() : base()
        {

        }

        /// <summary>
        /// creates exception with the description message
        /// </summary>
        /// <param name="message">exception message</param>
        public CantMoveException(string message) : base(message)
        {

        }

        /// <summary>
        /// creates exception with description message and an inner cause
        /// </summary>
        /// <param name="message">exception message</param>
        /// <param name="innerException">inner exception</param>
        public CantMoveException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
