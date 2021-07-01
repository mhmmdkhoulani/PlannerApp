using PlannetApp.Shared.Models;
using PlannetApp.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannerApp.Client.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<ApiResponse> RegisterUserRequsertAsync(RegisterRequest model);
    }
}
