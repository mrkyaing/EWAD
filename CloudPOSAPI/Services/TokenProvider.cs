using System.Security.Claims;

namespace CloudPOSAPI.Services
{
    public class TokenProvider : ITokenProvider
    {
        private readonly IHttpContextAccessor _context;
        public TokenProvider(IHttpContextAccessor context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public string GetUserId()
        {
            return _context.HttpContext.User.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value;
        }
    }
}
