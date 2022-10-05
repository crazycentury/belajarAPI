using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : Controller
    {
        //private readonly IConfiguration _configuration;
        //public TokenController(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        //[HttpGet]
        //[Route("GenerateToken")]
        //public ActionResult GenerateToken()
        //{
            
        //    string jwtToken = CreateToken();
        //    // logic to create token
        //    return Ok(jwtToken);
        //}
        //[HttpGet]
        //[Route("ValidateToken")]
        //[Authorize]
        //public ActionResult ValidateToken()
        //{
          
        //    return Ok("Congrats, your token is right!");
        //}


        //public string CreateToken()
        //{
        //    List<Claim> claims = new List<Claim>
        //    {
        //        new Claim(ClaimTypes.Name, "string")
        //    };

        //    var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
        //        _configuration.GetSection("Jwt:Token").Value));

        //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        //    var token = new JwtSecurityToken(
        //        claims: claims,
        //        expires: DateTime.Now.AddDays(1),
        //        signingCredentials: creds);

        //    var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        //    return jwt;
        //}

        //public IEnumerable<Claim>? ValidateJwtToken(string token)
        //{
        //    if (token == null)
        //        return null;

        //    try
        //    {
        //        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        //        SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
        //            _configuration.GetSection("Jwt:Token").Value));

        //        tokenHandler.ValidateToken(token, new TokenValidationParameters
        //        {
        //            ValidateIssuerSigningKey = true,
        //            IssuerSigningKey = key,
        //            ValidateLifetime = true,
        //            ClockSkew = TimeSpan.Zero
        //        }, out SecurityToken validatedToken);

        //        JwtSecurityToken jwtToken = (JwtSecurityToken)validatedToken;
        //        IEnumerable<Claim> claims = jwtToken.Claims;

        //        return claims;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}
    }
}

