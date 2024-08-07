﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pensopay.Parameters
{
    public enum SortDirection
    {
        asc,
        desc
    }

    public struct SortingParameters
    {
        public SortingParameters(string sortBy, SortDirection sortDirection)
        {
            SortBy = sortBy;
            SortDirection = sortDirection;
        }

        public string SortBy { get; set; }

        public SortDirection SortDirection { get; set; }
    }
}
