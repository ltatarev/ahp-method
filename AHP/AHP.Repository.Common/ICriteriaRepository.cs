using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHP.DAL.Entities;
using AHP.Model.Common;

namespace AHP.Repository.Common
{
	public interface ICriteriaRepository
	{
        //Interface body

        #region Methods

        //Methods for interface

        //Methods for getting criteria
        //Example for checking if first criteria was added

        IEnumerable<Criteria> GetCriterias();
        Criteria GetCriteriaById(int CriteriaId);
        void GetCritriaByProjectId(int ProjectId);
        void InsertCriteria(Criteria criteria);
        void DeleteCriteria(int CriteriaId);

        #endregion Methods
    }
}
