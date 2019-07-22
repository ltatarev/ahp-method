using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHP.DAL.Entities;
using AHP.Model.Common;

namespace AHP.Repository.Common
{
	public interface IAlternativeRepository
	{
        //Interface body

        #region Methods

        //Methods for interface

        //Methods for getting alternative
        //Example for checking if first alternative was added

        IEnumerable<Alternative> GetAlternatives();
        Alternative GetAlternativeById(int AlternativeId);
        void GetAlternativeByProjectId(int ProjectId);
        void InsertAlternative(Alternative Alternative);
        void DeleteAlternative(int AlternativeId);

        #endregion Methods
    }
}
