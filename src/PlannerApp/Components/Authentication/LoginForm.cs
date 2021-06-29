using Microsoft.AspNetCore.Components;
using PlannetApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PlannerApp.Components
{
    public partial class LoginForm : ComponentBase
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        private LoginRequest _model = new LoginRequest(); 

        public async Task LoginUserAsync()
        {
            throw new NotSupportedException();
        }
    }
}
