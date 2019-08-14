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
        Task<ICriteriaModel> AddCriteriaAsync(ICriteriaModel criteria);
        Task<List<ICriteriaModel>> AddRange(List<ICriteriaModel> criteria);
        Task<List<ICriteriaModel>> GetCriteriasByProjectId(Guid projectId, int pageNumber, int pageSize = 10);
        Task<List<ICriteriaModel>> GetCriteriasByProjectIdWithCRaAR(Guid projectId);
        Task<bool> DeleteCriteriaAsync(Guid id);
    }
}
