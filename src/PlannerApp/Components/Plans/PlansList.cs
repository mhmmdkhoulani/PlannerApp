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
    public partial class PlansList
    {
        [Inject]
        public IPlansServices  PlansService { get; set; }

        private bool _isBusy = false;
        private string _errorMessage = string.Empty;
        private int _pageNumber = 1;
        private int _pageSize = 10;
        private string _query = string.Empty;
        private int _totalPages = 1;
        private List<PlanSummary> _plans = new();

        private async Task<PagedList<PlanSummary>> GetPlansAsync(string query = "", int pageNumber = 1, int pageSize = 10)
        {
            _isBusy = true;
            try
            {
                var result = await PlansService.GetPlansAsync(query, pageNumber, pageSize);
                _plans = result.Value.Records.ToList();
                _pageNumber = result.Value.Page;
                _pageSize = result.Value.PageSize;
                _totalPages = result.Value.TotalPages;
                return result.Value;
            }
            catch (ApiException ex)
            {
                _errorMessage = ex.apiErrorResponse.Message;
            }
            catch (Exception ex)
            {
                //TODO: Log this errors 
                _errorMessage = ex.Message;
              
            }
            _isBusy = false;
            return null;
        }

        #region view Toggler
        private bool _isCardVirewEnabled = true;

        private void SetCardView()
        {
            _isCardVirewEnabled = true;
        }
        private void SetTableView()
        {
            _isCardVirewEnabled = false;
        }
        #endregion
    }
}
