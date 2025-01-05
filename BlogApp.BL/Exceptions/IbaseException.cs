using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.Exceptions
{
    public interface IbaseException
    {
        int Code { get; }   
        string ErrorMessage { get; }
    }
}
