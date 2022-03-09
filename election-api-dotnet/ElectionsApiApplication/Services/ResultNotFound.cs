using ElectionsApiApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElectionsApiApplication.Services
{
    public class ResultNotFound : NotFoundObjectResult
    {
        public ResultNotFound(int resultId) : base(new ApiResponse { Error = "not-found-001", Message = $"{resultId} not found" })
        {
        }
    }
}
