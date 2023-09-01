using System.Security.Claims;

namespace EmployeeManagement.Domain
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue(ClaimTypes.Upn);
        }
    }
}
