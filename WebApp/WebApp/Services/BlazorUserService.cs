using Application.Service.Interfaces;
using System.Security.Claims;

namespace WebUI.Services
{
    public class BlazorUserService : ICurrentUserService
    {

        private readonly IHttpContextAccessor _httpContextAccessor;

        public BlazorUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int? UserId
        {
            get
            {
                var userIdString = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

                if (int.TryParse(userIdString, out int userId))
                {
                    return userId;
                }

                return null;
            }
        }
    }
}
