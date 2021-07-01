using System;
using System.Collections.Generic;
using System.Text;

namespace MyVirtualFactory.Application.Interfaces
{
    public interface IAuthenticatedUserService
    {
        string UserId { get; }
    }
}
