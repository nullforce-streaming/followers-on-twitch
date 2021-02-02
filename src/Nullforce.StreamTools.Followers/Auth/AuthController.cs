using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Nullforce.StreamTools.Followers.Auth
{
    [Route("[controller]")]
    public class AuthController : Controller
    {
        [HttpGet("signin-twitch")]
        public IActionResult SignInTwitch() => Challenge(new AuthenticationProperties { RedirectUri = "/" }, "Twitch");

        [HttpGet("signout")]
        [HttpPost("signout")]
        public async Task<IActionResult> SignOutTwitch()
        {
            await HttpContext.SignOutAsync("Cookies");
            return Redirect("/");
        }
    }
}
