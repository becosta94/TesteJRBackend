using System;

namespace apiToDo.Exceptions
{
    public class ExistingIdException : Exception
    {
        public ExistingIdException() : base() { }
        public ExistingIdException(string message) : base(message) { }
    }
}
