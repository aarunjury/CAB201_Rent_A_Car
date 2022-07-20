using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRRC
{
    /// <summary>
    /// Custom exception for when more or less than exactly 3 command line arguments
    /// are entered for the file paths of the three files that are loaded (CRM, Fleet, Rentals)
    /// </summary>
    public class FileHandlingException : Exception
    {
        public FileHandlingException() { }

        public FileHandlingException(string message) : base(message) { }

        public FileHandlingException(string message, Exception inner) : base(message, inner) { }
    }
}
