using System;

namespace Lab.Logic.Excepciones
{
    public class EntityFoundException : Exception
    {
        public EntityFoundException(string message) : base(message)
        {
        }
    }
}
