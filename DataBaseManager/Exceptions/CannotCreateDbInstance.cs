using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseManager.Exceptions
{
    public class CannotCreateDbInstance : Exception
    {
        const string ExceptionMessage = "Creating the instance of database was failed";

        public CannotCreateDbInstance(string message)
            : base ($"{ExceptionMessage}: {message}")
        {

        }
        public CannotCreateDbInstance(string message, Exception inner)
            : base($"{ExceptionMessage}: {message}", inner)
        {

        }
    }
}
