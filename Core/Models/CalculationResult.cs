using Gorchun.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gorchun.Core.Models
{
    public class CalculationResult
    {
        public ImpactResult ImpactResult { get; set; }
        public string Recommendations { get; set; }
    }
}
