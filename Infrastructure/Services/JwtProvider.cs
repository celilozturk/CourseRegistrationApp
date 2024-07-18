using Application.Services;
using Domain.Abstractions.Repositories;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Services;
internal class JwtProvider(IConfiguration configuration,IUserRoleRepository userRoleRepository, RoleManager<AppRole> roleManager) : IJwtProvider
{
    public async Task<string> CreateTokenAsync(AppUser user,CancellationToken cancellationToken)
    {
        List<AppUserRole> appUserRoles = await userRoleRepository.Where(x => x.UserId == user.Id).ToListAsync();
        List<AppRole> roles = new();
        foreach (var userRole in appUserRoles)
        {
            AppRole? role = await roleManager.Roles.Where(p => p.Id == userRole.RoleId).FirstOrDefaultAsync();
            if (role is not null)
            {
                roles.Add(role);
            }
        }
        List<string?> stringRoles = roles.Select(s => s.Name).ToList();
        List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.FullName),
                new Claim(ClaimTypes.Email,user.Email ?? string.Empty),
                new Claim("UserName",user.UserName ?? string.Empty),
                new Claim(ClaimTypes.Role, JsonSerializer.Serialize(stringRoles))
            };
        DateTime expires = DateTime.Now.AddDays(1);
        SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(configuration.GetSection("Jwt:SecretKey").Value ?? ""));
        SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha512);
        JwtSecurityToken jwtSecurityToken = new(
               issuer: configuration.GetSection("Jwt:Issuer").Value,
               audience: configuration.GetSection("Jwt:Audience").Value,
               claims: claims,
               notBefore: DateTime.Now,
               expires: null,
               signingCredentials: signingCredentials);
        JwtSecurityTokenHandler handler = new();
        string token = handler.WriteToken(jwtSecurityToken);
        return token;
    }
}
