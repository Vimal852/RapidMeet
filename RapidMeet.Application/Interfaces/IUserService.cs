using RapidMeet.Application.DTOs.Auth;
using RapidMeet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidMeet.Application.Interfaces
{
    public interface IUserService
    {
        Task<AuthResponseDTO> LoginAsync(AuthRequestDTO request);
        Task<AuthResponseDTO> RegisterAsync(User user, string password);
    }
}
