using System;


namespace ConsoleProgram.Infrastructure.Exceptions
{
    public class NotFoundExpception : Exception
    {
        public NotFoundExpception(string message) : base(message) { }

    }
}
