﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PlannetApp.Shared.Models
{
    public class PageList<T>
    {
        public int TotalPages { get; set; }
        public int ItemsCount { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public IEnumerable<T> Recoreds { get; set; }
    }
}
