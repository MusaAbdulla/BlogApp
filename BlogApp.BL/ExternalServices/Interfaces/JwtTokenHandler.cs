using BlogApp.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.ExternalServices.Interfaces
{
    public interface IJwtTokenHandler
    {
        string CreatToken(User user,int hours);
    }
}
