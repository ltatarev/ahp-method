using AHP.Model.Common.Model_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHP.Service.Common
{
    public interface IFinalResultCalculator
    {
        double[] AHPMethod(double[] CriteriaPreference, double[][] AlternativePreferences);
        Task<List<IAlternativeModel>> Calculate(Guid id);
    }
}
