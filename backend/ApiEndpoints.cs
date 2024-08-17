using Microsoft.AspNetCore.Builder;

namespace backend
{
    public static class ApiEndpoints
    {
        public static void MapApiEndpoints(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/api/hello", () => new { Message = "Hello from .NET Minimal API!" });
        }
    }
}