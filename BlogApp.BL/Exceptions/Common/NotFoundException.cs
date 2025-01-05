using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.Exceptions.Common
{
    public class NotFoundException<T>:Exception,IbaseException
    {
        public int Code => StatusCodes.Status404NotFound;

        public string ErrorMessage { get; }
        public NotFoundException():base(nameof(T) + "Not Found")
        {
            ErrorMessage = nameof(T) + "Not Found";
        }

        public NotFoundException(string message) : base(message)
        {
            ErrorMessage = message;
        }
    }
}
