using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidMeet.Application.DTOs.Auth
{
    public class AuthResponseDTO
    {
        public string Token { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }

}
