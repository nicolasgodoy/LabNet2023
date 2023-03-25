using System;

namespace Lab.Logic.Excepciones
{
    public class FieldNullException : Exception
    {
        public FieldNullException(string message) : base(message)
        {
        }
    }
}
