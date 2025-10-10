using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Product.InventoryManagement.Application.Contracts.Auth;
using Product.InventoryManagement.Application.Models;
using Microsoft.AspNetCore.Identity;
using Product.InventoryManagement.Authentication.Models;
using Microsoft.Extensions.Options;
using Product.InventoryManagement.Application.Exceptions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace Product.InventoryManagement.Authentication.Services
{
    public class AuthService : IAuthService
    {
        /**
         * USER MANAGER - Responsible for querying the user in the database
         * SIGN-IN MANAGER - Responsible for verifying the credentials of the user
         * JWT - A token given to the user upon successful authentication that will serve as a verification that this user can perform the actions in the API
         * JWT SETTINGS - A model that represents what the token does such as when it expires, who issued, etc.
         * **/
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtSettings _jwtSettings;

        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<JwtSettings> jwtSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings.Value;
        }
        public async Task<AuthResponse> Login(AuthRequest request)
        {
            /**
             * FLOW
             * 1. Verify if user exists,
             * 2. Verify if password given matches the password of the user stored in the database
             * 3. Provide a token to the user that he could use in order to perform actions using the API
             * 
             * **/
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new NotFoundException($"User with {request.Email} not found", 123); // TODO: change NotFoundException to handle string
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (!result.Succeeded)
            {
                throw new BadRequestException($"Credentials for {request.Email} is not valid", new FluentValidation.Results.ValidationResult());
            }

            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

            var response = new AuthResponse
            {
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Email = user.Email,
                UserName = user.UserName,
            };

            return response;
        }

        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            /** 
             *  Generate token base on who this user is
             * 1. User Claims - Key value pairs that tell information about the user
             * 2. Roles - the group where the user belongs to
             * 3. roleClaims - converting the fetched roles of the user which is type string to type claim
             * 4. claims (base claims) - these are essential in creating the jwt token which includes the subject, the token identifier, and the email also with a custom claim that includes the id of the user
             * 5. combine the user claims (info about the user), and the role claims (the group where the user resides) with the base claims
             * 6. conver the key which will validate that this came from the server to a usable type that the signing credentials will use
             * 7. create the token based on the requirements
             * 
             * REQUIREMENTS
             * 1. Claims - consists of the base claims, user claims, and role claims
             * 2. Use the private jwt key and convert it to usable type that the signing algorithm could use
             * 3. Sign the credentials of the token using this converted key (this will be used to verify)
             * 4. combine these to create the token
             * **/
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);


            var roleClaims = roles.Select(roleValue => new Claim(ClaimTypes.Role, roleValue)).ToList();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));

            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }
    }
}
