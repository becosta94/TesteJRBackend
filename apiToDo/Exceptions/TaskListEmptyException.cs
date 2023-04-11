using System;

namespace apiToDo.Exceptions
{
    public class TaskListEmptyException : Exception
    {
        public TaskListEmptyException() : base() { }
        public TaskListEmptyException(string message) : base(message) { }
    }
}
