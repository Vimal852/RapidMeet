using RapidMeet.Application.DTOs.Auth;
using RapidMeet.Application.Interfaces;
using RapidMeet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using RapidMeet.Infrastructure.Data;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _context;
    private readonly IJwtService _jwtService;

    public UserService(ApplicationDbContext context, IJwtService jwtService)
    {
        _context = context;
        _jwtService = jwtService;
    }

    public async Task<AuthResponseDTO> RegisterAsync(User user, string password)
    {
        if (_context.Users.Any(u => u.Email == user.Email))
            throw new Exception("Email already exists");

        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        string token = _jwtService.GenerateToken(user);

        return new AuthResponseDTO
        {
            Token = token,
            FullName = user.Name,
            Email = user.Email
        };
    }

    public async Task<AuthResponseDTO> LoginAsync(AuthRequestDTO request)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.Email);
        if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            throw new Exception("Invalid credentials");

        string token = _jwtService.GenerateToken(user);

        return new AuthResponseDTO
        {
            Token = token,
            FullName = user.Name,
            Email = user.Email
        };
    }
}
