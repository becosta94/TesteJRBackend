using System;

namespace apiToDo.Exceptions
{
    public class IdNotFoundException : Exception
    {
        public IdNotFoundException() : base() { }
        public IdNotFoundException(string message) : base(message) { }
    }
}
