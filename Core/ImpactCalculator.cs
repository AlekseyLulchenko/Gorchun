using Gorchun.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gorchun.Core
{
    public class ImpactCalculator
    {
        public CalculationResult Calculate(ImpactParameters parameters, Material material)
        {
            CalculationResult result = new CalculationResult
            {
                ImpactResult = Enums.ImpactResult.No,
                Recommendations = ""
            };

            return result;
        }
    }
}
