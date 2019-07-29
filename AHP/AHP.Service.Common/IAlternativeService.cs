using AHP.Model.Common.Model_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHP.Service.Common
{
    public interface IAlternativeService
    {
        Task<bool> AddRange(List<IAlternativeModel> alternatives);
        Task<List<IAlternativeModel>> GetAlternativesByProjectId(int projectId, int pageNumber, int pageSize = 10);
        Task<IAlternativeModel> Update(IAlternativeModel alternative);
    }
}
