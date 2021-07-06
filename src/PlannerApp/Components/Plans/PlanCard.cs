using Microsoft.AspNetCore.Components;
using PlannetApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerApp.Components
{
    public partial class PlanCard
    {
        [Parameter]
        public PlanSummary PlanSummary { get; set; } 

        [Parameter]
        public EventCallback<PlanSummary> OnViewClicked { get; set; }
        
        [Parameter]
        public EventCallback<PlanSummary> OnDeleteClicked { get; set; }
        
        [Parameter]
        public EventCallback<PlanSummary> OnEditClicked { get; set; }

    }
}
