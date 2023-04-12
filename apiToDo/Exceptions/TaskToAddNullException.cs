using System;

namespace apiToDo.Exceptions
{
    public class TaskToAddNullException : Exception
    {
        public TaskToAddNullException() : base() { }
        public TaskToAddNullException(string message) : base(message) { }
    }
}
