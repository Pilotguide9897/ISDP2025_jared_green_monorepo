using idsp2025_jared_green.Entities;
using idsp2025_jared_green.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace idsp2025_jared_green.Services
{
    internal class JsonWebTokenService : IJsonWebToken
    {
        private readonly IConfigurationRoot configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        private string? secretKey;   

        public string GenerateToken(string username, List<Posn> roles)
        {
            secretKey = configuration.GetValue<String>("JWTKey");

            // Claims are pieces of information about the user that are encoded into the token.
            List<Claim> claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, username)
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.ToString()));
            }

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "idsp2025_jared_green",
                audience: "idsp2025_jared_green",
                claims: claims,
                expires: DateTime.UtcNow.AddSeconds(300000),
                signingCredentials: signingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateToken(string username, List<Posn> roles, string location)
        {
            secretKey = configuration.GetValue<String>("JWTKey");

            // Claims are pieces of information about the user that are encoded into the token.
            List<Claim> claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim("location", location)
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.ToString()));
            }

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "idsp2025_jared_green",
                audience: "idsp2025_jared_green",
                claims: claims,
                expires: DateTime.UtcNow.AddSeconds(300000),
                signingCredentials: signingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            // I need to set the expiration period on my refresh token.
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;

        }

        public List<string> GetRolesFromToken(string token)
        {
            var principal = ValidateToken(token);
            if (principal == null) return new List<string>();

            // Extract roles from claims
            return principal.Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value)
                .ToList();
        }

        public List<string> ExtractUserInfoFromToken(string token)
        {

            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);

                var username = jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub)?.Value;
                var location = jwtToken.Claims.FirstOrDefault(c => c.Type == "location")?.Value;

                List<string> data = new List<string>();
                if (username != null && location != null)
                {
                    data.Add(username);
                    data.Add(location);
                }

                return data;
            }
            catch (Exception ex)
            {
                throw new SecurityTokenException();
            }
        }



        public string RefreshToken(IEnumerable<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "idsp2025_jared_green",
                audience: "idsp2025_jared_green",
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(300000),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        public ClaimsPrincipal? ValidateToken(string webToken)
        {
            // public override System.Security.Claims.ClaimsPrincipal ValidateToken(string token,
            // Microsoft.IdentityModel.Tokens.TokenValidationParameters validationParameters,
            // out Microsoft.IdentityModel.Tokens.SecurityToken validatedToken);
            TokenValidationParameters validationParameters = new TokenValidationParameters { 
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "idsp2025_jared_green",
                ValidAudience = "idsp2025_jared_green",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
            };

            var jwtHandler = new JwtSecurityTokenHandler();
            SecurityToken st;
            try
            {
                // A claims principal will be returned if it is successful. Otherwise, an exception will be thrown.
                ClaimsPrincipal principal = jwtHandler.ValidateToken(webToken, validationParameters, out st);
                return principal;
            }
            catch (SecurityTokenException stEx) 
            {
                // Log the error...
                return null;
            }
        }
    }
}
