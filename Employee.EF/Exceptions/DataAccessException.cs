namespace EM.EF.Exceptions
{
    public class DataAccessException : Exception
    {
        // Default constructor
        public DataAccessException() { }

        // Constructor that accepts a message
        public DataAccessException(string message) : base(message) { }

        // Constructor that accepts a message and an inner exception
        public DataAccessException(string message, Exception innerException)
            : base(message, innerException) { }

    }
}
