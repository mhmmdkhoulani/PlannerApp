using Microsoft.AspNetCore.Components;
using PlannerApp.Client.Services.Exceptions;
using PlannerApp.Client.Services.Interfaces;
using PlannetApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerApp.Components
{
    public partial class RegisterForm
    {
        [Inject]
        public IAuthenticationService AuthenticationService { get; set; }


        [Inject]
        public NavigationManager Navigation { get; set; }



        private RegisterRequest _model = new RegisterRequest();
        private string _errorMessage = string.Empty;
        private bool _isBusy = false;

        public async Task RegisterUserAsync()
        {
            _isBusy = true;
            _errorMessage = string.Empty;
            try
            {
                await AuthenticationService.RegisterUserRequsertAsync(_model);
               Navigation.NavigateTo("/authentication/login");
            }
            catch (ApiException ex)
            {
                //Handle api exception
                _errorMessage = ex.apiErrorResponse.Message;
            }
            catch (Exception ex)
            {
                //handle error
                _errorMessage = ex.Message;
            }
            _isBusy = false;
        }
        private void RedirectToLogin()
        {
            Navigation.NavigateTo("/authentication/login");
        }
    }
}
