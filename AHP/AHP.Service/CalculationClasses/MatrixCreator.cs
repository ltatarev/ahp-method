using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHP.Service.CalculationClasses
{
    public class MatrixCreator
    {

        public double[,] CreateMatrix(int[] array, int dimension)
        {
            /// <summary>
            /// Method for creating square matrix out of a given array.
            /// </summary>
            /// <param name="array">Desired array for matrix</param>
            /// <param name="dimension">Desired matrix dimension</param>
            /// <returns>
            /// Matrix (dimension x dimension) with array elements as upper triangle, ones on diagonal 
            /// and lower triangle with values symmetrically reciprocal to upper triangle.
            /// </returns>

            int d = dimension;

            double[,] Matrix = new double[dimension, dimension];

            // Number of elements in upper triangle has to be (d * d - d) / 2
            if (array.Length == (d * d - d) / 2)
            {
                int k = 0;
                for (int i = 0; i < d; i++)
                {
                    Matrix[i, i] = 1;
                    for (int j = 0; j < d; j++)
                    {
                        if (j > i)
                        {

                            Matrix[i, j] = array[k];
                            k++;
                            Matrix[j, i] = 1 / Matrix[i, j];
                        }
                    }
                }
                return Matrix;
            }
            else
            {
                return null;
            }
        }  //posebna klasa
    }
}
