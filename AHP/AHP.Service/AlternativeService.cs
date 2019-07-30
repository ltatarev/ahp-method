using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHP.Service.Common;
using AHP.Repository.Common;
using AHP.Model.Common.Model_Interfaces;

namespace AHP.Service
{
    public class AlternativeService : IAlternativeService
    {
        #region Constructors
        public AlternativeService(IAlternativeRepository repository, IUnitOfWorkFactory uowFactory)
        {
            this.Repository = repository;
            this.uowFactory = uowFactory;
        }
        #endregion Constructors
        #region Properties
        protected IAlternativeRepository Repository { get; private set; }
        protected IUnitOfWorkFactory uowFactory;
        #endregion Properties

        #region Methods
        public double[] NormalizeVector(double[] vector)
        {
            /// <summary>
            /// Method for normalizing vector.
            /// </summary>
            /// <param name="vector">Input vector that needs to be normalized</param>
            /// <returns>
            /// Normalized vector.
            /// </returns>

            int len = vector.Length;
            double sum = 0;

            double[] NormalizedVector = new double[len];

            for (int i = 0; i < len; i++)
            {
                sum += vector[i];
            }

            for (int i = 0; i < len; i++)
            {
                NormalizedVector[i] = vector[i] / sum;
            }

            return NormalizedVector;
        }  //posebna klasa

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

        public double[] CalculatePriority(double[,] Matrix)
        {
            /// <summary>
            /// Method for calculating priorities of given parameters (criterion or alternatives).
            /// </summary>
            /// <param name="Matrix">Square parameter matrix.</param>
            /// <returns>
            /// Array of priorities.
            /// </returns>

            // Matrix size
            int len = Matrix.GetLength(0);

            // Array of geometric means
            double[] GeoMeans = new double[len];

            double sum = 0;
            for (int i = 0; i < len; i++)
            {
                double prod = 1;
                for (int j = 0; j < len; j++)
                {
                    prod *= Matrix[i, j];
                }
                GeoMeans[i] = Math.Pow(prod, (1 / (float)len));
                sum += GeoMeans[i];
            }

            return NormalizeVector(GeoMeans);
        }         //posebna klasa

        public double[] AHPMethod(int[] CriteriaPreference, int[][] AlternativePreferences)
        {
            /// <summary>
            /// Method for calculating final decision using AHP method, with given criteria preferences and alternative preference for every criterion.
            /// </summary>
            /// <param name="CriteriaPreference">Array of criterion preferences</param>
            /// <param name="AlternativePreferences">Jagged array of alternative preferences for every criterion</param>
            /// <returns>
            /// Array of priorities for every alternative.
            /// </returns>

            //int[] Kriterij = new int[(m * m - m) / 2];
            //int[] Kriterij = new int[] { 1, 3, 5 };

            int numberOfCriterions = CriteriaPreference.Length;
            int numberOfAlternatives = AlternativePreferences.Length;

            double[] CriteriaPriority = new double[numberOfCriterions];
            CriteriaPriority = CalculatePriority(CreateMatrix(CriteriaPreference, numberOfCriterions));

            // Matrix containing final weights
            // w_{i,j} = priority of i-th alternative considering j-th criterion
            double[,] W = new double[numberOfAlternatives, numberOfCriterions];

            for (int i = 0; i < numberOfCriterions; i++)
            {
                // Array of Alternative preferences considering i-th criterion
                int[] currentAlternatives = AlternativePreferences[i];

                // Array of priorities considering i-th criterion
                double[] AlternativePriority = CalculatePriority(CreateMatrix(currentAlternatives, numberOfAlternatives));

                for (int j = 0; j < numberOfAlternatives; j++)
                {
                    // Setting i-th column of matrix W to priorities of all alternatives
                    W[j, i] = AlternativePriority[j];
                }
            }

            double[] FinalDecision = new double[numberOfAlternatives];

            for (int i = 0; i < numberOfAlternatives; i++)
            {
                for (int j = 0; j < numberOfCriterions; j++)
                {
                    FinalDecision[i] += W[i, j] * CriteriaPriority[j];
                }
            }
            return NormalizeVector(FinalDecision);
        }

        #endregion Methods

        #region repositoryMethods

        public async Task<List<IAlternativeModel>> GetAlternativesByProjectId(int projectId, int pageNumber, int pageSize = 10)
        {
            var criterias = await Repository.GetAlternativesByProjectId(projectId, pageNumber,pageSize);
            return criterias;
        }
        public async Task<bool> AddRange(List<IAlternativeModel> alternatives)
        {
<<<<<<< HEAD
            var order = 1;
            foreach (var alter in alternatives)
            {
                alter.DateCreated = DateTime.Now;
                alter.DateUpdated = DateTime.Now;
                alter.Order = order;
                order++;
               // alter.ProjectId = id;
            }
            Repository.AddRange(alternatives);
            await Repository.SaveAsync();
=======
            using (var uow = uowFactory.CreateUnitOfWork())
            {
                await Repository.AddRange(alternatives);
                uow.Commit();
            }
>>>>>>> bc3958fcd4f25396d4790e0ee72781721f96633b
            return true;
        }

        public async Task<IAlternativeModel> Update(IAlternativeModel alternative)
        {
            using (var uow = uowFactory.CreateUnitOfWork())
            {
                var alternativeInDb = await Repository.GetAlternativeById(alternative.AlternativeId);
                alternativeInDb.DateUpdated = DateTime.Now;
                alternativeInDb.FinalPriority = alternative.FinalPriority;
                await Repository.UpdateAlternative(alternativeInDb);
                uow.Commit();
                return alternativeInDb;
            }
        }


        #endregion repositoryMethods
    }
}
