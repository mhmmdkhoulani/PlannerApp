
using System;
using System.Collections.Generic;
using System.Text;

namespace PlannetApp.Shared.Models
{
    public class LoginResult
    {
        public string Token { get; set; }
        public DateTime ExpiryDate { get; set; }

    }
}
