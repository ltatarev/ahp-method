using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHP.Service.Common.AHPCalculation
{
    public interface IMatrixCreator
    {
        double[,] CreateMatrix(double[] array, int dimension);
    }
}
