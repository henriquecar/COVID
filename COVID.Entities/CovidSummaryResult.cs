using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COVID.Entities
{
    public class CovidSummaryResult
    {
        public dynamic Global { get; set; }
        public CovidCountry[] Countries { get; set; }
    }
}