using RapidMeet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidMeet.Application.Interfaces
{
    // IJwtService.cs
    public interface IJwtService
    {
        string GenerateToken(User user);
    }

}
