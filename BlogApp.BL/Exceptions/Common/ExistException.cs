using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.Exceptions.Common
{
    public class ExistException<T> : Exception, IbaseException
    {
        public int Code => StatusCodes.Status409Conflict;

        public string ErrorMessage {  get;  }
        public ExistException() :base(typeof(T).Name + "is exist")
        {
            ErrorMessage = typeof(T).Name + "is exist";
        }
        public ExistException(string msg):base(msg) 
        {
            ErrorMessage = msg;
        }
    }
}
