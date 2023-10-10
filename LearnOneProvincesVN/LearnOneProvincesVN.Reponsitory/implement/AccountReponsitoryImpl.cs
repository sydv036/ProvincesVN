using LearnOneProvincesVN.Domain.Request;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LearnOneProvincesVN.Reponsitory.implement
{
    public class AccountReponsitoryImpl : IAccountReponsitory
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AccountReponsitoryImpl(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<IdentityUser> FinByEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<IdentityUser> FinByUserName(string UserName)
        {
            return await _userManager.FindByNameAsync(UserName);
        }

        public async Task<IdentityResult> Register(Register model)
        {
            var user = new IdentityUser
            {
                UserName = model.UserName,
                Email = model.Email,
            };
            var result = await _userManager.CreateAsync(user, model.PassWord);
            if (result.Succeeded)
            {
                _roleManager.CreateAsync(new IdentityRole("USER"));
                _userManager.AddToRoleAsync(user, "USER");
            }
            return result;
        }

        public async Task<string> SignIn(SignIn signIn)
        {
            var result = await _signInManager.PasswordSignInAsync(signIn.UserName, signIn.PassWord, false, false);
            if (result.Succeeded)
            {
                var authClaim = new List<Claim>
                {
                    new Claim("UserName", signIn.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                };
                var roles = new List<string> { "ADMIN", "USER" };
                foreach (var role in roles)
                {
                    authClaim.Add(new Claim(ClaimTypes.Role, role));
                }
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));
                var token = new JwtSecurityToken(
                        issuer: _configuration["JWT:ValidIssuer"],
                        audience: _configuration["JWT:ValidAudience"],
                        expires: DateTime.Now.AddHours(2),
                        claims: authClaim,
                        //ki vao token
                        signingCredentials: new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha512Signature)
                    );
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            return null;
        }
    }
}
