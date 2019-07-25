using AHP.DAL.Entities;
using AHP.Model.Common.Model_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHP.Service.Common
{
    public interface ICriteriaService
    {
        Task<bool> AddCriteriaAsync(ICriteriaModel criteria);
        Task<bool> AddRange(List<ICriteriaModel> criteria);
        Task<List<ICriteriaModel>> GetCriteriasByProjectId(int projectId, int pageNumber, int pageSize = 10);
    }
}
