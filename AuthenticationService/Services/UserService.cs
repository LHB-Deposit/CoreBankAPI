using AuthenticationAPIService.Interfaces;
using AuthenticationService.Data;
using AuthenticationService.Helpers;
using AuthenticationService.Models;
using Core.Utility;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace AuthenticationAPIService.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationSQLContext context;
        private readonly AppSettings appSettings;
        public UserService(ApplicationSQLContext context, IOptions<AppSettings> appSettings)
        {
            this.context = context;
            this.appSettings = appSettings.Value;
        }
        public UserProfileResponse Authenticate(AuthenticateModel authenticate)
        {
            UserProfileResponse userResponse = null;
            var user = context.UserProfiles.SingleOrDefault(s => s.UserId == authenticate.Username && s.ActiveStatus == true);

            if (user == null) return userResponse;
            bool isMatched = Cryptography.VerifyPassword(authenticate.Password, user.Hash, user.Salt);
            if (!isMatched) return userResponse;

            user.LastLogin = DateTime.Now;
            context.UserProfiles.Update(user);
            context.SaveChanges();

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.SECRET);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId),
                new Claim(ClaimTypes.Name, user.NameEN),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddSeconds(int.Parse(appSettings.Expiration))).ToUnixTimeSeconds().ToString()),
            };

            var token = new JwtSecurityToken(
                new JwtHeader(
                    new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256)),
                new JwtPayload(claims));

            userResponse = new UserProfileResponse
            {
                UserId = user.UserId,
                AccessToken = tokenHandler.WriteToken(token)
            };

            return userResponse;
        }

        public IEnumerable<UserProfile> GetUser()
        {
            return context.UserProfiles.ToList();
        }

        public void Register(RegisterModel register)
        {
            HashSalt hashSalt = Cryptography.GenerateSaltedHash(register.Password);
            register.Hash = hashSalt.Hash;
            register.Salt = hashSalt.Salt;
            register.ActiveStatus = true;
            register.CreateDate = DateTime.Now;
            context.UserProfiles.Add(register);
            context.SaveChanges();
        }
    }
}
