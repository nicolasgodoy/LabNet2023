using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Logic.Excepciones
{
    public class FieldLenghtInvalidException : Exception
    {
        public FieldLenghtInvalidException(string message) : base(message)
        {
        }

    }
}
