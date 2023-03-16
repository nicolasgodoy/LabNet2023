using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Logic.Excepciones
{
    public class EntityFoundException : Exception
    {
        public EntityFoundException(string message) : base(message)
        {
        }
    }
}
