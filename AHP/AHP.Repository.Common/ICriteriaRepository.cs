using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHP.Model.Common;

namespace AHP.Repository.Common
{
	public interface ICriteriaRepository
	{
        #region Methods

        List<ICriteria> Get();

        #endregion
    }
}
