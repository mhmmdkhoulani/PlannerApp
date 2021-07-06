using Microsoft.AspNetCore.Components;
using PlannetApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerApp.Components
{
    public partial class PlanCardsList
    {

        private bool _isBusy { get; set; }
        private int _pageNumber = 1;
        private int _pageSize = 10;
        private string _query = string.Empty;
        [Parameter]
        public Func<string, int,int,Task<PagedList<PlanSummary>>> FetchPlans { get; set; }
        
        private PagedList<PlanSummary> _result = new();

        protected async override Task OnInitializedAsync()
        {
            await GetPlansAsync(_pageNumber);
        }

        private async Task GetPlansAsync(int pageNumber)
        {
            _pageNumber = pageNumber;
            _isBusy = true;
            _result = await FetchPlans?.Invoke(_query, _pageNumber, _pageSize);
            _isBusy = false;
        }
    }
}
