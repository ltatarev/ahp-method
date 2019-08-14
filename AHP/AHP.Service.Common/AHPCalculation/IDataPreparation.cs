using AHP.Model.Common.Model_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHP.Service.Common.AHPCalculation
{
    public interface IDataPreparation
    {
        double[] NormalizeVector(double[] vector);
        double[][] Get2dArray(List<ICriteriaModel> criterias);
        double[] GetCriteriaRanks(List<ICriteriaModel> criterias);
    }
}
