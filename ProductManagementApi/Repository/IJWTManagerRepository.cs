using ProductManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagementApi.Repository
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(User users);
    }
}
